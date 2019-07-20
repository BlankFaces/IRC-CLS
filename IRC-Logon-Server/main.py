# Import Libraries
from validate_email import validate_email
from time import gmtime, strftime
from termcolor import colored
from colorama import init
from pathlib import Path
import _thread
import hashlib
import smtplib
import sqlite3
import logging
import getpass
import socket
import base64
import bcrypt
import uuid
import sys
import cgi
init()

# Sets up logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger()

# Create a file handler
handler = logging.FileHandler('serverFiles/server.log')
handler.setLevel(logging.INFO)

# Create a logging format
formatter = logging.Formatter('%(asctime)s - %(name)s - %(levelname)s - %(message)s')
handler.setFormatter(formatter)

# Add the handlers to the logger
logger.addHandler(handler)

CURSOR_UP_ONE = '\x1b[1A'
ERASE_LINE = '\x1b[2K'

# Handles login requests
def login(clientsock, addr, timeStamp):
    # Sets up the register connection
    logger = logging.getLogger("Login")
    clientsock.send("LOGIN\n".encode())
    data = clientsock.recv(1024)
    ip = addr[0]

    # split so that "fur password is the best password" becomes "fur" "password is the best password"
    username, password = data.decode().rstrip().split(" ", 1)
    password = base64.b64encode(hashlib.sha256(password.encode('utf-8')).digest())
    
    # Sets up the connection with the db
    conn = sqlite3.connect('serverFiles/server.db')
    conn.cursor().execute(
        "CREATE TABLE IF NOT EXISTS tbl_users (user TEXT PRIMARY KEY, pass TEXT, email TEXT last_logged TEXT, "
        "admin TEXT);")
    c = conn.cursor()

    # do a single query for all data relating to the user,
    c.execute("SELECT * FROM tbl_users WHERE user = ? LIMIT 1", (username,))
    user_row = c.fetchone()

    # TODO: you should really do sensitive string comparisons in constant-time to avoid potential timing attacks
    # Checks if the pass matches the account, logs the result
    if user_row is None or bcrypt.checkpw(password, user_row[1]) == False:
        clientsock.send("FAIL\n".encode())

        # If doesn't exist, it adds it to the db
        logger.info("FAIL, %s, User: %s" % (ip, username))
        # consider: what happens if two people log in at the same time? does the log get garbled?

    # Could add an admin mode in client possibly
    elif user_row[4] == "1":
        clientsock.send("ADMIN\n".encode())

        c.execute("UPDATE tbl_users SET last_logged = ? WHERE user = ?", (timeStamp, username))
        conn.commit()

        # If doesn't exist, it adds it to the db
        logger.info("ADMIN, %s, User: %s, %s" % (ip, username, timeStamp))

    # if it successful you can enter
    else:
        clientsock.send("PASS\n".encode())

        c.execute("UPDATE tbl_users SET last_logged = ? WHERE user = ?", (timeStamp, username))
        conn.commit()

        # If doesn't exist, it adds it to the db
        logger.info("PASS, %s, User: %s" % (ip, username))

    clientsock.close()
    # print(colored(repr(addr) + ": Login connection closed", 'red'))
    logger.info(repr(addr) + ": Login connection closed")


# Registers users into the db
def register(clientsock, addr, timeStamp):
    # Sets up the register connection
    logger = logging.getLogger("Register")
    clientsock.send("REGISTER\n".encode())
    data = clientsock.recv(1024)
    username, email, password = data.decode().rstrip().split(" ", 2)
    ip = addr[0]
    password = bcrypt.hashpw(base64.b64encode(hashlib.sha256(password.encode('utf-8')).digest()), bcrypt.gensalt(14))
    is_valid = validate_email(email)

    # Connects to the db
    conn = sqlite3.connect('serverFiles/server.db')
    conn.cursor().execute("CREATE TABLE IF NOT EXISTS tbl_users (user TEXT PRIMARY KEY, pass TEXT, email TEXT, "
                          "last_logged TEXT, admin TEXT);")

    # Sees if the user exists already in the database
    c = conn.cursor()
    c.execute("SELECT user FROM tbl_users WHERE user = ?", (username,))  # sees if user is already in db
    checkUser = c.fetchone()
    c.execute("SELECT email FROM tbl_users WHERE email = ?", (email,))  # sees if user is already in db
    checkEmail = c.fetchone()

    # If doesn't exist, it adds it to the db
    if checkUser is None and checkEmail is None and is_valid is True:
        c.execute("INSERT INTO tbl_users(user, pass, email, last_logged, admin) VALUES(?, ?, ?, ?, 0)",
                  (username, password, email, timeStamp))
        conn.commit()
        clientsock.send("CREATED\n".encode())

        # Logs to text file action
        logger.info("CREATED %s FROM %s" % (username, ip))

    # If user or email exists, return that it does, so user can think of a new one
    elif checkUser is not None:
        logger.info("USER EXISTS %s FROM %s %s" % (username, ip, email))
        clientsock.send("USER EXISTS\n".encode())
        conn.commit()

    elif is_valid is False:
        logger.info("EMAIL INVALID %s FROM %s %s" % (username, ip, email))
        clientsock.send("EMAIL NOT VALID\n".encode())
        conn.commit()

    elif checkEmail is not None:
        logger.info("EMAIL EXISTS %s FROM %s %s" % (username, ip, email))
        clientsock.send("EMAIL EXISTS\n".encode())
        conn.commit()

    clientsock.close()
    # print(colored(repr(addr) + ": Register connection closed", 'red'))
    logger.info(repr(addr) + ": Register connection closed")

