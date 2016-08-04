REM #################################################################################################
REM #
REM # In-A-Flash™ is a trademark of Hampton Consulting, LLC, all rights reserved
REM # In-A-Flash™ programming is copyrighted 2010/11 by Michael Potratz, Urbandale, Iowa
REM #
REM # This program is not public domain and unauthorized use is strictly prohibited
REM #
REM #################################################################################################

Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading
Imports System.Security.Cryptography
' enables the "start" command for opening a file with it's associated program.
Imports System.Diagnostics
Imports System.Diagnostics.Process
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class form1

    Dim readThispromptNumber As New readINIFile
    Dim operationsIniFile As New iniFile(runningFrom & "\support\operations.ini")
    Dim parametersIniFile As New iniFile(runningFrom & "\support\parameters.ini")

    Dim Prompt81 = readThispromptNumber.getFormText("Prompt81")     ' can't run yet...
    Dim Value06 As String = ""

    ' These are the 4 threads which are used to populate the drop-down menus
    Dim doCheckDownload As Thread
    Dim doCheckDownloadDone As Boolean = False
    Dim doCheckConnectivity As Thread
    Dim doCheckConnectivityDone As Boolean = False
    Dim gotConnectivity As Boolean = False




    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' SetNewCurrentLanguage()
        CheckFormFlow()

        '#######################################################################################
        Dim updateSite As String = "http://" & SupportURL & "/"            ' SupportURL = URL of the support site
        ' MsgBox("updateSite = " & updateSite)

        quickConnectivityCheck()

        If gotConnectivity = True Then

            ' MsgBox("got connectivity. updateSite = " & updateSite)
            ' Start by updating the start.exe file
            If AutoUpdate.UpdateFiles(updateSite) Then
                Dispose()                                                                       ' release resources
                Dim Prompt15 = readThispromptNumber.getFormText("Prompt15")     ' need to restart
                MsgBox(Prompt15, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, Prompt01)
                End
                ' Application.Exit()                                  ' dump and restart
            End If

        End If

        '#######################################################################################
        ' set the copyright text on the screen
        copyrightText.Text = "Version : " & System.Windows.Forms.Application.ProductVersion

        ' check to see if the drive registered, has a S/N and the password has been changed
        getOperationalStatus()
        Me.Refresh()

        ' MsgBox("runningfrom : " & runningFrom)
        ' check to see if the software is running on the original USB drive.
        ' If modeOfOperation = "USB" Then
        checkDSN()
        ' End If

        '#######################################################################################
        ' if the software is running from a computer then there is no encrypted volume.  So, the target
        ' drive to read from and update to is the same.  This bit of code makes sure that
        ' future string construction comes out correctly.

        If modeOfOperation = "Server" Then
            Dim lastCharacter As String = Microsoft.VisualBasic.Right(runningFrom, 1)   ' get the last character
            If lastCharacter = "\" Then                                                 ' check for backslash
                targetDrive = runningFrom                                               ' if there, set variable
            Else
                targetDrive = runningFrom & "\"                                         ' if not, add backslash
            End If
        End If

        ' MsgBox(getDriveSerialNumber())

        '#######################################################################################
        '# The getOperationalstatus  routine check three things: 1) mode of operation set      #
        '# 2) has the software been registered and 3) has the password been changed            #
        '# Using those three things it set 5 different operationalStates to handle.  Depending #
        '# on the operationalState, run all, or a combination of routines before loading the   #
        '# main page.                                                                          #
        '#######################################################################################

        'MsgBox("Operational State : " & operationalState)
        'MsgBox(modeOfOperation)

        Select Case operationalState

            Case 1  ' Everything is done.  Just run the program.

                loadItUp()

            Case 2  ' the person has changed the password but they still need to register the software

                quickConnectivityCheck()
                'MsgBox("Connected? : " & gotConnectivity)
                If gotConnectivity = True Then
                    If modeOfOperation = "USB" Then
                        Dim registerForm As New register_usb()          ' set the USB registration form
                        registerForm.ShowDialog()                       ' show it to the user
                    Else

                        doComputerRegistration()

                        'Dim registerForm As New register_restaurant()   ' set the restaurant registration form
                        'registerForm.ShowDialog()                       ' show it to the user

                    End If
                Else
                    Dim Prompt13 = readThispromptNumber.getFormText("Prompt13") ' can't register part 1
                    Dim Prompt14 = readThispromptNumber.getFormText("Prompt14") ' can't register part 2
                    Dim Prompt19 = readThispromptNumber.getFormText("Prompt19") ' can't register part 2
                    Dim showthis As String = Prompt13 & vbCrLf & vbCrLf & Prompt19 & vbCrLf & vbCrLf & Prompt14
                    MsgBox(showthis, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, Prompt01)

                    ' if they don't have connectivity to register, then exit the program
                    End
                End If

                loadItUp()

            Case 3  ' the person needs to set the password (usb only) and register the drive

                If modeOfOperation = "USB" Then

                    ' Check to see if Truecrypt is installed on the system.
                    checkForTrueCryptInstallation()

                    ' if TC is installed then have them change the password
                    Dim changePassword As New changeTCPassword()
                    changePassword.ShowDialog()

                    ' see if the person has actually changed the password or not.
                    ' if not then prompt and exit without allowing the person to register the drive.
                    Value06 = operationsIniFile.GetString("Operations", "Value06", "(none)")        ' pw changed?
                    If Value06 <> "Yes" Then
                        MsgBox(Prompt81, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, Prompt01)      ' prompt the user
                        End                                                                         ' end the program
                    End If

                    quickConnectivityCheck()
                    ' MsgBox("Connected? : " & gotConnectivity)
                    If gotConnectivity = True Then
                        ' show the USB registration screen
                        Dim registerUSB As New register_usb()
                        registerUSB.ShowDialog()
                    Else
                        Dim Prompt13 = readThispromptNumber.getFormText("Prompt13") ' can't register part 1
                        Dim Prompt14 = readThispromptNumber.getFormText("Prompt14") ' can't register part 2
                        Dim Prompt19 = readThispromptNumber.getFormText("Prompt19") ' can't register part 2
                        Dim showthis As String = Prompt13 & vbCrLf & vbCrLf & Prompt19 & vbCrLf & vbCrLf & Prompt14
                        MsgBox(showthis, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, Prompt01)

                        ' if they don't have connectivity to register, then exit the program
                        End
                    End If


                Else

                    doComputerRegistration()

                    ' if running from a restaurant server then just show them the 
                    ' restaurant registration form
                    'Dim registerForm As New register_restaurant()
                    'registerForm.ShowDialog()



                End If

                ' if they've gotten this far, then they're ready to fire things up.
                loadItUp()

            Case 4  ' software is registered but the password has not been changed yet.

                ' Check to see if Truecrypt is installed on the system.
                If modeOfOperation = "USB" Then

                    checkForTrueCryptInstallation()

                    Dim changePassword As New changeTCPassword()
                    changePassword.ShowDialog()

                    ' when done, let's see where we stand to fire things up...
                    ' only allow the person to access the information after they have changed the
                    ' original password on the drive.
                    '
                    ' This does not apply to Server Operation....Server operation writes "Yes" to
                    ' Value06 indicating the the PW has been taken care of

                    Dim Prompt81 = readThispromptNumber.getFormText("Prompt81")                     ' can't run yet...
                    Dim Value06 = operationsIniFile.GetString("Operations", "Value06", "(none)")    ' pw changed?

                    If Value06 = "Yes" Then
                        loadItUp()
                    Else
                        MsgBox(Prompt81, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, Prompt01)      ' prompt the user
                        End                                                                         ' end the program
                    End If

                Else

                    ' if running on a server then we don't need to change the password
                    ' just run the system.
                    loadItUp()

                End If

        End Select

    End Sub

    '####################################################################################
    '####################################################################################
    '# This is the main surbroutine that sets the operating mode and draws the panel    #
    '# on the screen.                                                                   #
    '####################################################################################
    Public Sub loadItUp()

        ' CheckFormFlow() ' check for right-to-left or left-to-right setting

        Me.Text = Prompt01
        Me.Visible = True

        If modeOfOperation = "USB" Then

            ' Check to see if Truecrypt is installed on the system.
            checkForTrueCryptInstallation()
            ' just in case the encrypted volume got let open for some reason, let's try
            ' and disconnect any encrypted volumes which might still be hanging on!
            disconnectTC()

            ' Get the users password and try and log into the drive
            Dim getUserPassword As New login()
            getUserPassword.ShowDialog()

        End If

        ' see if we can connect to the support site.  If we can, then check for updates
        ' at the same time
        doCheckConnectivity = New Thread(AddressOf Me.IsConnectionAvailable)
        doCheckConnectivity.Start()

        ' now show the exit button
        ExitButton.Visible = True
        MainPagehelpButton.Visible = True
        downloadArrow.Visible = True

        'Load the page first before showing it
        opsManualLabel.Text = Prompt05
        SetToolTips()
        opsManualLabel.Visible = True
        OpsManualPicture.Visible = True
        driveVersion.Visible = True
        copyrightText.Visible = True


        'Display the encryption and operating mode in the top left side of the window
        If modeOfOperation = "USB" Then
            MainPrompt.Text = MainPrompt.Text & vbCrLf & Prompt16
        Else
            MainPrompt.Text = Prompt03 & vbCrLf & Prompt17
        End If
        MainPrompt.Visible = True

        ' Show the version, language and serial number on the screen
        showDriveInformation()

        ' If Truecrypt is not installed, then first let's check to see if we can figure
        ' out if it's a BK machine or not.  Start with the basic BK nomenclature.
        ' Computer Names (CN) are in the parameters.ini > [Compatibility] section

        ' set up some dummy variables to throw stuff in
        Dim i As Integer
        Dim cnt As Integer
        Dim s As String
        Dim tempCN As String

        ' Get the total number of possible BK computer names
        Dim CN_Total = parametersIniFile.GetString("Compatibility", "CN_Total", "(none)")

        ' the INI file contains a string, we need to convert it to an inteter so the for/next
        ' loop will run properly
        cnt = CInt(CN_Total)

        For i = 1 To cnt
            ' need to convert i to a string to tack it onto the INI variable to read
            s = Convert.ToString(i)
            ' tack it together to get the final INI variable
            tempCN = "CN-" & s
            tempCN = parametersIniFile.GetString("Compatibility", tempCN, "(none)")
            IsBK = (thisComputerName Like tempCN)
            ' if we find a match then dump out of the for/next loop as we don't
            ' need to check anymore names.
            If IsBK = True Then
                MainPrompt.Text = MainPrompt.Text & vbCrLf & Prompt30     ' add Corporate
                Exit For
            End If

        Next

        If IsBK = False Then
            MainPrompt.Text = MainPrompt.Text & vbCrLf & Prompt31         ' add Franchise
        End If

    End Sub

    '####################################################################################
    '####################################################################################
    '# Check to see if TrueCrypt is installed on the computer.  Check for both a 32 or  #
    '# 64-bit version.                                                                  #
    '####################################################################################

    Public Sub checkForTrueCryptInstallation()

        If the32bitProgramFiles <> "\" And the32bitProgramFiles <> "" Then  ' if this is a 32-bit system.....
            truecrypt32Folder = the32bitProgramFiles & realTruecryptFolder  ' create the TC folder structure...
            does32Exist = IO.File.Exists(truecrypt32Folder)                 ' set does32Exist to TRUE
            MainPrompt.Text = Prompt02                                      ' Encryption installed
        End If

        If the64bitProgramFiles <> "\" And the64bitProgramFiles <> "" Then  ' if this is a 64-bit system...
            truecrypt64Folder = the64bitProgramFiles & realTruecryptFolder  ' create the TC folder structure...
            does64Exist = IO.File.Exists(truecrypt64Folder)                 ' set does64Exist to TRUE
            MainPrompt.Text = Prompt02                                      ' Encryption installed
        End If

        If does32Exist = False And does64Exist = False Then
            MainPrompt.Text = Prompt03                                      ' Encryption not installed

            '-----------------------------------------------------------------------------------------
            ' If the user has admin rights on the computer they are running this on, they can either
            ' run the program from the USB drive or install TrueCrypt and proceed from there.  If they
            ' do not have admin rights, then they will have to have their IT administrator run this
            ' program the first time to install TC.
            '-----------------------------------------------------------------------------------------
            If adminUser = True Then
                Dim doTC As New installTC()                                 ' target the install form
                doTC.ShowDialog()                                           ' open up the TC installation form
            Else
                ' if the user is not admin and TC is not installed the person cannot go any
                ' further.  Prompt to get IT for installation and end the program.
                Dim Prompt69 = readThispromptNumber.getFormText("Prompt69")
                Dim Prompt96 = readThispromptNumber.getFormText("Prompt96")
                Dim Prompt111 = readThispromptNumber.getFormText("Prompt111")
                Dim showThis = Prompt69 & vbCrLf & vbCr & Prompt96 & vbCrLf & vbCrLf & Prompt111

                MsgBox(showThis, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, Prompt01)
                End
            End If

        End If

        ' MsgBox("does32exist=" & does32Exist & vbCrLf & "does64exist=" & does64Exist)

    End Sub

    ' ###################################################################################
    ' ###################################################################################
    ' # View either the operations manual or the RightTRACK manual                      #
    ' ###################################################################################

    ' select the Operations Manual
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpsManualPicture.Click

        ' on Form2, the code reads this text label and inserts it into the directory structure
        ' string which then opens up the correct flipbook.
        Form2.whichMovie.Text = "operations_manual"
        showFlipBook()

    End Sub

    ' once the manual has been selected, then open the form to show the manual
    Private Sub showFlipBook()

        If opsManualOpen = "False" Then
            opsManualOpen = "True"
            ' Form2.Enabled = True
            Form2.Show()
        Else
            ' Form2.Enabled = True
            Form2.Visible = True
        End If

    End Sub

    '####################################################################################
    '####################################################################################
    '# If the person clicks the X in the top right of window to close it out, or click  #
    '# on the exit button, then run the disconnect subroutine                           #
    '####################################################################################

    ' the exit button on the screen
    Private Sub ExitButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click

        disconnectTC()
        'killProcess("TrueCrypt")
        End

    End Sub

    ' just close out the form with the "X" on the top right corner of the form
    Private Sub form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        disconnectTC()
        'killProcess("TrueCrypt")
        End

    End Sub

    ' dismount the encrypted volume and then exit from the program
    Public Sub disconnectTC()

        Dim TCUnload = parametersIniFile.GetString("DriveInfo", "TCUnload", "")

        ' If the software is running from the USB drive we need to close out the encrypted
        ' volume before we close the program.  If this running on a computer with no 
        ' encryption then just close it out.

        If modeOfOperation = "USB" Then

            ' see explaination of these parameters in the parameters.ini file.  The parameters have been
            ' moved to the parameters.ini file for ease of changing in case there is an issue.
            Dim dismountParameters As String = " " & TCUnload

            Dim p As New ProcessStartInfo

            If does32Exist Then
                p.FileName = truecrypt32Folder ' 32-bit TC location
            Else
                p.FileName = truecrypt64Folder ' 64-bit TC location
            End If

            p.Arguments = dismountParameters
            p.WindowStyle = ProcessWindowStyle.Hidden

            ' MsgBox("||" & p.FileName.ToString() & p.Arguments.ToString() & "||")

            Try
                Dim myProcess = Process.Start(p)
                'Sleep(2000)
                'MsgBox(myProcess.ExitCode.ToString())
            Catch ex As Exception
                Dim errorMessage As String = Prompt62 & " " & ex.ToString()
                MsgBox(errorMessage, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, Prompt01)
            End Try

        End If

        ' killProcess("TrueCrypt")    ' kill any TrueCrypt processes running after all dismounts are done

    End Sub

    '####################################################################################
    '####################################################################################
    '# Get the drive version, language and serial number from the ini files and then    #
    '# display it on the bottom right side of the screen                                #
    '####################################################################################

    Private Sub showDriveInformation()

        'Read the version.ini file and display the contents

        Dim Prompt33 = readThispromptNumber.getFormText("Prompt33")                     ' Version
        Dim Prompt34 = readThispromptNumber.getFormText("Prompt34")                     ' Language
        Dim Prompt35 = readThispromptNumber.getFormText("Prompt35")                     ' Serial Number

        Dim Version = parametersIniFile.GetString("DriveInfo", "Version", "(none)")     ' information YY.MM
        Dim Language = parametersIniFile.GetString("DriveInfo", "Language", "(none)")   ' language code letters

        ' generated serial number

        Dim handleEncryption As New encryption      ' setup the class
        Dim SerialNumber = handleEncryption.Decrypt(operationsIniFile.GetString("SerialNumber", "SerialNumber", "(none)"), EncryptionKey)
        SerialNumber = Microsoft.VisualBasic.Left(SerialNumber, 16)

        ' put it all together and show it on the screen
        driveVersion.Text = "|| " & Prompt33 & " : " & Version & " || " & Prompt34 & " : " & Language & " || " & Prompt35 & " : " & SerialNumber & " ||"
        driveVersion.Visible = True

    End Sub

    '####################################################################################
    '####################################################################################
    '# Form3 is the generic web display form for the application.  Set the parameters   #
    '# and then call the form.                                                          #
    '####################################################################################

    Private Sub HelpButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainPagehelpButton.Click

        Form3.updateURL.Text = "http://" & SupportURL  ' SupportURL is the URL for the support site
        Form3.urlType.Text = "Support"  ' Form3 uses this to change the heading prompt

        Me.TopMost = False
        Form3.Enabled = True
        Form3.Show()

    End Sub

    '####################################################################################
    '####################################################################################
    '# this subroutine also calls Form3.  But first gathers all the information and     #
    '# creates the URL along with the $_GET data so the web site can process it         #
    '# correctly                                                                        #
    '####################################################################################

    Private Sub downloadArrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles downloadArrow.Click

        Dim updateForm As New update
        updateForm.ShowDialog()

    End Sub


    '####################################################################################
    '####################################################################################
    '# Create the tool tips for the different items on the screen                       #
    '####################################################################################

    Private Sub SetToolTips()

        ' get prompts to display on the screen
        Dim Prompt21 = readThispromptNumber.getFormText("Prompt21") ' exit this program
        Dim Prompt22 = readThispromptNumber.getFormText("Prompt22") ' view ops manual
        Dim Prompt23 = readThispromptNumber.getFormText("Prompt23") ' view RTT manual
        Dim Prompt24 = readThispromptNumber.getFormText("Prompt24") ' update materials
        Dim Prompt25 = readThispromptNumber.getFormText("Prompt25") ' goto help web site
        Dim Prompt26 = readThispromptNumber.getFormText("Prompt26") ' hint...
        Dim Prompt27 = readThispromptNumber.getFormText("Prompt27") ' Program information
        Dim Prompt28 = readThispromptNumber.getFormText("Prompt28") ' Program status

        Dim apdelay As Integer = 6000
        Dim delay As Integer = 100

        Dim TT_basic As New ToolTip()
        TT_basic.AutoPopDelay = apdelay
        TT_basic.InitialDelay = delay
        TT_basic.ReshowDelay = delay
        TT_basic.ShowAlways = True
        TT_basic.IsBalloon = True
        TT_basic.BackColor = Color.LightBlue
        TT_basic.ForeColor = Color.DarkBlue
        TT_basic.ToolTipIcon = ToolTipIcon.Info
        TT_basic.ToolTipTitle = Prompt26
        TT_basic.UseAnimation = True
        TT_basic.UseFading = True

        TT_basic.SetToolTip(Me.ExitButton, SplitToolTip(Prompt21))
        TT_basic.SetToolTip(Me.OpsManualPicture, SplitToolTip(Prompt22))
        TT_basic.SetToolTip(Me.MainPagehelpButton, SplitToolTip(Prompt25))
        TT_basic.SetToolTip(Me.driveVersion, SplitToolTip(Prompt27))
        TT_basic.SetToolTip(Me.MainPrompt, SplitToolTip(Prompt28))
        TT_basic.SetToolTip(Me.downloadArrow, SplitToolTip(Prompt24))

    End Sub

    Function SplitToolTip(ByVal strOrig As String) As String

        Dim strArray As String()
        Dim SPACE As String = " "
        Dim CR As String = vbCrLf
        Dim strOneWord As String
        Dim strBuilder As String
        Dim strReturn As String

        strArray = strOrig.Split(SPACE)

        For Each strOneWord In strArray
            strBuilder = strBuilder & strOneWord & SPACE
            If Len(strBuilder) > 70 Then
                strReturn = strReturn & strBuilder & CR
                strBuilder = ""
            End If
        Next

        If Len(strBuilder) < 8 Then strReturn = strReturn.Substring(0, _
                                                    strReturn.Length - 2)

        Return strReturn & strBuilder

    End Function

    '####################################################################################
    '####################################################################################
    '# A simple pause method.  Used when changing password                              #
    '####################################################################################
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

    '####################################################################################
    '####################################################################################
    '# Reach out to Google and see if you get a response.  If so, enable the help and   #
    '# download buttons.                                                                #
    '####################################################################################

    Private Sub IsConnectionAvailable()

        ' Returns True if connection is available
        ' Replace www.yoursite.com with a site that
        ' is guaranteed to be online - perhaps your
        ' corporate site, or microsoft.com

        Dim objUrl As New System.Uri(UpdateURL)   ' Look for the update site
        Dim success As Boolean = False          ' let's start out with a not connected state

        ' Setup WebRequest
        Dim objWebReq As System.Net.WebRequest
        objWebReq = System.Net.WebRequest.Create(objUrl)
        Dim objResp As System.Net.WebResponse

        Try                                     ' Attempt to get response and return True
            objResp = objWebReq.GetResponse     ' reach out to the web site
            objResp.Close()                     ' close the connection
            objWebReq = Nothing
            success = True
        Catch ex As Exception                   ' Error, exit and return False
            success = False
        End Try

        If success = True Then
            MainPagehelpButton.Enabled = True                   ' enable the help button
            MainPagehelpButton.Image = My.Resources.help1       ' show the enabled button image
            downloadArrow.Image = My.Resources.download         ' show the enabled download arrow image

            doCheckDownload = New Thread(AddressOf Me.checkForUpdates)
            doCheckDownload.Start()

        Else
            MainPagehelpButton.Enabled = False          ' disable the help button
            downloadArrow.Enabled = False       ' disable the download button
        End If

        ' MsgBox("exiting the connectivity check")

        ' close down the thread
        doCheckConnectivity.Abort()

    End Sub

    Private Sub quickConnectivityCheck()

        Dim objUrl As New System.Uri(UpdateURL)   ' Look for the update site
        ' MsgBox("UpdateURL : " & UpdateURL)

        ' Setup WebRequest
        Dim objWebReq As System.Net.WebRequest
        objWebReq = System.Net.WebRequest.Create(objUrl)
        Dim objResp As System.Net.WebResponse

        Try                                     ' Attempt to get response and return True
            objResp = objWebReq.GetResponse     ' reach out to the web site
            objResp.Close()                     ' close the connection
            objWebReq = Nothing
            gotConnectivity = True
        Catch ex As Exception                   ' Error, exit and return False
            gotConnectivity = False
        End Try

    End Sub

    Private Sub checkForUpdates()

        ' get the version and the language code
        Dim Version = parametersIniFile.GetString("DriveInfo", "Version", "(none)")
        Dim Language = parametersIniFile.GetString("DriveInfo", "Language", "(none)")

        Dim handleEncryption As New encryption
        ' get the serial number of the installation
        Dim SerialNumber = handleEncryption.Decrypt(operationsIniFile.GetString("SerialNumber", "SerialNumber", "(none)"), EncryptionKey)
        Dim ConfCode = handleEncryption.Decrypt(operationsIniFile.GetString("SerialNumber", "ConfirmationCode", "(none)"), EncryptionKey)

        ' put it all together to pass to the register web page
        Dim passToRegister = "?queryType=checkForUpdates" & _
                             "&version=" & Version & _
                             "&language=" & Language & _
                             "&serialNumber=" & SerialNumber & _
                             "&ConfCode=" & ConfCode

        ' MsgBox("checkForUpdates : " & passToRegister)
        ' put together the complete address
        Dim checkForUpdates As String = ProgramDataURL & passToRegister
        ' MsgBox(checkForUpdates)
        Dim request As WebRequest = WebRequest.Create(checkForUpdates)
        Dim response As WebResponse = request.GetResponse()
        Dim reader As StreamReader = New StreamReader(response.GetResponseStream())
        Dim str As String = reader.ReadToEnd()

        ' MsgBox(str)
        ' End

        Select Case CInt(str)
            Case 0
                downloadArrow.Enabled = False
                downloadArrow.Image = My.Resources.no_download1
            Case 1
                downloadArrow.Image = My.Resources._1download
                downloadArrow.Enabled = True
            Case 2
                downloadArrow.Image = My.Resources._2download
                downloadArrow.Enabled = True
            Case 3
                downloadArrow.Image = My.Resources._3download
                downloadArrow.Enabled = True
            Case 4
                downloadArrow.Image = My.Resources._4download
                downloadArrow.Enabled = True
            Case 5
                downloadArrow.Image = My.Resources._5download
                downloadArrow.Enabled = True
            Case 6
                downloadArrow.Image = My.Resources._6download
                downloadArrow.Enabled = True
            Case 7
                downloadArrow.Image = My.Resources._7download
                downloadArrow.Enabled = True
            Case 8
                downloadArrow.Image = My.Resources._8download
                downloadArrow.Enabled = True
            Case 9
                downloadArrow.Image = My.Resources._9download
                downloadArrow.Enabled = True
            Case 10
                downloadArrow.Image = My.Resources.manydownload
                downloadArrow.Enabled = True
            Case 1000000001
                ' MsgBox("Update Check Result: User is disabled")
                downloadArrow.Enabled = False
                downloadArrow.Image = My.Resources.no_download1
                KillDrive()
                MsgBox("!!!! Unauthorized User !!!!", MsgBoxStyle.OkOnly, "UNAUTHORIZED USE")
                End

        End Select

        doCheckDownload.Abort()

    End Sub

    '####################################################################################
    '####################################################################################
    '# This subroutine will flip the form RTL or LTR depending upon the RTL entry in    #
    '# the parameters.ini file                                                          #
    '####################################################################################

    Private Sub CheckFormFlow()
        If RTLsetting = "Yes" Then
            Me.RightToLeftLayout = True
            Me.RightToLeft = Windows.Forms.RightToLeft.Yes
            ' Me.MainPrompt.RightToLeft = Windows.Forms.RightToLeft.Yes
            Me.TableLayoutPanel1.RightToLeft = Windows.Forms.RightToLeft.Yes
            Me.TableLayoutPanel2.RightToLeft = Windows.Forms.RightToLeft.Yes


        End If
    End Sub

    Public Sub SetNewCurrentLanguage()

        Dim myDefaultLanguage As InputLanguage = InputLanguage.DefaultInputLanguage
        Dim myCurrentLanguage As InputLanguage = InputLanguage.CurrentInputLanguage
        Dim langTest As String = ""
        langTest = "Current input language is: " & myCurrentLanguage.Culture.EnglishName & ControlChars.Cr
        langTest &= "Default input language is: " & myDefaultLanguage.Culture.EnglishName & ControlChars.Cr

        Dim lang As InputLanguage
        For Each lang In InputLanguage.InstalledInputLanguages
            langTest &= lang.Culture.EnglishName & ControlChars.Cr
        Next lang

        MsgBox(langTest)

    End Sub 'SetNewCurrentLanguage

    Private Sub checkDSN()

        Dim doEncryption As New encryption
        Dim currentSN As String = getDriveSerialNumber().ToString
        Dim registeredSN As String

        registeredSN = doEncryption.Decrypt(operationsIniFile.GetString("Operations", "Value98", ""), EncryptionKey)

        If currentSN.Equals(registeredSN) Then
            ' do nothing
        Else
            Dim Prompt116 = readThispromptNumber.getFormText("Prompt116")
            Dim Prompt118 = readThispromptNumber.getFormText("Prompt118")
            KillDrive()
            MsgBox(Prompt118 & vbCrLf & vbCrLf & Prompt116, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, Prompt01)
            End
        End If

    End Sub

    Private Sub doComputerRegistration()

        Dim selectForm As New typeOfRegistration()
        selectForm.ShowDialog()

        'Dim prompt As String = "Is this software being used on a restaurant back-of-house (BOH) computer? (Not your individual desktop or laptop)"
        'prompt += vbCrLf & vbCrLf & "If so, click the Yes button.  If not, click the No button."
        'Dim title As String = "Computer Registration"

        'Dim result = MessageBox.Show(prompt, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If (registrationType = "individual") Then
            Dim registerForm As New register_usb()          ' set the USB registration form
            registerForm.ShowDialog()
        End If

        If (registrationType = "restaurant") Then
            Dim registerForm As New register_restaurant()   ' set the restaurant registration form
            registerForm.ShowDialog()
        End If

    End Sub


End Class

