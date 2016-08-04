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
Imports System.Security.Cryptography
' enables the "start" command for opening a file with it's associated program.
Imports System.Diagnostics.Process

Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Module checkStatus

    Public typeOfOperation As String = ""
    Public typeofOperationSet As Boolean = False
    Public isRegistered As String = ""
    Public isRegisteredSet As Boolean = False
    Public passwordChanged As String = ""
    Public passwordChangedSet As Boolean = False

    Dim operationsIniFile As New iniFile(runningFrom & "\support\operations.ini")
    Dim parametersIniFile As New iniFile(runningFrom & "\support\parameters.ini")

    Public Sub getOperationalStatus()

        '######################################################################################
        '# Establish encryption ability                                                       #
        '######################################################################################

        Dim doEncryption As New encryption

        '######################################################################################
        '# Check to see if the drive serial number has been set, if not then read it and      #
        '# write it to the ini file for future reference.                                     #
        '######################################################################################

        Dim DSN = operationsIniFile.GetString("Operations", "Value98", "(none)")
        MsgBox("Current DSN : " & DSN)
        Dim currentEntry As String = Microsoft.VisualBasic.Right(DSN, 9)
        If DSN = "" Or DSN = "(none)" Or currentEntry = "ZOZJ7lQ==" Then
            Dim getSN As String
            getSN = getDriveSerialNumber().ToString
            operationsIniFile.WriteString("Operations", "Value98", doEncryption.Encrypt(getSN, EncryptionKey))
        End If
        ' MsgBox(doEncryption.Decrypt(DSN, EncryptionKey))

        '######################################################################################
        '# The first thing which needs to be done is to check to see if the EULA agreement    #
        '# has(been) agreed or disagreed with.  If the person has agreed then it will be Yes  #
        '# and this will proceed from there.  Otherwise they'll get an opportunity to agree   #
        '# to it.                                                                             #
        '######################################################################################

        ' Read in the values here.  If it isn't equal to nothing or (none) then decrypt it.
        Dim Value07 = operationsIniFile.GetString("Operations", "Value07", "(none)")    'EULA agreement
        If Trim(Value07) <> "" And Value07 <> "(none)" Then                             'see what's there
            Value07 = doEncryption.Decrypt(Value07, EncryptionKey)                      'decrypt it to english
        End If

        ' Take the decrypted result and compare it.  If it isn't Yes then pull up the EULA
        If Value07 <> "Yes" Then
            Dim EULAForm As New eula()
            EULAForm.ShowDialog()
        End If

        '######################################################################################
        '# After the EULA has been taken care of, we need to see if the software has been     #
        '# setup with a default language.  If not, then run the language selection process    #
        '# to set the drive before moving on to anything else                                 #
        '######################################################################################

        Dim defaultLanguage As String = parametersIniFile.GetString("DriveInfo", "Language", "(none)")

        If defaultLanguage = "" Or defaultLanguage = "(none)" Then
            Dim selectLanguageForm As New selectLanguage
            selectLanguageForm.ShowDialog()
        End If

        '######################################################################################
        '# Check the operational mode of the software.  If we find the 'bk_manuals' file      #
        '# then we are running from the USB drive.  Otherwise we're running from a computer   #
        '######################################################################################

        modeOfOperation = operationsIniFile.GetString("Operations", "Value02", "(none)")

        ' if the mode of operation has not been previously set, then check for bk_manuals and
        ' write the result out to the operations.ini file
        If modeOfOperation = "" Or modeOfOperation = "(none)" Then

            Dim encryptedVolumePresent As Boolean = False
            encryptedVolumePresent = IO.File.Exists(runningFrom & encryptedVolume)
            ' MsgBox(encryptedVolumePresent)

            If encryptedVolumePresent = True Then                               ' the encrypted volume exists

                ' we have USB mode of operation
                operationsIniFile.WriteString("Operations", "Value02", doEncryption.Encrypt("USB", EncryptionKey))
                modeOfOperation = "USB"

            Else                                                                ' else

                ' we have Server mode of operation
                operationsIniFile.WriteString("Operations", "Value02", doEncryption.Encrypt("Server", EncryptionKey))
                modeOfOperation = "Server"

                ' If this is running from the server, then write Yes to the password changed ini setting to
                ' take that out of the mix
                operationsIniFile.WriteString("Operations", "Value06", "Yes")

            End If
        Else

            modeOfOperation = doEncryption.Decrypt(operationsIniFile.GetString("Operations", "Value02", "(none)"), EncryptionKey)

        End If


        'MsgBox(modeOfOperation)

        '######################################################################################
        '# if there is no serial number i.e. the first time it's run, then generate on and    #
        '# write it back out to the parameters.ini file                                       #
        '######################################################################################

        Dim SerialNumber = operationsIniFile.GetString("SerialNumber", "SerialNumber", "(none)")  ' generated serial number

        If SerialNumber = "(none)" Or SerialNumber = "" Then

            Dim handleEncryption As New encryption      ' setup the class
            SerialNumber = handleEncryption.Encrypt(generateSerialNumber.GetSerialNumber(), EncryptionKey)
            operationsIniFile.WriteString("SerialNumber", "SerialNumber", SerialNumber)   ' write it to the ini file

        End If

        '######################################################################################
        '# read the variables stored in the operations.ini file to determine the status of    #
        '# the software.  Looking to see if the password has been changed, if the operational #
        '# status has been set and if the software has been registered.                       #
        '######################################################################################
        ' check to see if the USB password has been changed
        ' do this first because if this is a server operation then we'll
        ' modify this value to YES because server operation does not use
        ' any type of encryption
        ' testing message boxes to look at values in the ini file

        Value02 = operationsIniFile.GetString("Operations", "Value02", "(none)") 'USB or Server?
        Value04 = operationsIniFile.GetString("Operations", "Value04", "(none)") 'registered?
        Value06 = operationsIniFile.GetString("Operations", "Value06", "(none)") 'password changed?

        'MsgBox("checkstatus Value06 : " & Value06)
        'MsgBox("checkstatus Value02 : " & Value02)
        'MsgBox("checkstatus Value04 : " & Value04)

        passwordChanged = Value06
        If passwordChanged <> "Yes" Then
            passwordChangedSet = False
        Else
            passwordChangedSet = True
        End If

        ' check to see if the drive has been registered or not 
        isRegistered = Value04
        If isRegistered <> "Yes" Then
            isRegisteredSet = False
        Else
            isRegisteredSet = True
        End If

        '######################################################################################
        '# Once the variables have been read from the ini file and the boolean items have     #
        '# been set, use those booleans to set the value of the operationalState so we know   #
        '# what to do next                                                                    #
        '######################################################################################

        ' MsgBox("checkStatus: " & passwordChangedSet & " | " & typeofOperationSet & " | " & isRegisteredSet)

        ' If the password has been changed, the operational mode has been set and the software
        ' has been registered
        If passwordChangedSet = True And isRegisteredSet = True Then
            operationalState = "1"
        End If

        ' if the password has been changed and the operational mode has been set but the software
        ' has not been registered for some reason
        If passwordChangedSet = True And isRegisteredSet = False Then
            operationalState = "2"
        End If

        ' nothing has been done.  This is the first time the software has been run
        If passwordChangedSet = False And isRegisteredSet = False Then
            operationalState = "3"
        End If

        ' Person has not changed the password yet
        If passwordChangedSet = False And isRegisteredSet = True Then
            operationalState = "4"
        End If

        ' message boxes to check the values that have been set
        ' MsgBox("OperationalState : " & operationalState)

    End Sub

End Module