# Sends data to the user to store into their config file
def send(clientsock, addr):
    # Sets up the connection
    logger = logging.getLogger("Send")
    clientsock.send("SEND\n".encode())
    data = clientsock.recv(1024)
    username, password = data.decode().rstrip().split(" ", 1)
    password = base64.b64encode(hashlib.sha256(password.encode('utf-8')).digest())
    ip = addr[0]

    # Connects to the db to be used to authenticate user
    conn = sqlite3.connect('serverFiles/server.db')
    conn.cursor().execute(
        "CREATE TABLE IF NOT EXISTS tbl_users (user TEXT PRIMARY KEY, pass TEXT, email TEXT, last_logged TEXT, "
        "admin TEXT);")
    c = conn.cursor()

    # do a single query for all data relating to the user,
    c.execute("SELECT * FROM tbl_users WHERE user = ? LIMIT 1", (username,))
    user_row = c.fetchone()

    # If pass or username bad, return DENY
    if user_row is None or bcrypt.checkpw(password, user_row[1]) == False:
        clientsock.send("DENY\n".encode())

        # Logs to text file action
        logger.info("DENY SEND %s %s" % (ip, username))

    # Send the file to the client
    else:
        # Logs to text file action
        logger.info("ALLOW SEND %s %s" % (ip, username))

        fileDir = str("Configs/%s.conf" % username)
        with open(fileDir, "rb") as fUploadFile:
            sRead = fUploadFile.read(1024)
            while sRead:
                clientsock.send(sRead)
                sRead = fUploadFile.read(1024)

    clientsock.close()
    # print(colored(repr(addr) + ": Send connection closed", 'red'))
    logger.info(repr(addr) + ": Send connection closed")


# Updates local config for the user
def receive(clientsock, addr):
    logger = logging.getLogger("Receive")
    # Sets up the connection
    clientsock.send("RECEIVE\n".encode())
    data = clientsock.recv(1024)
    username, password = data.decode().rstrip().split(" ", 1)
    password = base64.b64encode(hashlib.sha256(password.encode('utf-8')).digest())
    ip = addr[0]

    # Connects to the db to be used to authenticate user
    conn = sqlite3.connect('serverFiles/server.db')
    conn.cursor().execute(
        "CREATE TABLE IF NOT EXISTS tbl_users (user TEXT PRIMARY KEY, pass TEXT, email TEXT, last_logged TEXT, "
        "admin TEXT);")
    c = conn.cursor()

    # do a single query for all data relating to the user,
    c.execute("SELECT * FROM tbl_users WHERE user = ? LIMIT 1", (username,))
    user_row = c.fetchone()

    # If pass or username bad, return DENY
    if user_row is None or bcrypt.checkpw(password, user_row[1]) == False:
        clientsock.send("DENY\n".encode())

        # Logs to text file action
        logger.info("DENY RECEIVE %s %s" % (ip, username))

    # Connect to the client to give the data to store
    else:
        logger.info("ALLOW RECEIVE %s %s" % (ip, username))
        sendServ = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        clientsock.close()
        sendServ.connect((addr[0], 9999))
        sData = sendServ.recv(1024)
        fDownloadFile = open(str("Configs/%s" % username), "wb")
        while sData:
            fDownloadFile.write(sData)
            sData = sendServ.recv(1024)

        sendServ.close()
        # Logs to text file action
        logger.info(repr(addr) + ": Send connection closed")


