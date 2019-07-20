<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ircForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ircForm))
        Me.usrLbl = New System.Windows.Forms.Label()
        Me.serverLBox = New System.Windows.Forms.ListBox()
        Me.settingsTSBtn = New System.Windows.Forms.ToolStripButton()
        Me.joinFreeBtn = New System.Windows.Forms.ToolStripButton()
        Me.disconnectBtn = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.friendsLBox = New System.Windows.Forms.ListBox()
        Me.usersLBox = New System.Windows.Forms.ListBox()
        Me.msgeBox = New System.Windows.Forms.RichTextBox()
        Me.sendBox = New System.Windows.Forms.TextBox()
        Me.headerBox = New System.Windows.Forms.TextBox()
        Me.serverPage = New System.Windows.Forms.TabPage()
        Me.channelTab = New System.Windows.Forms.TabControl()
        Me.ToolStrip1.SuspendLayout()
        Me.channelTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'usrLbl
        '
        Me.usrLbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.usrLbl.AutoSize = True
        Me.usrLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.usrLbl.Location = New System.Drawing.Point(232, 701)
        Me.usrLbl.Name = "usrLbl"
        Me.usrLbl.Size = New System.Drawing.Size(65, 13)
        Me.usrLbl.TabIndex = 17
        Me.usrLbl.Text = "PlaceHolder"
        '
        'serverLBox
        '
        Me.serverLBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.serverLBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.serverLBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.serverLBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.serverLBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.serverLBox.FormattingEnabled = True
        Me.serverLBox.ItemHeight = 16
        Me.serverLBox.Location = New System.Drawing.Point(12, 43)
        Me.serverLBox.Name = "serverLBox"
        Me.serverLBox.Size = New System.Drawing.Size(204, 674)
        Me.serverLBox.TabIndex = 9
        '
        'settingsTSBtn
        '
        Me.settingsTSBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.settingsTSBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.settingsTSBtn.Image = Global.IRC_Client.My.Resources.Resources.Cog
        Me.settingsTSBtn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.settingsTSBtn.Name = "settingsTSBtn"
        Me.settingsTSBtn.Size = New System.Drawing.Size(23, 22)
        Me.settingsTSBtn.Text = "ToolStripButton1"
        Me.settingsTSBtn.ToolTipText = "Settings"
        '
        'joinFreeBtn
        '
        Me.joinFreeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.joinFreeBtn.Image = CType(resources.GetObject("joinFreeBtn.Image"), System.Drawing.Image)
        Me.joinFreeBtn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.joinFreeBtn.Name = "joinFreeBtn"
        Me.joinFreeBtn.Size = New System.Drawing.Size(84, 22)
        Me.joinFreeBtn.Text = "Join Freenode"
        '
        'disconnectBtn
        '
        Me.disconnectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.disconnectBtn.Image = CType(resources.GetObject("disconnectBtn.Image"), System.Drawing.Image)
        Me.disconnectBtn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.disconnectBtn.Name = "disconnectBtn"
        Me.disconnectBtn.Size = New System.Drawing.Size(70, 22)
        Me.disconnectBtn.Text = "Disconnect"
        Me.disconnectBtn.ToolTipText = "Disconnect"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.settingsTSBtn, Me.joinFreeBtn, Me.disconnectBtn})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(1224, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'friendsLBox
        '
        Me.friendsLBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.friendsLBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.friendsLBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.friendsLBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.friendsLBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.friendsLBox.FormattingEnabled = True
        Me.friendsLBox.ItemHeight = 16
        Me.friendsLBox.Location = New System.Drawing.Point(1024, 523)
        Me.friendsLBox.Name = "friendsLBox"
        Me.friendsLBox.Size = New System.Drawing.Size(188, 194)
        Me.friendsLBox.TabIndex = 28
        '
        'usersLBox
        '
        Me.usersLBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.usersLBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.usersLBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.usersLBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.usersLBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.usersLBox.FormattingEnabled = True
        Me.usersLBox.ItemHeight = 16
        Me.usersLBox.Location = New System.Drawing.Point(1024, 80)
        Me.usersLBox.Name = "usersLBox"
        Me.usersLBox.Size = New System.Drawing.Size(188, 434)
        Me.usersLBox.TabIndex = 27
        '
        'msgeBox
        '
        Me.msgeBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.msgeBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.msgeBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.msgeBox.DetectUrls = False
        Me.msgeBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msgeBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.msgeBox.Location = New System.Drawing.Point(232, 103)
        Me.msgeBox.Name = "msgeBox"
        Me.msgeBox.ReadOnly = True
        Me.msgeBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.msgeBox.Size = New System.Drawing.Size(776, 588)
        Me.msgeBox.TabIndex = 26
        Me.msgeBox.Text = ""
        '
        'sendBox
        '
        Me.sendBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sendBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.sendBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.sendBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sendBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.sendBox.Location = New System.Drawing.Point(232, 697)
        Me.sendBox.Name = "sendBox"
        Me.sendBox.Size = New System.Drawing.Size(776, 20)
        Me.sendBox.TabIndex = 25
        '
        'headerBox
        '
        Me.headerBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.headerBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.headerBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.headerBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.headerBox.Location = New System.Drawing.Point(232, 77)
        Me.headerBox.Name = "headerBox"
        Me.headerBox.ReadOnly = True
        Me.headerBox.Size = New System.Drawing.Size(776, 20)
        Me.headerBox.TabIndex = 24
        '
        'serverPage
        '
        Me.serverPage.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.serverPage.Location = New System.Drawing.Point(4, 22)
        Me.serverPage.Name = "serverPage"
        Me.serverPage.Padding = New System.Windows.Forms.Padding(3)
        Me.serverPage.Size = New System.Drawing.Size(972, 0)
        Me.serverPage.TabIndex = 0
        '
        'channelTab
        '
        Me.channelTab.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.channelTab.Controls.Add(Me.serverPage)
        Me.channelTab.Location = New System.Drawing.Point(232, 43)
        Me.channelTab.Name = "channelTab"
        Me.channelTab.SelectedIndex = 0
        Me.channelTab.Size = New System.Drawing.Size(980, 25)
        Me.channelTab.TabIndex = 8
        '
        'ircForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1224, 737)
        Me.Controls.Add(Me.friendsLBox)
        Me.Controls.Add(Me.usersLBox)
        Me.Controls.Add(Me.msgeBox)
        Me.Controls.Add(Me.sendBox)
        Me.Controls.Add(Me.headerBox)
        Me.Controls.Add(Me.usrLbl)
        Me.Controls.Add(Me.serverLBox)
        Me.Controls.Add(Me.channelTab)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ircForm"
        Me.Text = "IRC"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.channelTab.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents usrLbl As Label
    Friend WithEvents serverLBox As ListBox
    Friend WithEvents settingsTSBtn As ToolStripButton
    Friend WithEvents joinFreeBtn As ToolStripButton
    Friend WithEvents disconnectBtn As ToolStripButton
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents sendBox As TextBox
    Friend WithEvents friendsLBox As ListBox
    Friend WithEvents usersLBox As ListBox
    Friend WithEvents msgeBox As RichTextBox
    Friend WithEvents headerBox As TextBox
    Friend WithEvents serverPage As TabPage
    Friend WithEvents channelTab As TabControl
End Class
