REM #################################################################################################
REM #
REM # In-A-Flash™ is a trademark of Hampton Consulting, LLC, all rights reserved
REM # In-A-Flash™ programming is copyrighted 2010 by Michael Potratz, Urbandale, Iowa
REM #
REM # This program is not public domain and unauthorized use is strictly prohibited
REM #
REM #################################################################################################

Imports System.Text
Imports System.Threading

Public Class installTC

    Dim readThispromptNumber As New readINIFile
    Dim parametersIniFile As New iniFile(runningFrom & "\support\parameters.ini")

    Dim Prompt13 As String = readThispromptNumber.getFormText("Prompt13")   ' domain/computer name
    Dim Prompt21 As String = readThispromptNumber.getFormText("Prompt21")   ' exit...
    Dim Prompt38 As String = readThispromptNumber.getFormText("Prompt38")   ' please wait
    Dim Prompt77 As String = readThispromptNumber.getFormText("Prompt77")   ' do not stop process
    Dim Prompt100 As String = readThispromptNumber.getFormText("Prompt100") ' admin prompt part 1
    Dim Prompt101 As String = readThispromptNumber.getFormText("Prompt101") ' admin prompt part 2
    Dim Prompt102 As String = readThispromptNumber.getFormText("Prompt102") ' admin prompt part 3
    Dim Prompt103 As String = readThispromptNumber.getFormText("Prompt103") ' admin prompt part 4
    Dim Prompt104 As String = readThispromptNumber.getFormText("Prompt104") ' admin prompt part 5
    Dim Prompt105 As String = readThispromptNumber.getFormText("Prompt105") ' install
    Dim Prompt106 As String = readThispromptNumber.getFormText("Prompt106") ' don't install
    Dim Prompt107 As String = readThispromptNumber.getFormText("Prompt107") ' run
    Dim Prompt108 As String = readThispromptNumber.getFormText("Prompt108") ' TC will be installed..
    Dim Prompt109 As String = readThispromptNumber.getFormText("Prompt109") ' need to install
    Dim Prompt110 As String = readThispromptNumber.getFormText("Prompt110") ' there was a problem...

    ' this needs to match what is in the suppport folder on the USB drive
    Dim currentTCVersion = parametersIniFile.GetString("DriveInfo", "CurrentTCVersion", "(none)")   'TrueCrypt_Setup_x.xx.exe
    Dim installTCPgm = parametersIniFile.GetString("DriveInfo", "InstallTC", "(none)")              'support\installTrueCrypt.exe

    ' setup the defaults for the change password routing to run as a thread
    Dim InstallTCProcess As Thread
    Dim InstallTCProcessDone As Boolean = False

    ' this sets the font for the main prompt on the screen
    Dim largeLabelFont As New Font("Microsoft Sans Serif", 14, FontStyle.Bold)

    Dim computerSystem As String = ""
    Dim installTC As Boolean = False
    Dim successORfailure As Boolean = False

    '####################################################################################
    '####################################################################################
    '# Main window load routing                                                         #
    '####################################################################################

    Private Sub installTC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Text = Prompt01

        ' check for a BK machine and set the prompt accordingly...
        If IsBK = True Then
            computerSystem = " " & Prompt30                                 ' this is a BK computer
        Else
            computerSystem = " " & Prompt31                                 ' this is a Franchise computer
        End If

        ' these are on the admin install/use panel
        notify01.Text = Prompt100 & vbCrLf & vbCrLf & _
                        Prompt101 & computerSystem & vbCrLf & vbCrLf & _
                        Prompt102 & vbCrLf & vbCrLf & _
                        Prompt103 & vbCrLf & vbCrLf & _
                        Prompt104
        InstallAdmin.Text = Prompt105                                       ' install
        ExitProgram.Text = Prompt21                                         ' exit this program

    End Sub

    '####################################################################################
    '####################################################################################
    '# If the user clicks the exit buttons as either admin or non-admin, exit the pgm   #
    '####################################################################################

    Private Sub ExitProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitProgram.Click

        End

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End

    End Sub

    '####################################################################################
    '####################################################################################
    '# If the user has admin rights on the computer, then they can run the automated    #
    '# installation program to put TC on their machine                                  #
    '####################################################################################

    Private Sub InstallAdmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstallAdmin.Click

        Dim x As Integer = 1
        Dim response As Integer

        ' set the parameters for the progress bar
        ProgressBar1.Step = 1                                           'set the progress bar to move x places each time
        ProgressBar1.Minimum = 1                                        'minimum value for the progress bar
        ProgressBar1.Maximum = 100                                      'maximum value for the progress bar
        ProgressBar1.Value = 1                                          'set the progress bar to 1 to begin with

        ' prompt them that TC will now be installed
        response = MsgBox(Prompt108 & vbCrLf & vbCrLf & Prompt77, MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, Prompt01)

        ' if the person clicks OK then it returns a 1.  Anything else and the person has bailed
        ' out of the installation routine.

        If response = 1 Then

            Me.Cursor = Cursors.WaitCursor                              'show the waiting cursor
            ProgressBar1.Visible = True                                 'show the progressbar at the bottom

            Sleep(250)                                                  'give the window a chance to react

            InstallTCProcess = New Thread(AddressOf Me.installTCNow)    'establish the install thread
            InstallTCProcess.Start()                                    'start it

            Do Until installTC = True
                ProgressBar1.PerformStep()                              'move the bar
                Sleep(500)                                              'sleep for a bit to lower CPU usage
                x = x + 1                                               'increment the value
                If x = ProgressBar1.Maximum Then                        'check to see if it's over 100
                    ProgressBar1.Value = 1                              'if so, reset to 1
                    ProgressBar1.PerformStep()                          'move the bar
                End If

            Loop

            ProgressBar1.Visible = False                                'hide the progressbar
            ' InstallTCProcess.Abort()                                    'stop the thread

        Else

            ' if they clicked CANCEL then prompt them and end the program
            MsgBox(Prompt109, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, Prompt01)
            End

        End If

    End Sub

    Private Sub installTCNow()

        Dim processExitCode As Integer = 0
        Dim hasFinished As Boolean = False

        Dim y As Integer = 0
        Dim checkProgress As String = ""

        ' the currentTCVersion is established in the parameters.ini file and tells the
        ' program which TC install program to use for the install
        Dim whichTCfile As String = "support\" & currentTCVersion
        Dim installNewTCParameters As String = " " & Chr(34) & runningFrom & Chr(34) & " " & whichTCfile

        Try

            Dim p As New ProcessStartInfo
            p.FileName = runningFrom & installTCPgm         ' this is the automated installation script
            p.Arguments = installNewTCParameters            ' these are the parameters passed to the install script
            Dim myProcess = Process.Start(p)                ' start the installTrueCrypt.exe file

            'Do Until successORfailure = True
            Do Until installTC = True

                Sleep(1000)                             'sleep for 1 second to lower CPU usage
                myProcess.Refresh()
                installTC = myProcess.HasExited()

            Loop

            processExitCode = myProcess.ExitCode()
            ' MsgBox(processExitCode)

            Me.Cursor = Cursors.Default                                             'set the cursor back to normal

            ' if everything went OK then check for the installation and set all the necessary
            ' variables to make things run.

            If processExitCode = 0 Then

                form1.MainPrompt.Text = Prompt02                                    ' Encryption installed

                If the32bitProgramFiles <> "\" And the32bitProgramFiles <> "" Then  ' if this is a 32-bit system.....
                    truecrypt32Folder = the32bitProgramFiles & realTruecryptFolder  ' create the TC folder structure...
                    does32Exist = IO.File.Exists(truecrypt32Folder)                 ' set does32Exist to TRUE
                End If

                If the64bitProgramFiles <> "\" And the64bitProgramFiles <> "" Then  ' if this is a 64-bit system...
                    truecrypt64Folder = the64bitProgramFiles & realTruecryptFolder  ' create the TC folder structure...
                    does64Exist = IO.File.Exists(truecrypt64Folder)                 ' set does64Exist to TRUE
                End If

                Me.Close()                                                          ' close this window

            End If

            ' if the installation didn't go as planned, then put a message up to alert the
            ' user to contact their technical support
            If processExitCode <> 0 Then

                ' reset these files back to Failure to establish the baseline
                'My.Computer.FileSystem.WriteAllText(whatToRead, "Failure", False)
                'My.Computer.FileSystem.WriteAllText(whatToWrite, "Failure", False)

                ' write No to the operations.ini file showing the pw change was not done
                Dim errorMessage As String = Prompt110
                MsgBox(errorMessage, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, Prompt01)
                End
            End If

        Catch ex As Exception

            Me.Cursor = Cursors.Default                                             ' set cursor back to default

            ' write No to the operations.ini file showing the pw change was not done
            Dim errorMessage As String = Prompt110 & vbCrLf & vbCrLf & Prompt62 & " " & ex.ToString()
            MsgBox(errorMessage, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, Prompt01)
            End

        End Try

    End Sub

    '####################################################################################
    '####################################################################################
    '# A simple pause method.  Used when changing password                              #
    '####################################################################################
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
    
End Class