<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class loginMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(loginMenu))
        Me.logoImg = New System.Windows.Forms.PictureBox()
        Me.userLbl = New System.Windows.Forms.Label()
        Me.loginBtn = New System.Windows.Forms.Button()
        Me.userBox = New System.Windows.Forms.TextBox()
        Me.passBox = New System.Windows.Forms.TextBox()
        Me.passLbl = New System.Windows.Forms.Label()
        Me.resetBtn = New System.Windows.Forms.Button()
        Me.forgotBtn = New System.Windows.Forms.Button()
        Me.regBtn = New System.Windows.Forms.Button()
        CType(Me.logoImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'logoImg
        '
        resources.ApplyResources(Me.logoImg, "logoImg")
        Me.logoImg.Image = Global.IRC_Client.My.Resources.Resources.Logo
        Me.logoImg.Name = "logoImg"
        Me.logoImg.TabStop = False
        '
        'userLbl
        '
        resources.ApplyResources(Me.userLbl, "userLbl")
        Me.userLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.userLbl.Name = "userLbl"
        '
        'loginBtn
        '
        resources.ApplyResources(Me.loginBtn, "loginBtn")
        Me.loginBtn.Name = "loginBtn"
        Me.loginBtn.UseVisualStyleBackColor = True
        '
        'userBox
        '
        Me.userBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        resources.ApplyResources(Me.userBox, "userBox")
        Me.userBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.userBox.Name = "userBox"
        '
        'passBox
        '
        Me.passBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        resources.ApplyResources(Me.passBox, "passBox")
        Me.passBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.passBox.Name = "passBox"
        '
        'passLbl
        '
        resources.ApplyResources(Me.passLbl, "passLbl")
        Me.passLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.passLbl.Name = "passLbl"
        '
        'resetBtn
        '
        resources.ApplyResources(Me.resetBtn, "resetBtn")
        Me.resetBtn.Name = "resetBtn"
        Me.resetBtn.UseVisualStyleBackColor = True
        '
        'forgotBtn
        '
        resources.ApplyResources(Me.forgotBtn, "forgotBtn")
        Me.forgotBtn.Name = "forgotBtn"
        Me.forgotBtn.UseVisualStyleBackColor = True
        '
        'regBtn
        '
        resources.ApplyResources(Me.regBtn, "regBtn")
        Me.regBtn.Name = "regBtn"
        Me.regBtn.UseVisualStyleBackColor = True
        '
        'loginMenu
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.Controls.Add(Me.regBtn)
        Me.Controls.Add(Me.forgotBtn)
        Me.Controls.Add(Me.resetBtn)
        Me.Controls.Add(Me.passBox)
        Me.Controls.Add(Me.passLbl)
        Me.Controls.Add(Me.userBox)
        Me.Controls.Add(Me.loginBtn)
        Me.Controls.Add(Me.userLbl)
        Me.Controls.Add(Me.logoImg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "loginMenu"
        CType(Me.logoImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents logoImg As PictureBox
    Friend WithEvents userLbl As Label
    Friend WithEvents loginBtn As Button
    Friend WithEvents userBox As TextBox
    Friend WithEvents passBox As TextBox
    Friend WithEvents passLbl As Label
    Friend WithEvents resetBtn As Button
    Friend WithEvents forgotBtn As Button
    Friend WithEvents regBtn As Button
End Class
