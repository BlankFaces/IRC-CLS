<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class registerForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(registerForm))
        Me.passBox = New System.Windows.Forms.TextBox()
        Me.passLbl = New System.Windows.Forms.Label()
        Me.userBox = New System.Windows.Forms.TextBox()
        Me.userLbl = New System.Windows.Forms.Label()
        Me.emailBox = New System.Windows.Forms.TextBox()
        Me.emailLbl = New System.Windows.Forms.Label()
        Me.regBtn = New System.Windows.Forms.Button()
        Me.backBtn = New System.Windows.Forms.Button()
        Me.regLbl = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'passBox
        '
        Me.passBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.passBox.Font = New System.Drawing.Font("Roboto Mono for Powerline", 14.25!)
        Me.passBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.passBox.Location = New System.Drawing.Point(57, 292)
        Me.passBox.Name = "passBox"
        Me.passBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passBox.Size = New System.Drawing.Size(266, 30)
        Me.passBox.TabIndex = 9
        '
        'passLbl
        '
        Me.passLbl.AutoSize = True
        Me.passLbl.Font = New System.Drawing.Font("HelveticaNeueLT Std Med", 14.25!)
        Me.passLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.passLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.passLbl.Location = New System.Drawing.Point(53, 267)
        Me.passLbl.Name = "passLbl"
        Me.passLbl.Size = New System.Drawing.Size(99, 22)
        Me.passLbl.TabIndex = 8
        Me.passLbl.Text = "Password"
        '
        'userBox
        '
        Me.userBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.userBox.Font = New System.Drawing.Font("Roboto Mono for Powerline", 14.25!)
        Me.userBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.userBox.Location = New System.Drawing.Point(57, 232)
        Me.userBox.Name = "userBox"
        Me.userBox.Size = New System.Drawing.Size(266, 30)
        Me.userBox.TabIndex = 7
        '
        'userLbl
        '
        Me.userLbl.AutoSize = True
        Me.userLbl.Font = New System.Drawing.Font("HelveticaNeueLT Std Med", 14.25!)
        Me.userLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.userLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.userLbl.Location = New System.Drawing.Point(53, 207)
        Me.userLbl.Name = "userLbl"
        Me.userLbl.Size = New System.Drawing.Size(102, 22)
        Me.userLbl.TabIndex = 6
        Me.userLbl.Text = "Username"
        '
        'emailBox
        '
        Me.emailBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.emailBox.Font = New System.Drawing.Font("Roboto Mono for Powerline", 14.25!)
        Me.emailBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.emailBox.Location = New System.Drawing.Point(57, 173)
        Me.emailBox.Name = "emailBox"
        Me.emailBox.Size = New System.Drawing.Size(266, 30)
        Me.emailBox.TabIndex = 11
        '
        'emailLbl
        '
        Me.emailLbl.AutoSize = True
        Me.emailLbl.Font = New System.Drawing.Font("HelveticaNeueLT Std Med", 14.25!)
        Me.emailLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.emailLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.emailLbl.Location = New System.Drawing.Point(53, 148)
        Me.emailLbl.Name = "emailLbl"
        Me.emailLbl.Size = New System.Drawing.Size(60, 22)
        Me.emailLbl.TabIndex = 10
        Me.emailLbl.Text = "Email"
        '
        'regBtn
        '
        Me.regBtn.Font = New System.Drawing.Font("Cabin", 14.25!, System.Drawing.FontStyle.Bold)
        Me.regBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.regBtn.Location = New System.Drawing.Point(182, 353)
        Me.regBtn.Name = "regBtn"
        Me.regBtn.Size = New System.Drawing.Size(88, 32)
        Me.regBtn.TabIndex = 13
        Me.regBtn.Text = "Register"
        Me.regBtn.UseVisualStyleBackColor = True
        '
        'backBtn
        '
        Me.backBtn.Font = New System.Drawing.Font("Cabin", 14.25!, System.Drawing.FontStyle.Bold)
        Me.backBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.backBtn.Location = New System.Drawing.Point(89, 353)
        Me.backBtn.Name = "backBtn"
        Me.backBtn.Size = New System.Drawing.Size(87, 32)
        Me.backBtn.TabIndex = 12
        Me.backBtn.Text = "Back"
        Me.backBtn.UseVisualStyleBackColor = True
        '
        'regLbl
        '
        Me.regLbl.AutoSize = True
        Me.regLbl.Font = New System.Drawing.Font("HelveticaNeueLT Std Med", 35.25!)
        Me.regLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.regLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.regLbl.Location = New System.Drawing.Point(82, 52)
        Me.regLbl.Name = "regLbl"
        Me.regLbl.Size = New System.Drawing.Size(214, 55)
        Me.regLbl.TabIndex = 14
        Me.regLbl.Text = "Register."
        '
        'registerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(374, 420)
        Me.Controls.Add(Me.regLbl)
        Me.Controls.Add(Me.regBtn)
        Me.Controls.Add(Me.backBtn)
        Me.Controls.Add(Me.emailBox)
        Me.Controls.Add(Me.emailLbl)
        Me.Controls.Add(Me.passBox)
        Me.Controls.Add(Me.passLbl)
        Me.Controls.Add(Me.userBox)
        Me.Controls.Add(Me.userLbl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "registerForm"
        Me.Text = "Register"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents passBox As TextBox
    Friend WithEvents passLbl As Label
    Friend WithEvents userBox As TextBox
    Friend WithEvents userLbl As Label
    Friend WithEvents emailBox As TextBox
    Friend WithEvents emailLbl As Label
    Friend WithEvents regBtn As Button
    Friend WithEvents backBtn As Button
    Friend WithEvents regLbl As Label
End Class
