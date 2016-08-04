REM #################################################################################################
REM #
REM # In-A-Flash™ is a trademark of Hampton Consulting, LLC, all rights reserved
REM # In-A-Flash™ programming is copyrighted 2010 by Michael Potratz, Urbandale, Iowa
REM #
REM # This program is not public domain and unauthorized use is strictly prohibited
REM #
REM #################################################################################################

Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Threading
' enables the "start" command for opening a file with it's associated program.
Imports System.Diagnostics
Imports System.Diagnostics.Process
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Resources
Imports System.Globalization

Public Class login

    Dim hasLoggedIn As Boolean = False  ' are we there or not?
    Dim startedThread As Boolean = False

    ' this variable is used to count the number of incorrect login attempts that have
    ' been made during this session.
    Dim incorrectTries As Integer = 0


    Dim readThispromptNumber As New readINIFile
    Dim operationsIniFile As New iniFile(runningFrom & "\support\operations.ini")
    Dim parametersIniFile As New iniFile(runningFrom & "\support\parameters.ini")

    ' get the serial number and conf code in case the person needs their password
    ' emailed back to them
    Dim handleEncryption As New encryption      ' setup the class
    Dim SerialNumber = handleEncryption.Decrypt(operationsIniFile.GetString("SerialNumber", "SerialNumber", "(none)"), EncryptionKey)
    Dim ConfCode = handleEncryption.Decrypt(operationsIniFile.GetString("SerialNumber", "ConfirmationCode", "(none)"), EncryptionKey)

    ' get the language from the drive for the return email
    Dim Language = parametersIniFile.GetString("DriveInfo", "Language", "(none)")       ' Language code
    Dim TCLoad = parametersIniFile.GetString("DriveInfo", "TCLoad", "")                 ' TC parameters
    Dim LoginDelay = parametersIniFile.GetString("DriveInfo", "Delay", "100")           ' login delay to test for success

    ' get the various prompts for the screen
    Dim Prompt21 = readThispromptNumber.getFormText("Prompt21")         'exit this program
    Dim Prompt38 = readThispromptNumber.getFormText("Prompt38")         'please wait
    Dim Prompt56 = readThispromptNumber.getFormText("Prompt56")         'OK
    Dim Prompt84 = readThispromptNumber.getFormText("Prompt84")         'forgot password
    Dim Prompt85 = readThispromptNumber.getFormText("Prompt85")         'email passwork
    Dim Prompt86 = readThispromptNumber.getFormText("Prompt86")         'no network
    Dim Prompt87 = readThispromptNumber.getFormText("Prompt87")         'PW email success part 1
    Dim Prompt88 = readThispromptNumber.getFormText("Prompt88")         'PW email success part 2
    Dim Prompt89 = readThispromptNumber.getFormText("Prompt89")         'PW email failure part 1
    Dim Prompt90 = readThispromptNumber.getFormText("Prompt90")         'PW email failure part 2
    Dim Prompt91 = readThispromptNumber.getFormText("Prompt91")         'Exit
    Dim Prompt93 = readThispromptNumber.getFormText("Prompt93")         'Incorrect Password
    Dim Prompt116 = readThispromptNumber.getFormText("Prompt116")       'Incorrect Password
    Dim Prompt117 = readThispromptNumber.getFormText("Prompt117")       'Incorrect Password

    ' setup the defaults for handling the new password
    Dim EnteredPassWord As String = ""
    Dim EnteredPasswordLength As Integer = 0

    ' setup the thread to check internet connectivity
    Dim doCheckConnectivity As Thread
    Dim doCheckConnectivityDone As Boolean = False

    ' do the login with TC
    Dim doLogin As Thread
    Dim doLoginDone As Boolean = False

    Dim emailSuccess As String = Prompt87 & vbCrLf & vbCr & Prompt88  'email success!
    Dim emailFailure As String = Prompt89 & vbCrLf & vbCr & Prompt90  'email failure!

    ' Dim resourceMgr


    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CheckFormFlow()

        Me.Text = Prompt01                      'Standard BK form title
        pwHeader.Text = Prompt04                'Enter your password
        submitPasswordButton.Text = Prompt56    'OK
        forgotPasswordButton.Text = Prompt86    'no network connection
        GroupBox1.Text = Prompt84               'forgotten password
        exitButton.Text = Prompt91              'exit

        killProcess("TrueCrypt")            ' start by shutting down any TC process already running

        ' see if we can connect to the support site.  If we can, then check for updates
        ' at the same time
        doCheckConnectivity = New Thread(AddressOf Me.IsConnectionAvailable)
        doCheckConnectivity.Start()

    End Sub

    '####################################################################################
    '####################################################################################
    '# Monitor the password input field and watch the number of characters which have   #
    '# been entered.  Enable/Disable the OK button as appropriate                       #
    '####################################################################################
    Private Sub passWord_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles passWord.TextChanged

        EnteredPassWord = passWord.Text.ToString()              ' retrieve the users input
        EnteredPasswordLength = EnteredPassWord.Length          ' check the length

        If EnteredPasswordLength >= minimumPasswordLength Then  ' if there are at least 4 characters in the box
            submitPasswordButton.BackColor = Color.Green        ' turn the background green
            submitPasswordButton.Enabled = True                 ' enable the button
        Else
            submitPasswordButton.Enabled = False                ' disable the button to prevent clicking
            submitPasswordButton.BackColor = Color.Gainsboro    ' put it back to the gray color
        End If

    End Sub

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

        Dim objUrl As New System.Uri(UpdateURL)             ' Look for the update site
        Dim success As Boolean = False                      ' let's start out with a not connected state

        ' Setup WebRequest
        Dim objWebReq As System.Net.WebRequest
        objWebReq = System.Net.WebRequest.Create(objUrl)
        Dim objResp As System.Net.WebResponse

        Try                                                 ' Attempt to get response and return True
            objResp = objWebReq.GetResponse                 ' reach out to the web site
            objResp.Close()                                 ' close the connection
            objWebReq = Nothing
            success = True
        Catch ex As Exception                               ' Error, exit and return False
            success = False
        End Try

        If success = True Then
            forgotPasswordButton.Enabled = True             ' enable forgot password button
            forgotPasswordButton.Text = Prompt85            ' email password
            statusPicture.Image = My.Resources.flag_green   ' green flag visual clue
            GroupBox1.Enabled = True                        ' enable the send email box

        Else
            forgotPasswordButton.Enabled = False            ' disable forgot password button
            forgotPasswordButton.Text = Prompt86            ' no internet connection
            statusPicture.Image = My.Resources.flag_red     ' red flag visual clue

        End If

        ' MsgBox("exiting the connectivity check")

        ' close down the thread
        doCheckConnectivity.Abort()

    End Sub

    '####################################################################################
    '####################################################################################
    '# If the user has forgotten their password then give them an opportunity to have   #
    '# it sent to the email address the drive is registered to.                         #
    '####################################################################################

    Private Sub forgotPasswordButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles forgotPasswordButton.Click

        Me.Cursor = Cursors.WaitCursor

        ' check to see if the prompt is "exit this program".  This gets set below so
        ' I need to check at the beginning verses the end of this routine.  If it is
        ' exit this program, then close this window and let the further processing
        ' continue

        If forgotPasswordButton.Text = Prompt21 Then

            End

        End If

        ' if the person click "email my password" then construct the string and send to the support
        ' site for a response.  The S/N & Conf Code are used to retrieve the email and then send the
        ' password for that combination to the email on the registration.  If it doesn't match the
        ' database then don't go any further

        If forgotPasswordButton.Text = Prompt85 Then

            ' put it all together to pass resend password
            Dim passToEmail = "?queryType=resendPassword" & _
                              "&serialNumber=" & SerialNumber & _
                              "&ConfCode=" & ConfCode & _
                              "&language=" & Language

            ' MsgBox(passToRegister)
            ' put together the complete address
            Dim checkForEmail As String = ProgramDataURL & passToEmail
            'MsgBox(checkForUpdates)
            Dim request As WebRequest = WebRequest.Create(checkForEmail)
            Dim response As WebResponse = request.GetResponse()
            Dim reader As StreamReader = New StreamReader(response.GetResponseStream())
            Dim str As String = reader.ReadToEnd()
            Dim strInt As Integer = CInt(str)
            'MsgBox(strInt)
            'End

            emailPrompt.BringToFront()                          'bring the prompt to the front
            GroupBox1.Text = ""                                 'clear out the group title
            forgotPasswordButton.Text = Prompt21                'change the prompt
            emailPrompt.Visible = True                          'show the prompt
            forgotPasswordButton.ForeColor = Color.White        'make the font white

            If strInt = 1 Then

                ' put success prompts and actions here

                emailPrompt.Text = emailSuccess                 'email success!
                emailPrompt.BackColor = Color.Green             'turn the background green
                forgotPasswordButton.BackColor = Color.Green    'make the button green
                statusPicture.Image = My.Resources.flag_green   'put the red flag up


            Else

                ' put failure prompts and actions here
                emailPrompt.Text = emailFailure                 'email failure
                emailPrompt.BackColor = Color.Red               'turn the background red
                forgotPasswordButton.BackColor = Color.Red      'make the button red
                statusPicture.Image = My.Resources.flag_red     'put the red flag up

            End If

        Else

        End If

        Me.Cursor = Cursors.Default

    End Sub

    '####################################################################################
    '####################################################################################
    '# If they click the exit button then shut the whole program down                   #
    '####################################################################################

    Private Sub exitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitButton.Click

        form1.disconnectTC()    ' disconnect all TC volumes
        End                     ' exit the program

    End Sub

    '####################################################################################
    '####################################################################################
    '# Handle the password entry for the program.                                       #
    '####################################################################################

    Private Sub submitPasswordButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submitPasswordButton.Click

        Dim i As Integer                    ' used for outside loop in drive discover
        Dim j As Integer                    ' used for inside loop for drive discover
        Dim tempPage                        ' temp filename to use to look for

        userPassword = Trim(passWord.Text.ToString())           'userPassword is used by TC to open the volume

        ' MsgBox(userPassword)

        doLogin = New Thread(AddressOf Me.loginToVolume)
        doLogin.Start()

        ' create an array of letters A through Z
        Dim characterListing As New ArrayList()
        For i = 0 To 26
            characterListing.Add(Convert.ToChar(i + 97))
        Next

        Do Until startedThread = True
            Sleep(100)
        Loop

        ' MsgBox("Started Thread in submitPassword : " & startedThread)

        ' MsgBox("Has logged in : " & hasLoggedIn)

        ' not knowing how long it will take the system to mount the drive, keep looping through
        ' the letters until we find the available.ini inside the encrypted volume
        For i = 1 To 15
            Sleep(LoginDelay)
            For j = 0 To 25
                tempPage = characterListing.Item(j) & ":\available.ini"
                frontPageExists = IO.File.Exists(tempPage)      ' look for the file...
                If frontPageExists = True Then                  ' tada - we found it!
                    targetDrive = characterListing.Item(j)      ' set the variable to the character
                    targetDrive = targetDrive & ":\"            ' add the stuff to the end of the letter
                    hasLoggedIn = True                          ' we've successfully logged in
                    ' MsgBox("Login form, line 290 : " & frontPageExists & vbCrLf & "targetdrive : " & targetDrive)
                    Me.Close()                                  ' everything is fine, close this window!
                End If
            Next
        Next
        ' Next

        ' MsgBox("Has logged in Line 311 : " & hasLoggedIn)

        ' if the user gave the wrong password, TC will have another prompt up under the window where the
        ' user cannot see it.  If we're still sitting there after 10 seconds then kill TC to get rid of
        ' the prompt, show the wrong password alert on the screen and let the person try it again.

        If hasLoggedIn = False Then

            killProcess("TrueCrypt")
            incorrectTries = incorrectTries + 1                     ' bump up the got it wrong number
            ' MsgBox("That's " & incorrectTries)
            If incorrectTries = 5 Then
                KillDrive()
                MsgBox(Prompt117 & vbCrLf & vbCrLf & Prompt116, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, Prompt01)
                End
            End If
            ' kill the TC login process
            pwHeader.Text = Prompt93                                ' show INCORRECT PASSWORD
            passWord.Text = ""                                      ' clear out whatever was entered
            passWord.BackColor = Color.Red                          ' make it red - get their attention
            passWord.Focus()                                        ' put the cursor in the input box again

        End If

    End Sub

    '####################################################################################
    '####################################################################################
    '# Attempt to login to the encrypted volume                                         #
    '####################################################################################

    Private Sub loginToVolume()

        'MsgBox("starting login thread")

        Dim p As New ProcessStartInfo                           ' the login process

        Dim openCommmandParameters As String = " " & TCLoad & _
                                               " " & Chr(34) & userPassword & Chr(34) & _
                                               " " & runningFrom & "bk_manuals"
        'MsgBox("Line 348 - Open parameters : " & openCommmandParameters)

        If does32Exist Then
            p.FileName = truecrypt32Folder                      ' set it to the 32-bit TC location
        Else
            p.FileName = truecrypt64Folder                      ' set it to the 64-bit TC location
        End If

        'MsgBox("Line 356 - Run This : " & p.FileName)

        p.Arguments = openCommmandParameters                    ' The parameters for opening the encrypted volume
        p.WindowStyle = ProcessWindowStyle.Hidden               ' Hide it all way

        'MsgBox("Line 361 : Command Line : " & p.FileName & vbCrLf & "Parameters : " & p.Arguments)

        Try

            Dim myProcess = Process.Start(p)                    ' open up the encrypted volume
            startedThread = True
            ' MsgBox("Started Thread in Thread : " & startedThread)

        Catch ex As Exception

            Dim errorMessage As String = Prompt62 & " " & ex.ToString()
            MsgBox(errorMessage, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, Prompt01)
            form1.disconnectTC()                                ' disconnect all TC volumes
            End                                                 ' exit the program.

        End Try

        doLogin.Abort()

    End Sub

    '####################################################################################
    '####################################################################################
    '# This subroutine will flip the form RTL or LTR depending upon the RTL entry in    #
    '# the parameters.ini file                                                          #
    '####################################################################################

    Private Sub CheckFormFlow()
        If RTLsetting = "Yes" Then
            Me.RightToLeftLayout = True
            ' Me.RightToLeft = Windows.Forms.RightToLeft.Yes
            GroupBox1.RightToLeft = Windows.Forms.RightToLeft.Yes
        End If
    End Sub

    '####################################################################################
    '####################################################################################
    '# A simple pause method.  Used when changing password                              #
    '####################################################################################
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

End Class