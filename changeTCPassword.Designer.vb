<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class changeTCPassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(changeTCPassword))
        Me.changePasswordPrompt = New System.Windows.Forms.Label
        Me.doChangePassword = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.changePWTitle = New System.Windows.Forms.Label
        Me.enterNewPWPrompt = New System.Windows.Forms.Label
        Me.newPWentry = New System.Windows.Forms.TextBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.okToExit = New System.Windows.Forms.Button
        Me.mainExitButton = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'changePasswordPrompt
        '
        Me.changePasswordPrompt.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.changePasswordPrompt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.changePasswordPrompt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.changePasswordPrompt.ForeColor = System.Drawing.Color.Gainsboro
        Me.changePasswordPrompt.Location = New System.Drawing.Point(12, 172)
        Me.changePasswordPrompt.Name = "changePasswordPrompt"
        Me.changePasswordPrompt.Padding = New System.Windows.Forms.Padding(5)
        Me.changePasswordPrompt.Size = New System.Drawing.Size(770, 200)
        Me.changePasswordPrompt.TabIndex = 0
        Me.changePasswordPrompt.Text = "Label1"
        Me.changePasswordPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'doChangePassword
        '
        Me.doChangePassword.AutoSize = True
        Me.doChangePassword.BackColor = System.Drawing.Color.Gainsboro
        Me.doChangePassword.Enabled = False
        Me.doChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.doChangePassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.doChangePassword.ForeColor = System.Drawing.Color.White
        Me.doChangePassword.Image = Global.Start.My.Resources.Resources.button_ok1
        Me.doChangePassword.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.doChangePassword.Location = New System.Drawing.Point(120, 431)
        Me.doChangePassword.Name = "doChangePassword"
        Me.doChangePassword.Size = New System.Drawing.Size(250, 30)
        Me.doChangePassword.TabIndex = 3
        Me.doChangePassword.Text = "do it"
        Me.doChangePassword.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.Start.My.Resources.Resources.messagebox_warning
        Me.PictureBox1.Location = New System.Drawing.Point(12, 68)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.Start.My.Resources.Resources.messagebox_warning
        Me.PictureBox2.Location = New System.Drawing.Point(718, 68)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.Start.My.Resources.Resources.messagebox_warning
        Me.PictureBox3.Location = New System.Drawing.Point(718, 427)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox3.TabIndex = 7
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.Start.My.Resources.Resources.messagebox_warning
        Me.PictureBox4.Location = New System.Drawing.Point(12, 427)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox4.TabIndex = 6
        Me.PictureBox4.TabStop = False
        '
        'changePWTitle
        '
        Me.changePWTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.changePWTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.changePWTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.changePWTitle.ForeColor = System.Drawing.Color.Gainsboro
        Me.changePWTitle.Location = New System.Drawing.Point(12, 148)
        Me.changePWTitle.Name = "changePWTitle"
        Me.changePWTitle.Size = New System.Drawing.Size(770, 25)
        Me.changePWTitle.TabIndex = 8
        Me.changePWTitle.Text = "Label1"
        Me.changePWTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'enterNewPWPrompt
        '
        Me.enterNewPWPrompt.BackColor = System.Drawing.Color.Transparent
        Me.enterNewPWPrompt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.enterNewPWPrompt.Location = New System.Drawing.Point(12, 374)
        Me.enterNewPWPrompt.Name = "enterNewPWPrompt"
        Me.enterNewPWPrompt.Size = New System.Drawing.Size(770, 23)
        Me.enterNewPWPrompt.TabIndex = 9
        Me.enterNewPWPrompt.Text = "Label1"
        Me.enterNewPWPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'newPWentry
        '
        Me.newPWentry.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newPWentry.Location = New System.Drawing.Point(247, 399)
        Me.newPWentry.Name = "newPWentry"
        Me.newPWentry.Size = New System.Drawing.Size(300, 26)
        Me.newPWentry.TabIndex = 10
        Me.newPWentry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(150, 467)
        Me.ProgressBar1.MarqueeAnimationSpeed = 20
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(498, 15)
        Me.ProgressBar1.TabIndex = 12
        Me.ProgressBar1.Visible = False
        '
        'okToExit
        '
        Me.okToExit.BackColor = System.Drawing.Color.Gainsboro
        Me.okToExit.Enabled = False
        Me.okToExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.okToExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.okToExit.ForeColor = System.Drawing.Color.White
        Me.okToExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.okToExit.Location = New System.Drawing.Point(424, 431)
        Me.okToExit.Name = "okToExit"
        Me.okToExit.Size = New System.Drawing.Size(250, 30)
        Me.okToExit.TabIndex = 13
        Me.okToExit.Text = "ok"
        Me.okToExit.UseVisualStyleBackColor = False
        '
        'mainExitButton
        '
        Me.mainExitButton.BackColor = System.Drawing.Color.Red
        Me.mainExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.mainExitButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainExitButton.ForeColor = System.Drawing.Color.White
        Me.mainExitButton.Image = Global.Start.My.Resources.Resources.window_close
        Me.mainExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.mainExitButton.Location = New System.Drawing.Point(247, 487)
        Me.mainExitButton.Name = "mainExitButton"
        Me.mainExitButton.Size = New System.Drawing.Size(300, 30)
        Me.mainExitButton.TabIndex = 14
        Me.mainExitButton.Text = "main exit button"
        Me.mainExitButton.UseVisualStyleBackColor = False
        '
        'changeTCPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Start.My.Resources.Resources.full_world_background
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(794, 522)
        Me.ControlBox = False
        Me.Controls.Add(Me.mainExitButton)
        Me.Controls.Add(Me.okToExit)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.newPWentry)
        Me.Controls.Add(Me.enterNewPWPrompt)
        Me.Controls.Add(Me.changePWTitle)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.doChangePassword)
        Me.Controls.Add(Me.changePasswordPrompt)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "changeTCPassword"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "changeTCPassword"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents changePasswordPrompt As System.Windows.Forms.Label
    Friend WithEvents doChangePassword As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents changePWTitle As System.Windows.Forms.Label
    Friend WithEvents enterNewPWPrompt As System.Windows.Forms.Label
    Friend WithEvents newPWentry As System.Windows.Forms.TextBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents okToExit As System.Windows.Forms.Button
    Friend WithEvents mainExitButton As System.Windows.Forms.Button
End Class
