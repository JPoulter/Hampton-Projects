<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.ExitButton = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.pageHeader = New System.Windows.Forms.Label
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.updateURL = New System.Windows.Forms.Label
        Me.urlType = New System.Windows.Forms.Label
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.ExitButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.SplitContainer1.Panel1.CausesValidation = False
        Me.SplitContainer1.Panel1.Controls.Add(Me.ExitButton)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pageHeader)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.WebBrowser1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.updateURL)
        Me.SplitContainer1.Panel2.Controls.Add(Me.urlType)
        Me.SplitContainer1.TabStop = False
        '
        'ExitButton
        '
        resources.ApplyResources(Me.ExitButton, "ExitButton")
        Me.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ExitButton.Image = Global.Start.My.Resources.Resources.exit1
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.TabStop = False
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'pageHeader
        '
        resources.ApplyResources(Me.pageHeader, "pageHeader")
        Me.pageHeader.ForeColor = System.Drawing.Color.Gainsboro
        Me.pageHeader.Name = "pageHeader"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.AllowWebBrowserDrop = False
        resources.ApplyResources(Me.WebBrowser1, "WebBrowser1")
        Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Url = New System.Uri("", System.UriKind.Relative)
        Me.WebBrowser1.WebBrowserShortcutsEnabled = False
        '
        'updateURL
        '
        resources.ApplyResources(Me.updateURL, "updateURL")
        Me.updateURL.Name = "updateURL"
        '
        'urlType
        '
        resources.ApplyResources(Me.urlType, "urlType")
        Me.urlType.Name = "urlType"
        '
        'Form3
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "Form3"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.ExitButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents ExitButton As System.Windows.Forms.PictureBox
    Friend WithEvents pageHeader As System.Windows.Forms.Label
    Friend WithEvents updateURL As System.Windows.Forms.Label
    Friend WithEvents urlType As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
