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
Imports System.Security
Imports System.Security.Permissions

<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
Public Class Form3

    Dim readThispromptNumber As New readINIFile
    ' get prompts to display on the screen
    Dim Prompt26 = readThispromptNumber.getFormText("Prompt26") ' exit this program
    Dim Prompt95 = readThispromptNumber.getFormText("Prompt95") ' close this window...

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CheckFormFlow() ' check for right-to-left or left-to-right setting

        Me.Text = Prompt01      ' set the form title
        SetToolTips()           ' set the tooltips for the screen

        ' Form1 update button puts URL string into this hidden field on the form
        Dim updateURLString As String = updateURL.Text

        ' If the user has selected the support button, just set the prompt and open the support 
        ' URL passed in the updateURL.Text field
        If urlType.Text = "Support" Then
            pageHeader.Text = Prompt01
        End If

        If urlType.Text = "Update" Then
            pageHeader.Text = Prompt01 & "  ||  " & Prompt07
        End If

        ' enable the form, set the style and open it up
        Me.Enabled = True
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        ' Me.TopMost = True
        Me.Visible = True

        ' open up the selected manual in the form web browser component
        Me.WebBrowser1.Navigate(New Uri(updateURLString))

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click

        Me.Close()

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