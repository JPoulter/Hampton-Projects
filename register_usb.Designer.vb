<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class register_usb
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(register_usb))
        Me.pageHeader = New System.Windows.Forms.Label
        Me.USBRegisterHelpButton = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.LabelFirstName = New System.Windows.Forms.Label
        Me.LabelLastName = New System.Windows.Forms.Label
        Me.LabelAddress = New System.Windows.Forms.Label
        Me.LabelCity = New System.Windows.Forms.Label
        Me.LabelCountry = New System.Windows.Forms.Label
        Me.LabelState = New System.Windows.Forms.Label
        Me.LabelZip = New System.Windows.Forms.Label
        Me.LabelEmail = New System.Windows.Forms.Label
        Me.LabelJobTitle = New System.Windows.Forms.Label
        Me.LabelFranchiseName = New System.Windows.Forms.Label
        Me.inputFirstName = New System.Windows.Forms.TextBox
        Me.inputLastName = New System.Windows.Forms.TextBox
        Me.inputAddress1 = New System.Windows.Forms.TextBox
        Me.inputAddress2 = New System.Windows.Forms.TextBox
        Me.inputCity = New System.Windows.Forms.TextBox
        Me.inputZipcode = New System.Windows.Forms.TextBox
        Me.inputEmail = New System.Windows.Forms.TextBox
        Me.inputCountry = New System.Windows.Forms.ComboBox
        Me.inputState = New System.Windows.Forms.ComboBox
        Me.inputJobTitle = New System.Windows.Forms.ComboBox
        Me.inputFranchiseName = New System.Windows.Forms.ComboBox
        Me.inputCorporate = New System.Windows.Forms.RadioButton
        Me.inputFranchise = New System.Windows.Forms.RadioButton
        Me.AssociationBox = New System.Windows.Forms.GroupBox
        Me.flagAssociation = New System.Windows.Forms.PictureBox
        Me.flagFranchiseName = New System.Windows.Forms.PictureBox
        Me.RegisterButton = New System.Windows.Forms.Button
        Me.flag1 = New System.Windows.Forms.PictureBox
        Me.flag2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.LabelYellowFlag = New System.Windows.Forms.Label
        Me.LabelGreenFlag = New System.Windows.Forms.Label
        Me.LabelRedFlag = New System.Windows.Forms.Label
        Me.flagFirstName = New System.Windows.Forms.PictureBox
        Me.flagLastName = New System.Windows.Forms.PictureBox
        Me.flagAddress = New System.Windows.Forms.PictureBox
        Me.flagCountry = New System.Windows.Forms.PictureBox
        Me.flagCity = New System.Windows.Forms.PictureBox
        Me.flagState = New System.Windows.Forms.PictureBox
        Me.flagZipcode = New System.Windows.Forms.PictureBox
        Me.flagEmail = New System.Windows.Forms.PictureBox
        Me.flagJobTitle = New System.Windows.Forms.PictureBox
        Me.waitLabel = New System.Windows.Forms.Label
        Me.suiteNumber = New System.Windows.Forms.Label
        Me.RegisterusbBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.USBRegisterHelpButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AssociationBox.SuspendLayout()
        CType(Me.flagAssociation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.flagFranchiseName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.flag1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.flag2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.flagFirstName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.flagLastName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.flagAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.flagCountry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.flagCity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.flagState, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.flagZipcode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.flagEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.flagJobTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RegisterusbBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pageHeader
        '
        Me.pageHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(115, Byte), Integer))
        resources.ApplyResources(Me.pageHeader, "pageHeader")
        Me.pageHeader.ForeColor = System.Drawing.Color.Transparent
        Me.pageHeader.Name = "pageHeader"
        '
        'USBRegisterHelpButton
        '
        Me.USBRegisterHelpButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.USBRegisterHelpButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.USBRegisterHelpButton.Image = Global.Start.My.Resources.Resources.help1
        resources.ApplyResources(Me.USBRegisterHelpButton, "USBRegisterHelpButton")
        Me.USBRegisterHelpButton.Name = "USBRegisterHelpButton"
        Me.USBRegisterHelpButton.TabStop = False
        '
        'PictureBox2
        '
        resources.ApplyResources(Me.PictureBox2, "PictureBox2")
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = Global.Start.My.Resources.Resources.exit1
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.TabStop = False
        '
        'LabelFirstName
        '
        resources.ApplyResources(Me.LabelFirstName, "LabelFirstName")
        Me.LabelFirstName.BackColor = System.Drawing.Color.Transparent
        Me.LabelFirstName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.LabelFirstName.Name = "LabelFirstName"
        '
        'LabelLastName
        '
        resources.ApplyResources(Me.LabelLastName, "LabelLastName")
        Me.LabelLastName.BackColor = System.Drawing.Color.Transparent
        Me.LabelLastName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.LabelLastName.Name = "LabelLastName"
        '
        'LabelAddress
        '
        resources.ApplyResources(Me.LabelAddress, "LabelAddress")
        Me.LabelAddress.BackColor = System.Drawing.Color.Transparent
        Me.LabelAddress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.LabelAddress.Name = "LabelAddress"
        '
        'LabelCity
        '
        resources.ApplyResources(Me.LabelCity, "LabelCity")
        Me.LabelCity.BackColor = System.Drawing.Color.Transparent
        Me.LabelCity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.LabelCity.Name = "LabelCity"
        '
        'LabelCountry
        '
        resources.ApplyResources(Me.LabelCountry, "LabelCountry")
        Me.LabelCountry.BackColor = System.Drawing.Color.Transparent
        Me.LabelCountry.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.LabelCountry.Name = "LabelCountry"
        '
        'LabelState
        '
        resources.ApplyResources(Me.LabelState, "LabelState")
        Me.LabelState.BackColor = System.Drawing.Color.Transparent
        Me.LabelState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.LabelState.Name = "LabelState"
        '
        'LabelZip
        '
        resources.ApplyResources(Me.LabelZip, "LabelZip")
        Me.LabelZip.BackColor = System.Drawing.Color.Transparent
        Me.LabelZip.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.LabelZip.Name = "LabelZip"
        '
        'LabelEmail
        '
        resources.ApplyResources(Me.LabelEmail, "LabelEmail")
        Me.LabelEmail.BackColor = System.Drawing.Color.Transparent
        Me.LabelEmail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.LabelEmail.Name = "LabelEmail"
        '
        'LabelJobTitle
        '
        resources.ApplyResources(Me.LabelJobTitle, "LabelJobTitle")
        Me.LabelJobTitle.BackColor = System.Drawing.Color.Transparent
        Me.LabelJobTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.LabelJobTitle.Name = "LabelJobTitle"
        '
        'LabelFranchiseName
        '
        resources.ApplyResources(Me.LabelFranchiseName, "LabelFranchiseName")
        Me.LabelFranchiseName.BackColor = System.Drawing.Color.Transparent
        Me.LabelFranchiseName.Name = "LabelFranchiseName"
        '
        'inputFirstName
        '
        resources.ApplyResources(Me.inputFirstName, "inputFirstName")
        Me.inputFirstName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.inputFirstName.Name = "inputFirstName"
        '
        'inputLastName
        '
        resources.ApplyResources(Me.inputLastName, "inputLastName")
        Me.inputLastName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.inputLastName.Name = "inputLastName"
        '
        'inputAddress1
        '
        resources.ApplyResources(Me.inputAddress1, "inputAddress1")
        Me.inputAddress1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.inputAddress1.Name = "inputAddress1"
        '
        'inputAddress2
        '
        resources.ApplyResources(Me.inputAddress2, "inputAddress2")
        Me.inputAddress2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.inputAddress2.Name = "inputAddress2"
        '
        'inputCity
        '
        resources.ApplyResources(Me.inputCity, "inputCity")
        Me.inputCity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.inputCity.Name = "inputCity"
        '
        'inputZipcode
        '
        resources.ApplyResources(Me.inputZipcode, "inputZipcode")
        Me.inputZipcode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.inputZipcode.Name = "inputZipcode"
        '
        'inputEmail
        '
        resources.ApplyResources(Me.inputEmail, "inputEmail")
        Me.inputEmail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.inputEmail.Name = "inputEmail"
        '
        'inputCountry
        '
        Me.inputCountry.Cursor = System.Windows.Forms.Cursors.Hand
        Me.inputCountry.DropDownHeight = 160
        Me.inputCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.inputCountry, "inputCountry")
        Me.inputCountry.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.inputCountry.Name = "inputCountry"
        '
        'inputState
        '
        Me.inputState.Cursor = System.Windows.Forms.Cursors.Hand
        Me.inputState.DropDownHeight = 160
        Me.inputState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.inputState, "inputState")
        Me.inputState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.inputState.Name = "inputState"
        '
        'inputJobTitle
        '
        Me.inputJobTitle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.inputJobTitle.DropDownHeight = 160
        Me.inputJobTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.inputJobTitle, "inputJobTitle")
        Me.inputJobTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.inputJobTitle.Name = "inputJobTitle"
        '
        'inputFranchiseName
        '
        Me.inputFranchiseName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.inputFranchiseName.DropDownHeight = 320
        Me.inputFranchiseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.inputFranchiseName, "inputFranchiseName")
        Me.inputFranchiseName.FormattingEnabled = True
        Me.inputFranchiseName.Name = "inputFranchiseName"
        '
        'inputCorporate
        '
        resources.ApplyResources(Me.inputCorporate, "inputCorporate")
        Me.inputCorporate.BackColor = System.Drawing.Color.Transparent
        Me.inputCorporate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.inputCorporate.Name = "inputCorporate"
        Me.inputCorporate.TabStop = True
        Me.inputCorporate.UseVisualStyleBackColor = False
        '
        'inputFranchise
        '
        resources.ApplyResources(Me.inputFranchise, "inputFranchise")
        Me.inputFranchise.BackColor = System.Drawing.Color.Transparent
        Me.inputFranchise.Cursor = System.Windows.Forms.Cursors.Hand
        Me.inputFranchise.Name = "inputFranchise"
        Me.inputFranchise.TabStop = True
        Me.inputFranchise.UseVisualStyleBackColor = False
        '
        'AssociationBox
        '
        Me.AssociationBox.BackColor = System.Drawing.Color.Transparent
        Me.AssociationBox.Controls.Add(Me.flagAssociation)
        Me.AssociationBox.Controls.Add(Me.flagFranchiseName)
        Me.AssociationBox.Controls.Add(Me.inputFranchise)
        Me.AssociationBox.Controls.Add(Me.inputFranchiseName)
        Me.AssociationBox.Controls.Add(Me.inputCorporate)
        Me.AssociationBox.Controls.Add(Me.LabelFranchiseName)
        Me.AssociationBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        resources.ApplyResources(Me.AssociationBox, "AssociationBox")
        Me.AssociationBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.AssociationBox.Name = "AssociationBox"
        Me.AssociationBox.TabStop = False
        '
        'flagAssociation
        '
        Me.flagAssociation.BackColor = System.Drawing.Color.Transparent
        Me.flagAssociation.Image = Global.Start.My.Resources.Resources.flag_yellow
        resources.ApplyResources(Me.flagAssociation, "flagAssociation")
        Me.flagAssociation.Name = "flagAssociation"
        Me.flagAssociation.TabStop = False
        '
        'flagFranchiseName
        '
        Me.flagFranchiseName.BackColor = System.Drawing.Color.Transparent
        Me.flagFranchiseName.Image = Global.Start.My.Resources.Resources.flag_yellow
        resources.ApplyResources(Me.flagFranchiseName, "flagFranchiseName")
        Me.flagFranchiseName.Name = "flagFranchiseName"
        Me.flagFranchiseName.TabStop = False
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
        'flag1
        '
        Me.flag1.BackColor = System.Drawing.Color.Transparent
        Me.flag1.Image = Global.Start.My.Resources.Resources.flag_yellow
        resources.ApplyResources(Me.flag1, "flag1")
        Me.flag1.Name = "flag1"
        Me.flag1.TabStop = False
        '
        'flag2
        '
        Me.flag2.BackColor = System.Drawing.Color.Transparent
        Me.flag2.Image = Global.Start.My.Resources.Resources.flag_green
        resources.ApplyResources(Me.flag2, "flag2")
        Me.flag2.Name = "flag2"
        Me.flag2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.Start.My.Resources.Resources.flag_red
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'LabelYellowFlag
        '
        resources.ApplyResources(Me.LabelYellowFlag, "LabelYellowFlag")
        Me.LabelYellowFlag.BackColor = System.Drawing.Color.Transparent
        Me.LabelYellowFlag.Name = "LabelYellowFlag"
        '
        'LabelGreenFlag
        '
        resources.ApplyResources(Me.LabelGreenFlag, "LabelGreenFlag")
        Me.LabelGreenFlag.BackColor = System.Drawing.Color.Transparent
        Me.LabelGreenFlag.Name = "LabelGreenFlag"
        '
        'LabelRedFlag
        '
        resources.ApplyResources(Me.LabelRedFlag, "LabelRedFlag")
        Me.LabelRedFlag.BackColor = System.Drawing.Color.Transparent
        Me.LabelRedFlag.Name = "LabelRedFlag"
        '
        'flagFirstName
        '
        Me.flagFirstName.BackColor = System.Drawing.Color.Transparent
        Me.flagFirstName.Image = Global.Start.My.Resources.Resources.flag_yellow
        resources.ApplyResources(Me.flagFirstName, "flagFirstName")
        Me.flagFirstName.Name = "flagFirstName"
        Me.flagFirstName.TabStop = False
        '
        'flagLastName
        '
        Me.flagLastName.BackColor = System.Drawing.Color.Transparent
        Me.flagLastName.Image = Global.Start.My.Resources.Resources.flag_yellow
        resources.ApplyResources(Me.flagLastName, "flagLastName")
        Me.flagLastName.Name = "flagLastName"
        Me.flagLastName.TabStop = False
        '
        'flagAddress
        '
        Me.flagAddress.BackColor = System.Drawing.Color.Transparent
        Me.flagAddress.Image = Global.Start.My.Resources.Resources.flag_yellow
        resources.ApplyResources(Me.flagAddress, "flagAddress")
        Me.flagAddress.Name = "flagAddress"
        Me.flagAddress.TabStop = False
        '
        'flagCountry
        '
        Me.flagCountry.BackColor = System.Drawing.Color.Transparent
        Me.flagCountry.Image = Global.Start.My.Resources.Resources.flag_yellow
        resources.ApplyResources(Me.flagCountry, "flagCountry")
        Me.flagCountry.Name = "flagCountry"
        Me.flagCountry.TabStop = False
        '
        'flagCity
        '
        Me.flagCity.BackColor = System.Drawing.Color.Transparent
        Me.flagCity.Image = Global.Start.My.Resources.Resources.flag_yellow
        resources.ApplyResources(Me.flagCity, "flagCity")
        Me.flagCity.Name = "flagCity"
        Me.flagCity.TabStop = False
        '
        'flagState
        '
        Me.flagState.BackColor = System.Drawing.Color.Transparent
        Me.flagState.Image = Global.Start.My.Resources.Resources.flag_yellow
        resources.ApplyResources(Me.flagState, "flagState")
        Me.flagState.Name = "flagState"
        Me.flagState.TabStop = False
        '
        'flagZipcode
        '
        Me.flagZipcode.BackColor = System.Drawing.Color.Transparent
        Me.flagZipcode.Image = Global.Start.My.Resources.Resources.flag_yellow
        resources.ApplyResources(Me.flagZipcode, "flagZipcode")
        Me.flagZipcode.Name = "flagZipcode"
        Me.flagZipcode.TabStop = False
        '
        'flagEmail
        '
        Me.flagEmail.BackColor = System.Drawing.Color.Transparent
        Me.flagEmail.Image = Global.Start.My.Resources.Resources.flag_yellow
        resources.ApplyResources(Me.flagEmail, "flagEmail")
        Me.flagEmail.Name = "flagEmail"
        Me.flagEmail.TabStop = False
        '
        'flagJobTitle
        '
        Me.flagJobTitle.BackColor = System.Drawing.Color.Transparent
        Me.flagJobTitle.Image = Global.Start.My.Resources.Resources.flag_yellow
        resources.ApplyResources(Me.flagJobTitle, "flagJobTitle")
        Me.flagJobTitle.Name = "flagJobTitle"
        Me.flagJobTitle.TabStop = False
        '
        'waitLabel
        '
        Me.waitLabel.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.waitLabel, "waitLabel")
        Me.waitLabel.ForeColor = System.Drawing.Color.Red
        Me.waitLabel.Name = "waitLabel"
        '
        'suiteNumber
        '
        resources.ApplyResources(Me.suiteNumber, "suiteNumber")
        Me.suiteNumber.BackColor = System.Drawing.Color.Transparent
        Me.suiteNumber.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.suiteNumber.Name = "suiteNumber"
        '
        'RegisterusbBindingSource
        '
        Me.RegisterusbBindingSource.DataSource = GetType(Start.register_usb)
        '
        'register_usb
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Start.My.Resources.Resources.full_world_background
        Me.ControlBox = False
        Me.Controls.Add(Me.suiteNumber)
        Me.Controls.Add(Me.waitLabel)
        Me.Controls.Add(Me.flagJobTitle)
        Me.Controls.Add(Me.flagEmail)
        Me.Controls.Add(Me.flagZipcode)
        Me.Controls.Add(Me.flagState)
        Me.Controls.Add(Me.flagCity)
        Me.Controls.Add(Me.flagCountry)
        Me.Controls.Add(Me.flagAddress)
        Me.Controls.Add(Me.flagLastName)
        Me.Controls.Add(Me.flagFirstName)
        Me.Controls.Add(Me.LabelRedFlag)
        Me.Controls.Add(Me.LabelGreenFlag)
        Me.Controls.Add(Me.LabelYellowFlag)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.flag2)
        Me.Controls.Add(Me.flag1)
        Me.Controls.Add(Me.RegisterButton)
        Me.Controls.Add(Me.AssociationBox)
        Me.Controls.Add(Me.inputJobTitle)
        Me.Controls.Add(Me.inputState)
        Me.Controls.Add(Me.inputCountry)
        Me.Controls.Add(Me.inputEmail)
        Me.Controls.Add(Me.inputZipcode)
        Me.Controls.Add(Me.inputCity)
        Me.Controls.Add(Me.inputAddress2)
        Me.Controls.Add(Me.inputAddress1)
        Me.Controls.Add(Me.inputLastName)
        Me.Controls.Add(Me.inputFirstName)
        Me.Controls.Add(Me.LabelJobTitle)
        Me.Controls.Add(Me.LabelEmail)
        Me.Controls.Add(Me.LabelZip)
        Me.Controls.Add(Me.LabelState)
        Me.Controls.Add(Me.LabelCountry)
        Me.Controls.Add(Me.LabelCity)
        Me.Controls.Add(Me.LabelAddress)
        Me.Controls.Add(Me.LabelLastName)
        Me.Controls.Add(Me.LabelFirstName)
        Me.Controls.Add(Me.pageHeader)
        Me.Controls.Add(Me.USBRegisterHelpButton)
        Me.Controls.Add(Me.PictureBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "register_usb"
        CType(Me.USBRegisterHelpButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AssociationBox.ResumeLayout(False)
        Me.AssociationBox.PerformLayout()
        CType(Me.flagAssociation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.flagFranchiseName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.flag1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.flag2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.flagFirstName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.flagLastName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.flagAddress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.flagCountry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.flagCity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.flagState, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.flagZipcode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.flagEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.flagJobTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RegisterusbBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pageHeader As System.Windows.Forms.Label
    Friend WithEvents USBRegisterHelpButton As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents LabelFirstName As System.Windows.Forms.Label
    Friend WithEvents LabelLastName As System.Windows.Forms.Label
    Friend WithEvents LabelAddress As System.Windows.Forms.Label
    Friend WithEvents LabelCity As System.Windows.Forms.Label
    Friend WithEvents LabelCountry As System.Windows.Forms.Label
    Friend WithEvents LabelState As System.Windows.Forms.Label
    Friend WithEvents LabelZip As System.Windows.Forms.Label
    Friend WithEvents LabelEmail As System.Windows.Forms.Label
    Friend WithEvents LabelJobTitle As System.Windows.Forms.Label
    Friend WithEvents LabelFranchiseName As System.Windows.Forms.Label
    Friend WithEvents inputFirstName As System.Windows.Forms.TextBox
    Friend WithEvents inputLastName As System.Windows.Forms.TextBox
    Friend WithEvents inputAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents inputAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents inputCity As System.Windows.Forms.TextBox
    Friend WithEvents inputZipcode As System.Windows.Forms.TextBox
    Friend WithEvents inputEmail As System.Windows.Forms.TextBox
    Friend WithEvents inputCountry As System.Windows.Forms.ComboBox
    Friend WithEvents inputState As System.Windows.Forms.ComboBox
    Friend WithEvents inputJobTitle As System.Windows.Forms.ComboBox
    Friend WithEvents inputFranchiseName As System.Windows.Forms.ComboBox
    Friend WithEvents inputCorporate As System.Windows.Forms.RadioButton
    Friend WithEvents inputFranchise As System.Windows.Forms.RadioButton
    Friend WithEvents AssociationBox As System.Windows.Forms.GroupBox
    Friend WithEvents RegisterButton As System.Windows.Forms.Button
    Friend WithEvents flag1 As System.Windows.Forms.PictureBox
    Friend WithEvents flag2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LabelYellowFlag As System.Windows.Forms.Label
    Friend WithEvents LabelGreenFlag As System.Windows.Forms.Label
    Friend WithEvents LabelRedFlag As System.Windows.Forms.Label
    Friend WithEvents flagAssociation As System.Windows.Forms.PictureBox
    Friend WithEvents flagFranchiseName As System.Windows.Forms.PictureBox
    Friend WithEvents flagFirstName As System.Windows.Forms.PictureBox
    Friend WithEvents flagLastName As System.Windows.Forms.PictureBox
    Friend WithEvents flagAddress As System.Windows.Forms.PictureBox
    Friend WithEvents flagCountry As System.Windows.Forms.PictureBox
    Friend WithEvents flagCity As System.Windows.Forms.PictureBox
    Friend WithEvents flagState As System.Windows.Forms.PictureBox
    Friend WithEvents flagZipcode As System.Windows.Forms.PictureBox
    Friend WithEvents flagEmail As System.Windows.Forms.PictureBox
    Friend WithEvents flagJobTitle As System.Windows.Forms.PictureBox
    Friend WithEvents waitLabel As System.Windows.Forms.Label
    Friend WithEvents RegisterusbBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents suiteNumber As System.Windows.Forms.Label
End Class
