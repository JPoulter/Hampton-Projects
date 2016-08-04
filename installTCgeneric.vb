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

Public Class installTCgeneric

    Dim englishPrompt As String = ""
    Dim englishInstallPrompt As String = ""
    Dim englishCancel As String = ""
    Dim englishError As String = ""

    Dim germanPrompt As String = ""
    Dim germanInstallPrompt As String = ""
    Dim germanCancel As String = ""
    Dim germanError As String = ""

    Dim spanishPrompt As String = ""
    Dim spanishInstallPrompt As String = ""
    Dim spanishCancel As String = ""
    Dim spanishError As String = ""

    Dim totalPrompt As String = ""
    Dim totalInstallPrompt As String = ""
    Dim totalCancelPrompt As String = ""
    Dim totalErrorPrompt As String = ""


    ' this needs to match what is in the suppport folder on the USB drive
    Dim parametersIniFile As New iniFile(runningFrom & "\support\parameters.ini")
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

    Private Sub installTCgeneric_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        englishPrompt = "In order to access this information you can install the TrueCrypt® encryption program onto this computer.   Would you like to install TrueCrypt® at this time?"
        germanPrompt = "Um auf diese Informationen zuzugreifen, können Sie das Verschlüsselungsprogramm TrueCrypt® auf diesem Computer installieren.   Möchten Sie TrueCrypt® jetzt installieren?"
        spanishPrompt = "Para acceder a esta información puede instalar el programa de cifrado TrueCrypt® en este equipo.   ¿Desea instalar TrueCrypt® en este momento?"
        totalPrompt = englishPrompt & vbCrLf & vbCrLf & vbCrLf & germanPrompt & vbCrLf & vbCrLf & vbCrLf & spanishPrompt

        englishInstallPrompt = "TrueCrypt® will now be installed and will take a short period of time. Do not stop or interrupt this process.  The program will continue when installation is complete."
        germanInstallPrompt = "TrueCrypt® wird nun installiert. Dies wird nur kurze Zeit dauern. Diesen Vorgang nicht beenden oder unterbrechen.  Nach Abschluss der Installation wird das Programm fortgesetzt."
        spanishInstallPrompt = "La instalación de TrueCrypt® se realizará ahora y llevará un corto periodo de tiempo. No detenga ni interrumpa este proceso.  El programa continuará ejecutándose una vez finalizada la instalación."
        totalInstallPrompt = englishInstallPrompt & vbCrLf & vbCrLf & germanInstallPrompt & vbCrLf & vbCrLf & spanishInstallPrompt

        englishCancel = "You have cancelled the installation process.  You can not use this program until it it completed."
        germanCancel = "Sie haben die Installation abgebrochen.  Sie können dieses Programm erst verwenden, nachdem die Installation abgeschlossen wurde."
        spanishCancel = "Ha cancelado el proceso de instalación.  No puede usar este programa antes de que se haya completado."
        totalCancelPrompt = englishCancel & vbCrLf & vbCrLf & germanCancel & vbCrLf & vbCrLf & spanishCancel

        englishError = "There was a problem installing TrueCrypt®.  Please contact your IT support."
        germanError = "Beim Installieren von TrueCrypt® ist ein Fehler aufgetreten.  Bitte wenden Sie sich an den IT-Support."
        spanishError = "Se produjo un problema durante la instalación de TrueCrypt®.  Póngase en contacto con su servicio de asistencia técnica de TI."
        totalErrorPrompt = englishError & vbCrLf & vbCrLf & germanError & vbCrLf & vbCrLf & spanishError
        ' these are on the admin install/use panel
        notify01.Text = totalPrompt

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
        response = MsgBox(totalInstallPrompt, MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, Prompt01)

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
            MsgBox(totalCancelPrompt, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, Prompt01)
            End

        End If

    End Sub

    Private Sub installTCNow()

        Dim processExitCode As Integer = 0
        Dim hasFinished As Boolean = False

        Dim y As Integer = 0
        Dim checkProgress As String = ""
        ' create the command line string to pass to the changePassword.exe file
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

               ' write No to the operations.ini file showing the pw change was not done
                MsgBox("Error 215: " & totalErrorPrompt, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, Prompt01)
                End

            End If

        Catch ex As Exception

            Me.Cursor = Cursors.Default                                             ' set cursor back to default

            Dim errorMessage As String = totalErrorPrompt & vbCrLf & vbCrLf & ex.ToString()
            MsgBox("Error 225 : " & errorMessage, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, Prompt01)
            End

        End Try

    End Sub

    '####################################################################################
    '####################################################################################
    '# A simple pause method.  Used when changing password                              #
    '####################################################################################
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
End Class