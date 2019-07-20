import sqlite3
import socket
import _thread

sendServ = socket.socket()
sendServ.bind(('', 9999))
sendServ.listen(10)

print('Started send server!')
while True:
	(clientsock, addr) = sendServ.accept()
	print('Connection from: ' + repr(addr))
	with open("config.txt", 'rb') as f:
		clientsock.sendfile(f, 0)
	clientsock.close()
