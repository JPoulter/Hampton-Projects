<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class installTC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(installTC))
        Me.DisplayAdminUser = New System.Windows.Forms.Panel
        Me.ExitProgram = New System.Windows.Forms.Button
        Me.InstallAdmin = New System.Windows.Forms.Button
        Me.notify01 = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.DisplayAdminUser.SuspendLayout()
        Me.SuspendLayout()
        '
        'DisplayAdminUser
        '
        Me.DisplayAdminUser.BackColor = System.Drawing.Color.Transparent
        Me.DisplayAdminUser.Controls.Add(Me.ExitProgram)
        Me.DisplayAdminUser.Controls.Add(Me.InstallAdmin)
        Me.DisplayAdminUser.Controls.Add(Me.notify01)
        Me.DisplayAdminUser.Location = New System.Drawing.Point(29, 169)
        Me.DisplayAdminUser.Name = "DisplayAdminUser"
        Me.DisplayAdminUser.Size = New System.Drawing.Size(728, 311)
        Me.DisplayAdminUser.TabIndex = 0
        '
        'ExitProgram
        '
        Me.ExitProgram.BackColor = System.Drawing.Color.Red
        Me.ExitProgram.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ExitProgram.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ExitProgram.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitProgram.ForeColor = System.Drawing.Color.White
        Me.ExitProgram.Image = Global.Start.My.Resources.Resources.window_close
        Me.ExitProgram.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ExitProgram.Location = New System.Drawing.Point(506, 259)
        Me.ExitProgram.Name = "ExitProgram"
        Me.ExitProgram.Size = New System.Drawing.Size(200, 35)
        Me.ExitProgram.TabIndex = 3
        Me.ExitProgram.Text = "exit"
        Me.ExitProgram.UseVisualStyleBackColor = False
        '
        'InstallAdmin
        '
        Me.InstallAdmin.BackColor = System.Drawing.Color.Green
        Me.InstallAdmin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.InstallAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.InstallAdmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InstallAdmin.ForeColor = System.Drawing.Color.White
        Me.InstallAdmin.Image = CType(resources.GetObject("InstallAdmin.Image"), System.Drawing.Image)
        Me.InstallAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.InstallAdmin.Location = New System.Drawing.Point(20, 260)
        Me.InstallAdmin.Name = "InstallAdmin"
        Me.InstallAdmin.Size = New System.Drawing.Size(200, 35)
        Me.InstallAdmin.TabIndex = 1
        Me.InstallAdmin.Text = "install"
        Me.InstallAdmin.UseVisualStyleBackColor = False
        '
        'notify01
        '
        Me.notify01.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.notify01.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.notify01.Location = New System.Drawing.Point(17, 4)
        Me.notify01.Name = "notify01"
        Me.notify01.Size = New System.Drawing.Size(690, 240)
        Me.notify01.TabIndex = 0
        Me.notify01.Text = "Label1"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.ProgressBar1.Location = New System.Drawing.Point(49, 501)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(686, 15)
        Me.ProgressBar1.Step = 2
        Me.ProgressBar1.TabIndex = 2
        Me.ProgressBar1.Visible = False
        '
        'installTC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Start.My.Resources.Resources.full_world_background
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(784, 528)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.DisplayAdminUser)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "installTC"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "installTC"
        Me.TopMost = True
        Me.DisplayAdminUser.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DisplayAdminUser As System.Windows.Forms.Panel
    Friend WithEvents notify01 As System.Windows.Forms.Label
    Friend WithEvents InstallAdmin As System.Windows.Forms.Button
    Friend WithEvents ExitProgram As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
