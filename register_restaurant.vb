REM #################################################################################################
REM #
REM # In-A-Flash™ is a trademark of Hampton Consulting, LLC, all rights reserved
REM # In-A-Flash™ programming is copyrighted 2010 by Michael Potratz, Urbandale, Iowa
REM #
REM # This program is not public domain and unauthorized use is strictly prohibited
REM #
REM #################################################################################################

Imports System
Imports System.Windows.Forms
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading
' enables the "start" command for opening a file with it's associated program.
Imports System.Diagnostics.Process


Public Class register_restaurant

    '#######################################
    'Inherits System.Windows.Forms.Form
    '#######################################

    Public websiteAnswers(25) As String
    Public whichFileName As String

    ' read in all the prompts and information used in this page
    Dim readThispromptNumber As New readINIFile
    Dim Prompt13 = readThispromptNumber.getFormText("Prompt13")                     ' no network...
    Dim Prompt14 = readThispromptNumber.getFormText("Prompt14")                     ' next time...
    Dim Prompt18 = readThispromptNumber.getFormText("Prompt18")                     ' Is this corrrect?
    Dim Prompt19 = readThispromptNumber.getFormText("Prompt19")                     ' can't use till registered
    Dim Prompt36 = readThispromptNumber.getFormText("Prompt36")                     ' Register
    Dim Prompt38 = readThispromptNumber.getFormText("Prompt38")                     ' please wait
    Dim Prompt39 = readThispromptNumber.getFormText("Prompt39")                     ' registration success
    Dim Prompt40 = readThispromptNumber.getFormText("Prompt40")                     ' select rest. #
    Dim Prompt41 = readThispromptNumber.getFormText("Prompt41")                     ' rest. information
    Dim Prompt114 = readThispromptNumber.getFormText("Prompt114")                   ' problem connecting
    Dim Prompt115 = readThispromptNumber.getFormText("Prompt115")                   ' try again later

    Dim operationsIniFile As New iniFile(runningFrom & "\support\operations.ini")
    Dim updateWebSite = UpdateURL                                                                   ' update site 
    Dim queryWebSite = ProgramDataURL                                                               ' all purpose database query
    Dim handleEncryption As New encryption      ' setup the class
    Dim SerialNumber As String = handleEncryption.Decrypt(operationsIniFile.GetString("SerialNumber", "SerialNumber", "(none)"), EncryptionKey)
    Dim ConfirmCode As String = ""
    'Dim SerialNumber = handleEncryption.Decrypt(operationsIniFile.GetString("SerialNumber", "SerialNumber", "(none)"), EncryptionKey)
    'Dim ConfirmCode = handleEncryption.Decrypt(operationsIniFile.GetString("SerialNumber", "ConfirmationCode", "(none)"), EncryptionKey)     ' confirmation code

    Dim parametersIniFile As New iniFile(runningFrom & "\support\parameters.ini")
    Dim Version = parametersIniFile.GetString("DriveInfo", "Version", "(none)")                     ' version number
    Dim Language = parametersIniFile.GetString("DriveInfo", "Language", "(none)")                   ' language code

    Dim getRN As Thread


    Private Sub register_restaurant_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' MsgBox("Line 67 : " & SerialNumber)
        ' Me.RightToLeft = Windows.Forms.RightToLeft.Inherit

        restaurantNumber.Text = Prompt11 & " ..."
        getRN = New Thread(AddressOf Me.getRestaurantNumbers)
        getRN.Start()

        'MsgBox("thread started")

        'CheckFormFlow() ' check for right-to-left or left-to-right setting

        'MsgBox("checkform flow done")

        Me.Text = Prompt01
        pageHeader.Text = Prompt01 & "  ||  " & Prompt10 & " || " & Prompt36
        RegisterButton.Text = Prompt11
        SelectRNTitle.Text = Prompt40
        RNInfoTitle.Text = Prompt41

        waitLabel.Text = Prompt38   ' Please wait...
        waitLabel.Visible = True

        ' Me.Visible = True
        ' MsgBox("after visible")

    End Sub

    '####################################################################################
    '####################################################################################
    '# Set the type of web query to do and pass that to the web site.  Then take the    #
    '# response we get and populate the restaurant downdown list on the form.           #
    '####################################################################################

    Private Sub getRestaurantNumbers()

        Me.Cursor = Cursors.WaitCursor

        ' The query type is fed to pgmData.php on the server which tells it what part of
        ' the switch/case statement to process
        Dim whichURL As String = queryWebSite & "?queryType=restaurantNumber"
        ' Dim whichControl As String = destination
        ' MsgBox("whichURL : " & whichURL)

        ' Create a request for the URL. 		
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

                ' The | character is used to separate the response items.  This
                ' code will split it out into it's separate parts

                Dim split As String() = responseFromServer.Split(New [Char]() {"|"c})

                restaurantNumber.BeginUpdate()
                Dim i As Integer = 1
                For Each segment As String In split
                    If segment.Trim() <> "" Then
                        restaurantNumber.Items.Add(segment)
                        i = i + 1
                    End If
                Next segment
                restaurantNumber.EndUpdate()

                ' Cleanup the streams and the response.
                reader.Close()
                dataStream.Close()
                response.Close()

                ' remove the please wait from the screen
                waitLabel.Visible = False
                ' put the cursor back to normal
                Me.Cursor = Cursors.Default
                ' enable the drop down and focus on it
                restaurantNumber.Enabled = True
                ' restaurantNumber.Focus()

            End If

        Catch ex As Exception

            MsgBox(Prompt114 & vbCrLf & vbCr & Prompt115, MsgBoxStyle.OkOnly)

        End Try


        ' kill the background thread filling out the dropdown list
        getRN.Abort()
        Me.Cursor = Cursors.Default


    End Sub

    '####################################################################################
    '####################################################################################
    '# When the person makes a restaurant number selection, take that information and   #
    '# send it to the pgmData.php file on the web server.  Parse the returned data and  #
    '# display it on the screen.                                                        #
    '####################################################################################

    Private Sub restaurantNumber_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles restaurantNumber.SelectedValueChanged
        'MsgBox("valueChanged")

        Me.Cursor = Cursors.WaitCursor

        Dim rnValue As String
        rnValue = restaurantNumber.Text
        'MsgBox("Index change: " & rnValue)
        Dim addressValues(30) As String
        Dim whichURL As String = queryWebSite & "?queryType=restaurantInfo" & "&rnValue=" & rnValue
        Try
            Dim request As HttpWebRequest = HttpWebRequest.Create(whichURL)
            request.Credentials = CredentialCache.DefaultCredentials
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            If response.StatusCode = "200" Then
                Dim strRowSource As String = ""
                Dim dataStream As Stream = response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                Dim responseFromServer As String = reader.ReadToEnd()
                Dim split As String() = responseFromServer.Split(New [Char]() {"|"c})
                Dim i As Integer = 1
                For Each segment As String In split
                    ' MsgBox(segment)
                    addressValues(i) = segment
                    i = i + 1
                Next segment
                reader.Close()
                dataStream.Close()
                response.Close()
                ' set the values on the screen
                rnAddress1.Text = addressValues(1)
                rnAddress2.Text = addressValues(2)
                rnAddress3.Text = addressValues(3)
                rnCity.Text = addressValues(4)
                rnState.Text = addressValues(5)
                rnCountry.Text = addressValues(6)
                rnZipcode.Text = addressValues(7)
                rnOwnership.Text = addressValues(8)
                rnFranchiseName.Text = addressValues(9)

                RegisterButton.Enabled = True
            End If
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(Prompt114 & vbCrLf & vbCr & Prompt115, MsgBoxStyle.OkOnly)
        End Try

    End Sub

    '####################################################################################
    '####################################################################################
    '# When the person clicks the exit door icon, close out the form                    #
    '####################################################################################

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitButton.Click

        operationsIniFile.WriteString("Operations", "Value02", "")      'if they bail, then zero out mode of operation
        operationsIniFile.WriteString("Operations", "Value04", "No")    'if they bail, Registered = No
        ' operationsIniFile.WriteString("Operations", "Value06", "No")    'if they bail, then PW change = No
        MsgBox(Prompt19, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, Prompt36)
        End ' Exit the program.  Can't use until registered

    End Sub

    '####################################################################################
    '####################################################################################
    '# Form3 is the generic web display form for the application.  Set the parameters   #
    '# and then call the form.                                                          #
    '####################################################################################

    Private Sub HelpButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestRegisterhelpButton.Click

        Form3.updateURL.Text = "http://" & SupportURL  ' SupportURL is the URL for the support site
        Form3.urlType.Text = "Support"  ' Form3 uses this to change the heading prompt

        Me.TopMost = False
        Form3.Enabled = True
        Form3.Show()

    End Sub

    '####################################################################################
    '####################################################################################
    '# When the user clicks the select button we need to gather all the information     #
    '# and pass it to the web site for processing.  We then listen for the response     #
    '# from the web site and write that to the operations.ini file                      #
    '####################################################################################

    Private Sub RegisterButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegisterButton.Click

        Dim handleEncryption As New encryption      ' setup the class
        Me.Cursor = Cursors.WaitCursor
        Dim temptext As String = ""
        Dim rnValue As String
        Dim MsgResponse
        rnValue = restaurantNumber.Text
        'MsgResponse = MsgBox(Prompt37 & " : " & rnValue & vbCrLf & vbCrLf & Prompt14, 36, Prompt36)
        MsgResponse = MsgBox(Prompt37 & " : " & rnValue & vbCrLf & vbCrLf & Prompt18, MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Prompt36)
        Dim passToRegister = "?version=" & Version & _
                             "&language=" & Language & _
                             "&serialNumber=" & SerialNumber & _
                             "&operationalMode=" & modeOfOperation & _
                             "&restaurantNumber=" & rnValue

        Dim whichURL As String = queryWebSite & passToRegister & "&queryType=registerRestaurant"
        ' MsgBox(whichURL)
        ' MsgBox(MsgResponse)

        '########################################################################################
        ' if the person has selected 'Yes' from the confirmation box, then process the info
        '########################################################################################

        If MsgResponse = 6 Then ' the person clicked the Yes button

            waitLabel.Text = Prompt38   ' Please wait...
            waitLabel.Visible = True

            ' MsgBox("Line 304 : " & whichURL)

            Try

                Dim request As HttpWebRequest = HttpWebRequest.Create(whichURL)
                request.Credentials = CredentialCache.DefaultCredentials
                Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                If response.StatusCode = "200" Then
                    Dim strRowSource As String = ""
                    Dim dataStream As Stream = response.GetResponseStream()
                    Dim reader As New StreamReader(dataStream)
                    Dim responseFromServer As String = reader.ReadToEnd()
                    responseFromServer = Microsoft.VisualBasic.Left(responseFromServer, 20)
                    Dim howLong As Integer = Len(Trim(responseFromServer))    'get the length of the response. Confirmation codes = 20

                    ' MsgBox("Line 318 : " & vbCrLf & howLong & vbCrLf & "[" & responseFromServer & "]")

                    reader.Close()
                    dataStream.Close()
                    response.Close()
                    Me.Cursor = Cursors.Default     ' put the cursor back to normal
                    waitLabel.Visible = False       ' remove the please wait at the bottom of the screen

                    ' write the confirmation number to the operations.ini file
                    If howLong = 20 Then

                        Dim encryptThis As String = handleEncryption.Encrypt(responseFromServer, EncryptionKey)
                        operationsIniFile.WriteString("SerialNumber", "ConfirmationCode", encryptThis)   ' serial number

                        operationsIniFile.WriteString("Operations", "Value04", "Yes")   ' Set registered to Yes
                        ' if this is registered as a server operation, then we don't need to change the
                        ' password. In this case set the changed password ini value to Yes
                        operationsIniFile.WriteString("Operations", "Value06", "Yes")   ' Set changed password to Yes
                        MsgBox(Prompt39, MsgBoxStyle.OkOnly, Prompt36)

                    Else

                        operationsIniFile.WriteString("Operations", "Value04", "No")    ' Set registered to No
                        MsgBox(Prompt114 & vbCrLf & vbCr & Prompt115, MsgBoxStyle.OkOnly)
                        ' MsgBox("Line 342 : " & response.StatusCode)
                    End If

                End If

            Catch ex As Exception

                Me.Cursor = Cursors.Default
                waitLabel.Visible = False
                operationsIniFile.WriteString("Operations", "Value04", "No")  ' Set registered to No
                MsgBox(Prompt114 & vbCrLf & vbCr & Prompt115 & vbCrLf & vbCrLf & ex.ToString, MsgBoxStyle.OkOnly)

            End Try

            ' in either case of a successful registration or not, close out this window.  If not, then
            ' keep the window open for the person to select the restaurant number

            Me.Close()

        End If

        Me.Cursor = Cursors.Default

    End Sub


    '####################################################################################
    '####################################################################################
    '# This subroutine will flip the form RTL or LTR depending upon the RTL entry in    #
    '# the parameters.ini file                                                          #
    '####################################################################################

    Private Sub CheckFormFlow()

        If RTLsetting = "Yes" Then
            Me.RightToLeftLayout = True
            Me.RightToLeft = Windows.Forms.RightToLeft.Yes
        End If

    End Sub

End Class