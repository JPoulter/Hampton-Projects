<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form1
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form1))
        Me.MainPrompt = New System.Windows.Forms.Label
        Me.driveVersion = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.copyrightText = New System.Windows.Forms.Label
        Me.OpsManualPicture = New System.Windows.Forms.PictureBox
        Me.downloadArrow = New System.Windows.Forms.PictureBox
        Me.ExitButton = New System.Windows.Forms.PictureBox
        Me.MainPagehelpButton = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.opsManualLabel = New System.Windows.Forms.Label
        CType(Me.OpsManualPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.downloadArrow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExitButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainPagehelpButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainPrompt
        '
        Me.MainPrompt.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.MainPrompt.Dock = System.Windows.Forms.DockStyle.Left
        Me.MainPrompt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MainPrompt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainPrompt.ForeColor = System.Drawing.Color.Gainsboro
        Me.MainPrompt.Location = New System.Drawing.Point(0, 0)
        Me.MainPrompt.Margin = New System.Windows.Forms.Padding(0)
        Me.MainPrompt.Name = "MainPrompt"
        Me.MainPrompt.Size = New System.Drawing.Size(528, 50)
        Me.MainPrompt.TabIndex = 1
        Me.MainPrompt.Text = "gotta see this."
        Me.MainPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MainPrompt.Visible = False
        '
        'driveVersion
        '
        Me.driveVersion.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.driveVersion.Dock = System.Windows.Forms.DockStyle.Right
        Me.driveVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.driveVersion.ForeColor = System.Drawing.Color.Gainsboro
        Me.driveVersion.Location = New System.Drawing.Point(403, 0)
        Me.driveVersion.Name = "driveVersion"
        Me.driveVersion.Size = New System.Drawing.Size(394, 25)
        Me.driveVersion.TabIndex = 11
        Me.driveVersion.Text = "Label1"
        Me.driveVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.driveVersion.Visible = False
        '
        'copyrightText
        '
        Me.copyrightText.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.copyrightText.Dock = System.Windows.Forms.DockStyle.Left
        Me.copyrightText.ForeColor = System.Drawing.Color.Gainsboro
        Me.copyrightText.Location = New System.Drawing.Point(3, 0)
        Me.copyrightText.Name = "copyrightText"
        Me.copyrightText.Size = New System.Drawing.Size(322, 25)
        Me.copyrightText.TabIndex = 21
        Me.copyrightText.Text = "In-A-Flash ™ 2010, Hampton Consulting LLC"
        Me.copyrightText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.copyrightText.Visible = False
        '
        'OpsManualPicture
        '
        Me.OpsManualPicture.BackColor = System.Drawing.Color.Transparent
        Me.OpsManualPicture.Cursor = System.Windows.Forms.Cursors.Hand
        Me.OpsManualPicture.Image = CType(resources.GetObject("OpsManualPicture.Image"), System.Drawing.Image)
        Me.OpsManualPicture.Location = New System.Drawing.Point(343, 235)
        Me.OpsManualPicture.Margin = New System.Windows.Forms.Padding(0)
        Me.OpsManualPicture.Name = "OpsManualPicture"
        Me.OpsManualPicture.Size = New System.Drawing.Size(128, 134)
        Me.OpsManualPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.OpsManualPicture.TabIndex = 7
        Me.OpsManualPicture.TabStop = False
        Me.OpsManualPicture.Visible = False
        '
        'downloadArrow
        '
        Me.downloadArrow.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.downloadArrow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.downloadArrow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.downloadArrow.Enabled = False
        Me.downloadArrow.Image = Global.Start.My.Resources.Resources.no_download1
        Me.downloadArrow.Location = New System.Drawing.Point(650, 0)
        Me.downloadArrow.Margin = New System.Windows.Forms.Padding(0)
        Me.downloadArrow.Name = "downloadArrow"
        Me.downloadArrow.Size = New System.Drawing.Size(50, 50)
        Me.downloadArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.downloadArrow.TabIndex = 26
        Me.downloadArrow.TabStop = False
        Me.downloadArrow.Visible = False
        '
        'ExitButton
        '
        Me.ExitButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ExitButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExitButton.Image = Global.Start.My.Resources.Resources.exit1
        Me.ExitButton.Location = New System.Drawing.Point(750, 0)
        Me.ExitButton.Margin = New System.Windows.Forms.Padding(0)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(50, 50)
        Me.ExitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.ExitButton.TabIndex = 10
        Me.ExitButton.TabStop = False
        Me.ExitButton.Visible = False
        '
        'MainPagehelpButton
        '
        Me.MainPagehelpButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.MainPagehelpButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MainPagehelpButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPagehelpButton.Enabled = False
        Me.MainPagehelpButton.Image = Global.Start.My.Resources.Resources.no_help1
        Me.MainPagehelpButton.Location = New System.Drawing.Point(700, 0)
        Me.MainPagehelpButton.Margin = New System.Windows.Forms.Padding(0)
        Me.MainPagehelpButton.Name = "MainPagehelpButton"
        Me.MainPagehelpButton.Size = New System.Drawing.Size(50, 50)
        Me.MainPagehelpButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.MainPagehelpButton.TabIndex = 24
        Me.MainPagehelpButton.TabStop = False
        Me.MainPagehelpButton.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.Start.My.Resources.Resources.full_world_background
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(800, 528)
        Me.PictureBox2.TabIndex = 27
        Me.PictureBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(73, 213)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 28
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.downloadArrow, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.MainPrompt, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.MainPagehelpButton, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ExitButton, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(800, 50)
        Me.TableLayoutPanel1.TabIndex = 29
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.copyrightText, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.driveVersion, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 503)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(800, 25)
        Me.TableLayoutPanel2.TabIndex = 30
        '
        'opsManualLabel
        '
        Me.opsManualLabel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.opsManualLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.opsManualLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opsManualLabel.ForeColor = System.Drawing.Color.Maroon
        Me.opsManualLabel.Location = New System.Drawing.Point(207, 381)
        Me.opsManualLabel.Name = "opsManualLabel"
        Me.opsManualLabel.Size = New System.Drawing.Size(400, 31)
        Me.opsManualLabel.TabIndex = 31
        Me.opsManualLabel.Text = "Operations Manual"
        Me.opsManualLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(800, 528)
        Me.Controls.Add(Me.opsManualLabel)
        Me.Controls.Add(Me.OpsManualPicture)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 300)
        Me.Name = "form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.OpsManualPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.downloadArrow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExitButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainPagehelpButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainPrompt As System.Windows.Forms.Label
    Friend WithEvents OpsManualPicture As System.Windows.Forms.PictureBox
    Friend WithEvents ExitButton As System.Windows.Forms.PictureBox
    Friend WithEvents driveVersion As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MainPagehelpButton As System.Windows.Forms.PictureBox
    Friend WithEvents downloadArrow As System.Windows.Forms.PictureBox
    Friend WithEvents copyrightText As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents opsManualLabel As System.Windows.Forms.Label

End Class
