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
Imports System.Security.Cryptography
' enables the "start" command for opening a file with it's associated program.
Imports System.Diagnostics
Imports System.Diagnostics.Process
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Security.Permissions

<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
Public Class Form2


    Dim readThispromptNumber As New readINIFile
    ' get prompts to display on the screen
    Dim Prompt20 = readThispromptNumber.getFormText("Prompt20")     ' requires flash
    Dim Prompt26 = readThispromptNumber.getFormText("Prompt26")     ' exit this program
    Dim Prompt94 = readThispromptNumber.getFormText("Prompt94")     ' copy selection
    Dim Prompt95 = readThispromptNumber.getFormText("Prompt95")     ' close this window...
    Dim Prompt96 = readThispromptNumber.getFormText("Prompt96")     ' don't have rights...
    Dim Prompt112 = readThispromptNumber.getFormText("Prompt112")   ' contact tech support
    Dim Prompt113 = readThispromptNumber.getFormText("Prompt113")   ' reload the manual

    Dim getHTMLcode As String = ""                                  ' set location of pieces of code
    Dim whichManual As String = ""
    Dim playThisMovie As String = ""
    Dim intX As Integer = Screen.PrimaryScreen.Bounds.Width
    Dim intY As Integer = Screen.PrimaryScreen.Bounds.Height

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Me.Width = (intX * 0.8)
        'Me.Height = (intY * 0.8)
        'Me.StartPosition = FormStartPosition.CenterParent

        If modeOfOperation = "Server" Then
            getHTMLcode = runningFrom & "\support\display\"   ' set location of pieces of code
        Else
            getHTMLcode = runningFrom & "support\display\"    ' set location of pieces of code
        End If

        whichManual = whichMovie.Text       ' get the manual directory to display

        ' buildHTMLpage()                     ' build the correct index.html file

        CheckFormFlow()                     ' check for right-to-left or left-to-right setting
        SetToolTips()                       ' set the tool tips on the screen

        If adminUser = True Then
            ReloadPageIcon.Visible = True
        End If

        Me.Enabled = True                   ' enable the form
        Me.Text = Prompt01                  ' set the form label
        headlineBanner.Text = Prompt01      ' set the first main prompt to show


        ' whichMovie.text is set in form1.vb when the user selects either the Ops Manual
        ' or the RTT manual.  We read that here and then insert the file 'path' into the
        ' string for the web browser Uri to play

        ' playThisMovie = "file://" & Microsoft.VisualBasic.Left(targetDrive, 2) & "/read/" & whichManual & "/index.html"
        playThisMovie = targetDrive & "read\" & whichManual & "\index.html"
        ' MsgBox("playThisMovie : " & playThisMovie)
        ' make it visible
        Me.Visible = True
        ' flip this public variable so that form1.vb knows another window is open
        Visible = True

        ' open up the selected manual in the form web browser component
        Try
            Me.WebBrowser1.Navigate(New Uri(playThisMovie))
        Catch ex As Exception
            Dim errorMessage As String = Prompt112 & vbCrLf & vbCrLf & Prompt62 & " " & ex.ToString()
            MsgBox(errorMessage, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, Prompt01)
            Me.Close()
        End Try

        ' This section will show the flipbook in a flash player directly verses using the html
        ' version using IE as a display mechanism.
        ' Comment this out and uncomment the webbrowser lines above...

        'Dim playThisSWF As String = targetDrive & "read\" & whichManual & "\movie.swf"
        'AxShockwaveFlash1.Movie = playThisSWF

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Visible = False
        Me.Enabled = False
    End Sub

    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Visible = False
        Me.Enabled = False
    End Sub

    Private Sub PictureBox1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles copySelection.Click

        Dim p As New ProcessStartInfo

        If modeOfOperation = "Server" Then
            p.FileName = runningFrom & "\support\ScreenClipper.exe"  ' ScreenClipper program
        Else
            p.FileName = runningFrom & "support\ScreenClipper.exe"  ' ScreenClipper program
        End If

        Process.Start(p)                                        ' open up the encrypted volume

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

    '####################################################################################
    '####################################################################################
    '# This subroutine will flip the form RTL or LTR depending upon the RTL entry in    #
    '# the parameters.ini file                                                          #
    '####################################################################################
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    '####################################################################################
    '####################################################################################
    '# Build the display page to handle a problem with showing the flash content        #
    '####################################################################################

    Private Sub buildHTMLpage()

        Dim part1 As String = My.Computer.FileSystem.ReadAllText(getHTMLcode & "part_1.txt")
        Dim part2 As String = My.Computer.FileSystem.ReadAllText(getHTMLcode & "part_2.txt")
        Dim part3 As String = My.Computer.FileSystem.ReadAllText(getHTMLcode & "part_3.txt")
        Dim part4 As String = My.Computer.FileSystem.ReadAllText(getHTMLcode & "part_4.txt")
        Dim part5 As String = My.Computer.FileSystem.ReadAllText(getHTMLcode & "part_5.txt")
        Dim entirePage As String = ""

        entirePage = entirePage & part1

        If adminUser = True Then
            entirePage = entirePage & Prompt20 & part2
        Else
            entirePage = entirePage & Prompt20 & "<br><br>" & Prompt112 & "'"
        End If

        entirePage = entirePage & part3

        If adminUser = True Then
            entirePage = entirePage & Prompt20 & part4
        Else
            entirePage = entirePage & Prompt20 & vbCrLf & vbCrLf & Prompt112 & "</P>"
        End If

        entirePage = entirePage & part5

        ' MsgBox(entirePage)

        My.Computer.FileSystem.WriteAllText(targetDrive & "read\" & whichManual & "\index.html", entirePage, False)

    End Sub

    '####################################################################################
    '####################################################################################
    '# Create the tool tips for the different items on the screen                       #
    '####################################################################################

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
        TT_exit.ToolTipTitle = Prompt26
        TT_exit.UseAnimation = True
        TT_exit.UseFading = True
        TT_exit.SetToolTip(Me.ExitButton, Prompt95)

        ' this is the tooltip for the exit button
        Dim TT_copy As New ToolTip()
        TT_copy.AutoPopDelay = apdelay
        TT_copy.InitialDelay = delay
        TT_copy.ReshowDelay = delay
        TT_copy.ShowAlways = True
        TT_copy.IsBalloon = True
        TT_copy.BackColor = Color.LightBlue
        TT_copy.ForeColor = Color.DarkBlue
        TT_copy.ToolTipIcon = ToolTipIcon.Info
        TT_copy.ToolTipTitle = Prompt26
        TT_copy.UseAnimation = True
        TT_copy.UseFading = True
        TT_copy.SetToolTip(Me.copySelection, Prompt94)

        ' this is the tooltip for the exit button
        Dim TT_reload As New ToolTip()
        TT_copy.AutoPopDelay = apdelay
        TT_copy.InitialDelay = delay
        TT_copy.ReshowDelay = delay
        TT_copy.ShowAlways = True
        TT_copy.IsBalloon = True
        TT_copy.BackColor = Color.LightBlue
        TT_copy.ForeColor = Color.DarkBlue
        TT_copy.ToolTipIcon = ToolTipIcon.Info
        TT_copy.ToolTipTitle = Prompt26
        TT_copy.UseAnimation = True
        TT_copy.UseFading = True
        TT_copy.SetToolTip(Me.ReloadPageIcon, Prompt113)

    End Sub

    Private Sub ReloadPageIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadPageIcon.Click

        ' open up the selected manual in the form web browser component
        Try
            Me.WebBrowser1.Navigate(New Uri(playThisMovie))
        Catch ex As Exception
            Dim errorMessage As String = Prompt112 & vbCrLf & vbCrLf & Prompt62 & " " & ex.ToString()
            MsgBox(errorMessage, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, Prompt01)
            Me.Close()
        End Try

    End Sub
End Class