# Sends a code to the users email address to reset their password
def forgot(clientsock, addr, mailEmail, mailPassword):
    # Sets up the register connection
    logger = logging.getLogger("Forgot")
    clientsock.send("FORGOT\n".encode())
    data = clientsock.recv(1024)
    ip = addr[0]
    username = data.decode().rstrip()

    # Connects to the db
    conn = sqlite3.connect('serverFiles/server.db')
    conn.cursor().execute(
        "CREATE TABLE IF NOT EXISTS tbl_users (user TEXT PRIMARY KEY, pass TEXT, email TEXT, last_logged TEXT, "
        "admin TEXT);")

    # Used to get the email for later
    c = conn.cursor()
    c.execute("SELECT * FROM tbl_users WHERE user = ? LIMIT 1", (username,))
    row = c.fetchone()

    # If doesn't exist, it adds it to the db
    if row is None:
        clientsock.send("DENY\n".encode())
        logger.info("NO SUCH USER %s %s" % (username, ip))

    else:
        # Gets the users email
        email = row[2]

        # Connects to the db, creates table if not exist
        conn = sqlite3.connect('serverFiles/server.db')
        conn.cursor().execute("CREATE TABLE IF NOT EXISTS tbl_reset_codes (reset_code TEXT PRIMARY KEY, user TEXT, "
                              "FOREIGN KEY(user) REFERENCES tbl_users(user));")

        # Connects to the table to see if there is already a code
        c = conn.cursor()
        c.execute("SELECT reset_code FROM tbl_reset_codes WHERE user = ? LIMIT 1", (username,))
        checkCode = c.fetchone()

        # Creates a randomly generated code and adds it to a global dictionary for later use
        rawCode = uuid.uuid4().hex
        resetCode = hashlib.sha256(rawCode.encode()).hexdigest()

        # If there isn't a code for the user, add one
        if checkCode is None:
            c.execute("INSERT INTO tbl_reset_codes(reset_code, user) VALUES(?, ?)", (resetCode, username))
            conn.commit()

        # Else delete the old code, and set the new one
        else:
            c.execute("DELETE FROM tbl_reset_codes WHERE user = ?", (username,))
            conn.commit()
            c.execute("INSERT INTO tbl_reset_codes(reset_code, user) VALUES(?, ?)", (resetCode, username))
            conn.commit()

        # Sets up email contents
        sent_from = mailEmail
        to = [email]
        subject = 'IRC Reset Code'
        body = 'Here is your reset code for user %s:\n%s' % (username, resetCode)

        # Orders the strings to be sent
        email_text = """From: %s\nTo: %s \nSubject: %s\n\n%s
        """ % (sent_from, ", ".join(to), subject, body)

        # Attempt to send the email
        try:
            # Sets up the connection and sends the email
            server = smtplib.SMTP_SSL('smtp.gmail.com', 465)
            server.ehlo()
            server.login(mailEmail, mailPassword)
            server.sendmail(sent_from, to, email_text)
            server.close()

            # If it was successful, these lines run
            clientsock.send("SENT\n".encode())
            logger.info("FORGOT SENT %s %s %s" % (ip, username, email))

        # If fails, send back it failed.
        except:
            clientsock.send("FAIL\n".encode())
            logger.error("FORGOT SENT FAIL %s %s %s" % (ip, username, email))

    clientsock.close()
    # print(colored(repr(addr) + ": Forgot connection closed", 'red'))
    logger.info(repr(addr) + ": Forgot connection closed")


# Resets the password if the reset code is correct
def reset(clientsock, addr):
    # Sets up the register connection
    logger = logging.getLogger("Reset")
    clientsock.send("RESET\n".encode())
    data = clientsock.recv(1024)
    ip = addr[0]
    username, resetCode, password = data.decode().rstrip().split(" ", 3)
    password = bcrypt.hashpw(base64.b64encode(hashlib.sha256(password.encode('utf-8')).digest()), bcrypt.gensalt(14))

    # Connects to the db
    conn = sqlite3.connect('serverFiles/server.db')
    conn.cursor().execute(
        "CREATE TABLE IF NOT EXISTS tbl_users (user TEXT PRIMARY KEY, pass TEXT, email TEXT, last_logged TEXT, "
        "admin TEXT);")

    # Used to get the username
    c = conn.cursor()
    c.execute("SELECT * FROM tbl_users WHERE user = ? LIMIT 1", (username,))
    row = c.fetchone()

    # If doesn't exist, it adds it to the db
    if row is None:
        clientsock.send("DENY\n".encode())
        logger.info("NO SUCH USER %s %s" % (username, ip))

    # If exists see if reset code is correct
    else:

        # Connects to the db, creates table if not exist
        conn = sqlite3.connect('serverFiles/server.db')
        conn.cursor().execute("CREATE TABLE IF NOT EXISTS tbl_reset_codes (reset_code TEXT PRIMARY KEY, user TEXT, "
                              "FOREIGN KEY(user) REFERENCES tbl_users(user));")

        # Connects to the table to see if there is already a code
        c = conn.cursor()
        c.execute("SELECT reset_code FROM tbl_reset_codes WHERE user = ?", (username,))
        checkCode = str(c.fetchone()).strip("[('',)]")

        # Checks if the user has a reset code
        if checkCode is None:
            clientsock.send("DENY\n".encode())
            logger.info("NO CODE FOR USER %s %s" % (username, ip))

        # If the code is correct reset the password
        elif checkCode == resetCode:
            c.execute("DELETE FROM tbl_reset_codes WHERE user = ?", (username,))
            conn.commit()
            c.execute("UPDATE tbl_users SET pass = ? WHERE user = ?", (password, username))
            conn.commit()
            clientsock.send("CHANGED\n".encode())
            logger.info("CORRECT CODE FOR USER %s %s" % (username, ip))

        # If incorrect, log and deny it
        else:
            clientsock.send("DENY\n".encode())
            logger.info("INCORRECT CODE FOR USER %s %s" % (username, ip))

    clientsock.close()
    # print(colored(repr(addr) + ": Reset connection closed", 'red'))
    logger.info(repr(addr) + ": Reset connection closed")


