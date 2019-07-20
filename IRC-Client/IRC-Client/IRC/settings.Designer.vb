<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class settingsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(settingsForm))
        Me.settingsLbl = New System.Windows.Forms.Label()
        Me.saveBtn = New System.Windows.Forms.Button()
        Me.backBox = New System.Windows.Forms.TextBox()
        Me.backLbl = New System.Windows.Forms.Label()
        Me.foregroundBox = New System.Windows.Forms.TextBox()
        Me.foregroundLbl = New System.Windows.Forms.Label()
        Me.textCBox = New System.Windows.Forms.TextBox()
        Me.textLbl = New System.Windows.Forms.Label()
        Me.nickBox = New System.Windows.Forms.TextBox()
        Me.nickLbl = New System.Windows.Forms.Label()
        Me.fontBox = New System.Windows.Forms.TextBox()
        Me.fontLbl = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'settingsLbl
        '
        Me.settingsLbl.AutoSize = True
        Me.settingsLbl.Font = New System.Drawing.Font("HelveticaNeueLT Std Med", 25.25!)
        Me.settingsLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.settingsLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.settingsLbl.Location = New System.Drawing.Point(27, 22)
        Me.settingsLbl.Name = "settingsLbl"
        Me.settingsLbl.Size = New System.Drawing.Size(146, 40)
        Me.settingsLbl.TabIndex = 23
        Me.settingsLbl.Text = "Settings"
        '
        'saveBtn
        '
        Me.saveBtn.Font = New System.Drawing.Font("Cabin", 14.25!, System.Drawing.FontStyle.Bold)
        Me.saveBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.saveBtn.Location = New System.Drawing.Point(101, 446)
        Me.saveBtn.Name = "saveBtn"
        Me.saveBtn.Size = New System.Drawing.Size(110, 32)
        Me.saveBtn.TabIndex = 22
        Me.saveBtn.Text = "Save"
        Me.saveBtn.UseVisualStyleBackColor = True
        '
        'backBox
        '
        Me.backBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.backBox.Font = New System.Drawing.Font("Roboto Mono for Powerline", 14.25!)
        Me.backBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.backBox.Location = New System.Drawing.Point(34, 109)
        Me.backBox.Name = "backBox"
        Me.backBox.Size = New System.Drawing.Size(266, 30)
        Me.backBox.TabIndex = 21
        '
        'backLbl
        '
        Me.backLbl.AutoSize = True
        Me.backLbl.Font = New System.Drawing.Font("HelveticaNeueLT Std Med", 14.25!)
        Me.backLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.backLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.backLbl.Location = New System.Drawing.Point(30, 84)
        Me.backLbl.Name = "backLbl"
        Me.backLbl.Size = New System.Drawing.Size(227, 22)
        Me.backLbl.TabIndex = 20
        Me.backLbl.Text = "RGB Background Values"
        '
        'foregroundBox
        '
        Me.foregroundBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.foregroundBox.Font = New System.Drawing.Font("Roboto Mono for Powerline", 14.25!)
        Me.foregroundBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.foregroundBox.Location = New System.Drawing.Point(34, 178)
        Me.foregroundBox.Name = "foregroundBox"
        Me.foregroundBox.Size = New System.Drawing.Size(266, 30)
        Me.foregroundBox.TabIndex = 25
        '
        'foregroundLbl
        '
        Me.foregroundLbl.AutoSize = True
        Me.foregroundLbl.Font = New System.Drawing.Font("HelveticaNeueLT Std Med", 14.25!)
        Me.foregroundLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.foregroundLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.foregroundLbl.Location = New System.Drawing.Point(30, 153)
        Me.foregroundLbl.Name = "foregroundLbl"
        Me.foregroundLbl.Size = New System.Drawing.Size(222, 22)
        Me.foregroundLbl.TabIndex = 24
        Me.foregroundLbl.Text = "RGB Foreground Values"
        '
        'textCBox
        '
        Me.textCBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.textCBox.Font = New System.Drawing.Font("Roboto Mono for Powerline", 14.25!)
        Me.textCBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.textCBox.Location = New System.Drawing.Point(34, 248)
        Me.textCBox.Name = "textCBox"
        Me.textCBox.Size = New System.Drawing.Size(266, 30)
        Me.textCBox.TabIndex = 27
        '
        'textLbl
        '
        Me.textLbl.AutoSize = True
        Me.textLbl.Font = New System.Drawing.Font("HelveticaNeueLT Std Med", 14.25!)
        Me.textLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.textLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.textLbl.Location = New System.Drawing.Point(30, 223)
        Me.textLbl.Name = "textLbl"
        Me.textLbl.Size = New System.Drawing.Size(155, 22)
        Me.textLbl.TabIndex = 26
        Me.textLbl.Text = "RGB Text Values"
        '
        'nickBox
        '
        Me.nickBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.nickBox.Font = New System.Drawing.Font("Roboto Mono for Powerline", 14.25!)
        Me.nickBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.nickBox.Location = New System.Drawing.Point(34, 318)
        Me.nickBox.Name = "nickBox"
        Me.nickBox.Size = New System.Drawing.Size(266, 30)
        Me.nickBox.TabIndex = 29
        '
        'nickLbl
        '
        Me.nickLbl.AutoSize = True
        Me.nickLbl.Font = New System.Drawing.Font("HelveticaNeueLT Std Med", 14.25!)
        Me.nickLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.nickLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.nickLbl.Location = New System.Drawing.Point(30, 293)
        Me.nickLbl.Name = "nickLbl"
        Me.nickLbl.Size = New System.Drawing.Size(223, 22)
        Me.nickLbl.TabIndex = 28
        Me.nickLbl.Text = "RGB Nick Colour Values"
        '
        'fontBox
        '
        Me.fontBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.fontBox.Font = New System.Drawing.Font("Roboto Mono for Powerline", 14.25!)
        Me.fontBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.fontBox.Location = New System.Drawing.Point(34, 387)
        Me.fontBox.Name = "fontBox"
        Me.fontBox.Size = New System.Drawing.Size(266, 30)
        Me.fontBox.TabIndex = 31
        '
        'fontLbl
        '
        Me.fontLbl.AutoSize = True
        Me.fontLbl.Font = New System.Drawing.Font("HelveticaNeueLT Std Med", 14.25!)
        Me.fontLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.fontLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.fontLbl.Location = New System.Drawing.Point(30, 362)
        Me.fontLbl.Name = "fontLbl"
        Me.fontLbl.Size = New System.Drawing.Size(92, 22)
        Me.fontLbl.TabIndex = 30
        Me.fontLbl.Text = "Font Size"
        '
        'settingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(336, 504)
        Me.Controls.Add(Me.fontBox)
        Me.Controls.Add(Me.fontLbl)
        Me.Controls.Add(Me.nickBox)
        Me.Controls.Add(Me.nickLbl)
        Me.Controls.Add(Me.textCBox)
        Me.Controls.Add(Me.textLbl)
        Me.Controls.Add(Me.foregroundBox)
        Me.Controls.Add(Me.foregroundLbl)
        Me.Controls.Add(Me.settingsLbl)
        Me.Controls.Add(Me.saveBtn)
        Me.Controls.Add(Me.backBox)
        Me.Controls.Add(Me.backLbl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "settingsForm"
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents settingsLbl As Label
    Friend WithEvents saveBtn As Button
    Friend WithEvents backBox As TextBox
    Friend WithEvents backLbl As Label
    Friend WithEvents foregroundBox As TextBox
    Friend WithEvents foregroundLbl As Label
    Friend WithEvents textCBox As TextBox
    Friend WithEvents textLbl As Label
    Friend WithEvents nickBox As TextBox
    Friend WithEvents nickLbl As Label
    Friend WithEvents fontBox As TextBox
    Friend WithEvents fontLbl As Label
End Class
