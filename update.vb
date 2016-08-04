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
Imports System.Web
' enables the "start" command for opening a file with it's associated program.
Imports System.Diagnostics.Process

Public Class update

    Dim downloadFiles As Thread
    Dim downloadFilesDone As Boolean = False

    'Dim doCheckConnectivity As Thread
    'Dim doCheckConnectivityDone As Boolean = False
    Dim responseListing As String = ""

    Dim readThispromptNumber As New readINIFile
    Dim operationsIniFile As New iniFile(runningFrom & "\support\operations.ini")
    Dim parametersIniFile As New iniFile(runningFrom & "\support\parameters.ini")

    Dim numberOfUpdates = operationsIniFile.GetString("Updates", "update1", "(none)")
    Dim handleEncryption As New encryption
    Dim SerialNumber = handleEncryption.Decrypt(operationsIniFile.GetString("SerialNumber", "SerialNumber", "(none)"), EncryptionKey)
    Dim ConfCode = handleEncryption.Decrypt(operationsIniFile.GetString("SerialNumber", "ConfirmationCode", "(none)"), EncryptionKey)

    Dim Version = parametersIniFile.GetString("DriveInfo", "Version", "(none)")
    Dim Language = parametersIniFile.GetString("DriveInfo", "Language", "(none)")
    Dim WGetParameters = parametersIniFile.GetString("DriveInfo", "WGetParameters", "")
    Dim ZipParameters = parametersIniFile.GetString("DriveInfo", "ZipParameters", "")

    Dim Prompt38 = readThispromptNumber.getFormText("Prompt38") 'please wait
    Dim Prompt72 = readThispromptNumber.getFormText("Prompt72") 'downloading
    Dim Prompt73 = readThispromptNumber.getFormText("Prompt73") 'installing
    Dim Prompt74 = readThispromptNumber.getFormText("Prompt74") 'begin update
    Dim Prompt75 = readThispromptNumber.getFormText("Prompt75") 'exit update
    Dim Prompt76 = readThispromptNumber.getFormText("Prompt76") 'warning text part 1
    Dim Prompt77 = readThispromptNumber.getFormText("Prompt77") 'warning text part 2
    Dim Prompt78 = readThispromptNumber.getFormText("Prompt78") 'problem connecting
    Dim Prompt79 = readThispromptNumber.getFormText("Prompt79") 'try again later
    Dim Prompt80 = readThispromptNumber.getFormText("Prompt80") 'complete!

    Dim whichFileName As String = ""

    Private Sub update_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CheckFormFlow()                                     'check for RTL or LTR layout
        'MsgBox("checked flow")
        StartButton.Text = Prompt74                         'Begin Update
        ExitUpdate.Text = Prompt75                          'exit update
        instructions1.Text = Prompt76                       'first part of warning text
        instructions2.Text = Prompt77                       'second part of warning text
        'MsgBox("set text prompts")
        If modeOfOperation = "USB" Then
            HeadlineBanner.Text = Prompt07 & " " & Prompt09 ' Update USB Drive
        Else
            HeadlineBanner.Text = Prompt07 & " " & Prompt10 ' Update Restaurant Computer
        End If
        'MsgBox("set mode of operation text")
        Me.Text = Prompt01                                  ' set the windows title

        getFilenames()                                      ' hit the web site and download the filenames
        
    End Sub

    '#######################################################################################
    '#######################################################################################
    '# start the update process for the material                                           #
    '#######################################################################################

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        Me.Cursor = Cursors.WaitCursor      'show the waiting cursor
        StartButton.Enabled = False         'disable the start button so they don't start the download again.
        StartButton.Visible = False
        ExitUpdate.Enabled = False          'disable the exit button until the update process is complete.
        ExitUpdate.Text = Prompt80          ' change the button label to complete!
        ExitUpdate.BackColor = Color.Green  ' set the background to green

        downloadFiles = New Thread(AddressOf Me.downloadFile)
        downloadFiles.Start()


        'call the download and install routine
        'downloadFile()

        ExitUpdate.Enabled = True           ' enable the exit button
        Me.Cursor = Cursors.Default         ' put the cursor back to normal

        ' showDriveInformation()

        'Me.Cursor = Cursors.Default     ' set the cursor back to normal
        'ExitUpdate.Text = Prompt80      ' change the button label to complete!

    End Sub

    '#######################################################################################
    '#######################################################################################
    '# The the total number of updates and the filenames for the files to download         #
    '#######################################################################################

    Private Sub getFilenames()

        StartButton.Enabled = False

        ' put it all together to pass to the register web page
        Dim passToRegister = "?version=" & Version & _
                             "&language=" & Language & _
                             "&serialNumber=" & SerialNumber & _
                             "&ConfCode=" & ConfCode

        Dim whichURL As String = UpdateURL & passToRegister

        ' MsgBox(whichURL)

        Try
            Dim request As HttpWebRequest = HttpWebRequest.Create(whichURL)
            request.Credentials = CredentialCache.DefaultCredentials

            ' Get the response.
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

            ' MsgBox(response.StatusCode)

            If response.StatusCode = "200" Then
                Dim strRowSource As String = ""
                Dim dataStream As Stream = response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                Dim responseFromServer As String = reader.ReadToEnd()                   ' Read the content

                ' MsgBox(responseFromServer)

                Dim split As String() = responseFromServer.Split(New [Char]() {"|"c})   ' split it out

                ' Take the response from the server and break it out.  this will write out
                ' entries to the operations.ini file in the form of update1, update2, etc.
                ' update1 is always the total number of available updates.
                ' update2/4/6... (even) contain the version numbers
                ' update3/5/7... (odd) contain the file names for downloading

                Dim i As Integer = 1                                                    'set start number
                Dim tempentry As String                                                 'define the string
                For Each segment As String In split
                    If segment.Trim() <> "" Then                                        'if it's not empty....
                        tempentry = "update" & CInt(i)                                  'convert the string to integer
                        operationsIniFile.WriteString("Updates", tempentry, segment)
                        responseListing = responseListing & segment & vbCrLf
                        i += 1
                    End If
                Next segment

                ' close out all the open streams and operations to tidy things up.
                reader.Close()
                dataStream.Close()
                response.Close()

                StartButton.Enabled = True                                              'enable the start button

            End If

        Catch ex As Exception

            MsgBox(Prompt78 & vbCrLf & vbCr & Prompt79 & vbCrLf & vbCrLf & "Error 173: " & ex.ToString(), MsgBoxStyle.OkOnly, Prompt01) 'alert there was a problem
            Me.Close()  ' If there was an error then close out the update window...

        End Try

    End Sub

    '#######################################################################################
    '#######################################################################################
    '# download the file onto the target location                                          #
    '#######################################################################################

    Public Sub downloadFile()

        Dim i As Integer = 1
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim numberOfUpdates = operationsIniFile.GetString("Updates", "update1", "(none)")
        Dim numberOfUpdatesInteger As Integer = CInt(numberOfUpdates)
        Dim tempVersion As String
        Dim tempFilename As String
        Dim downloadFileName As String
        Dim whichEntry As String
        Dim whichVersion As String
        Dim returnCode As Integer

        ExitUpdate.Enabled = False                                              'disable the exit button first!

        For i = 1 To numberOfUpdatesInteger

            ' update1 is always the total number of available updates.
            ' update2/4/6... (even) contain the version numbers
            ' update3/5/7... (odd) contain the file names for downloading

            j = (i * 2)
            k = (i * 2) + 1

            whichVersion = "update" & j.ToString()
            tempVersion = operationsIniFile.GetString("Updates", whichVersion, "(none)")
            'MsgBox(whichVersion)
            whichEntry = "update" & k.ToString()
            tempFilename = operationsIniFile.GetString("Updates", whichEntry, "(none)")
            'MsgBox(tempFilename)

            actionLabel.Text = Prompt72                                         ' put "downloading" on the screen

            If modeOfOperation = "Server" Then
                showAnimation.Image = My.Resources.download_to_server1          ' show the server to server image
            Else
                showAnimation.Image = My.Resources.download_to_usb2             ' show the server to USB image
            End If

            Try

                actionLabel.Text = Prompt72 & " " & tempFilename                ' show downloading + filename
                downloadFileName = "http://" & SupportURL & "/downloads/" & Language & "/" & tempFilename

                ' MsgBox(downloadFileName)

                ' The WGet parameters are located in the parameters.ini file.  I did this in case there were
                ' issues with the download I could adjust things by updating the parameters.ini file instead 
                ' of the entire .EXE file.
                ' The --http-user/password parameters are added here outside of the parameters.ini file to
                ' eliminate the easy spotting that this information is being used and passed to the site
                ' in order to access the files.
                Dim Parameters As String = " " & WGetParameters & _
                                           " --http-user=" & accessUsername & _
                                           " --http-password=" & accessPassword & _
                                           " " & downloadFileName

                ' MsgBox("WGET Parameters Line 244 : " & Parameters)

                Directory.SetCurrentDirectory(targetDrive & "updates")          ' download to the updates directory..

                Dim p As New Process

                If modeOfOperation = "Server" Then
                    p.StartInfo.FileName = runningFrom & "\support\wget\wget.exe"
                Else
                    p.StartInfo.FileName = runningFrom & "support\wget\wget.exe"
                End If

                ' MsgBox(p.StartInfo.FileName)

                p.StartInfo.Arguments = Parameters                              ' set the Wget parameters
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden             ' do it in the background
                p.Start()                                                       ' start the process
                p.WaitForExit()                                                 ' wait for the download to process
                returnCode = p.ExitCode                                         ' grab the exit code

                If returnCode = 0 Then                                          ' 0 means success!

                    ' MsgBox("242 - download returncode : " & returnCode)

                    If modeOfOperation = "Server" Then
                        showAnimation.Image = My.Resources.unzip_to_server1     ' show the server to server image
                    Else
                        showAnimation.Image = My.Resources.unzip_to_usb1        ' show the server to USB image
                    End If

                    unZipUpdate(tempFilename, tempVersion)                      ' unzip the file that was just downloaded

                    operationsIniFile.WriteString("Updates", whichVersion, "")  ' zero out the filename
                    operationsIniFile.WriteString("Updates", whichEntry, "")    ' zero out the version

                Else
                    ' alert there was a problem
                    MsgBox(Prompt78 & vbCrLf & vbCr & Prompt79 & vbCrLf & vbCrLf, MsgBoxStyle.OkOnly)
                End If

            Catch ex As Exception
                ' alert there was a problem
                MsgBox(Prompt78 & vbCrLf & vbCr & Prompt79 & vbCrLf & vbCrLf & "Error 285: " & ex.ToString(), MsgBoxStyle.OkOnly, Prompt01)
                Me.Close()

            End Try
        Next

        Directory.SetCurrentDirectory(targetDrive)
        operationsIniFile.WriteString("Updates", "update1", "")                 ' zero out the number of downloads
        actionLabel.Visible = False                                             ' hide the label
        showAnimation.Visible = False                                           ' hide the graphic
        Me.Cursor = Cursors.Default                                             ' set the cursor back to normal
        ExitUpdate.Enabled = True                                               ' re-enable the exit button
        downloadFiles.Abort()                                                   ' stop the threa

    End Sub

    '#######################################################################################
    '#######################################################################################
    '# unzip the file into the target location                                             #
    '#######################################################################################
    Public Sub unZipUpdate(ByVal fileToDownload, ByVal fileVersion)

        Dim newFileVersion = fileVersion
        Dim returnCode As Integer

        Try
            whichFileName = fileToDownload                                  ' passed from the download subroutine
            actionLabel.Text = Prompt73 & " " & whichFileName               ' show installing + filename
            whichFileName = targetDrive & "updates\" & whichFileName        ' get it from the updates directory

            Dim p As New Process

            If modeOfOperation = "Server" Then
                p.StartInfo.FileName = runningFrom & "\support\7z\7za.exe"       ' set the unzip program name
            Else
                p.StartInfo.FileName = runningFrom & "support\7z\7za.exe"       ' set the unzip program name
            End If

            '#######################################################################################
            '# 7-Zip command line options                                                          #
            '#                                                                                     #
            '# x    : extract files from archive with their full paths                             #
            '# -y   : assumes YES on all 7-Zip queries during the unzipping process                #
            '# -aoa : Overwrite All existing files without prompt.                                 #
            '# -o   : Set output directory                                                         #
            '#######################################################################################

            Dim unzipParameters As String = " " & ZipParameters & " " & _
                                Chr(34) & whichFileName & Chr(34)

            Directory.SetCurrentDirectory(targetDrive)

            'MsgBox("Filename : " & whichFileName & vbCrLf & vbCrLf & _
            '       "Version : " & newFileVersion & vbCrLf & vbCrLf & _
            '       "Runthis : " & p.StartInfo.FileName & vbCrLf & vbCrLf & _
            '       "Unzip Parameters : " & unzipParameters & vbCrLf & vbCrLf & _
            '       "TargetDrive : " & targetDrive & vbCrLf & vbCrLf & _
            '       "Mode : " & modeOfOperation)

            p.StartInfo.Arguments = unzipParameters                         ' set the parameters
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden             ' do it in the background
            p.Start()                                                       ' start the process
            p.WaitForExit()                                                 ' wait for it to finish
            returnCode = p.ExitCode                                         ' get the exit code

            ' MsgBox("325 - unzip returnCode : " & returnCode)

            ' MsgBox(returnCode)

            '#######################################################################################
            '# 7-Zip exit codes                                                                    #
            '#                                                                                     #
            '# Code(Meaning)                                                                       #
            '# 0 No error                                                                          #
            '# 1 Warning (Non fatal error(s)). For example, one or more files were locked by some  #
            '# other application, so they were not compressed.                                     #
            '# 2 Fatal error                                                                       #
            '# 7 Command line error                                                                #
            '# 8 Not enough memory for operation                                                   #
            '# 255 User stopped the process                                                        #
            '#######################################################################################

            ' If the unzipping of the file is successful, then update the version number
            ' in the parameters.ini file

            If returnCode = 0 Then
                Dim strResponse As String = ""

                ' MsgBox("370 - unzip returnCode : " & returnCode)

                My.Computer.FileSystem.DeleteFile(whichFileName)
                parametersIniFile.WriteString("DriveInfo", "Version", newFileVersion)

                '#####################################################################################
                ' need to add the code to update the users information on the server at this point
                '#####################################################################################
                Try
                    Dim passToRegister = "?queryType=updateUserVersion" & _
                         "&version=" & newFileVersion & _
                         "&serialNumber=" & SerialNumber & _
                         "&ConfCode=" & ConfCode

                    ' MsgBox("Line 384 - Pass to update user : " & vbCrLf & passToRegister)
                    ' put together the complete address
                    Dim updateUserVersion As String = ProgramDataURL & passToRegister
                    ' MsgBox("Line 387 - all : " & vbCrLf & updateUserVersion)
                    Dim request As WebRequest = WebRequest.Create(updateUserVersion)
                    Dim response As WebResponse = request.GetResponse()
                    Dim reader As StreamReader = New StreamReader(response.GetResponseStream())
                    strResponse = reader.ReadToEnd()
                Catch ex As Exception

                End Try

                ' MsgBox("Line 396 - web return code : " & vbCrLf & strResponse)

                '#####################################################################################
                '#####################################################################################

            End If

        Catch ex As Exception

            MsgBox(Prompt78 & vbCrLf & vbCr & Prompt79 & vbCrLf & vbCrLf & "Error 407: " & ex.ToString(), MsgBoxStyle.OkOnly, Prompt01)
            Me.Close()

        End Try

        Directory.SetCurrentDirectory(targetDrive)

    End Sub

    '####################################################################################
    '####################################################################################
    '# Close the window if this button is clicked                                       #
    '####################################################################################

    Private Sub ExitUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitUpdate.Click
        If ExitUpdate.Text = Prompt80 Then                                          ' Prompt80 = Done!
            showDriveInformation()                                                  ' update drive information                                    
        End If
        Me.Close()
    End Sub


    '####################################################################################
    '####################################################################################
    '# A simple pause method.  Used when changing password                              #
    '####################################################################################
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

    '####################################################################################
    '####################################################################################
    '# Get the drive version, language and serial number from the ini files and then    #
    '# display it on the bottom right side of the screen                                #
    '####################################################################################

    Private Sub showDriveInformation()

        'Read the version.ini file and display the contents

        Dim Prompt33 = readThispromptNumber.getFormText("Prompt33")                 ' Version
        Dim Prompt34 = readThispromptNumber.getFormText("Prompt34")                 ' Language
        Dim Prompt35 = readThispromptNumber.getFormText("Prompt35")                 ' Serial Number

        Dim Version = parametersIniFile.GetString("DriveInfo", "Version", "(none)")                 ' information YY.MM
        Dim Language = parametersIniFile.GetString("DriveInfo", "Language", "(none)")               ' language code letters
        Dim SerialNumber = handleEncryption.Decrypt(operationsIniFile.GetString("SerialNumber", "SerialNumber", "(none)"), EncryptionKey)  ' generated serial number
        SerialNumber = Microsoft.VisualBasic.Left(SerialNumber, 16)

        ' put it all together and show it on the screen
        form1.driveVersion.Text = "|| " & Prompt33 & " : " & Version & " || " & Prompt34 & " : " & Language & " || " & Prompt35 & " : " & SerialNumber & " ||"

        form1.downloadArrow.Image = My.Resources.no_download1       ' set the download arrow to "No downloads"
        form1.downloadArrow.Enabled = False                         ' disable the download arrow

    End Sub

    '####################################################################################
    '####################################################################################
    '# This subroutine will flip the form RTL or LTR depending upon the RTL entry in    #
    '# the parameters.ini file                                                          #
    '####################################################################################

    Private Sub CheckFormFlow()
        If RTLsetting = "Yes" Then
            ' MsgBox(RTLsetting)
            Me.RightToLeftLayout = True
            ' Me.RightToLeft = Windows.Forms.RightToLeft.Yes
            Me.TableLayoutPanel1.RightToLeft = Windows.Forms.RightToLeft.Yes
            Me.TableLayoutPanel2.RightToLeft = Windows.Forms.RightToLeft.Yes
            ' MsgBox("set form flow")
        End If
    End Sub
End Class