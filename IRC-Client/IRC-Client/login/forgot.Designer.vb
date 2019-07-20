<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class forgotForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(forgotForm))
        Me.forgotLbl = New System.Windows.Forms.Label()
        Me.forgotBtn = New System.Windows.Forms.Button()
        Me.userBox = New System.Windows.Forms.TextBox()
        Me.userLbl = New System.Windows.Forms.Label()
        Me.discrpitionLbl = New System.Windows.Forms.Label()
        Me.backBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'forgotLbl
        '
        Me.forgotLbl.AutoSize = True
        Me.forgotLbl.Font = New System.Drawing.Font("HelveticaNeueLT Std Med", 25.25!)
        Me.forgotLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.forgotLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.forgotLbl.Location = New System.Drawing.Point(16, 73)
        Me.forgotLbl.Name = "forgotLbl"
        Me.forgotLbl.Size = New System.Drawing.Size(304, 40)
        Me.forgotLbl.TabIndex = 19
        Me.forgotLbl.Text = "Forgot Password?"
        '
        'forgotBtn
        '
        Me.forgotBtn.Font = New System.Drawing.Font("Cabin", 14.25!, System.Drawing.FontStyle.Bold)
        Me.forgotBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.forgotBtn.Location = New System.Drawing.Point(188, 257)
        Me.forgotBtn.Name = "forgotBtn"
        Me.forgotBtn.Size = New System.Drawing.Size(110, 32)
        Me.forgotBtn.TabIndex = 18
        Me.forgotBtn.Text = "Forgot"
        Me.forgotBtn.UseVisualStyleBackColor = True
        '
        'userBox
        '
        Me.userBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.userBox.Font = New System.Drawing.Font("Roboto Mono for Powerline", 14.25!)
        Me.userBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.userBox.Location = New System.Drawing.Point(32, 180)
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
        Me.userLbl.Location = New System.Drawing.Point(28, 155)
        Me.userLbl.Name = "userLbl"
        Me.userLbl.Size = New System.Drawing.Size(102, 22)
        Me.userLbl.TabIndex = 15
        Me.userLbl.Text = "Username"
        '
        'discrpitionLbl
        '
        Me.discrpitionLbl.AutoSize = True
        Me.discrpitionLbl.Font = New System.Drawing.Font("HelveticaNeueLT Std Med", 11.25!)
        Me.discrpitionLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.discrpitionLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.discrpitionLbl.Location = New System.Drawing.Point(42, 216)
        Me.discrpitionLbl.Name = "discrpitionLbl"
        Me.discrpitionLbl.Size = New System.Drawing.Size(240, 18)
        Me.discrpitionLbl.TabIndex = 20
        Me.discrpitionLbl.Text = "We will email you your reset code"
        '
        'backBtn
        '
        Me.backBtn.Font = New System.Drawing.Font("Cabin", 14.25!, System.Drawing.FontStyle.Bold)
        Me.backBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.backBtn.Location = New System.Drawing.Point(32, 257)
        Me.backBtn.Name = "backBtn"
        Me.backBtn.Size = New System.Drawing.Size(110, 32)
        Me.backBtn.TabIndex = 21
        Me.backBtn.Text = "Back"
        Me.backBtn.UseVisualStyleBackColor = True
        '
        'forgotForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(335, 323)
        Me.Controls.Add(Me.backBtn)
        Me.Controls.Add(Me.discrpitionLbl)
        Me.Controls.Add(Me.forgotLbl)
        Me.Controls.Add(Me.forgotBtn)
        Me.Controls.Add(Me.userBox)
        Me.Controls.Add(Me.userLbl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "forgotForm"
        Me.Text = "Forgot"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents forgotLbl As Label
    Friend WithEvents forgotBtn As Button
    Friend WithEvents userBox As TextBox
    Friend WithEvents userLbl As Label
    Friend WithEvents discrpitionLbl As Label
    Friend WithEvents backBtn As Button
End Class
