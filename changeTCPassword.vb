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
Imports System.Threading
Imports System.Security.Cryptography
' enables the "start" command for opening a file with it's associated program.
Imports System.Diagnostics
Imports System.Diagnostics.Process
Imports System.Text.RegularExpressions
Imports System.Windows.Forms


Public Class changeTCPassword

    ' Dim startIniFile As New iniFile(runningFrom & "\support\start.ini")
    Dim readThispromptNumber As New readINIFile
    Dim operationsIniFile As New iniFile(runningFrom & "\support\operations.ini")
    Dim parametersIniFile As New iniFile(runningFrom & "\support\parameters.ini")

    ' get prompts to display on the screen
    Dim Prompt21 = readThispromptNumber.getFormText("Prompt21") ' exit this program
    Dim Prompt23 = readThispromptNumber.getFormText("Prompt23") ' after clicking ok...
    Dim Prompt38 = readThispromptNumber.getFormText("Prompt38") ' please wait
    Dim Prompt56 = readThispromptNumber.getFormText("Prompt56") ' please wait
    Dim Prompt60 = readThispromptNumber.getFormText("Prompt60") ' change pw
    Dim Prompt61 = readThispromptNumber.getFormText("Prompt61") ' change pw
    Dim Prompt62 = readThispromptNumber.getFormText("Prompt62") ' change pw
    Dim Prompt63 = readThispromptNumber.getFormText("Prompt63") ' change pw
    Dim Prompt64 = readThispromptNumber.getFormText("Prompt64") ' change pw
    Dim Prompt65 = readThispromptNumber.getFormText("Prompt65") ' change pw
    Dim Prompt66 = readThispromptNumber.getFormText("Prompt66") ' change pw
    Dim Prompt67 = readThispromptNumber.getFormText("Prompt67") ' change pw
    Dim Prompt68 = readThispromptNumber.getFormText("Prompt68") ' change pw
    Dim Prompt70 = readThispromptNumber.getFormText("Prompt70") ' pw change error
    Dim Prompt71 = readThispromptNumber.getFormText("Prompt71") ' pw change success
    Dim Prompt81 = readThispromptNumber.getFormText("Prompt81") ' pw change success

    ' setup the defaults for handling the new password
    Dim newPassWord As String = ""
    Dim newPassWordLength As Integer = 0

    ' setup the defaults for the change password routing to run as a thread
    Dim ChangePWProcess As Thread
    Dim ChangePWProcessDone As Boolean = False

    ' setup the process to run the changepassword.exe file and monitor it
    Public myProcess As Process
    Public pwcDone As Boolean = False       'set a "Is it done yet?" variable

    ' get ready to encrypt the password
    Dim encryptPassword As New encryption

    ' this sets the font for the main prompt on the screen
    Dim largeLabelFont As New Font("Microsoft Sans Serif", 14, FontStyle.Bold)

    Dim isTCInstalled As Boolean = False
    Dim changePWPrompt

    Private Sub changeTCPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If does32Exist = True Or does64Exist = True Then
            isTCInstalled = True
        End If

        ' form1.disconnectTC()                    ' try disconnecting any volumes just in case...

        ' killProcess("TrueCrypt")                ' go through and kill any instances of Truecrypt

        killProcess("changePassword")           ' go through and kill any instances of changePassword

        Me.Focus()                              ' grab focus
        Me.Text = Prompt01                      ' BK title
        enterNewPWPrompt.Text = Prompt66        ' Enter your new password
        doChangePassword.Text = Prompt67        ' Change password
        okToExit.Text = Prompt56                ' OK
        changePWTitle.Text = Prompt60           ' change your password

        If isTCInstalled = False Then
            ' if the user is not admin and TC is not installed the person cannot go any
            ' further.  Prompt to get IT for installation and end the program.

            Dim Prompt69 = readThispromptNumber.getFormText("Prompt69")
            Dim Prompt111 = readThispromptNumber.getFormText("Prompt111")

            changePWPrompt = Prompt69 & vbCrLf & vbCr & Prompt111

            ' remove the buttons from the screen to prevent any further action
            doChangePassword.Visible = False
            okToExit.Visible = False
            newPWentry.Visible = False
            ' write "No" to the password changed flag in the operations.ini file
            operationsIniFile.WriteString("Operations", "Value06", "No")

        Else

            changePWPrompt = Prompt61 & vbCrLf & vbCrLf & _
                             Prompt63 & vbCrLf & vbCrLf & _
                             Prompt64 & vbCrLf & vbCrLf & _
                             Prompt65

            changePasswordPrompt.Text = changePWPrompt
            newPWentry.Focus()                          ' put the cursor in the new PW entry field
            mainExitButton.Text = Prompt21

        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles doChangePassword.Click

        ProgressBar1.Visible = True                                                 ' show the progress bar
        changePasswordPrompt.Text = Prompt38                                        ' please wait...
        doChangePassword.Enabled = False                                            ' disable the change button
        doChangePassword.BackColor = Color.DimGray                                  ' set the button background to gray
        newPWentry.Enabled = False                                                  ' disable the password text box
        changePasswordPrompt.Font = largeLabelFont                                  ' make it big font
        changePasswordPrompt.ForeColor = Color.Yellow                               ' change the background to yellow
        Sleep(500)                                                                  ' sleep for a bit to let things happen
        mainExitButton.Visible = False                                              ' remove the main exit button

        MsgBox(Prompt23, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, Prompt01)   ' One last warning not to touch!!!

        ChangePWProcess = New Thread(AddressOf Me.changeNewPassword)
        ChangePWProcess.Start()

    End Sub

    '####################################################################################
    '####################################################################################
    '# This is the subroutine to run as a thread to actually change the password        #
    '####################################################################################

    Private Sub changeNewPassword()

        ' establish the variables for this subroutine
        Dim x As Integer = 1
        Dim y As Integer = 0
        Dim exitCode As String = ""
        Dim changeTCRun As String = ""
        Dim checkProgress As String = ""
        Dim changePW As Boolean = True
        Dim p As New ProcessStartInfo

        Me.Cursor = Cursors.WaitCursor          ' display the waiting cursor on the screen

        ' check for TC on the hard drive and set the variable to the applicable location
        If does32Exist Then
            changeTCRun = truecrypt32Folder
        End If

        If does64Exist Then
            changeTCRun = truecrypt64Folder
        End If

        ' create the command line string to pass to the changePassword.exe file
        ' changeTCRun is the location from Truecrypt
        ' newPassWord is the new password the person entered
        ' runningFrom is the root directory of the USB drive
        Dim changePWParameters As String = " " & Chr(34) & changeTCRun & Chr(34) & _
                                           " " & Chr(34) & newPassWord & Chr(34) & _
                                           " " & Chr(34) & runningFrom & Chr(34)
        ' MsgBox("newPassword : " & newPassWord)


        ' changePassword.exe is a file created with AutoIt3 to run Truecrypt and automate
        ' all of the entries and button pushes on the various forms.
        p.FileName = runningFrom & "support\changePassword.exe"
        p.Arguments = changePWParameters

        'test messages to check parameters
        'MsgBox("Line 181 - TrueCrypt Location : " & changeTCRun & vbCrLf & vbCrLf & _
        '        "File to run : " & p.FileName & vbCrLf & vbCrLf & _
        '        "Pass to program : " & p.Arguments)

        ' this routine uses a compiled AutoIt script to change the password on the drive
        ' the person just enters a new password and the script takes it from there
        Try

            myProcess = Process.Start(p)            'start the changePassword.exe file

            ProgressBar1.Step = 1                   'set the progress bar to move 1 place each time
            ProgressBar1.Minimum = 1                'minimum value for the progress bar
            ProgressBar1.Maximum = 100              'maximum value for the progress bar
            ProgressBar1.Value = 1                  'set the progress bar to 1 to begin with

            'loop through the test
            Do Until pwcDone = True

                ProgressBar1.PerformStep()

                Sleep(1500)                         'sleep for 2.5 seconds to lower CPU usage

                myProcess.Refresh()
                pwcDone = myProcess.HasExited()

                x = x + 1                           ' increment the value
                If x = ProgressBar1.Maximum Then    ' check to see if it's over 100
                    ProgressBar1.Value = 1          ' if so, reset to 1
                    ProgressBar1.PerformStep()      ' move the bar a bit..
                End If
            Loop

            exitCode = myProcess.ExitCode()

            ProgressBar1.Visible = False            'remove the progress bar from the screen
            Me.Cursor = Cursors.Default

            ' if the process completed successfully, write Yes to the operations.ini file showing 
            ' that the pw change was done
            ' ExitCode = 0 means the AutoIt script exited properly
            ' ExitCode = 1 means the AutoIt script did NOT exit properly
            ' MsgBox("Line 214 - Process ExitCode : " & exitCode)

            If exitCode = 0 Then

                Sleep(500)

                okToExit.BackColor = Color.Green                'set the OK button background to green
                okToExit.Image = My.Resources.button_ok1
                okToExit.Enabled = True                         'enable it
                changePasswordPrompt.BackColor = Color.Green    ' set background to red
                changePasswordPrompt.ForeColor = Color.White    ' set font to white
                changePasswordPrompt.Text = Prompt71            'prompt the user to click the OK button

                ' write "Yes" to the operations.ini file to indicate that the person has successfully
                ' changed the password.
                operationsIniFile.WriteString("Operations", "Value06", "Yes")

                ' take the new password that the user has entered, encrypt it and then write
                ' it to Value99 in the operations.ini field.
                ' MsgBox("Line 237 - changeTC - newpassword : " & newPassWord)

                operationsIniFile.WriteString("Operations", "Value99", encryptPassword.Encrypt(newPassWord, EncryptionKey))

            Else

                ' write No to the operations.ini file showing the pw change was not done
                operationsIniFile.WriteString("Operations", "Value06", "No")

                newPWentry.Text = ""                            ' clear out the new password entry
                changePasswordPrompt.Text = Prompt70            ' there was a problem
                changePasswordPrompt.BackColor = Color.Red      ' set background to red
                changePasswordPrompt.ForeColor = Color.White    ' set font to white
                okToExit.BackColor = Color.Red                  ' set background to red
                okToExit.Enabled = True                         ' enable the button
                okToExit.Image = My.Resources.window_close      ' change the image to the x

            End If

        Catch ex As Exception

            ' write No to the operations.ini file showing the pw change was not done
            operationsIniFile.WriteString("Operations", "Value06", "No")

            newPWentry.Text = ""                                ' clear out the new password entry
            changePasswordPrompt.BackColor = Color.Red          ' set background to red
            changePasswordPrompt.ForeColor = Color.White        ' set font to white
            okToExit.BackColor = Color.Red                      ' set background to red
            okToExit.Enabled = True                             ' enable the button
            okToExit.Image = My.Resources.window_close          ' change the image to the x
            okToExit.Text = Prompt21                            ' exit this program

            Dim errorMessage As String = Prompt70 & vbCrLf & vbCrLf & Prompt62 & " " & ex.ToString()
            changePasswordPrompt.Text = errorMessage            ' show the error message

        End Try

        ChangePWProcess.Abort()                                 ' close out the thread

    End Sub

    '####################################################################################
    '####################################################################################
    '# This checks to see if the person has entered anything into the new password      #
    '# box on the screen.  This prevents them from trying to change it without putting  #
    '# at least 4 characters in the box.  If the person starts deleting text from the   #
    '# form it will also disable the button again.                                      #
    '####################################################################################
    Private Sub newPWentry_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newPWentry.TextChanged

        newPassWord = newPWentry.Text.ToString()
        'MsgBox(newPassWord)

        newPassWordLength = newPassWord.Length
        'MsgBox(newPassWordLength)

        If newPassWordLength >= minimumPasswordLength Then  ' if there are at least 4 characters in the box
            doChangePassword.BackColor = Color.Green        ' turn the background green
            doChangePassword.Enabled = True                 ' enable the button
        Else
            doChangePassword.Enabled = False                ' disable the button to prevent clicking
            doChangePassword.BackColor = Color.Gainsboro    ' put it back to the gray color
        End If

    End Sub

    '####################################################################################
    '####################################################################################
    '# A simple pause method.  Used when changing password                              #
    '####################################################################################
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

    '####################################################################################
    '####################################################################################
    '# Exit out of this form.                                                           #
    '####################################################################################

    Private Sub doneButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles okToExit.Click

        Me.Close()

    End Sub

    Private Sub mainExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mainExitButton.Click

        MsgBox(Prompt81, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, Prompt01)
        End

    End Sub
End Class