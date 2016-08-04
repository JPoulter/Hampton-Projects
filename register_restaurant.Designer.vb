<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class register_restaurant
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(register_restaurant))
        Me.rnOwnership = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.rnFranchiseName = New System.Windows.Forms.Label
        Me.rnZipcode = New System.Windows.Forms.Label
        Me.rnCity = New System.Windows.Forms.Label
        Me.rnState = New System.Windows.Forms.Label
        Me.rnCountry = New System.Windows.Forms.Label
        Me.rnAddress3 = New System.Windows.Forms.Label
        Me.rnAddress2 = New System.Windows.Forms.Label
        Me.rnAddress1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.restaurantNumber = New System.Windows.Forms.ComboBox
        Me.SelectRNTitle = New System.Windows.Forms.GroupBox
        Me.headerPicture = New System.Windows.Forms.PictureBox
        Me.exitButton = New System.Windows.Forms.PictureBox
        Me.RestRegisterhelpButton = New System.Windows.Forms.PictureBox
        Me.pageHeader = New System.Windows.Forms.Label
        Me.RegisterButton = New System.Windows.Forms.Button
        Me.waitLabel = New System.Windows.Forms.Label
        Me.RNInfoTitle = New System.Windows.Forms.GroupBox
        Me.SelectRNTitle.SuspendLayout()
        CType(Me.headerPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.exitButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RestRegisterhelpButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RNInfoTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'rnOwnership
        '
        resources.ApplyResources(Me.rnOwnership, "rnOwnership")
        Me.rnOwnership.Name = "rnOwnership"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'rnFranchiseName
        '
        resources.ApplyResources(Me.rnFranchiseName, "rnFranchiseName")
        Me.rnFranchiseName.Name = "rnFranchiseName"
        '
        'rnZipcode
        '
        resources.ApplyResources(Me.rnZipcode, "rnZipcode")
        Me.rnZipcode.Name = "rnZipcode"
        '
        'rnCity
        '
        resources.ApplyResources(Me.rnCity, "rnCity")
        Me.rnCity.Name = "rnCity"
        '
        'rnState
        '
        resources.ApplyResources(Me.rnState, "rnState")
        Me.rnState.Name = "rnState"
        '
        'rnCountry
        '
        resources.ApplyResources(Me.rnCountry, "rnCountry")
        Me.rnCountry.Name = "rnCountry"
        '
        'rnAddress3
        '
        resources.ApplyResources(Me.rnAddress3, "rnAddress3")
        Me.rnAddress3.Name = "rnAddress3"
        '
        'rnAddress2
        '
        resources.ApplyResources(Me.rnAddress2, "rnAddress2")
        Me.rnAddress2.Name = "rnAddress2"
        '
        'rnAddress1
        '
        resources.ApplyResources(Me.rnAddress1, "rnAddress1")
        Me.rnAddress1.Name = "rnAddress1"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'restaurantNumber
        '
        Me.restaurantNumber.Cursor = System.Windows.Forms.Cursors.Hand
        Me.restaurantNumber.DropDownHeight = 200
        Me.restaurantNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.restaurantNumber.DropDownWidth = 40
        resources.ApplyResources(Me.restaurantNumber, "restaurantNumber")
        Me.restaurantNumber.FormattingEnabled = True
        Me.restaurantNumber.Name = "restaurantNumber"
        '
        'SelectRNTitle
        '
        Me.SelectRNTitle.BackColor = System.Drawing.Color.Transparent
        Me.SelectRNTitle.Controls.Add(Me.restaurantNumber)
        Me.SelectRNTitle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        resources.ApplyResources(Me.SelectRNTitle, "SelectRNTitle")
        Me.SelectRNTitle.Name = "SelectRNTitle"
        Me.SelectRNTitle.TabStop = False
        '
        'headerPicture
        '
        Me.headerPicture.Image = Global.Start.My.Resources.Resources.headline_background
        resources.ApplyResources(Me.headerPicture, "headerPicture")
        Me.headerPicture.Name = "headerPicture"
        Me.headerPicture.TabStop = False
        '
        'exitButton
        '
        resources.ApplyResources(Me.exitButton, "exitButton")
        Me.exitButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.exitButton.Image = Global.Start.My.Resources.Resources.exit1
        Me.exitButton.Name = "exitButton"
        Me.exitButton.TabStop = False
        '
        'RestRegisterhelpButton
        '
        Me.RestRegisterhelpButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.RestRegisterhelpButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RestRegisterhelpButton.Image = Global.Start.My.Resources.Resources.help1
        resources.ApplyResources(Me.RestRegisterhelpButton, "RestRegisterhelpButton")
        Me.RestRegisterhelpButton.Name = "RestRegisterhelpButton"
        Me.RestRegisterhelpButton.TabStop = False
        '
        'pageHeader
        '
        Me.pageHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(115, Byte), Integer))
        resources.ApplyResources(Me.pageHeader, "pageHeader")
        Me.pageHeader.ForeColor = System.Drawing.Color.Transparent
        Me.pageHeader.Name = "pageHeader"
        '
        'RegisterButton
        '
        Me.RegisterButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.RegisterButton.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.RegisterButton, "RegisterButton")
        Me.RegisterButton.ForeColor = System.Drawing.Color.Gainsboro
        Me.RegisterButton.Image = Global.Start.My.Resources.Resources.button_ok1
        Me.RegisterButton.Name = "RegisterButton"
        Me.RegisterButton.UseVisualStyleBackColor = False
        '
        'waitLabel
        '
        Me.waitLabel.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.waitLabel, "waitLabel")
        Me.waitLabel.ForeColor = System.Drawing.Color.Red
        Me.waitLabel.Name = "waitLabel"
        '
        'RNInfoTitle
        '
        Me.RNInfoTitle.BackColor = System.Drawing.Color.Transparent
        Me.RNInfoTitle.Controls.Add(Me.Label9)
        Me.RNInfoTitle.Controls.Add(Me.rnOwnership)
        Me.RNInfoTitle.Controls.Add(Me.Label6)
        Me.RNInfoTitle.Controls.Add(Me.Label7)
        Me.RNInfoTitle.Controls.Add(Me.Label10)
        Me.RNInfoTitle.Controls.Add(Me.Label5)
        Me.RNInfoTitle.Controls.Add(Me.Label8)
        Me.RNInfoTitle.Controls.Add(Me.rnFranchiseName)
        Me.RNInfoTitle.Controls.Add(Me.Label4)
        Me.RNInfoTitle.Controls.Add(Me.Label3)
        Me.RNInfoTitle.Controls.Add(Me.rnZipcode)
        Me.RNInfoTitle.Controls.Add(Me.rnAddress1)
        Me.RNInfoTitle.Controls.Add(Me.Label2)
        Me.RNInfoTitle.Controls.Add(Me.rnCity)
        Me.RNInfoTitle.Controls.Add(Me.rnAddress2)
        Me.RNInfoTitle.Controls.Add(Me.rnAddress3)
        Me.RNInfoTitle.Controls.Add(Me.rnState)
        Me.RNInfoTitle.Controls.Add(Me.rnCountry)
        resources.ApplyResources(Me.RNInfoTitle, "RNInfoTitle")
        Me.RNInfoTitle.Name = "RNInfoTitle"
        Me.RNInfoTitle.TabStop = False
        '
        'register_restaurant
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Start.My.Resources.Resources.mono_world_background
        Me.ControlBox = False
        Me.Controls.Add(Me.RNInfoTitle)
        Me.Controls.Add(Me.RegisterButton)
        Me.Controls.Add(Me.pageHeader)
        Me.Controls.Add(Me.RestRegisterhelpButton)
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.SelectRNTitle)
        Me.Controls.Add(Me.waitLabel)
        Me.Controls.Add(Me.headerPicture)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "register_restaurant"
        Me.SelectRNTitle.ResumeLayout(False)
        CType(Me.headerPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.exitButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RestRegisterhelpButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RNInfoTitle.ResumeLayout(False)
        Me.RNInfoTitle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rnFranchiseName As System.Windows.Forms.Label
    Friend WithEvents rnZipcode As System.Windows.Forms.Label
    Friend WithEvents rnCity As System.Windows.Forms.Label
    Friend WithEvents rnState As System.Windows.Forms.Label
    Friend WithEvents rnCountry As System.Windows.Forms.Label
    Friend WithEvents rnAddress3 As System.Windows.Forms.Label
    Friend WithEvents rnAddress2 As System.Windows.Forms.Label
    Friend WithEvents rnAddress1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents restaurantNumber As System.Windows.Forms.ComboBox
    Friend WithEvents SelectRNTitle As System.Windows.Forms.GroupBox
    Friend WithEvents headerPicture As System.Windows.Forms.PictureBox
    Friend WithEvents exitButton As System.Windows.Forms.PictureBox
    Friend WithEvents RestRegisterhelpButton As System.Windows.Forms.PictureBox
    Friend WithEvents pageHeader As System.Windows.Forms.Label
    Friend WithEvents RegisterButton As System.Windows.Forms.Button
    Friend WithEvents rnOwnership As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents waitLabel As System.Windows.Forms.Label
    Friend WithEvents RNInfoTitle As System.Windows.Forms.GroupBox
End Class
