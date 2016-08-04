<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class update
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(update))
        Me.HeadlineBanner = New System.Windows.Forms.TextBox
        Me.actionLabel = New System.Windows.Forms.Label
        Me.showAnimation = New System.Windows.Forms.PictureBox
        Me.ExitUpdate = New System.Windows.Forms.Button
        Me.instructions2 = New System.Windows.Forms.Label
        Me.StartButton = New System.Windows.Forms.Button
        Me.instructions1 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.PictureBox8 = New System.Windows.Forms.PictureBox
        CType(Me.showAnimation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HeadlineBanner
        '
        Me.HeadlineBanner.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.HeadlineBanner.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TableLayoutPanel2.SetColumnSpan(Me.HeadlineBanner, 3)
        Me.HeadlineBanner.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.HeadlineBanner, "HeadlineBanner")
        Me.HeadlineBanner.ForeColor = System.Drawing.Color.Gainsboro
        Me.HeadlineBanner.Name = "HeadlineBanner"
        Me.HeadlineBanner.ReadOnly = True
        Me.HeadlineBanner.TabStop = False
        '
        'actionLabel
        '
        Me.actionLabel.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.actionLabel, "actionLabel")
        Me.actionLabel.Name = "actionLabel"
        '
        'showAnimation
        '
        Me.showAnimation.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.showAnimation, "showAnimation")
        Me.showAnimation.Name = "showAnimation"
        Me.showAnimation.TabStop = False
        '
        'ExitUpdate
        '
        Me.ExitUpdate.BackColor = System.Drawing.Color.Red
        resources.ApplyResources(Me.ExitUpdate, "ExitUpdate")
        Me.ExitUpdate.ForeColor = System.Drawing.Color.White
        Me.ExitUpdate.Name = "ExitUpdate"
        Me.ExitUpdate.UseVisualStyleBackColor = False
        '
        'instructions2
        '
        Me.instructions2.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.instructions2, "instructions2")
        Me.instructions2.Name = "instructions2"
        '
        'StartButton
        '
        Me.StartButton.BackColor = System.Drawing.Color.Green
        resources.ApplyResources(Me.StartButton, "StartButton")
        Me.StartButton.ForeColor = System.Drawing.Color.White
        Me.StartButton.Name = "StartButton"
        Me.StartButton.UseVisualStyleBackColor = False
        '
        'instructions1
        '
        Me.instructions1.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.instructions1, "instructions1")
        Me.instructions1.Name = "instructions1"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackgroundImage = Global.Start.My.Resources.Resources.small_world_background
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.instructions1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.showAnimation, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.actionLabel, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.instructions2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.StartButton, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ExitUpdate, 0, 5)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel2.SetRowSpan(Me.TableLayoutPanel1, 4)
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(115, Byte), Integer))
        resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBox8, 2, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBox2, 2, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBox3, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBox4, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBox5, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBox6, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBox7, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel1, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.HeadlineBanner, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBox1, 0, 1)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Image = Global.Start.My.Resources.Resources.messagebox_warning
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        resources.ApplyResources(Me.PictureBox2, "PictureBox2")
        Me.PictureBox2.Image = Global.Start.My.Resources.Resources.messagebox_warning
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        resources.ApplyResources(Me.PictureBox3, "PictureBox3")
        Me.PictureBox3.Image = Global.Start.My.Resources.Resources.messagebox_warning
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        resources.ApplyResources(Me.PictureBox4, "PictureBox4")
        Me.PictureBox4.Image = Global.Start.My.Resources.Resources.messagebox_warning
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.TabStop = False
        '
        'PictureBox5
        '
        resources.ApplyResources(Me.PictureBox5, "PictureBox5")
        Me.PictureBox5.Image = Global.Start.My.Resources.Resources.messagebox_warning
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.TabStop = False
        '
        'PictureBox6
        '
        resources.ApplyResources(Me.PictureBox6, "PictureBox6")
        Me.PictureBox6.Image = Global.Start.My.Resources.Resources.messagebox_warning
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.TabStop = False
        '
        'PictureBox7
        '
        resources.ApplyResources(Me.PictureBox7, "PictureBox7")
        Me.PictureBox7.Image = Global.Start.My.Resources.Resources.messagebox_warning
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.TabStop = False
        '
        'PictureBox8
        '
        resources.ApplyResources(Me.PictureBox8, "PictureBox8")
        Me.PictureBox8.Image = Global.Start.My.Resources.Resources.messagebox_warning
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.TabStop = False
        '
        'update
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "update"
        CType(Me.showAnimation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HeadlineBanner As System.Windows.Forms.TextBox
    Friend WithEvents instructions1 As System.Windows.Forms.Label
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents ExitUpdate As System.Windows.Forms.Button
    Friend WithEvents instructions2 As System.Windows.Forms.Label
    Friend WithEvents actionLabel As System.Windows.Forms.Label
    Friend WithEvents showAnimation As System.Windows.Forms.PictureBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
