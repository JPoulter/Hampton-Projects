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


Public Class register_usb

    ' these are the background colors used in the form entries
    Dim activeInput = Color.LightGoldenrodYellow    ' control that has focus
    Dim inactiveInput = Color.White                 ' not focused and hasn't been entered yet
    Dim goodInput = Color.LightGreen                ' the entry is valid
    Dim badInput = Color.LightPink                  ' the entry is bad or missing

    ' read in all the prompts and information used in this page
    Dim readThispromptNumber As New readINIFile
    Dim Prompt12 = readThispromptNumber.getFormText("Prompt12")                     ' Suite/Apt #
    Dim Prompt13 = readThispromptNumber.getFormText("Prompt13")                     ' no network...
    Dim Prompt19 = readThispromptNumber.getFormText("Prompt19")                     ' can't use till registered
    Dim Prompt14 = readThispromptNumber.getFormText("Prompt14")                     ' Is this corrrect?
    Dim Prompt36 = readThispromptNumber.getFormText("Prompt36")                     ' Register
    Dim Prompt38 = readThispromptNumber.getFormText("Prompt38")                     ' please wait
    Dim Prompt39 = readThispromptNumber.getFormText("Prompt39")                     ' registration success
    Dim Prompt40 = readThispromptNumber.getFormText("Prompt40")                     ' select rest. #
    Dim Prompt42 = readThispromptNumber.getFormText("Prompt42")                     ' first name
    Dim Prompt43 = readThispromptNumber.getFormText("Prompt43")                     ' last name
    Dim Prompt44 = readThispromptNumber.getFormText("Prompt44")                     ' address
    Dim Prompt45 = readThispromptNumber.getFormText("Prompt45")                     ' country
    Dim Prompt46 = readThispromptNumber.getFormText("Prompt46")                     ' city
    Dim Prompt47 = readThispromptNumber.getFormText("Prompt47")                     ' state
    Dim Prompt48 = readThispromptNumber.getFormText("Prompt48")                     ' zip area code
    Dim Prompt49 = readThispromptNumber.getFormText("Prompt49")                     ' email 
    Dim Prompt50 = readThispromptNumber.getFormText("Prompt50")                     ' association
    Dim Prompt51 = readThispromptNumber.getFormText("Prompt51")                     ' operational level
    Dim Prompt52 = readThispromptNumber.getFormText("Prompt52")                     ' job title
    Dim Prompt53 = readThispromptNumber.getFormText("Prompt53")                     ' franchise name
    Dim Prompt54 = readThispromptNumber.getFormText("Prompt54")                     ' register
    Dim Prompt55 = readThispromptNumber.getFormText("Prompt55")                     ' required
    Dim Prompt56 = readThispromptNumber.getFormText("Prompt56")                     ' OK
    Dim Prompt57 = readThispromptNumber.getFormText("Prompt57")                     ' missing
    Dim Prompt58 = readThispromptNumber.getFormText("Prompt58")                     ' success
    Dim Prompt59 = readThispromptNumber.getFormText("Prompt59")                     ' bad email
    Dim Prompt114 = readThispromptNumber.getFormText("Prompt114")                   ' problem connecting
    Dim Prompt115 = readThispromptNumber.getFormText("Prompt115")                   ' try again later

    Dim operationsIniFile As New iniFile(runningFrom & "\support\operations.ini")
    Dim updateWebSite = UpdateURL                                                                   ' update site 
    Dim queryWebSite = ProgramDataURL                                                               ' all purpose database query

    Dim handleEncryption As New encryption      ' setup the class
    Dim SerialNumber = handleEncryption.Decrypt(operationsIniFile.GetString("SerialNumber", "SerialNumber", "(none)"), EncryptionKey)
    Dim ConfirmCode As String = ""

    Dim parametersIniFile As New iniFile(runningFrom & "\support\parameters.ini")
    Dim Version = parametersIniFile.GetString("DriveInfo", "Version", "(none)")                     ' version number
    Dim Language = parametersIniFile.GetString("DriveInfo", "Language", "(none)")                   ' language code

    ' these boolean variables are used to keep track of valid or invalid entries
    ' in the registration form
    Dim OKFirstName As Boolean = False
    Dim OKLastName As Boolean = False
    Dim OKAddress As Boolean = False
    Dim OKCountry As Boolean = False
    Dim OKCity As Boolean = False
    Dim OKState As Boolean = False
    Dim OKZip As Boolean = False
    Dim OKEmail As Boolean = False
    Dim OKJobTitle As Boolean = False
    Dim OKAssociation As Boolean = False
    Dim OKFranName As Boolean = False

    ' these variables hold the information which is sent to the web site to
    ' complete the registration
    Dim submitFirstname As String = ""
    Dim submitLastName As String = ""
    Dim submitAddress1 As String = ""
    Dim submitAddress2 As String = ""
    Dim submitCountry As String = ""
    Dim submitCity As String = ""
    Dim submitState As String = ""
    Dim submitZip As String = ""
    Dim submitEmail As String = ""
    Dim submitJobTitle As String = ""
    Dim submitAssociation As String = ""
    Dim submitFranName As String = ""

    ' These are the 4 threads which are used to populate the drop-down menus
    Dim doGetState As Thread
    Dim doGetStateDone As Boolean = False
    Dim doGetCountry As Thread
    Dim doGetCountryDone As Boolean = False
    Dim doGetJobTitle As Thread
    Dim doGetJobTitleDone As Boolean = False
    Dim doGetFranchise As Thread
    Dim doGetFranchiseDone As Boolean = False

    '####################################################################################
    '####################################################################################
    '# When the form loads set the labels to the applicable language prompts and then   #
    '# start all of the threads to download the information from the web site           #
    '####################################################################################

    Private Sub register_usb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' MsgBox(SerialNumber)
        ' Me.RightToLeft = Windows.Forms.RightToLeft.Inherit

        ' CheckFormFlow() ' check for right-to-left or left-to-right setting

        ' set all the labels on the screen to the applicable language texts
        SetLabels()
        Me.Refresh()
        SetLabels()

        ' set and start the threads to populate the drop downs on the form
        Me.Cursor = Cursors.WaitCursor

        waitLabel.Visible = True
        doGetState = New Thread(AddressOf Me.getStates)
        doGetState.Start()
        doGetCountry = New Thread(AddressOf Me.getCountry)
        doGetCountry.Start()
        doGetJobTitle = New Thread(AddressOf Me.getJobTitles)
        doGetJobTitle.Start()
        doGetFranchise = New Thread(AddressOf Me.getFranchiseNames)
        doGetFranchise.Start()

    End Sub

    '####################################################################################
    '####################################################################################
    '# Set the type of web query to do and pass that to the web site.  Then take the    #
    '# response we get and populate the states downdown list on the form.               #
    '####################################################################################
    Private Sub getStates()

        ' The query type is fed to pgmData.php on the server which tells it what part of
        ' the switch/case statement to process
        Dim whichURL As String = queryWebSite & "?queryType=getState"

        Try
            Dim request As HttpWebRequest = HttpWebRequest.Create(whichURL)
            request.Credentials = CredentialCache.DefaultCredentials

            ' Get the response.
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

            ' 200 is an OK response from a web site when it is contacted.  Anything other
            ' then 200 means there was an issue.
            If response.StatusCode = "200" Then
                Dim strRowSource As String = ""
                ' Get the stream containing content returned by the server.
                Dim dataStream As Stream = response.GetResponseStream()
                ' Open the stream using a StreamReader for easy access.
                Dim reader As New StreamReader(dataStream)
                Dim responseFromServer As String = reader.ReadToEnd()   ' Read the content
                ' The | character is used to separate the response items.  This
                ' code will split it out into it's separate parts
                Dim split As String() = responseFromServer.Split(New [Char]() {"|"c})
                inputState.BeginUpdate() ' begin the dropdown update process
                Dim i As Integer = 1
                For Each segment As String In split
                    If segment.Trim() <> "" Then
                        inputState.Items.Add(segment)
                        i = i + 1
                    End If
                Next segment
                inputState.EndUpdate() ' stop the update process
                ' Cleanup the streams and the response.
                reader.Close()
                dataStream.Close()
                response.Close()
                doGetStateDone = True
                gotAllData()

            End If

        Catch ex As Exception

            MsgBox(Prompt114 & vbCrLf & vbCr & Prompt115, MsgBoxStyle.OkOnly)

        End Try

        ' kill the background thread filling out the dropdown list
        doGetState.Abort()
    End Sub

    '####################################################################################
    '####################################################################################
    '# Set the type of web query to do and pass that to the web site.  Then take the    #
    '# response we get and populate the countries downdown list on the form.            #
    '####################################################################################
    Private Sub getCountry()

        ' The query type is fed to pgmData.php on the server which tells it what part of
        ' the switch/case statement to process
        Dim whichURL As String = queryWebSite & "?queryType=getCountry"
        Try
            Dim request As HttpWebRequest = HttpWebRequest.Create(whichURL)
            request.Credentials = CredentialCache.DefaultCredentials
            ' Get the response.
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

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

                Dim split As String() = responseFromServer.Split(New [Char]() {"|"c})
                inputCountry.BeginUpdate()
                Dim i As Integer = 1
                For Each segment As String In split
                    If segment.Trim() <> "" Then
                        inputCountry.Items.Add(segment)
                        i = i + 1
                    End If
                Next segment
                inputCountry.EndUpdate()
                ' Cleanup the streams and the response.
                reader.Close()
                dataStream.Close()
                response.Close()
                doGetCountryDone = True
                gotAllData() ' check to see if all the threads are done
                inputCountry.Enabled = True

            End If

        Catch ex As Exception

            MsgBox(Prompt114 & vbCrLf & vbCr & Prompt115, MsgBoxStyle.OkOnly)

        End Try

        ' kill the background thread filling out the dropdown list
        doGetCountry.Abort()
    End Sub

    '####################################################################################
    '####################################################################################
    '# Set the type of web query to do and pass that to the web site.  Then take the    #
    '# response we get and populate the job titles downdown list on the form.           #
    '####################################################################################
    Private Sub getJobTitles()

        ' The query type is fed to pgmData.php on the server which tells it what part of
        ' the switch/case statement to process
        Dim whichURL As String = queryWebSite & "?queryType=getJobTitle"
        Try
            Dim request As HttpWebRequest = HttpWebRequest.Create(whichURL)
            request.Credentials = CredentialCache.DefaultCredentials

            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
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
                ' The | character is used to separate the response items.  This
                ' code will split it out into it's separate parts
                Dim split As String() = responseFromServer.Split(New [Char]() {"|"c})
                inputJobTitle.BeginUpdate()
                Dim i As Integer = 1
                For Each segment As String In split
                    If segment.Trim() <> "" Then
                        inputJobTitle.Items.Add(segment)
                        i = i + 1
                    End If
                Next segment
                inputJobTitle.EndUpdate()

                ' Cleanup the streams and the response.
                reader.Close()
                dataStream.Close()
                response.Close()
                doGetJobTitleDone = True
                gotAllData() ' check to see if all the threads are done
                inputJobTitle.Enabled = True

            End If

        Catch ex As Exception

            MsgBox(Prompt114 & vbCrLf & vbCr & Prompt115, MsgBoxStyle.OkOnly)

        End Try

        ' kill the background thread filling out the dropdown list
        doGetJobTitle.Abort()
    End Sub

    '####################################################################################
    '####################################################################################
    '# Set the type of web query to do and pass that to the web site.  Then take the    #
    '# response we get and populate the job titles downdown list on the form.           #
    '####################################################################################
    Private Sub getFranchiseNames()

        ' The query type is fed to pgmData.php on the server which tells it what part of
        ' the switch/case statement to process
        Dim whichURL As String = queryWebSite & "?queryType=getFranchiseName"
        Try
            Dim request As HttpWebRequest = HttpWebRequest.Create(whichURL)
            request.Credentials = CredentialCache.DefaultCredentials
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
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
                inputFranchiseName.BeginUpdate()
                Dim i As Integer = 1
                For Each segment As String In split
                    If segment.Trim() <> "" Then
                        inputFranchiseName.Items.Add(segment)
                        i = i + 1
                    End If
                Next segment
                inputFranchiseName.EndUpdate()
                ' Cleanup the streams and the response.
                reader.Close()
                dataStream.Close()
                response.Close()
                doGetFranchiseDone = True
                gotAllData() ' check to see if all the threads are done

            End If

        Catch ex As Exception

            MsgBox(Prompt114 & vbCrLf & vbCr & Prompt115 & vbCrLf & vbCrLf & Prompt62 & " " & ex.ToString, MsgBoxStyle.OkOnly)
        End Try

        ' kill the background thread filling out the dropdown list
        doGetFranchise.Abort()
    End Sub

    '#####################################################################################
    '#####################################################################################
    '# set all the inputs to Light Yellow when they have focus                           #
    '#####################################################################################
    Private Sub inputFirstName_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles inputFirstName.Enter
        inputFirstName.BackColor = activeInput
        If Trim(inputFirstName.Text) = "" Then
            flagFirstName.Image = My.Resources.flag_yellow
        End If
    End Sub
    Private Sub inputLastName_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles inputLastName.Enter
        inputLastName.BackColor = activeInput
        If Trim(inputLastName.Text) = "" Then
            flagLastName.Image = My.Resources.flag_yellow
        End If
    End Sub

    Private Sub inputAddress1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles inputAddress1.Enter
        inputAddress1.BackColor = activeInput
        If Trim(inputAddress1.Text) = "" Then
            flagAddress.Image = My.Resources.flag_yellow
        End If
    End Sub

    Private Sub inputAddress2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles inputAddress2.Enter
        inputAddress2.BackColor = activeInput
    End Sub

    Private Sub inputCountry_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles inputCountry.Enter
        inputCountry.BackColor = activeInput
        If inputCountry.SelectedIndex = -1 Then
            flagCountry.Image = My.Resources.flag_yellow
        End If
    End Sub

    Private Sub inputCity_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles inputCity.Enter
        inputCity.BackColor = activeInput
        If Trim(inputCity.Text) = "" Then
            flagCity.Image = My.Resources.flag_yellow
        End If
    End Sub

    Private Sub inputState_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles inputState.Enter
        inputState.BackColor = activeInput
        If inputState.SelectedIndex = -1 Then
            flagState.Image = My.Resources.flag_yellow
        End If
    End Sub

    Private Sub inputZipcode_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles inputZipcode.Enter
        inputZipcode.BackColor = activeInput
        If Trim(inputZipcode.Text) = "" Then
            flagZipcode.Image = My.Resources.flag_yellow
        End If
    End Sub

    Private Sub inputEmail_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles inputEmail.Enter
        inputEmail.BackColor = activeInput
        If Trim(inputEmail.Text) = "" Then
            flagEmail.Image = My.Resources.flag_yellow
        End If
    End Sub

    Private Sub inputJobTitle_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles inputJobTitle.Enter
        inputJobTitle.BackColor = activeInput
        If inputJobTitle.SelectedIndex = -1 Then
            flagJobTitle.Image = My.Resources.flag_yellow
        End If
    End Sub

    Private Sub inputFranchiseName_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles inputFranchiseName.Enter
        inputFranchiseName.BackColor = activeInput
        If inputFranchiseName.SelectedIndex = -1 Then
            flagFranchiseName.Image = My.Resources.flag_yellow
        End If
    End Sub



    '#####################################################################################
    '#####################################################################################
    '# process the entries as they are passed through..                                  #
    '#####################################################################################

    ' Handle the first name input field
    Private Sub inputFirstName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles inputFirstName.LostFocus

        If Trim(inputFirstName.Text) <> "" Then
            flagFirstName.Image = My.Resources.flag_green
            inputFirstName.Text = Trim(StrConv(inputFirstName.Text, VbStrConv.ProperCase))
            inputFirstName.BackColor = goodInput
            OKFirstName = True
            submitFirstname = "firstname=" & inputFirstName.Text
        Else
            inputFirstName.BackColor = badInput
            flagFirstName.Image = My.Resources.flag_red
            OKFirstName = False
            submitFirstname = ""
        End If
        checkEntries()  ' Check to see if everything is entered

    End Sub



    ' Handle the last name input field
    Private Sub inputLastName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles inputLastName.LostFocus

        If Trim(inputLastName.Text) <> "" Then
            flagLastName.Image = My.Resources.flag_green
            inputLastName.Text = Trim(StrConv(inputLastName.Text, VbStrConv.ProperCase))
            inputLastName.BackColor = goodInput
            OKLastName = True
            submitLastName = "lastname=" & inputLastName.Text
        Else
            inputLastName.BackColor = badInput
            flagLastName.Image = My.Resources.flag_red
            OKLastName = False
            submitLastName = ""
        End If
        checkEntries()  ' Check to see if everything is entered

    End Sub



    ' Handle the first address field
    Private Sub inputAddress1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles inputAddress1.LostFocus

        If Trim(inputAddress1.Text) <> "" Then
            flagAddress.Image = My.Resources.flag_green
            inputAddress1.Text = Trim(StrConv(inputAddress1.Text, VbStrConv.ProperCase))
            inputAddress1.BackColor = goodInput
            OKAddress = True
            submitAddress1 = "address1=" & inputAddress1.Text
        Else
            inputAddress1.BackColor = badInput
            flagAddress.Image = My.Resources.flag_red
            OKAddress = False
            submitAddress1 = ""
        End If
        checkEntries()  ' Check to see if everything is entered

    End Sub

    ' Handle the second address field
    Private Sub inputAddress2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles inputAddress2.LostFocus

        If Trim(inputAddress2.Text) <> "" Then
            inputAddress2.Text = Trim(inputAddress2.Text.ToUpper)
            'inputAddress2.Text = Trim(StrConv(inputAddress2.Text, VbStrConv.ProperCase))
            inputAddress2.BackColor = goodInput
            submitAddress2 = "address2=" & inputAddress2.Text
        Else
            inputAddress2.BackColor = inactiveInput
            submitAddress2 = ""
        End If
        checkEntries()  ' Check to see if everything is entered

    End Sub



    ' Handle the zipcode input field
    Private Sub inputZipcode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles inputZipcode.LostFocus

        If Trim(inputZipcode.Text) <> "" Then
            flagZipcode.Image = My.Resources.flag_green
            inputZipcode.Text = Trim(inputZipcode.Text.ToUpper)
            inputZipcode.BackColor = goodInput
            OKZip = True
            submitZip = "zipcode=" & inputZipcode.Text
        Else
            inputZipcode.BackColor = badInput
            flagZipcode.Image = My.Resources.flag_red
            OKZip = False
            submitZip = ""
        End If
        checkEntries()  ' Check to see if everything is entered

    End Sub


    ' Handle the email input field
    Private Sub inputEmail_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles inputEmail.LostFocus

        If Trim(inputEmail.Text) <> "" And EmailAddressCheck(inputEmail.Text) = True Then
            flagEmail.Image = My.Resources.flag_green
            inputEmail.Text = Trim(inputEmail.Text.ToLower)
            inputEmail.BackColor = goodInput
            OKEmail = True
            submitEmail = "email=" & inputEmail.Text
        ElseIf Trim(inputEmail.Text) <> "" And EmailAddressCheck(inputEmail.Text) <> True Then
            MsgBox(Prompt59, 16, Prompt36)                      ' show the invalid email message
            flagEmail.Image = My.Resources.flag_red
            inputEmail.BackColor = badInput
            inputEmail.Focus()                                  ' focus on the email textbox
            inputEmail.SelectionStart = 0                       ' set the cursor to the beginning of the box
            inputEmail.SelectionLength = inputEmail.Text.Length ' select the entire length of the entry
            submitEmail = ""
        Else
            inputEmail.BackColor = badInput
            flagEmail.Image = My.Resources.flag_red
            OKEmail = False
            submitEmail = ""
        End If

        checkEntries()  ' Check to see if everything is entered

    End Sub

    ' Handle the city input field
    Private Sub inputCity_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles inputCity.LostFocus

        If Trim(inputCity.Text) <> "" Then
            flagCity.Image = My.Resources.flag_green
            inputCity.Text = Trim(StrConv(inputCity.Text, VbStrConv.ProperCase))
            inputCity.BackColor = goodInput
            OKCity = True
            submitCity = "city=" & inputCity.Text
        Else
            inputCity.BackColor = badInput
            flagCity.Image = My.Resources.flag_red
            OKCity = False
            submitCity = ""
        End If
        checkEntries()  ' Check to see if everything is entered

    End Sub

    '#####################################################################################
    '# Handle the corporate/franchise slections on the form.  If corporate then that's   #
    '# all there is to ask.  If franchise then we need to have them select a franchise   #
    '# name from the drop-down box.
    '#####################################################################################
    Private Sub inputCorporate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles inputCorporate.Click
        flagAssociation.Image = My.Resources.flag_green
        inputFranchiseName.Enabled = False
        inputFranchiseName.SelectedIndex = -1
        OKAssociation = True
        OKFranName = True ' If selecting corporate then we don't need franchise, so make it true
        submitAssociation = "association=Company"
        submitFranName = ""
        checkEntries()  ' Check to see if everything is entered

    End Sub

    Private Sub inputFranchise_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles inputFranchise.Click
        inputFranchiseName.Enabled = True
        flagAssociation.Image = My.Resources.flag_yellow
        OKAssociation = False
        OKFranName = False
        submitAssociation = "association=Franchise"
        checkEntries()  ' Check to see if everything is entered
    End Sub
    Private Sub inputFranchiseName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles inputFranchiseName.SelectedIndexChanged
        flagAssociation.Image = My.Resources.flag_green
        OKFranName = True
        OKAssociation = True
        submitFranName = "franchise=" & inputFranchiseName.SelectedItem
        checkEntries()  ' Check to see if everything is entered
    End Sub

    '#####################################################################################
    '# This next section handles the drop down lists on the form                         #
    '#####################################################################################
    '# check the selection to see if it the US.  If so, enable the states drop doow      #
    '# selection list.  Turn the flag green before leaving                               #
    '#####################################################################################

    ' Handles the country selection drop down box
    Private Sub inputCountry_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles inputCountry.SelectedIndexChanged
        If inputCountry.SelectedItem = "United States" Then
            inputState.Enabled = True
            flagState.Visible = True
        ElseIf inputCountry.SelectedItem <> "United States" Then
            inputState.SelectedIndex = -1
            inputState.Enabled = False
            inputState.BackColor = inactiveInput
            flagState.Image = My.Resources.flag_yellow
            flagState.Visible = False
            OKState = True 'If outside the US we don't need state so flip it to TRUE
        End If
        flagCountry.Image = My.Resources.flag_green
        inputCountry.BackColor = goodInput
        submitCountry = "country=" & inputCountry.SelectedItem
        OKCountry = True
        checkEntries()  ' Check to see if everything is entered
    End Sub

    ' Handles the state selection drop down box
    Private Sub inputState_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles inputState.SelectedIndexChanged
        flagState.Image = My.Resources.flag_green
        inputState.BackColor = goodInput
        submitState = "state=" & inputState.SelectedItem
        OKState = True
        checkEntries()  ' Check to see if everything is entered
    End Sub

    ' Handles the job title selection drop down box
    Private Sub inputJobTitle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles inputJobTitle.SelectedIndexChanged
        flagJobTitle.Image = My.Resources.flag_green
        inputJobTitle.BackColor = goodInput
        submitJobTitle = "jobtitle=" & inputJobTitle.SelectedItem
        OKJobTitle = True
        checkEntries()  ' Check to see if everything is entered
    End Sub

    '#####################################################################################
    '# check the entries to make sure all inputs are completed.  If so then enable       #
    '# the register button so it will work.                                              #
    '#####################################################################################
    Private Sub checkEntries()

        ' ------------------------------------------------------
        ' check boolean states for the input fields
        ' ------------------------------------------------------
        'MsgBox("firstname   = " & OKFirstName & vbCrLf & _
        '       "lastname    = " & OKLastName & vbCrLf & _
        '       "address1    = " & OKAddress & vbCrLf & _
        '       "country     = " & OKCountry & vbCrLf & _
        '       "city        = " & OKCity & vbCrLf & _
        '       "state       = " & OKState & vbCrLf & _
        '       "zip         = " & OKZip & vbCrLf & _
        '       "email       = " & OKEmail & vbCrLf & _
        '       "jobtitle    = " & OKJobTitle & vbCrLf & _
        '       "association = " & OKAssociation & vbCrLf & _
        '       "franchise   = " & OKFranName)

        If OKFirstName = True And OKLastName = True And OKAddress = True And OKCountry = True And OKCity = True And OKState = True And OKZip = True And OKEmail = True And OKJobTitle = True And OKAssociation = True And OKFranName = True Then
            RegisterButton.Enabled = True

            ' ------------------------------------------------------
            ' check inputs on all of the fields
            ' ------------------------------------------------------
            'MsgBox(submitFirstname & vbCrLf & _
            '       submitLastName & vbCrLf & _
            '       submitAddress1 & vbCrLf & _
            '       submitAddress2 & vbCrLf & _
            '       submitCity & vbCrLf & _
            '       submitCountry & vbCrLf & _
            '       submitEmail & vbCrLf & _
            '       submitState & vbCrLf & _
            '       submitZip & vbCrLf & _
            '       submitAssociation & vbCrLf & _
            '       submitFranName)
        Else
            RegisterButton.Enabled = False
        End If
    End Sub
    '####################################################################################
    '####################################################################################
    '# If all of the threads are done downloading from the web site then set the cursor #
    '# back to default and hide the loading... prompt                                   #
    '####################################################################################
    Private Sub gotAllData()
        If doGetStateDone = True And doGetCountryDone = True And doGetJobTitleDone = True And doGetFranchiseDone = True Then
            Me.Cursor = Cursors.Default
            waitLabel.Visible = False
        End If
    End Sub

    '#####################################################################################
    '# Display the help information from the web site when the ? is clicked              #
    '#####################################################################################
    Private Sub HelpButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USBRegisterHelpButton.Click

        Form3.updateURL.Text = "http://" & SupportURL  ' SupportURL is the URL for the support site
        Form3.urlType.Text = "Support"  ' Form3 uses this to change the heading prompt

        Me.TopMost = False
        Form3.Enabled = True
        Form3.Show()
    End Sub

    '#####################################################################################
    '# close the form when they click the exit button.  There is no other close action   #
    '# on the form as the control box for the form is not shown.                         #
    '#####################################################################################
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click

        operationsIniFile.WriteString("Operations", "Value02", "")      'if they bail, then zero out mode of operation
        operationsIniFile.WriteString("Operations", "Value04", "No")    'if they bail, Registered = No
        ' operationsIniFile.WriteString("Operations", "Value06", "No")    'if they bail, then PW change = No
        MsgBox(Prompt19, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, Prompt36)
        End ' Exit the program.  Can't use until registered

    End Sub

    '#####################################################################################
    '# set all the labels on the screen                                                  #
    '#####################################################################################
    Private Sub SetLabels()

        Me.Text = Prompt01
        pageHeader.Text = Prompt01 & "  ||  " & Prompt09 & " || " & Prompt36

        suiteNumber.Text = Prompt12
        LabelFirstName.Text = Prompt42
        LabelLastName.Text = Prompt43
        LabelAddress.Text = Prompt44
        LabelCountry.Text = Prompt45
        LabelCity.Text = Prompt46
        LabelState.Text = Prompt47
        LabelZip.Text = Prompt48
        LabelEmail.Text = Prompt49
        AssociationBox.Text = "| " & Prompt50 & " |"
        LabelJobTitle.Text = Prompt52
        LabelFranchiseName.Text = Prompt53
        inputCorporate.Text = Prompt30
        inputFranchise.Text = Prompt31
        RegisterButton.Text = Prompt54
        LabelYellowFlag.Text = Prompt55
        LabelGreenFlag.Text = Prompt56
        LabelRedFlag.Text = Prompt57
        waitLabel.Text = Prompt38

    End Sub

    Private Sub RegisterButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegisterButton.Click

        Me.Cursor = Cursors.WaitCursor

        Dim handleEncryption As New encryption
        Dim temptext = operationsIniFile.GetString("Operations", "Value99", "(none)")

        ' If the software is being used on a desktop or laptop AND
        ' the software is being registered to an individual, there will
        ' not be any password.  In this case set the password variable to
        ' "Server" and pass that to the registration database

        If (temptext <> "") And (temptext = "(none)") Then
            temptext = handleEncryption.Decrypt(temptext, EncryptionKey)
        Else
            temptext = "ComputerInstallation"
        End If

        ' MsgBox("temptext : " & temptext & vbCrLf & "EncryptionKey : " & EncryptionKey)

        waitLabel.Text = Prompt38   ' Please wait...
        waitLabel.Visible = True

        ' The query type is fed to pgmData.php on the server which tells it what part of
        ' the switch/case statement to process
        Dim whichURL As String = queryWebSite & "?queryType=registerUSB"
        Dim submittedInfo As String = "&" & submitFirstname & _
                                      "&" & submitLastName & _
                                      "&" & submitAddress1 & _
                                      "&" & submitAddress2 & _
                                      "&" & submitCity & _
                                      "&" & submitCountry & _
                                      "&" & submitEmail & _
                                      "&" & submitState & _
                                      "&" & submitZip & _
                                      "&" & submitAssociation & _
                                      "&" & submitFranName & _
                                      "&" & submitJobTitle & _
                                      "&version=" & Version & _
                                      "&language=" & Language & _
                                      "&serialNumber=" & SerialNumber & _
                                      "&operationalMode=" & modeOfOperation & _
                                      "&temptext=" & temptext

        whichURL = whichURL & submittedInfo

        ' testing msgbox to check submissions to the server
        'MsgBox("Line 825 : " & vbCrLf & submittedInfo)
        'MsgBox("Line 826 : " & whichURL)

        Try
            Dim request As HttpWebRequest = HttpWebRequest.Create(whichURL)
            request.Credentials = CredentialCache.DefaultCredentials
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            ' 200 is an OK response from a web site when it is contacted.  Anything other
            ' then 200 means there was an issue.
            If response.StatusCode = "200" Then
                Dim strRowSource As String = ""
                Dim dataStream As Stream = response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                Dim responseFromServer As String = reader.ReadToEnd()
                responseFromServer = Microsoft.VisualBasic.Left(responseFromServer, 20)
                Dim howLong As Integer = Len(Trim(responseFromServer))    'get the length of the response. Confirmation codes = 20

                'MsgBox("Line 831 : " & howLong)
                ' testing msgbox to see reply from server
                'MsgBox("LIne 833 beginning|" & responseFromServer & "|end")

                reader.Close()
                dataStream.Close()
                response.Close()
                ' put things back to normal and alert the user
                Me.Cursor = Cursors.Default     ' put the cursor back to normal
                waitLabel.Visible = False       ' remove the please wait at the bottom of the screen

                ' write the confirmation number to the operations.ini file


                If howLong = 20 Then


                    Dim encryptThis As String = handleEncryption.Encrypt(responseFromServer, EncryptionKey)
                    operationsIniFile.WriteString("SerialNumber", "ConfirmationCode", encryptThis)   ' serial number

                    operationsIniFile.WriteString("Operations", "Value04", "Yes")       ' Set registered to Yes

                    ' generate a random serial number and write it to the password holding variable
                    ' just to muck up the works
                    'temptext = handleEncryption.Encrypt(generateSerialNumber.GetSerialNumber(), EncryptionKey)
                    'operationsIniFile.WriteString("Operations", "Value99", temptext)    ' write bogus info to the password entry

                    MsgBox(Prompt39, MsgBoxStyle.OkOnly, Prompt36)

                Else

                    operationsIniFile.WriteString("Operations", "Value04", "No")  ' Set registered to No
                    MsgBox(Prompt114 & vbCrLf & vbCr & Prompt115, MsgBoxStyle.OkOnly)

                End If

            End If

        Catch ex As Exception

            Me.Cursor = Cursors.Default     ' put the cursor back to normal
            waitLabel.Visible = False       ' remove the please wait at the bottom of the screen
            operationsIniFile.WriteString("Operations", "Value04", "No")  ' Set registered to No
            MsgBox(Prompt114 & vbCrLf & vbCr & Prompt115 & vbCrLf & vbCrLf & Prompt62 & " " & ex.ToString, MsgBoxStyle.OkOnly)

        End Try

        Me.Close()

    End Sub

    '#####################################################################################
    '# Capture the keystokes in the fields that the person can enter text into.  Need    #
    '# to do this to prevent extraneous crappy characters that can get into the bit      #
    '# stream and mess up the GET transfer, escape sequences and sql actions needed on   #
    '# the backend.  See an ASCII character chart for what is being excluded here.       #
    '#####################################################################################

    ' Handle the first name input field
    Private Sub inputFirstName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles inputFirstName.KeyPress

        If (e.KeyChar >= Chr(33) And e.KeyChar <= Chr(44)) Or _
           (e.KeyChar >= Chr(47) And e.KeyChar <= Chr(64)) Or _
           (e.KeyChar >= Chr(91) And e.KeyChar <= Chr(96)) Or _
           (e.KeyChar >= Chr(123) And e.KeyChar <= Chr(127)) Or _
           (e.KeyChar >= Chr(169) And e.KeyChar <= Chr(255)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If

    End Sub

    ' Handle the last name input field. Same restrictions as first name field
    Private Sub inputLastName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles inputLastName.KeyPress

        If (e.KeyChar >= Chr(33) And e.KeyChar <= Chr(44)) Or _
           (e.KeyChar >= Chr(47) And e.KeyChar <= Chr(64)) Or _
           (e.KeyChar >= Chr(91) And e.KeyChar <= Chr(96)) Or _
           (e.KeyChar >= Chr(123) And e.KeyChar <= Chr(127)) Or _
           (e.KeyChar >= Chr(169) And e.KeyChar <= Chr(255)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If

    End Sub

    ' Handle the first address line field
    Private Sub inputAddress1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles inputAddress1.KeyPress

        If (e.KeyChar >= Chr(33) And e.KeyChar <= Chr(39)) Or _
           (e.KeyChar >= Chr(42) And e.KeyChar <= Chr(43)) Or _
           (e.KeyChar = Chr(47)) Or _
           (e.KeyChar >= Chr(58) And e.KeyChar <= Chr(64)) Or _
           (e.KeyChar >= Chr(91) And e.KeyChar <= Chr(96)) Or _
           (e.KeyChar >= Chr(123) And e.KeyChar <= Chr(127)) Or _
           (e.KeyChar >= Chr(169) And e.KeyChar <= Chr(255)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If

    End Sub

    ' Handle the second address line field. Same restrictions as the first address line
    Private Sub inputAddress2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles inputAddress2.KeyPress

        If (e.KeyChar >= Chr(33) And e.KeyChar <= Chr(39)) Or _
           (e.KeyChar >= Chr(42) And e.KeyChar <= Chr(43)) Or _
           (e.KeyChar = Chr(47)) Or _
           (e.KeyChar >= Chr(58) And e.KeyChar <= Chr(64)) Or _
           (e.KeyChar >= Chr(91) And e.KeyChar <= Chr(96)) Or _
           (e.KeyChar >= Chr(123) And e.KeyChar <= Chr(127)) Or _
           (e.KeyChar >= Chr(169) And e.KeyChar <= Chr(255)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If

    End Sub

    ' Handle the zipcode field. Same restrictions as the first address line. 
    ' While the US has numeric zipcodes, that is not the case in other countries as the
    ' can use a combination of letters and numbers.
    Private Sub inputZipcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles inputZipcode.KeyPress

        If (e.KeyChar >= Chr(33) And e.KeyChar <= Chr(44)) Or _
           (e.KeyChar = Chr(47)) Or _
           (e.KeyChar >= Chr(58) And e.KeyChar <= Chr(64)) Or _
           (e.KeyChar >= Chr(91) And e.KeyChar <= Chr(96)) Or _
           (e.KeyChar >= Chr(123) And e.KeyChar <= Chr(127)) Or _
           (e.KeyChar >= Chr(169) And e.KeyChar <= Chr(255)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If

    End Sub

    ' Handle the email input field
    ' Same as the address fields but allows the use of the @ character
    Private Sub inputEmail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles inputEmail.KeyPress
        If (e.KeyChar >= Chr(33) And e.KeyChar <= Chr(44)) Or _
           (e.KeyChar = Chr(47)) Or _
           (e.KeyChar >= Chr(58) And e.KeyChar <= Chr(63)) Or _
           (e.KeyChar >= Chr(91) And e.KeyChar <= Chr(96)) Or _
           (e.KeyChar >= Chr(123) And e.KeyChar <= Chr(127)) Or _
           (e.KeyChar >= Chr(169) And e.KeyChar <= Chr(255)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    ' Handle the city input.  Do not allow numbers in this field.
    Private Sub inputCity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles inputCity.KeyPress
        If (e.KeyChar >= Chr(33) And e.KeyChar <= Chr(44)) Or _
           (e.KeyChar >= Chr(47) And e.KeyChar <= Chr(64)) Or _
           (e.KeyChar >= Chr(91) And e.KeyChar <= Chr(96)) Or _
           (e.KeyChar >= Chr(123) And e.KeyChar <= Chr(127)) Or _
           (e.KeyChar >= Chr(169) And e.KeyChar <= Chr(255)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    '####################################################################################
    '####################################################################################
    '# This subroutine will flip the form RTL or LTR depending upon the RTL entry in    #
    '# the parameters.ini file                                                          #
    '####################################################################################

    Private Sub CheckFormFlow()
        If RTLsetting = "Yes" Then
            'Me.RightToLeftLayout = True
            Me.RightToLeft = Windows.Forms.RightToLeft.Yes
        End If
    End Sub



End Class