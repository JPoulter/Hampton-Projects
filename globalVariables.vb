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
Imports System.Text
Imports System.Security.Cryptography

Module globalVariables

    Public opsManualOpen As String = "False"

    Public thisComputerName = UCase(Environ("computerName"))
    Public the32bitProgramFiles = Environ("ProgramFiles")       ' 32-bit program files directory
    Public the64bitProgramFiles = Environ("ProgramFiles(x86)")  ' 64-bit program files directory
    Public realTruecryptFolder = "\Truecrypt\TrueCrypt.exe"     ' default Truecrypt installation folders
    Public truecrypt32Folder                                    ' = the32bitProgramFiles & realTruecryptFolder
    Public truecrypt64Folder                                    ' = the64bitProgramFiles & realTruecryptFolder
    Public does32Exist = False                                  ' does truecrypt32Folder exist?
    Public does64Exist = False                                  ' does truecrypt64Folder exist?
    Public runningFrom = CurDir()                               ' shows current location the start.exe file is running from
    Public userPassword As String = ""                          ' zero it out on program start
    Public targetDrive = ""                                     ' default drive letter for mounting encrypted volume
    Public frontPage = targetDrive & "available.ini"            ' empty file to look for
    Public frontPageExists = False                              ' does the 'frontPage' file exist?
    Public Visible = False                                      ' turn visibility off
    Public EncryptionKey = "2Yi*Eq}46_XoWf/5c"                  ' set an encryption string for use
    Public accessUsername = "burgerking"                        ' username to access protected directories
    Public accessPassword = "S%r9!8BcF}x6+5NyT*z2"              ' password to access protected directories
    Public modeOfOperation As String = ""                       ' Is this running from a USB or computer?
    Public IsBK As Boolean = False                              ' variable to identify BK corporate vs. Franchise systems
    Public adminUser As Boolean = checkGroup.isAdministrator()  ' does the user have admin rights?
    Public operationalState As String = ""                      ' usb or server?/registered?/pw changed?
    Public encryptedVolume As String = "bk_manuals"             ' name of the encrypted volume to look for
    Public USBTrueCrypt As String = "TrueCrypt\TrueCrypt.exe"  ' location of TrueCrypt on the USB Drive
    Public registrationType As String = ""                      ' used in non-encrypted software registration

    ' Get the prompts in the applicable language

    Dim startIniFile As New iniFile(runningFrom & "\support\start.ini")
    Dim readThispromptNumber As New readINIFile

    Public Prompt01 = readThispromptNumber.getFormText("Prompt01") ' Burger King® Operations Resources
    Public Prompt02 = readThispromptNumber.getFormText("Prompt02") ' Encryption Installed
    Public Prompt03 = readThispromptNumber.getFormText("Prompt03") ' Encryption Not Installed
    Public Prompt04 = readThispromptNumber.getFormText("Prompt04") ' Enter your Password
    Public Prompt05 = readThispromptNumber.getFormText("Prompt05") ' Operations Manual
    Public Prompt06 = readThispromptNumber.getFormText("Prompt06") ' RightTRACK Training
    Public Prompt07 = readThispromptNumber.getFormText("Prompt07") ' Update
    Public Prompt08 = readThispromptNumber.getFormText("Prompt08") ' How are you accessing this program?
    Public Prompt09 = readThispromptNumber.getFormText("Prompt09") ' USB Drive
    Public Prompt10 = readThispromptNumber.getFormText("Prompt10") ' Restaurant Computer
    Public Prompt11 = readThispromptNumber.getFormText("Prompt11") ' Select
    Public Prompt16 = readThispromptNumber.getFormText("Prompt16") ' USB Operation
    Public Prompt17 = readThispromptNumber.getFormText("Prompt17") ' Restaurant Computer Operation
    Public Prompt29 = readThispromptNumber.getFormText("Prompt29") ' Remove the USB drive when complete
    Public Prompt30 = readThispromptNumber.getFormText("Prompt30") ' Corporate
    Public Prompt31 = readThispromptNumber.getFormText("Prompt31") ' Franchise
    Public Prompt32 = readThispromptNumber.getFormText("Prompt32") ' Alert!
    Public Prompt37 = readThispromptNumber.getFormText("Prompt37") ' You have selected
    Public Prompt62 = readThispromptNumber.getFormText("Prompt62") ' Error

    ' get prompts to display on the screen
    'Public Prompt01 = startIniFile.GetString("StartPrompts", "Prompt01", "(none)") ' Burger King® Operations Resources
    'Public Prompt02 = startIniFile.GetString("StartPrompts", "Prompt02", "(none)") ' Encryption Installed
    'Public Prompt03 = startIniFile.GetString("StartPrompts", "Prompt03", "(none)") ' Encryption Not Installed
    'Public Prompt04 = startIniFile.GetString("StartPrompts", "Prompt04", "(none)") ' Enter your Password
    'Public Prompt05 = startIniFile.GetString("StartPrompts", "Prompt05", "(none)") ' Operations Manual
    'Public Prompt06 = startIniFile.GetString("StartPrompts", "Prompt06", "(none)") ' RightTRACK Training
    'Public Prompt07 = startIniFile.GetString("StartPrompts", "Prompt07", "(none)") ' Update
    'Public Prompt08 = startIniFile.GetString("StartPrompts", "Prompt08", "(none)") ' How are you accessing this program?
    'Public Prompt09 = startIniFile.GetString("StartPrompts", "Prompt09", "(none)") ' USB Drive
    'Public Prompt10 = startIniFile.GetString("StartPrompts", "Prompt10", "(none)") ' Restaurant Computer
    'Public Prompt11 = startIniFile.GetString("StartPrompts", "Prompt11", "(none)") ' Select
    'Public Prompt16 = startIniFile.GetString("StartPrompts", "Prompt16", "(none)") ' USB Operation
    'Public Prompt17 = startIniFile.GetString("StartPrompts", "Prompt17", "(none)") ' Restaurant Computer Operation
    'Public Prompt29 = startIniFile.GetString("StartPrompts", "Prompt29", "(none)") ' Remove the USB drive when complete
    'Public Prompt30 = startIniFile.GetString("StartPrompts", "Prompt30", "(none)") ' Corporate
    'Public Prompt31 = startIniFile.GetString("StartPrompts", "Prompt31", "(none)") ' Franchise
    'Public Prompt32 = startIniFile.GetString("StartPrompts", "Prompt32", "(none)") ' Alert!
    'Public Prompt37 = startIniFile.GetString("StartPrompts", "Prompt37", "(none)") ' You have selected
    'Public Prompt62 = startIniFile.GetString("StartPrompts", "Prompt62", "(none)") ' Error


    ' get operational values for the program
    Dim operationsIniFile As New iniFile(runningFrom & "\support\operations.ini")

    Public Value02 = operationsIniFile.GetString("Operations", "Value02", "(none)") 'USB or server operation
    Public Value04 = operationsIniFile.GetString("Operations", "Value04", "(none)") 'registered? Yes or No
    Public Value06 = operationsIniFile.GetString("Operations", "Value06", "(none)") 'password changed? Yes or No

    ' get operational values for the program
    Dim parametersIniFile As New iniFile(runningFrom & "\support\parameters.ini")
    Public RTLsetting = parametersIniFile.GetString("DriveInfo", "RTL", "(none)")   'left-to-right or right-to-left


    ' The URLs in the parameters.ini file are encrypted to keep people from knowing where
    ' they point to.  We need to decrypt those URLs for use inside the program.

    Dim handleEncryption As New encryption      ' setup the class
    Dim temptext As String                      ' establish a temporary string to use

    Dim tt1 As String = parametersIniFile.GetString("Operations", "SupportURL", "(none)")        'support web site
    Public SupportURL = handleEncryption.Decrypt(tt1, EncryptionKey)               'extract the information

    Dim tt2 As String = parametersIniFile.GetString("Operations", "UpdateURL", "(none)")         'register web site
    Public UpdateURL = handleEncryption.Decrypt(tt2, EncryptionKey)                'extract the information

    Dim tt3 As String = parametersIniFile.GetString("Operations", "ProgramDataURL", "(none)")    'program data
    Public ProgramDataURL = handleEncryption.Decrypt(tt3, EncryptionKey)           'extract the information

    ' set the minimum password length
    Public minimumPasswordLength = parametersIniFile.GetString("DriveInfo", "PWMinimum", "4")

End Module
