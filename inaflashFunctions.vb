REM #################################################################################################
REM #
REM # In-A-Flash™ is a trademark of Hampton Consulting, LLC, all rights reserved
REM # In-A-Flash™ programming is copyrighted 2010 by Michael Potratz, Urbandale, Iowa
REM #
REM # This program is not public domain and unauthorized use is strictly prohibited
REM #
REM #################################################################################################

Imports System.Text.RegularExpressions
Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Diagnostics

'#########################################################################################
'# Instead of sprinkling functions around the different forms, all of them are           #
'# consolidated into one place so I don't have to go looking                             #
'#########################################################################################

Module inaflashFunctions

    '#####################################################################################
    '# This class is used to read the UTF-8 formatted start.ini files in the different   #
    '# languages and encode them to UNICODE format for display in the program.           #
    '#                                                                                   #
    '# Without the encoding of the strings the double-byte characters ie. Japanese,      #
    '# Russian, Chinese, Thai, Bulgarian, Korean, etc. show up as a jumbled mess on the  #
    '# screen.                                                                           #
    '#                                                                                   #
    '# This function is used in place of the iniFile.vb function which is used to read   #
    '# and write the operations.ini & parameters.ini files.  Since they are english only #
    '# I don't have to worry about encoding/decoding the strings.                        #
    '#####################################################################################

    Class readINIFile

        Public Function getFormText(ByVal promptNumber As String) As String

            Dim myFileStream As FileStream
            Dim myStreamReader As StreamReader
            Dim anciiStreamReader As StreamReader
            Dim strRead As String = ""
            Dim StreamEncoding As Encoding
            Dim searchFor As String = ""
            Dim lengthSearchFor As Integer
            Dim stringLength As Integer
            Dim stringPrompt As String = ""
            Dim emptyString As Boolean = False

            'Dim runningFrom As String = "L:\"

            searchFor = promptNumber

            lengthSearchFor = searchFor.Length                                  'get the length of the prompt text

            ' MsgBox("Searching For: " & searchFor & vbCrLf & "Search Length: " & lengthSearchFor)

            ' This first 'Try' is for reading the UTF-8 encoded start.ini file.

            Try
                ' Set the program to encode the string to UNICODE.  Then set what file to read and finally 
                ' create the new instance of the streamreader to process the information.
                StreamEncoding = Encoding.Unicode
                myFileStream = New FileStream(runningFrom & "\support\start.ini", FileMode.Open, FileAccess.Read)
                myStreamReader = New StreamReader(myFileStream, StreamEncoding)

                Do
                    strRead = myStreamReader.ReadLine()                         ' just read in 1 line at a time

                    If (Microsoft.VisualBasic.Left(strRead, 1)) <> "#" Then     'If the first character of the first
                        Exit Do                                                 'line is not # then we're reading a
                    End If                                                      'ANCII encoded file, not UTF-8

                    stringLength = strRead.Length                               'get the length of the string

                    ' if the left portion of the string is equal to the text prompt passed to this function
                    ' then we have found what we are looking for.  We take the prompt length + 2 to get the first
                    ' character past the = sign in the ini file string.  Extract the string starting there to the
                    ' end of the line.  Once we have that, we can exit the DO LOOP because we don't need to read
                    ' any more
                    If Microsoft.VisualBasic.Left(strRead, lengthSearchFor) = searchFor Then
                        stringPrompt = Microsoft.VisualBasic.Mid(strRead, lengthSearchFor + 2, stringLength - lengthSearchFor)
                        Exit Do
                    End If
                Loop
            Catch EX As IOException
                MsgBox(EX.ToString)
            End Try

            '#####################################################################################
            '# This portion of the code is used to read ANCII formatted files.  This coding is
            '# necessary because there are still some ANCII formatted start.ini files out there
            '# from early 'deployment' of the USB drives.  
            '#####################################################################################
            Try

                myFileStream = New FileStream(runningFrom & "\support\start.ini", FileMode.Open, FileAccess.Read)
                anciiStreamReader = New StreamReader(myFileStream)

                Do
                    strRead = anciiStreamReader.ReadLine()
                    stringLength = strRead.Length

                    If Microsoft.VisualBasic.Left(strRead, lengthSearchFor) = searchFor Then
                        stringPrompt = Microsoft.VisualBasic.Mid(strRead, lengthSearchFor + 2, stringLength - lengthSearchFor)
                        Exit Do
                    End If

                Loop
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            myFileStream.Close()
            myStreamReader.Close()
            Return (stringPrompt)

        End Function

    End Class


    '#####################################################################################
    '# this function checks the person currently logged into the computer and sees if    #
    '# they are a member of the administrators group on the computer.  If so, then it is #
    '# possible to run TrueCrypt from the USB drive if they want to.                     #
    '# Referenced in the globalVariables.vb in setting public variables                  #
    '#                                                                                   #
    '# For Vista & Windows 7, even if a person is a part of the Administrators group,    #
    '# if the UAC is set to alert the user whenever a change is being made, you cannot   #
    '# launch an external process to install TrueCrypt or change the password.           #
    '#####################################################################################
    Public Class checkGroup

        Public Shared Function isAdministrator() As Boolean

            '##################################################################################
            ' this portion of the code will show members of the administrator group regardless
            ' of the setting of the UAC in Vista & Windows 7
            '##################################################################################

            'Dim domainName As String = System.Environment.GetEnvironmentVariable("USERDOMAIN")
            'Dim currentUser As String = System.Environment.GetEnvironmentVariable("USERNAME")
            'Dim groupName
            'Dim member

            'groupName = GetObject("WinNT://" & domainName & "/Administrators")

            'For Each member In groupName.Members
            '    MsgBox("Admin Group Member : " & member.Name)
            '    If member.Name = currentUser Then
            '        Return True
            '    End If
            'Next

            '###################################################################################
            ' this portion of the code will only show a user as part of the administrators 
            ' group if the UAC is turned off.  
            '###################################################################################

            ' Check if the user is authenticated before continuing.
            If My.User.IsAuthenticated Then
                ' If the user is in the administrators group.
                If My.User.IsInRole("Administrators") Then
                    Return True
                End If
            End If

            ' Return false because the user isn't an administrator or authenticated.
            Return False

        End Function

    End Class

    '#####################################################################################
    '# this function is used to generate the serial number for the drive.  There is      #
    '# 600,000,000,000,000 different combinations that can be generates so the chance of #
    '# having a duplicate is pretty remote                                               #
    '# Referenced in form1.vb to set the serial number if there isn't one already        #
    '# assigned.                                                                         #
    '#####################################################################################
    Public Class generateSerialNumber

        Private Shared Function RandomNumber(ByVal min As Integer, ByVal max As Integer) As Integer
            Dim random As New Random()
            Return random.Next(min, max)
        End Function 'RandomNumber

        Private Shared Function RandomString(ByVal size As Integer, ByVal lowerCase As Boolean) As String
            Dim builder As New StringBuilder()
            Dim random As New Random()
            Dim ch As Char
            Dim i As Integer
            For i = 0 To size - 1
                ch = Convert.ToChar(Convert.ToInt32((25 * random.NextDouble() + 65)))
                'MsgBox(Convert.ToInt32((27 * random.NextDouble() + 65)))
                builder.Append(ch)
            Next
            If lowerCase Then
                Return builder.ToString().ToLower()
            End If
            Return builder.ToString()
        End Function 'RandomString

        Public Shared Function GetSerialNumber() As String
            Dim builder As New StringBuilder()
            builder.Append(RandomString(10, False))
            builder.Append("-")
            builder.Append(RandomNumber(100000000, 999999999))
            Return builder.ToString()
        End Function 'GetPassword
    End Class

    '#####################################################################################
    '# this function is used in the register_usb.vb form.  When the user enters their    #
    '# email this function checks to see if it fits the correct email pattern.           #
    '#####################################################################################
    Public Function EmailAddressCheck(ByVal emailAddress As String) As Boolean

        ' Original email regex validation string
        ' Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"

        'Dim pattern As String = "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
        'Dim emailAddressMatch As Match = Regex.Match(emailAddress, pattern)
        'If emailAddressMatch.Success Then
        '    EmailAddressCheck = True
        'Else
        '    EmailAddressCheck = False
        'End If

        EmailAddressCheck = True

    End Function

    '#####################################################################################
    '# this function is used to find the drive the program is running from and where     #
    '# the files are located.                                                            #
    '#####################################################################################
    ' This function is no longer used - 5/24/2011

    'Public Function getMountedDriveLetter()

    '    Dim i
    '    Dim tempPage
    '    ' create an array of letters A through Z
    '    Dim characterListing As New ArrayList()
    '    For i = 0 To 26
    '        characterListing.Add(Convert.ToChar(i + 97))
    '    Next

    '    ' not knowing how long it will take the system to mount the drive, keep looping through
    '    ' the letters until we find the discoverdrive.ini inside the encrypted volume
    '    Do Until frontPageExists = True
    '        For i = 0 To 25
    '            tempPage = characterListing.Item(i) & ":\support\discoverdrive.ini"
    '            frontPageExists = IO.File.Exists(tempPage)
    '            If frontPageExists = True Then
    '                targetDrive = characterListing.Item(i) ' set the variable to the character
    '                frontPage = targetDrive & ":\" & frontPage ' frontPage is index.htm
    '                Exit Do
    '            End If
    '        Next
    '    Loop

    '    ' add the stuff to the end of the letter here so we don't have to worry about it later
    '    targetDrive = targetDrive & ":\"

    '    Return targetDrive.ToString()

    'End Function

    '#####################################################################################
    '# this function is used to read the serial number off of the drive for registration #
    '# and update verification.  Can be used to check to see if the drive has been       #
    '# to another drive or location.
    '#####################################################################################

    Public Function getDriveSerialNumber()

        Dim fso
        Dim drv

        fso = CreateObject("Scripting.FileSystemObject")
        drv = fso.GetDrive(Microsoft.VisualBasic.Left(runningFrom, 3))

        Return drv.SerialNumber

    End Function

    '#####################################################################################
    '# Use this to kill any processes which may be left open for some unknown reason     #
    '#####################################################################################

    Public Sub killProcess(ByRef strProcessToKill As String)

        Dim matchPoint As Integer = 0
        Dim proc() As Process = Process.GetProcesses
        For i As Integer = 0 To proc.GetUpperBound(0)
            Try
                matchPoint = InStr(1, UCase(proc(i).ProcessName), UCase(strProcessToKill), CompareMethod.Text)
                If matchPoint <> 0 Then
                    proc(i).Kill()
                    matchPoint = 0
                End If
            Catch ex As Exception
                ' do nothing
            End Try
        Next
    End Sub

    Public Sub KillDrive()

        Dim sourceDir As String = ""
        Dim fileList As String()
        Dim fileExists As Boolean = False

        If modeOfOperation = "Server" Then
            Dim lastCharacter As String = Microsoft.VisualBasic.Right(runningFrom, 1)   ' get the last character
            If lastCharacter = "\" Then                                                 ' check for backslash
                sourceDir = runningFrom                                               ' if there, set variable
            Else
                sourceDir = runningFrom & "\"                                         ' if not, add backslash
            End If
        End If

        ' MsgBox("sourceDir : " & sourceDir)

        fileList = Directory.GetFiles(sourceDir, "*.*")
        For Each f As String In fileList
            fileExists = f.Contains("exe")
            If fileExists = False Then
                File.Delete(f)
            End If
        Next

        If System.IO.Directory.Exists(sourceDir & "support") Then
            System.IO.Directory.Delete(sourceDir & "support", True)
        End If

        If System.IO.Directory.Exists(sourceDir & "updates") Then
            System.IO.Directory.Delete(sourceDir & "updates", True)
        End If

        If System.IO.Directory.Exists(sourceDir & "read") Then
            System.IO.Directory.Delete(sourceDir & "read", True)
        End If

    End Sub


End Module
