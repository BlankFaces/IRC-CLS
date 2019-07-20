<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class resetForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(resetForm))
        Me.resetLbl = New System.Windows.Forms.Label()
        Me.resetBtn = New System.Windows.Forms.Button()
        Me.backBtn = New System.Windows.Forms.Button()
        Me.pass2Box = New System.Windows.Forms.TextBox()
        Me.pass1Box = New System.Windows.Forms.TextBox()
        Me.pass1Lbl = New System.Windows.Forms.Label()
        Me.userBox = New System.Windows.Forms.TextBox()
        Me.userLbl = New System.Windows.Forms.Label()
        Me.pass2Lbl = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.resetBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'resetLbl
        '
        Me.resetLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.resetLbl.AutoSize = True
        Me.resetLbl.Font = New System.Drawing.Font("HelveticaNeueLT Std Med", 35.25!)
        Me.resetLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.resetLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.resetLbl.Location = New System.Drawing.Point(85, 38)
        Me.resetLbl.Name = "resetLbl"
        Me.resetLbl.Size = New System.Drawing.Size(162, 55)
        Me.resetLbl.TabIndex = 23
        Me.resetLbl.Text = "Reset."
        Me.resetLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'resetBtn
        '
        Me.resetBtn.Font = New System.Drawing.Font("Cabin", 14.25!, System.Drawing.FontStyle.Bold)
        Me.resetBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.resetBtn.Location = New System.Drawing.Point(161, 398)
        Me.resetBtn.Name = "resetBtn"
        Me.resetBtn.Size = New System.Drawing.Size(88, 32)
        Me.resetBtn.TabIndex = 22
        Me.resetBtn.Text = "Reset"
        Me.resetBtn.UseVisualStyleBackColor = True
        '
        'backBtn
        '
        Me.backBtn.Font = New System.Drawing.Font("Cabin", 14.25!, System.Drawing.FontStyle.Bold)
        Me.backBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.backBtn.Location = New System.Drawing.Point(68, 398)
        Me.backBtn.Name = "backBtn"
        Me.backBtn.Size = New System.Drawing.Size(87, 32)
        Me.backBtn.TabIndex = 21
        Me.backBtn.Text = "Back"
        Me.backBtn.UseVisualStyleBackColor = True
        '
        'pass2Box
        '
        Me.pass2Box.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.pass2Box.Font = New System.Drawing.Font("Roboto Mono for Powerline", 14.25!)
        Me.pass2Box.ForeColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.pass2Box.Location = New System.Drawing.Point(31, 269)
        Me.pass2Box.Name = "pass2Box"
        Me.pass2Box.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.pass2Box.Size = New System.Drawing.Size(266, 30)
        Me.pass2Box.TabIndex = 20
        '
        'pass1Box
        '
        Me.pass1Box.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.pass1Box.Font = New System.Drawing.Font("Roboto Mono for Powerline", 14.25!)
        Me.pass1Box.ForeColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.pass1Box.Location = New System.Drawing.Point(31, 205)
        Me.pass1Box.Name = "pass1Box"
        Me.pass1Box.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.pass1Box.Size = New System.Drawing.Size(266, 30)
        Me.pass1Box.TabIndex = 18
        '
        'pass1Lbl
        '
        Me.pass1Lbl.AutoSize = True
        Me.pass1Lbl.Font = New System.Drawing.Font("HelveticaNeueLT Std Med", 14.25!)
        Me.pass1Lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.pass1Lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pass1Lbl.Location = New System.Drawing.Point(27, 180)
        Me.pass1Lbl.Name = "pass1Lbl"
        Me.pass1Lbl.Size = New System.Drawing.Size(99, 22)
        Me.pass1Lbl.TabIndex = 17
        Me.pass1Lbl.Text = "Password"
        '
        'userBox
        '
        Me.userBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.userBox.Font = New System.Drawing.Font("Roboto Mono for Powerline", 14.25!)
        Me.userBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.userBox.Location = New System.Drawing.Point(31, 145)
        Me.userBox.Name = "userBox"
        Me.userBox.Size = New System.Drawing.Size(266, 30)
        Me.userBox.TabIndex = 16
        '
        'userLbl
        '
        Me.userLbl.AutoSize = True
        Me.userLbl.Font = New System.Drawing.Font("HelveticaNeueLT Std Med", 14.25!)
        Me.userLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.userLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.userLbl.Location = New System.Drawing.Point(27, 120)
        Me.userLbl.Name = "userLbl"
        Me.userLbl.Size = New System.Drawing.Size(102, 22)
        Me.userLbl.TabIndex = 15
        Me.userLbl.Text = "Username"
        '
        'pass2Lbl
        '
        Me.pass2Lbl.AutoSize = True
        Me.pass2Lbl.Font = New System.Drawing.Font("HelveticaNeueLT Std Med", 14.25!)
        Me.pass2Lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.pass2Lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pass2Lbl.Location = New System.Drawing.Point(30, 244)
        Me.pass2Lbl.Name = "pass2Lbl"
        Me.pass2Lbl.Size = New System.Drawing.Size(167, 22)
        Me.pass2Lbl.TabIndex = 24
        Me.pass2Lbl.Text = "Retype Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("HelveticaNeueLT Std Med", 14.25!)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(30, 310)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 22)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Reset Code"
        '
        'resetBox
        '
        Me.resetBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.resetBox.Font = New System.Drawing.Font("Roboto Mono for Powerline", 14.25!)
        Me.resetBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.resetBox.Location = New System.Drawing.Point(31, 335)
        Me.resetBox.Name = "resetBox"
        Me.resetBox.Size = New System.Drawing.Size(266, 30)
        Me.resetBox.TabIndex = 25
        '
        'resetForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(334, 470)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.resetBox)
        Me.Controls.Add(Me.pass2Lbl)
        Me.Controls.Add(Me.resetLbl)
        Me.Controls.Add(Me.resetBtn)
        Me.Controls.Add(Me.backBtn)
        Me.Controls.Add(Me.pass2Box)
        Me.Controls.Add(Me.pass1Box)
        Me.Controls.Add(Me.pass1Lbl)
        Me.Controls.Add(Me.userBox)
        Me.Controls.Add(Me.userLbl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "resetForm"
        Me.Text = "Reset"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents resetLbl As Label
    Friend WithEvents resetBtn As Button
    Friend WithEvents backBtn As Button
    Friend WithEvents pass2Box As TextBox
    Friend WithEvents pass1Box As TextBox
    Friend WithEvents pass1Lbl As Label
    Friend WithEvents userBox As TextBox
    Friend WithEvents userLbl As Label
    Friend WithEvents pass2Lbl As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents resetBox As TextBox
End Class
