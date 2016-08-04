<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.headlineBanner = New System.Windows.Forms.Label
        Me.whichMovie = New System.Windows.Forms.Label
        Me.ReloadPageIcon = New System.Windows.Forms.PictureBox
        Me.ExitButton = New System.Windows.Forms.PictureBox
        Me.copySelection = New System.Windows.Forms.PictureBox
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.ReloadPageIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExitButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.copySelection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(115, Byte), Integer))
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Panel1.CausesValidation = False
        Me.SplitContainer1.Panel1.Controls.Add(Me.WebBrowser1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.headlineBanner)
        Me.SplitContainer1.Panel1.Controls.Add(Me.whichMovie)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.SplitContainer1.Panel2.Controls.Add(Me.ReloadPageIcon)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ExitButton)
        Me.SplitContainer1.Panel2.Controls.Add(Me.copySelection)
        Me.SplitContainer1.TabStop = False
        '
        'WebBrowser1
        '
        Me.WebBrowser1.AllowWebBrowserDrop = False
        resources.ApplyResources(Me.WebBrowser1, "WebBrowser1")
        Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.WebBrowserShortcutsEnabled = False
        '
        'headlineBanner
        '
        Me.headlineBanner.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.headlineBanner, "headlineBanner")
        Me.headlineBanner.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.headlineBanner.Name = "headlineBanner"
        '
        'whichMovie
        '
        resources.ApplyResources(Me.whichMovie, "whichMovie")
        Me.whichMovie.BackColor = System.Drawing.Color.Transparent
        Me.whichMovie.ForeColor = System.Drawing.Color.White
        Me.whichMovie.Name = "whichMovie"
        '
        'ReloadPageIcon
        '
        resources.ApplyResources(Me.ReloadPageIcon, "ReloadPageIcon")
        Me.ReloadPageIcon.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ReloadPageIcon.Image = Global.Start.My.Resources.Resources.reload
        Me.ReloadPageIcon.Name = "ReloadPageIcon"
        Me.ReloadPageIcon.TabStop = False
        '
        'ExitButton
        '
        resources.ApplyResources(Me.ExitButton, "ExitButton")
        Me.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ExitButton.Image = Global.Start.My.Resources.Resources.exit1
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.TabStop = False
        '
        'copySelection
        '
        Me.copySelection.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.copySelection, "copySelection")
        Me.copySelection.Cursor = System.Windows.Forms.Cursors.Hand
        Me.copySelection.Image = Global.Start.My.Resources.Resources.copy_icon
        Me.copySelection.Name = "copySelection"
        Me.copySelection.TabStop = False
        '
        'Form2
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "Form2"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.ReloadPageIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExitButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.copySelection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents whichMovie As System.Windows.Forms.Label
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents headlineBanner As System.Windows.Forms.Label
    Friend WithEvents copySelection As System.Windows.Forms.PictureBox
    Friend WithEvents ExitButton As System.Windows.Forms.PictureBox
    Friend WithEvents ReloadPageIcon As System.Windows.Forms.PictureBox
End Class
