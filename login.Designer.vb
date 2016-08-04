<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(login))
        Me.pwHeader = New System.Windows.Forms.Label
        Me.passWord = New System.Windows.Forms.TextBox
        Me.submitPasswordButton = New System.Windows.Forms.Button
        Me.forgotPasswordButton = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.statusPicture = New System.Windows.Forms.PictureBox
        Me.emailPrompt = New System.Windows.Forms.Label
        Me.exitButton = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.statusPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pwHeader
        '
        Me.pwHeader.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.pwHeader, "pwHeader")
        Me.pwHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.pwHeader.Name = "pwHeader"
        '
        'passWord
        '
        Me.passWord.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.passWord, "passWord")
        Me.passWord.Name = "passWord"
        '
        'submitPasswordButton
        '
        Me.submitPasswordButton.BackColor = System.Drawing.Color.Gainsboro
        Me.submitPasswordButton.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.submitPasswordButton, "submitPasswordButton")
        Me.submitPasswordButton.ForeColor = System.Drawing.Color.White
        Me.submitPasswordButton.Image = Global.Start.My.Resources.Resources.button_ok
        Me.submitPasswordButton.Name = "submitPasswordButton"
        Me.submitPasswordButton.UseVisualStyleBackColor = False
        '
        'forgotPasswordButton
        '
        Me.forgotPasswordButton.BackColor = System.Drawing.Color.Yellow
        Me.forgotPasswordButton.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.forgotPasswordButton, "forgotPasswordButton")
        Me.forgotPasswordButton.ForeColor = System.Drawing.Color.Black
        Me.forgotPasswordButton.Name = "forgotPasswordButton"
        Me.forgotPasswordButton.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.statusPicture)
        Me.GroupBox1.Controls.Add(Me.forgotPasswordButton)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'statusPicture
        '
        Me.statusPicture.Image = Global.Start.My.Resources.Resources.flag_red
        resources.ApplyResources(Me.statusPicture, "statusPicture")
        Me.statusPicture.Name = "statusPicture"
        Me.statusPicture.TabStop = False
        '
        'emailPrompt
        '
        Me.emailPrompt.BackColor = System.Drawing.Color.Gainsboro
        resources.ApplyResources(Me.emailPrompt, "emailPrompt")
        Me.emailPrompt.ForeColor = System.Drawing.Color.White
        Me.emailPrompt.Name = "emailPrompt"
        '
        'exitButton
        '
        Me.exitButton.BackColor = System.Drawing.Color.Red
        Me.exitButton.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.exitButton, "exitButton")
        Me.exitButton.ForeColor = System.Drawing.Color.White
        Me.exitButton.Image = Global.Start.My.Resources.Resources.window_close
        Me.exitButton.Name = "exitButton"
        Me.exitButton.UseVisualStyleBackColor = False
        '
        'login
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Start.My.Resources.Resources.small_world_background
        Me.ControlBox = False
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.submitPasswordButton)
        Me.Controls.Add(Me.passWord)
        Me.Controls.Add(Me.pwHeader)
        Me.Controls.Add(Me.emailPrompt)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "login"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.statusPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pwHeader As System.Windows.Forms.Label
    Friend WithEvents passWord As System.Windows.Forms.TextBox
    Friend WithEvents submitPasswordButton As System.Windows.Forms.Button
    Friend WithEvents forgotPasswordButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents statusPicture As System.Windows.Forms.PictureBox
    Friend WithEvents emailPrompt As System.Windows.Forms.Label
    Friend WithEvents exitButton As System.Windows.Forms.Button
End Class
