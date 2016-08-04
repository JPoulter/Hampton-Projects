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
Imports System.Drawing
Imports System.Threading
Imports System.Web
Imports System.Diagnostics.Process

Public Class selectLanguage

    Dim parametersIniFile As New iniFile(runningFrom & "\support\parameters.ini")
    Dim WGetParameters = parametersIniFile.GetString("DriveInfo", "WGetParameters", "")
    Dim ZipParameters = parametersIniFile.GetString("DriveInfo", "ZipParameters", "")

    Dim englishPrompt1 As String = ""
    Dim englishPrompt2 As String = ""
    Dim englishPrompt3 As String = ""
    Dim totalenglishPrompt As String = ""
    Dim englishLabelDisplay As String = ""
    Dim englishConfirm As String = ""
    Dim englishInstall As String = ""
    Dim englishExitConfig As String = ""
    Dim englishError As String = ""
    Dim englishNoRights1 As String = ""
    Dim englishNoRights2 As String = ""
    Dim englishNoRights3 As String = ""
    Dim totalenglishNoRightsPrompt As String = ""
    Dim englishPleaseWait As String = ""


    Dim germanPrompt1 As String = ""
    Dim germanPrompt2 As String = ""
    Dim germanPrompt3 As String = ""
    Dim totalgermanPrompt As String = ""
    Dim germanLabelDisplay As String = ""
    Dim germanConfirm As String = ""
    Dim germanInstall As String = ""
    Dim germanExitConfig As String = ""
    Dim germanError As String = ""
    Dim germanNoRights1 As String = ""
    Dim germanNoRights2 As String = ""
    Dim germanNoRights3 As String = ""
    Dim totalgermanNoRightsPrompt As String = ""
    Dim germanPleaseWait As String = ""

    Dim spanishPrompt1 As String = ""
    Dim spanishPrompt2 As String = ""
    Dim spanishPrompt3 As String = ""
    Dim totalspanishPrompt As String = ""
    Dim spanishLabelDisplay As String = ""
    Dim spanishConfirm As String = ""
    Dim spanishInstall As String = ""
    Dim spanishExitConfig As String = ""
    Dim spanishError As String = ""
    Dim spanishNoRights1 As String = ""
    Dim spanishNoRights2 As String = ""
    Dim spanishNoRights3 As String = ""
    Dim totalspanishNoRightsPrompt As String = ""
    Dim spanishPleaseWait As String = ""

    Dim totalConfirmationPrompt As String = ""
    Dim startInstallationPrompt As String = ""
    Dim totalExitConfigurationPrompt As String = ""
    Dim totalNoRightsPrompt As String = ""
    Dim totalPleaseWait As String = ""

    Dim ItemSelected As Integer
    Dim ItemName As String = ""

    Dim newStartINI As String = ""
    Dim newOpsManual As String = ""
    Dim tempvariables(5) As String
    Dim currentDownload As String = ""
    Dim modeOfOperation As String = ""
    Dim disconnectDriveLetter As String = ""

    Dim encryptedVolumePresent As Boolean = False
    Dim hasLoggedIn As Boolean = False
    Dim threadEnded As Boolean = False

    Dim pwcDone As Boolean = False
    Dim x As Integer = 1



    Private Sub selectLanguage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        englishLabelDisplay = "Select Language"
        englishPrompt1 = "This is a one time only selection which you need to make.  The Language you select will be used to configure this software for your use."
        englishPrompt2 = "Once you have selected a language, and verified your choice, the program will download and install all the applicable files."
        englishPrompt3 = "Make sure you have selected the correct language.  Once you have done so, there is no way to change the operation to another Language!"
        totalenglishPrompt = englishPrompt1 & vbCrLf & vbCrLf & englishPrompt2 & vbCrLf & vbCrLf & englishPrompt3
        englishError = "There was a problem connecting to the site." & vbCrLf & "Please Try again later."
        englishConfirm = "You have selected the following Language." & vbCrLf & "Are you sure?"
        englishInstall = "The configuration download and installation process can take several minutes to complete depending upon the speed of your network.  DO NOT interrupt this process!"
        englishExitConfig = "Exit Configuration"
        englishNoRights1 = "Please contact your IT support to have the TrueCrypt® software installed onto your system.  You cannot utilize this program until that has been done."
        englishNoRights2 = "You do not have sufficient rights to install programs on this computer."
        englishNoRights3 = "If you have access to the adminstrator username and password, you can right click on the program and select 'Run as Administrator'."
        totalenglishNoRightsPrompt = englishNoRights1 & vbCrLf & englishNoRights2 & vbCrLf & englishNoRights3
        englishPleaseWait = "Please wait.  Finalizing the installation."

        germanLabelDisplay = "Sprache wählen"
        germanPrompt1 = "Diese Auswahl ist obligatorisch. Sie können Sie nur einmal vornehmen.  Mit der ausgewählten Sprache wird diese Software für Ihre Nutzung konfiguriert."
        germanPrompt2 = "Nachdem Sie eine Sprache ausgewählt und Ihre Auswahl bestätigt haben, lädt das Programm alle zutreffenden Dateien herunter und installiert sie."
        germanPrompt3 = "Achten Sie darauf, die korrekte Sprache auszuwählen.  Nachdem Sie Ihre Auswahl bestätigt haben, lässt sich die Spracheinstellung nicht mehr ändern!"
        totalgermanPrompt = germanPrompt1 & vbCrLf & vbCrLf & germanPrompt2 & vbCrLf & vbCrLf & germanPrompt3
        germanError = "Beim Herstellen einer Verbindung zur Website ist ein Fehler aufgetreten." & vbCrLf & "Versuchen Sie es bitte später noch einmal."
        germanConfirm = "Sie haben die folgende Sprache ausgewählt." & vbCrLf & "Sind Sie sicher?"
        germanInstall = "Das Herunterladen und Installieren der Konfiguration kann je nach Geschwindigkeit Ihres Netzwerks einige Minuten dauern.  Unterbrechen Sie diesen Vorgang NICHT!"
        germanExitConfig = "Konfiguration beenden"
        germanNoRights1 = "Bitten Sie den IT-Support, die TrueCrypt®-Software auf Ihrem Rechner zu installieren.  Sie können dieses Programm erst verwenden, nachdem diese Software installiert wurde."
        germanNoRights2 = "Sie haben nicht die erforderlichen Rechte zum Installieren von Programmen auf diesem Computer."
        germanNoRights3 = "Wenn Sie Zugriff auf den Benutzernamen und das Passwort des Administrators haben, können Sie mit der rechten Maustaste auf das Programm klicken und " & Chr(132) & "Run as Administrator" & Chr(147) & " (Als Administrator ausführen) auswählen."
        totalgermanNoRightsPrompt = germanNoRights1 & vbCrLf & germanNoRights2 & vbCrLf & germanNoRights3
        germanPleaseWait = "Bitte warten Sie. Festlegen der Installation."

        spanishLabelDisplay = "Seleccione un idioma"
        spanishPrompt1 = "Sólo tendrá que hacer esta selección una vez.  El idioma que seleccione será el utilizado para configurar este software para su uso."
        spanishPrompt2 = "Una vez que haya seleccionado un idioma y verificado su elección, el programa descargará e instalará todos los archivos correspondientes."
        spanishPrompt3 = "Asegúrese de haber seleccionado el idioma correcto.  Una vez seleccionado, no es posible cambiar la operación a otro idioma."
        totalspanishPrompt = spanishPrompt1 & vbCrLf & vbCrLf & spanishPrompt2 & vbCrLf & vbCrLf & spanishPrompt3
        spanishError = "Se produjo un problema al conectarse al sitio." & vbCrLf & "Inténtelo de nuevo más tarde."
        spanishConfirm = "Ha seleccionado el siguiente idioma." & vbCrLf & "¿Está seguro?"
        spanishInstall = "El proceso de descarga e instalación puede durar varios minutos, según la rapidez de la red.  NO detenga ni interrumpa este proceso."
        spanishExitConfig = "Salir de la configuración"
        spanishNoRights1 = "Póngase en contacto con su servicio de asistencia técnica de TI para que instale el software TrueCrypt®.  No puede utilizar este programa hasta que se haya completado la acción."
        spanishNoRights2 = "No dispone de los privilegios necesarios para instalar programas en esta computadora."
        spanishNoRights3 = "Si tiene acceso al nombre y contraseña del administrador, puede hacer clic derecho en el programa y seleccionar " & Chr(34) & "Ejecutar como Administrador" & Chr(34) & "."
        totalspanishNoRightsPrompt = spanishNoRights1 & vbCrLf & spanishNoRights2 & vbCrLf & spanishNoRights3
        spanishPleaseWait = "Espere por favor. Completar la instalación."

        totalConfirmationPrompt = englishConfirm & vbCrLf & vbCrLf & germanConfirm & vbCrLf & vbCrLf & spanishConfirm
        startInstallationPrompt = englishInstall & vbCrLf & vbCrLf & germanInstall & vbCrLf & vbCrLf & spanishInstall
        totalExitConfigurationPrompt = englishExitConfig & vbCrLf & vbCrLf & germanExitConfig & vbCrLf & vbCrLf & spanishExitConfig
        totalNoRightsPrompt = totalenglishNoRightsPrompt & vbCrLf & vbCrLf & totalgermanNoRightsPrompt & vbCrLf & vbCrLf & totalspanishNoRightsPrompt
        totalPleaseWait = englishPleaseWait & vbCrLf & vbCrLf & germanPleaseWait & vbCrLf & vbCrLf & spanishPleaseWait

        ' check to see if the encrypted volume is present in the operational folder.  If it 
        ' isn't there, then we're running on a server.  If this is the case then don't run
        ' the disconnect encrypted volume code in the disconnectTC() subroutine
        encryptedVolumePresent = IO.File.Exists(runningFrom & encryptedVolume)

        SetToolTips()

        Panel1.BringToFront()

        englishLabel.Text = englishLabelDisplay
        englishInstructions.Text = totalenglishPrompt

        germanLabel.Text = germanLabelDisplay
        germanInstructions.Text = totalgermanPrompt

        spanishLabel.Text = spanishLabelDisplay
        spanishInstructions.Text = totalspanishPrompt

        ' We need to know if the encrypted volume is present or not.  If not, then we can unzip the
        ' baseload file onto the unit.  If it is there, then we need to open up the encrypted volume
        ' with the default password and then unzip the files there.

        ' MsgBox(runningFrom & encryptedVolume & vbCrLf & encryptedVolumePresent)
        ' MsgBox("Line 160 - Running From : " & runningFrom & vbCrLf & "Encrypted Volume : " & encryptedVolume & vbCrLf & "encryptedVolumePresent : " & encryptedVolumePresent)
        ' If the encrypted volume is present, then we need to see if truecrypt is installed on the
        ' system or not.  If not, then it needs to be installed.

        If encryptedVolumePresent = True Then

            checkForTrueCryptInstallation()
            modeOfOperation = "USB"
            ' MsgBox("Line 161: Mode of Operation - " & modeOfOperation)

            ' if Truecrypt exists on the system at this point, then log into the encrypted volume using the
            ' default password - "whopper"
            If does32Exist = True Or does64Exist = True Then
                loginToVolume()
            End If

        Else

            modeOfOperation = "Server"

        End If

        If modeOfOperation = "Server" Then
            runningFrom = runningFrom & "\"
            Dim startIniFile As New iniFile(runningFrom & "support\start.ini")
        End If

        ' MsgBox("Mode of operation : " & modeOfOperation)
        ' MsgBox("Running From : " & runningFrom)

        ' get the listing of available languages from the web site.
        getLanguages()

    End Sub


    '######################################################################################
    '# Query the online database and get a listing of available languages and applicable  #
    '# codes to populate the dropdown listing                                             #
    '######################################################################################

    Private Sub getLanguages()

        Me.Cursor = Cursors.WaitCursor

        Dim whichURL As String = ProgramDataURL & "?queryType=getLanguages"
        'MsgBox(whichURL)
        Try
            Dim request As HttpWebRequest = HttpWebRequest.Create(whichURL)

            ' If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials

            ' Get the response.
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

            ' Display the status.
            ' MsgBox(response.StatusDescription)
            ' MsgBox(response.StatusCode)
            ' 200 is an OK response from a web site when it is contacted.  Anything other
            ' then 200 means there was an issue.
            If response.StatusCode = "200" Then
                Dim strRowSource As String = ""
                ' Get the stream containing content returned by the server.
                Dim dataStream As Stream = response.GetResponseStream()
                ' Open the stream using a StreamReader for easy access.
                Dim reader As New StreamReader(dataStream)
                ' Read the content.
                Dim responseFromServer As String = reader.ReadToEnd()

                ' MsgBox(responseFromServer)

                ' The | character is used to separate the response items.  This
                ' code will split it out into it's separate parts
                Dim split As String() = responseFromServer.Split(New [Char]() {"|"c})

                Dim i As Integer = 0
                Dim j As Integer = 0
                Dim tempLangvariables(100) As String

                For Each segment As String In split
                    If segment.Trim() <> "" Then
                        tempLangvariables(i) = CStr(segment)
                        i = i + 1
                    End If
                Next segment
                ' MsgBox("Total in array : " & i & vbCrLf & "Divided by 2 = " & (i / 2))

                LanguageList.BeginUpdate()
                For j = 0 To (i - 2) Step 2
                    LanguageList.Items.Add(New ValueDescriptionPair(CInt(tempLangvariables(j)), tempLangvariables(j + 1).ToString()))
                Next
                LanguageList.EndUpdate()

                ' Cleanup the streams and the response.
                reader.Close()
                dataStream.Close()
                response.Close()

                ' remove the please wait from the screen
                ' put the cursor back to normal
                Me.Cursor = Cursors.Default
                ' enable the drop down and focus on it
                LanguageList.Enabled = True

            End If

        Catch ex As Exception
            'MsgBox("Calling disconnect from line 277")
            disconnectTC()

            MsgBox(englishError & vbCrLf & vbCr & _
                   germanError & vbCrLf & vbCr & _
                   spanishError & vbCrLf & vbCr & _
                   "Error 283: " & ex.ToString(), MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Language Selection")
            End

        End Try


        ' kill the background thread filling out the dropdown list
        ' getRN.Abort()
        Me.Cursor = Cursors.Default
    End Sub

    '######################################################################################
    '# On a change to the language selection dropdown listing, grab the associated        #
    '# variables tied to the persons selection                                            #
    '######################################################################################

    Private Sub LanguageList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LanguageList.SelectedIndexChanged

        ItemName = ""

        ItemSelected = CType(LanguageList.SelectedItem, ValueDescriptionPair).Value     ' id_language number
        ItemName = CType(LanguageList.SelectedItem, ValueDescriptionPair).Description   ' the descriptive language name
        'MsgBox("Value Selected = " & ItemSelected, MsgBoxStyle.Information)
        'MsgBox("Item Selected = " & ItemName, MsgBoxStyle.Information)

    End Sub

    '######################################################################################
    '# if the user selects the NO button on the screen, hide the current panel and take   #
    '# them back to the first panel                                                       #
    '######################################################################################

    Private Sub noButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles noButton.Click

        Panel2.Visible = False
        Panel1.Visible = True
        Panel1.BringToFront()

    End Sub

    '######################################################################################
    '# If the person selects the YES button, hide the confirmation panel and take them    #
    '# to the download & install panel                                                    #
    '######################################################################################

    Private Sub yesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles yesButton.Click

        Panel2.Visible = False
        Panel3.Visible = True
        Panel3.BringToFront()
        installationPrompt.Text = startInstallationPrompt
        installThisLanguage.Text = ItemName

    End Sub

    '######################################################################################
    '# if the user selects the NO button on the screen, hide the current panel and take   #
    '# them back to the first panel                                                       #
    '######################################################################################

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitDownloadButton.Click
        'MsgBox("Calling disconnect from line 344")
        disconnectTC()              ' disconnect from any mounted drive
        Panel3.Visible = False
        Panel1.Visible = True

    End Sub

    '######################################################################################
    '# After the person has selected a language from the dropdown listing, the then need  #
    '# to click the SELECT button.  When they do, set the variables and bring up the      #
    '# first confirmation screen.                                                         #
    '######################################################################################

    Private Sub chooseLanguageButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chooseLanguageButton.Click

        confirmLanguagePrompt.Text = totalConfirmationPrompt
        selectedLanguage.Text = ItemName
        Panel1.Visible = False
        Panel3.Visible = False
        Panel2.Visible = True
        Panel2.BringToFront()

    End Sub

    '######################################################################################
    '# Exit the program if the person clicks on the exit button in the top right corner   #
    '# of the form                                                                        #
    '######################################################################################

    Private Sub ExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        'MsgBox("Calling disconnect from line 374")

        If encryptedVolumePresent = True Then
            disconnectTC()                          ' disconnect from any mounted drive
            End
        Else
            End
        End If

    End Sub


    '######################################################################################
    '# This is where the heavy lifting takes place.  When the person clicks the START     #
    '# button start by going out and getting the langauage abbreviation.  We need that    #
    '# because the abbreviation is used to build the download URL to get the start.ini    #
    '# file for that language along with the [language_abbreviation]_baseload.zip to      #
    '# populate the read folder                                                           #
    '######################################################################################

    Private Sub StartDownloadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartDownloadButton.Click

        Me.Cursor = Cursors.WaitCursor

        installThisLanguage.Visible = False

        Dim whichURL As String = ProgramDataURL & "?queryType=setLanguage&selectedLanguage=" & ItemSelected
        'MsgBox("Line 404, whichURL : " & whichURL)

        Try
            Dim request As HttpWebRequest = HttpWebRequest.Create(whichURL)

            ' If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials

            ' Get the response.
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

            ' Display the status.
            ' MsgBox(response.StatusDescription)
            ' MsgBox(response.StatusCode)
            ' 200 is an OK response from a web site when it is contacted.  Anything other
            ' then 200 means there was an issue.
            If response.StatusCode = "200" Then
                Dim strRowSource As String = ""
                ' Get the stream containing content returned by the server.
                Dim dataStream As Stream = response.GetResponseStream()
                ' Open the stream using a StreamReader for easy access.
                Dim reader As New StreamReader(dataStream)
                ' Read the content.
                Dim responseFromServer As String = reader.ReadToEnd()

                ' MsgBox("response from server L429 : " & responseFromServer)

                ' The | character is used to separate the response items.  This
                ' code will split it out into it's separate parts
                Dim split As String() = responseFromServer.Split(New [Char]() {"|"c})

                Dim i As Integer = 0

                For Each segment As String In split
                    If segment.Trim() <> "" Then
                        tempvariables(i) = CStr(segment)
                        i = i + 1
                    End If
                Next segment

                ' Cleanup the streams and the response.
                reader.Close()
                dataStream.Close()
                response.Close()

                ' The first thing we need to do is establish the download URLs to get the
                ' files from the support server and into the UPDATES folder.
                newStartINI = "http://" & _
                              SupportURL & "/downloads/" & _
                              tempvariables(0) & "/" & tempvariables(0) & "_start.ini"

                newOpsManual = "http://" & _
                              SupportURL & "/downloads/" & _
                              tempvariables(0) & "/" & tempvariables(0) & "_baseload.zip"

                'MsgBox(newStartINI)
                'MsgBox(newOpsManual)

                downloadStartFile()                                 ' download the start.ini file
                downloadSelectedBaseFile()                          ' download the base language file

                'MsgBox("Line 422 : Finished the base download")

                ' put the cursor back to normal
                Me.Cursor = Cursors.Default

                'parametersIniFile.WriteString("DriveInfo", "Language", tempvariables(0))
                'parametersIniFile.WriteString("DriveInfo", "RTL", tempvariables(1))
                'parametersIniFile.WriteString("DriveInfo", "Version", tempvariables(2))
                ' MsgBox("Line 452 : " & modeOfOperation)
                'If modeOfOperation = "USB" Then
                '    MsgBox("Calling disconnect from line 467")
                '    disconnectTC()
                'End If
                Me.Cursor = Cursors.AppStarting
                Me.Close()

            End If

        Catch ex As Exception

            If modeOfOperation = "USB" Then
                'MsgBox("Calling disconnect from line 478")
                disconnectTC()
            End If

            MsgBox(englishError & vbCrLf & vbCr & _
                    germanError & vbCrLf & vbCr & _
                    spanishError & vbCrLf & vbCr & _
                    "Error 485: " & ex.ToString(), MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Language Selection")
            End

        End Try

        Me.Cursor = Cursors.Default

    End Sub

    '######################################################################################
    '# Download the start.ini file from the web site                                      #
    '######################################################################################

    Public Sub downloadStartFile()


        Dim returnCode As Integer
        Dim p As New Process

        currentDownload = tempvariables(0) & "_start.ini"                   ' i.e. USEN_start.ini

        'MsgBox("Line 514 current download : " & currentDownload)
        Directory.SetCurrentDirectory(runningFrom & "updates")              ' download to the updates directory..

        Dim fileFrom As String = runningFrom & "updates\" & currentDownload
        Dim fileTo As String = runningFrom & "support\start.ini"

        p.StartInfo.FileName = runningFrom & "support\wget\wget.exe"        ' setup the wget for use
        'MsgBox("Line 505 - program to run : " & p.StartInfo.FileName)

        ' The WGet parameters are located in the parameters.ini file.  I did this in case there were
        ' issues with the download I could adjust things by updating the parameter.ini file instead of the
        ' entire .EXE file


        '#########################################################
        ' this is the production string
        '#########################################################

        Dim Parameters As String = " " & WGetParameters & _
                                   " --http-user=" & accessUsername & _
                                   " --http-password=" & accessPassword & _
                                   " " & newStartINI


        '#########################################################
        ' this is the testing string
        '#########################################################
        ' Dim Parameters As String = " " & WGetParameters & " " & newStartINI

        'MsgBox("Line 543 - WGET Parameters : " & Parameters)

        ' The first thing we need to do is get the start.ini file which contains all of the 
        ' prompts for the language the person has selected.
        Try

            p.StartInfo.Arguments = Parameters                              ' set the Wget parameters
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden             ' do it in the background
            p.Start()                                                       ' start the process
            p.WaitForExit()                                                 ' wait for the download to process
            returnCode = p.ExitCode                                         ' grab the exit code

            If returnCode = 0 Then ' 0 means success!

                ' MsgBox("Line 557 - download returncode : " & returnCode)

                ' for the start.ini file we don't need to unzip it, we just need to copy it
                ' to the correct directory for use.
                Try

                    ' once things are setup, copy the file from the updates directory to the
                    ' target directory.  In case there is an error, capture it and quite
                    File.Copy(fileFrom, fileTo, True)                       ' copy with overwrite enabled (TRUE)
                    My.Computer.FileSystem.DeleteFile(fileFrom)             ' delete the file from the updates directory

                    resetGlobals()                                          ' re-read the major global prompts
                    ' MsgBox("Line 569 : Just reset globals")

                Catch ex As Exception

                    If modeOfOperation = "USB" Then
                        'MsgBox("Calling disconnect from line 574")
                        disconnectTC()
                    End If
                    Me.Cursor = Cursors.Default                             ' restore the default cursor
                    ' alert there was a problem
                    MsgBox(englishError & vbCrLf & vbCr & _
                            germanError & vbCrLf & vbCr & _
                            spanishError & vbCrLf & vbCr & _
                            "Error 582: " & ex.ToString(), MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Language Selection")
                    End

                End Try

            Else

                If modeOfOperation = "USB" Then
                    'MsgBox("Calling disconnect from line 590")
                    disconnectTC()
                End If
                Me.Cursor = Cursors.Default                                 ' restore the default cursor
                ' alert there was a problem
                MsgBox("L595" & vbCrLf & vbCr & _
                        englishError & vbCrLf & vbCr & _
                        germanError & vbCrLf & vbCr & _
                        spanishError, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Language Selection")
                End

            End If

        Catch ex As Exception

            If modeOfOperation = "USB" Then
                'MsgBox("Calling disconnect from line 606")
                disconnectTC()
            End If
            Me.Cursor = Cursors.Default                                     ' restore the default cursor
            ' alert there was a problem
            MsgBox(englishError & vbCrLf & vbCr & _
                    germanError & vbCrLf & vbCr & _
                    spanishError & vbCrLf & vbCr & _
                    "Error 614: " & ex.ToString(), MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Language Selection")
            End

        End Try

        Me.Cursor = Cursors.Default                                         ' restore the default cursor

    End Sub

    '######################################################################################
    '# Download the base language file from the web site                                  #
    '######################################################################################

    Public Sub downloadSelectedBaseFile()

        Dim returnCode As Integer
        Dim p As New Process
        ExitButton.Enabled = False

        currentDownload = tempvariables(0) & "_baseload.zip"                ' i.e. USEN_baseload.zip

        ' MsgBox("Line 635 : " & currentDownload)
        Directory.SetCurrentDirectory(runningFrom & "updates")              ' download to the updates directory..

        p.StartInfo.FileName = runningFrom & "support\wget\wget.exe"        ' setup the wget for use
        ' MsgBox("Line 644 - program to run : " & p.StartInfo.FileName)

        ' The WGet parameters are located in the parameters.ini file.  I did this in case there were
        ' issues with the download I could adjust things by updating the parameter.ini file instead of the
        ' entire .EXE file
        Dim Parameters As String = " " & WGetParameters & _
                                   " --http-user=" & accessUsername & _
                                   " --http-password=" & accessPassword & _
                                   " " & newOpsManual
        ' MsgBox("Line 653 - WGET Parameters : " & Parameters)

        ' The first thing we need to do is get the start.ini file which contains all of the 
        ' prompts for the language the person has selected.

        Try

            p.StartInfo.Arguments = Parameters                              ' set the Wget parameters
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden             ' do it in the background
            p.Start()                                                       ' start the process

            '------------------------------------------------------------------------------------------
            ProgressBar1.Visible = True
            ProgressBar1.Step = 1                   'set the progress bar to move 1 place each time
            ProgressBar1.Minimum = 1                'minimum value for the progress bar
            ProgressBar1.Maximum = 100              'maximum value for the progress bar
            ProgressBar1.Value = 1                  'set the progress bar to 1 to begin with

            'loop through the test
            Do Until pwcDone = True

                ProgressBar1.PerformStep()
                Sleep(1250)                          'sleep for 1.5 seconds to lower CPU usage
                p.Refresh()
                pwcDone = p.HasExited()
                x = x + 1                           ' increment the value
                If x = ProgressBar1.Maximum Then    ' check to see if it's over 100
                    ProgressBar1.Value = 1          ' if so, reset to 1
                    ProgressBar1.PerformStep()      ' move the bar a bit..
                End If
            Loop
            '------------------------------------------------------------------------------------------

            returnCode = p.ExitCode                                         ' grab the exit code

            If returnCode = 0 Then ' 0 means success!

                ' MsgBox("Line 667 - download returncode : " & returnCode)

                Try

                    unZipUpdate(currentDownload)                            ' unzip the file that was just downloaded

                Catch ex As Exception

                    ExitButton.Enabled = True
                    StartDownloadButton.Text = ""
                    If modeOfOperation = "USB" Then
                        'MsgBox("Calling disconnect from line 674")
                        disconnectTC()
                    End If

                    ProgressBar1.Visible = False
                    Me.Cursor = Cursors.Default                             ' restore the default cursor
                    ' alert there was a problem
                    MsgBox(englishError & vbCrLf & vbCr & _
                            germanError & vbCrLf & vbCr & _
                            spanishError & vbCrLf & vbCr & _
                            "Error 706: " & ex.ToString(), MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Language Selection")

                End Try

            Else

                ExitButton.Enabled = True
                StartDownloadButton.Text = ""
                ProgressBar1.Visible = False
                Me.Cursor = Cursors.Default                                 ' restore the default cursor
                If modeOfOperation = "USB" Then
                    'MsgBox("Calling disconnect from line 717")
                    disconnectTC()
                End If
                ' alert there was a problem
                MsgBox(englishError & vbCrLf & vbCr & _
                        germanError & vbCrLf & vbCr & _
                        spanishError, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Language Selection")
                End

            End If

        Catch ex As Exception

            ExitButton.Enabled = True
            StartDownloadButton.Text = ""
            If modeOfOperation = "USB" Then
                'MsgBox("Calling disconnect from line 733")
                disconnectTC()
            End If

            ProgressBar1.Visible = False
            Me.Cursor = Cursors.Default                                     ' restore the default cursor
            ' alert there was a problem
            MsgBox(englishError & vbCrLf & vbCr & _
                    germanError & vbCrLf & vbCr & _
                    spanishError & vbCrLf & vbCr & _
                    "Error 743: " & ex.ToString(), MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Language Selection")
            End

        End Try

        ExitButton.Enabled = True
        StartDownloadButton.Text = ""
        ProgressBar1.Visible = False
        Me.Cursor = Cursors.Default                                         ' restore the default cursor

    End Sub

    '#######################################################################################
    '#######################################################################################
    '# unzip the file into the target location                                             #
    '#######################################################################################
    Public Sub unZipUpdate(ByVal fileToDownload)

        Dim returnCode As Integer
        Dim whichFileName As String = ""
        Dim p As New Process

        If modeOfOperation = "Server" Then
            targetDrive = runningFrom
        End If

        ' MsgBox("Line 688 ModeOfOperation : " & modeOfOperation)

        whichFileName = fileToDownload                                      ' passed from the download subroutine

        whichFileName = runningFrom & "updates\" & whichFileName            ' get it from the updates directory
        Dim unzipParameters As String = " " & ZipParameters & " " & _
                            Chr(34) & whichFileName & Chr(34)

        p.StartInfo.FileName = runningFrom & "support\7z\7za.exe"           ' set the unzip program name

        'MsgBox("Filename : " & whichFileName & vbCrLf & vbCrLf & _
        '       "Runthis : " & p.StartInfo.FileName & vbCrLf & vbCrLf & _
        '       "Unzip Parameters : " & unzipParameters & vbCrLf & vbCrLf & _
        '       "TargetDrive : " & targetDrive & vbCrLf & vbCrLf & _
        '       "Mode : " & modeOfOperation)

        Directory.SetCurrentDirectory(targetDrive)

        Try

            '#######################################################################################
            '# 7-Zip command line options                                                          #
            '#                                                                                     #
            '# x    : extract files from archive with their full paths                             #
            '# -y   : assumes YES on all 7-Zip queries during the unzipping process                #
            '# -aoa : Overwrite All existing files without prompt.                                 #
            '# -o   : Set output directory                                                         #
            '#######################################################################################

            p.StartInfo.Arguments = unzipParameters                         ' set the parameters
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden             ' do it in the background
            p.Start()                                                       ' start the process

            '------------------------------------------------------------------------------------------
            pwcDone = False
            x = 1
            ProgressBar1.Value = 1                  'set the progress bar to 1 to begin with
            ProgressBar1.Step = 1                   'set the progress bar to move 1 place each time
            ProgressBar1.Minimum = 1                'minimum value for the progress bar
            ProgressBar1.Maximum = 100              'maximum value for the progress bar

            'loop through the test
            Do Until pwcDone = True

                ProgressBar1.PerformStep()
                Sleep(1250)                         'sleep for 1.5 seconds to lower CPU usage
                p.Refresh()
                pwcDone = p.HasExited()
                x = x + 1                           ' increment the value
                If x = ProgressBar1.Maximum Then    ' check to see if it's over 100
                    ProgressBar1.Value = 1          ' if so, reset to 1
                    ProgressBar1.PerformStep()      ' move the bar a bit..
                End If
            Loop
            '------------------------------------------------------------------------------------------

            ' p.WaitForExit()                                                 ' wait for it to finish
            returnCode = p.ExitCode                                         ' get the exit code

            ' MsgBox("828 - unzip returnCode : " & returnCode)

            '#######################################################################################
            '# 7-Zip exit codes                                                                    #
            '#                                                                                     #
            '# Code(Meaning)                                                                       #
            '# 0   No error                                                                        #
            '# 1   Warning (Non fatal error(s)). For example, one or more files were locked by     #
            '#     some other application, so they were not compressed.                            #
            '# 2   Fatal error                                                                     #
            '# 7   Command line error                                                              #
            '# 8   Not enough memory for operation                                                 #
            '# 255 User stopped the process                                                        #
            '#######################################################################################

            ' If the unzipping of the file is successful, then update the version number
            ' in the parameters.ini file

            If returnCode = 0 Then

                My.Computer.FileSystem.DeleteFile(whichFileName)

                ' if the files have been successfully unzipped into the directory, then write all
                ' of the variables into the INI files to show it's been completed.

                parametersIniFile.WriteString("DriveInfo", "Language", tempvariables(0))
                parametersIniFile.WriteString("DriveInfo", "RTL", tempvariables(1))
                parametersIniFile.WriteString("DriveInfo", "Version", tempvariables(2))
                ' MsgBox("Calling disconnect from line 856")
                'MsgBox("Line 857" & vbCrLf & _
                '       "language code : " & tempvariables(0) & vbCrLf & _
                '       "RTL : " & tempvariables(1) & vbCrLf & _
                '       "Version : " & tempvariables(2))
                disconnectTC()

            End If

        Catch ex As Exception

            ExitButton.Enabled = True

            If modeOfOperation = "USB" Then
                'MsgBox("Calling disconnect from line 844")
                disconnectTC()
            End If

            ProgressBar1.Visible = False
            MsgBox(englishError & vbCrLf & vbCr & _
                    germanError & vbCrLf & vbCr & _
                    spanishError & vbCrLf & vbCr & _
                    "Error 852: " & ex.ToString(), MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Language Selection")
            End

        End Try

        Directory.SetCurrentDirectory(runningFrom)

    End Sub

    ' dismount the encrypted volume and then exit from the program
    Private Sub disconnectTC()

        Dim HasChanged As Boolean = False
        Do Until HasChanged = True
            ProgressBar1.Visible = False
            installationPrompt.Text = totalPleaseWait
            installationPrompt.BackColor = Color.White
            installationPrompt.ForeColor = Color.Red
            Dim myfont As New Font("Sans Serif", 16, FontStyle.Regular)
            installationPrompt.Font = myfont
            installationPrompt.TextAlign = ContentAlignment.MiddleCenter
            StartDownloadButton.Visible = False
            ExitDownloadButton.Visible = False
            ExitButton.Enabled = True
            HasChanged = True
        Loop
        MsgBox(totalPleaseWait, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Language Selection")


        ' if the encrypted volume is present then run TC disconnect parameters to close the volume out.
        ' if it isn't present, then disregard all the TC stuff and proceed

        If encryptedVolumePresent = True Then

            ' see explaination of these parameters in the parameters.ini file.  The parameters have been
            ' moved to the parameters.ini file for ease of changing in case there is an issue.
            Dim dismountParameters As String = " " & parametersIniFile.GetString("DriveInfo", "TCUnload", "/s /f /q /w /d")
            ' dismountParameters = dismountParameters & " " & disconnectDriveLetter
            Dim p As New ProcessStartInfo

            If does32Exist Then
                p.FileName = truecrypt32Folder ' 32-bit TC location
            Else
                p.FileName = truecrypt64Folder ' 64-bit TC location
            End If

            p.Arguments = dismountParameters
            p.WindowStyle = ProcessWindowStyle.Hidden

            ' MsgBox("Truecrypt location : " & p.FileName.ToString() & vbCrLf & "Arguments : " & p.Arguments.ToString())

            Try
                Dim myProcess = Process.Start(p)
                myProcess.WaitForExit()
                ' MsgBox("Line 885 Exit Code : " & myProcess.ExitCode.ToString())
            Catch ex As Exception

                MsgBox(englishError & vbCrLf & vbCr & _
                        germanError & vbCrLf & vbCr & _
                        spanishError & vbCrLf & vbCr & _
                        "Error 903: " & ex.ToString(), MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Language Selection")
                End

            End Try

        End If

    End Sub


    '######################################################################################
    '# Create all the tool tips for the page                                              #
    '######################################################################################

    Private Sub SetToolTips()
        Dim apdelay As Integer = 6000
        Dim delay As Integer = 100

        ' this is the tooltip for the exit button
        Dim TT_exit As New ToolTip()
        TT_exit.AutoPopDelay = apdelay
        TT_exit.InitialDelay = delay
        TT_exit.ReshowDelay = delay
        TT_exit.ShowAlways = True
        TT_exit.IsBalloon = True
        TT_exit.BackColor = Color.LightBlue
        TT_exit.ForeColor = Color.DarkBlue
        TT_exit.ToolTipIcon = ToolTipIcon.Info
        TT_exit.UseAnimation = True
        TT_exit.UseFading = True
        TT_exit.SetToolTip(Me.ExitButton, totalExitConfigurationPrompt)

    End Sub

    '####################################################################################
    '####################################################################################
    '# Check to see if TrueCrypt is installed on the computer.  Check for both a 32 or  #
    '# 64-bit version.                                                                  #
    '####################################################################################

    Private Sub checkForTrueCryptInstallation()

        If the32bitProgramFiles <> "\" And the32bitProgramFiles <> "" Then  ' if this is a 32-bit system.....
            truecrypt32Folder = the32bitProgramFiles & realTruecryptFolder  ' create the TC folder structure...
            does32Exist = IO.File.Exists(truecrypt32Folder)                 ' set does32Exist to TRUE
        End If

        If the64bitProgramFiles <> "\" And the64bitProgramFiles <> "" Then  ' if this is a 64-bit system...
            truecrypt64Folder = the64bitProgramFiles & realTruecryptFolder  ' create the TC folder structure...
            does64Exist = IO.File.Exists(truecrypt64Folder)                 ' set does64Exist to TRUE
        End If

        If does32Exist = False And does64Exist = False Then

            '-----------------------------------------------------------------------------------------
            ' If the user has admin rights on the computer they are running this on, they can either
            ' run the program from the USB drive or install TrueCrypt and proceed from there.  If they
            ' do not have admin rights, then they will have to have their IT administrator run this
            ' program the first time to install TC.
            '-----------------------------------------------------------------------------------------
            If adminUser = True Then
                Dim doTC As New installTCgeneric()                          ' target the install form
                doTC.ShowDialog()                                           ' open up the TC installation form
            Else
                ' if the user is not admin and TC is not installed the person cannot go any
                ' further.  Prompt to get IT for installation and end the program.
                MsgBox(totalNoRightsPrompt, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Select Language")
                End
            End If

        End If

        ' MsgBox("Line 914 : does32exist=" & does32Exist & vbCrLf & "does64exist=" & does64Exist)

    End Sub

    '####################################################################################
    '# Attempt to login to the encrypted volume                                         #
    '####################################################################################

    Private Sub loginToVolume()

        Dim TCLoad As String = parametersIniFile.GetString("DriveInfo", "TCLoad", "(none)")
        Dim p As New ProcessStartInfo                           ' the login process

        Dim openCommmandParameters As String = " " & TCLoad & _
                                               " " & Chr(34) & "whopper" & Chr(34) & _
                                               " " & runningFrom & "bk_manuals"
        ' MsgBox("Open parameters : " & openCommmandParameters)

        If does32Exist Then
            p.FileName = truecrypt32Folder                      ' set it to the 32-bit TC location
        Else
            p.FileName = truecrypt64Folder                      ' set it to the 64-bit TC location
        End If

        ' MsgBox("Run This : " & p.FileName)

        p.Arguments = openCommmandParameters                                ' The parameters for opening the encrypted volume
        p.WindowStyle = ProcessWindowStyle.Hidden                           ' Hide it all way

        'MsgBox("Line 943 : Command Line : " & p.FileName & vbCrLf & "Parameters : " & p.Arguments)

        Try

            Dim myProcess = Process.Start(p)                                ' open up the encrypted volume

        Catch ex As Exception

            MsgBox(englishError & vbCrLf & vbCr & _
                    germanError & vbCrLf & vbCr & _
                    spanishError & vbCrLf & vbCr & _
                    "Error 1013: " & ex.ToString(), MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Language Selection")

            End                                                             ' exit the program.

        End Try

        Dim tempPage As String = ""
        Dim characterListing As New ArrayList()
        For i = 0 To 26
            characterListing.Add(Convert.ToChar(i + 97))
        Next

        ' not knowing how long it will take the system to mount the drive, keep looping through
        ' the letters until we find the available.ini inside the encrypted volume
        For i = 1 To 15
            Sleep(100)
            For j = 0 To 25
                tempPage = characterListing.Item(j) & ":\available.ini"
                frontPageExists = IO.File.Exists(tempPage)                  ' look for the file...
                If frontPageExists = True Then                              ' tada - we found it!
                    disconnectDriveLetter = characterListing.Item(j)
                    targetDrive = characterListing.Item(j)                  ' set the variable to the character
                    targetDrive = targetDrive & ":\"                        ' add the stuff to the end of the letter
                    hasLoggedIn = True                                      ' we've successfully logged in
                    ' MsgBox("Line 978 : " & frontPageExists & vbCrLf & "targetdrive : " & targetDrive)
                End If
            Next
        Next


    End Sub

    Private Sub resetGlobals()


        Dim startIniFile As New iniFile(runningFrom & "support\start.ini")
        Me.Refresh()
        ' get prompts to display on the screen
        Prompt01 = startIniFile.GetString("StartPrompts", "Prompt01", "(none)") ' Burger King® Operations Resources
        Prompt02 = startIniFile.GetString("StartPrompts", "Prompt02", "(none)") ' Encryption Installed
        Prompt03 = startIniFile.GetString("StartPrompts", "Prompt03", "(none)") ' Encryption Not Installed
        Prompt04 = startIniFile.GetString("StartPrompts", "Prompt04", "(none)") ' Enter your Password
        Prompt05 = startIniFile.GetString("StartPrompts", "Prompt05", "(none)") ' Operations Manual
        Prompt06 = startIniFile.GetString("StartPrompts", "Prompt06", "(none)") ' RightTRACK Training
        Prompt07 = startIniFile.GetString("StartPrompts", "Prompt07", "(none)") ' Update
        Prompt08 = startIniFile.GetString("StartPrompts", "Prompt08", "(none)") ' How are you accessing this program?
        Prompt09 = startIniFile.GetString("StartPrompts", "Prompt09", "(none)") ' USB Drive
        Prompt10 = startIniFile.GetString("StartPrompts", "Prompt10", "(none)") ' Restaurant Computer
        Prompt11 = startIniFile.GetString("StartPrompts", "Prompt11", "(none)") ' Select
        Prompt16 = startIniFile.GetString("StartPrompts", "Prompt16", "(none)") ' USB Operation
        Prompt17 = startIniFile.GetString("StartPrompts", "Prompt17", "(none)") ' Restaurant Computer Operation
        Prompt29 = startIniFile.GetString("StartPrompts", "Prompt29", "(none)") ' Remove the USB drive when complete
        Prompt30 = startIniFile.GetString("StartPrompts", "Prompt30", "(none)") ' Corporate
        Prompt31 = startIniFile.GetString("StartPrompts", "Prompt31", "(none)") ' Franchise
        Prompt32 = startIniFile.GetString("StartPrompts", "Prompt32", "(none)") ' Alert!
        Prompt37 = startIniFile.GetString("StartPrompts", "Prompt37", "(none)") ' You have selected
        Prompt62 = startIniFile.GetString("StartPrompts", "Prompt62", "(none)") ' Error

    End Sub


    '####################################################################################
    '####################################################################################
    '# A simple pause method.  Used when changing password                              #
    '####################################################################################
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

End Class

'######################################################################################
'# Used to get the values from the dropdown list                                      #
'######################################################################################

Public Class ValueDescriptionPair

    Public Value As Object
    Public Description As String

    Public Sub New(ByVal NewValue As Object, ByVal NewDescription As String)
        Value = NewValue
        Description = NewDescription
    End Sub

    Public Overrides Function ToString() As String
        Return Description
    End Function

End Class

'######################################################################################