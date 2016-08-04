Imports System.IO
Imports System.Net
Imports System.Diagnostics


Public Module AutoUpdate

    Dim startIniFile As New iniFile(runningFrom & "\support\start.ini")
    Dim operationsIniFile As New iniFile(runningFrom & "\support\operations.ini")
    Dim parametersIniFile As New iniFile(runningFrom & "\support\parameters.ini")

    Dim Value10 = operationsIniFile.GetString("Operations", "Value10", "(none)")        'update data file
    Dim Prompt82 = startIniFile.GetString("StartPrompts", "Prompt82", "(none)")         'update error prompt
    Dim Prompt83 = startIniFile.GetString("StartPrompts", "Prompt83", "(none)")         'update available prompt


    Private m_RemotePath As String = "http://" & SupportURL & "/"      ' the URL of the support site
    Private m_UpdateFileName As String = Value10        ' the name of the update data file
    Private m_ErrorMessage As String = Prompt82         ' update error prompt

    ' <File Name>;<Version>   [' comments    ]
    ' <File Name>[;<Version>] [' comments    ]  
    ' <File Name>[;?]         [' comments    ]
    ' <File Name>[;delete]    [' comments    ]
    ' ...
    ' Blank lines and comments are ignored
    ' The first line should be the current program/version
    ' from the second line to the end the second parameter is optional
    ' if the second parameter is not specified the file is updated.
    ' if the version is specified the update checks the version
    ' if the second parameter is an interrogation mark (?) the update checks if the 
    ' file alredy exists and "don't" upgrade if exists.
    ' if the second parameter is "delete" the system try to delete the file
    ' "'" (chr(39)) start a line comment (like vb)

    ' Function Return Value
    ' True means that the program needs to exit because: the autoupdate did the update
    ' or there was an error during the update
    ' False - nothing was done
    Public Function UpdateFiles(Optional ByVal RemotePath As String = "") As Boolean

        '################################################################################################
        ' We need to check for network connectivity before we can look for an update to the
        ' program.  If there is not connectivity, then just return without checking.

        Dim objUrl As New System.Uri(UpdateURL)               ' Look for the update site
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

        ' MsgBox("Update connection success: " & success)
        '################################################################################################

        ' only run this if there is connectivity
        If success = True Then

            If RemotePath = "" Then
                RemotePath = m_RemotePath                   ' SupportURL & "/"
            Else
                m_RemotePath = RemotePath
            End If

            Dim Ret As Boolean = False
            Dim AssemblyName As String = System.Reflection.Assembly.GetEntryAssembly.GetName.Name
            Dim ToDeleteExtension As String = ".ToDelete"

            '-------------------------------------------------------------------------------
            ' this was the original path to the update files on the support site
            '-------------------------------------------------------------------------------
            'Dim RemoteUri As String = RemotePath & AssemblyName & "/"                   ' SupportURL & "/" & Start & "/"

            '-------------------------------------------------------------------------------
            ' in order to get the new multiple file update working, I had to use the original
            ' location get the updated start.exe file out to the user.  The new start.exe file
            ' then contained the updated files location in order to 're-update' the start.exe
            ' and then also the other new files which needed to be pushed out to the user.
            '-------------------------------------------------------------------------------
            Dim RemoteUri As String = RemotePath & "pgmUpdate/" & AssemblyName & "/"       ' SupportURL & "pgmUpdate/" & Start & "/"

            Dim MyWebClient As New WebClient
            Dim variableTarget As String = ""
            Dim variableTime As String = ""

            'MsgBox("Line 83" & vbCrLf & _
            '       "RemotePath = " & RemotePath & vbCrLf & _
            '       "m_RemotePath = " & m_RemotePath & vbCrLf & _
            '       "AssemblyName = " & AssemblyName & vbCrLf & _
            '       "RemoteUri = " & RemoteUri)
            'MsgBox("Download String = " & RemoteUri & UpdateFileName)

            Try

                '#######################################################################################
                ' try to delete old files if they exist
                Dim s As String = Dir(Application.StartupPath & "\*" & ToDeleteExtension)
                Do While s <> ""
                    Try
                        File.Delete(Application.StartupPath & "\" & s)
                    Catch ex As Exception
                    End Try
                    s = Dir()
                Loop
                '#######################################################################################

                ' get the update file content
                ' UpdateFileName = Value10  > updatepgm.dat
                Dim Contents As String = MyWebClient.DownloadString(RemoteUri & UpdateFileName)

                'MsgBox("Line 108 : " & vbCrLf & Contents)

                '#######################################################################################
                ' Process the autoupdate
                ' get rid of the line feeds if exists

                Contents = Replace(Contents, Chr(Keys.LineFeed), "")
                Dim FileList() As String = Split(Contents, Chr(Keys.Return))
                Contents = ""
                '#######################################################################################
                '#######################################################################################
                '#######################################################################################
                ' Remove all comments and blank lines

                For Each F As String In FileList
                    ' MsgBox("Line 127 F : " & F)
                    If InStr(F, "'") <> 0 Then F = Strings.Left(F, InStr(F, "'") - 1)
                    If F.Trim <> "" Then
                        If Contents <> "" Then Contents += Chr(Keys.Return)
                        Contents += F.Trim
                        'MsgBox("Line 128 : " & vbCrLf & Contents)
                    End If
                Next
                '#######################################################################################
                '#######################################################################################
                '#######################################################################################
                ' rebuild the file list

                FileList = Split(Contents, Chr(Keys.Return))
                Dim Info() As String = Split(FileList(0), ";")

                If modeOfOperation = "Server" Then
                    variableTarget = "\" & Info(0).ToLower                  'add the leading slash for server operation
                    variableTime = "\" & Now.TimeOfDay.TotalMilliseconds    'add the leading slash for temp filename
                Else
                    variableTarget = Info(0).ToLower                        'leave the slash off if USB operaton
                    variableTime = Now.TimeOfDay.TotalMilliseconds          'leave the slass off of the temp filename
                End If
                '#######################################################################################
                '#######################################################################################
                '#######################################################################################
                ' if the name matches and the version on the update site is newer
                ' then the existing version then process the update

                'MsgBox("Line 152 : " & vbCrLf & Application.StartupPath.ToLower & variableTarget & vbCrLf & Application.ExecutablePath.ToLower)
                'MsgBox("Line 153 : " & vbCrLf & GetVersion(Info(1)) & vbCrLf & GetVersion(Application.ProductVersion))

                If Application.StartupPath.ToLower & variableTarget = Application.ExecutablePath.ToLower AndAlso _
                    GetVersion(Info(1)) > GetVersion(Application.ProductVersion) Then

                    ' process files in the list
                    MsgBox(Prompt83, MsgBoxStyle.Exclamation, Prompt01)     'Alert the user there is an update

                    For Each F As String In FileList

                        variableTarget = F

                        'MsgBox("Application.StartupPath = " & Application.StartupPath)
                        'MsgBox("variableTarget = " & variableTarget)

                        Info = Split(F, ";")                                ' ; is the split character in updatepgm.dat
                        Dim isToDelete As Boolean = False
                        Dim isToUpgrade As Boolean = False
                        Dim TempFileName As String = Application.StartupPath & Info(0) & variableTime
                        Dim FileName As String = Application.StartupPath & Info(0)
                        Dim FileExists As Boolean = File.Exists(FileName)
                        ' MsgBox("Line 174 " & vbCrLf & "Filename: " & vbCrLf & FileName & vbCrLf & "Exist? " & FileExists)

                        If Info.Length = 1 Then
                            ' Just the file as parameter always upgrade
                            isToUpgrade = True
                            isToDelete = FileExists

                        ElseIf Info(1).Trim = "delete" Then
                            ' second parameter is "delete"
                            isToDelete = FileExists             ' check to see if the original file exists

                        ElseIf Info(1).Trim = "?" Then
                            ' second parameter is "?" (check if file exists and don't upgrade if exists)
                            isToUpgrade = Not FileExists

                        ElseIf FileExists Then
                            ' verify the file version
                            Dim fv As FileVersionInfo = FileVersionInfo.GetVersionInfo(FileName)
                            isToUpgrade = (GetVersion(Info(1).Trim) > GetVersion(fv.FileMajorPart & "." & fv.FileMinorPart & "." & fv.FileBuildPart & "." & fv.FilePrivatePart))
                            isToDelete = isToUpgrade
                        Else
                            ' the second parameter exists as version number and the file doesn't exists
                            isToUpgrade = True
                        End If

                        Debug.Print(TempFileName)

                        ' download the new file
                        If isToUpgrade Then MyWebClient.DownloadFile(RemoteUri & Info(0), TempFileName)

                        ' rename the existent file to be deleted in the future
                        If isToDelete Then File.Move(FileName, TempFileName & ToDeleteExtension)

                        ' rename the downloaded file to the real name
                        If isToUpgrade Then File.Move(TempFileName, FileName)

                    Next
                    ' call the new version
                    System.Diagnostics.Process.Start(Application.ExecutablePath, Microsoft.VisualBasic.Command())
                    Ret = True
                End If

            Catch ex As Exception

                Ret = True
                MsgBox(m_ErrorMessage & vbCr & ex.Message & vbCr & "Assembly 212: " & AssemblyName, MsgBoxStyle.Critical, Application.ProductName)

            End Try

            Return Ret

        End If

    End Function

    Public Property RemotePath() As String
        Get
            Return m_RemotePath
        End Get
        Set(ByVal value As String)
            m_RemotePath = value
        End Set
    End Property

    Public Property UpdateFileName() As String
        Get
            Return m_UpdateFileName
        End Get
        Set(ByVal value As String)
            m_UpdateFileName = value
        End Set
    End Property

    Public Property ErrorMessage() As String
        Get
            Return m_ErrorMessage
        End Get
        Set(ByVal value As String)
            m_ErrorMessage = value
        End Set
    End Property

    Private Function GetVersion(ByVal Version As String) As String
        Dim x() As String = Split(Version, ".")
        Return String.Format("{0:00000}{1:00000}{2:00000}{3:00000}", Int(x(0)), Int(x(1)), Int(x(2)), Int(x(3)))
    End Function

End Module