# Prints a sick mf title boi
print(colored("      ________  ______   ___         __  __  " + "\r", 'cyan'))
print(colored("     /  _/ __ \\/ ____/  /   | __  __/ /_/ /_ " + "\r", 'cyan'))
print(colored("     / // /_/ / /      / /| |/ / / / __/ __ \\" + "\r", 'cyan'))
print(colored("   _/ // _, _/ /___   / ___ / /_/ / /_/ / / /" + "\r", 'cyan'))
print(colored("  /___/_/ |_|\\____/  /_/  |_\\__,_/\\__/_/ /_/ " + "\n", 'cyan'))

# Checks if login conf exists, if does use that to setup server
logger = logging.getLogger("Setup")
loginConf = Path("serverFiles/login.conf")
if loginConf.is_file():
    with open("serverFiles/login.conf") as f:
        contents = f.readlines()
    PORT, mailEmail, mailPassword = contents[0].split(" ", 3)
    PORT = int(PORT)
    print(colored('PORT: %s Gmail Email: %s Gmail Password: ********\n' % (PORT, mailEmail), 'magenta'))

else:
    # Set up listening address and port
    PORT = int(input('Enter port to listen on: '))

    # Set up recovery email sender
    mailEmail = input('Enter gmail email: ')
    mailPassword = getpass.getpass(prompt='Enter gmail password: ')

    # Removes the last three lines
    for i in range(0, 3):
        sys.stdout.write(CURSOR_UP_ONE)
        sys.stdout.write(ERASE_LINE)
    print("\n")

# Setup the socket
HOST = ''
loginServ = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

# Bind socket to local host and port
try:
    loginServ.bind((HOST, PORT))
except:
    logger.error('Bind failed. Check if port is being used')
    input()
    sys.exit()

# Start listening on socket
loginServ.listen(10)
# print(colored('Socket successfully started at port: ' + str(PORT), 'green'))
logger.info('Socket successfully started at port: ' + str(PORT))
# print(colored('Server listening for connections...', 'yellow'))
logger.info('Server listening for connections...')

# Creates threads of the functions when called, so many can be used at once
while True:
    logger = logging.getLogger("Connections")
    # Accepts connections to the server, gets the time they connected and puts received data into a var
    (clientsock, addr) = loginServ.accept()

    logger.info('Connection from: ' + repr(addr))
    timeStamp = strftime('%Y-%m-%d %H:%M:%S', gmtime())
    text = clientsock.recv(1024)

    if "login" in str(text):
        logger.info('New login thread from: ' + repr(addr))
        _thread.start_new_thread(login, (clientsock, addr, timeStamp))

    elif "register" in str(text):
        logger.info('New register thread from: ' + repr(addr))
        _thread.start_new_thread(register, (clientsock, addr, timeStamp))

    elif "reset" in str(text):
        logger.info('New reset thread from: ' + repr(addr))
        _thread.start_new_thread(reset, (clientsock, addr))

    elif "forgot" in str(text):
        logger.info('New forgot thread from: ' + repr(addr))
        _thread.start_new_thread(forgot, (clientsock, addr, mailEmail, mailPassword))

    elif "send" in str(text):
        logger.info('New send thread from: ' + repr(addr))
        _thread.start_new_thread(send, (clientsock, addr))

    elif "receive" in str(text):
        logger.info('New receive thread from: ' + repr(addr))
        _thread.start_new_thread(receive, (clientsock, addr))

    elif "GET" in str(text):
        clientsock.send('HTTP/1.1 200 OK\nContent-Type: text/html\n\n'.encode())
        with open("redirect.html", 'rb') as f:
            clientsock.sendfile(f, 0)
        clientsock.close()

        logger.warning('Connection from browser: ' + repr(addr))
    else:
        logger.warning('Invalid command from: ' + repr(addr))
        clientsock.send('Command Unknown\n'.encode())
        clientsock.close()
