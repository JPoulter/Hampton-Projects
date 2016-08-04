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

Public Class typeOfRegistration

    Dim readThispromptNumber As New readINIFile
    Dim Prompt119 = readThispromptNumber.getFormText("Prompt119")
    Dim Prompt120 = readThispromptNumber.getFormText("Prompt120")
    Dim Prompt121 = readThispromptNumber.getFormText("Prompt121")
    Dim Prompt122 = readThispromptNumber.getFormText("Prompt122")
    Dim Prompt123 = readThispromptNumber.getFormText("Prompt123")
    Dim Prompt124 = readThispromptNumber.getFormText("Prompt124")
    Dim Prompt125 = readThispromptNumber.getFormText("Prompt125")
    Dim Prompt126 = readThispromptNumber.getFormText("Prompt126")
    Dim Prompt127 = readThispromptNumber.getFormText("Prompt127")
    Dim Prompt128 = readThispromptNumber.getFormText("Prompt128")
    Dim Prompt129 = readThispromptNumber.getFormText("Prompt129")
    Dim Prompt130 = readThispromptNumber.getFormText("Prompt130")

    ' Prompt119
    ' Dim alertTitle As String = "Confirm Registration Type"
    Dim alertTitle As String = Prompt119

    ' Prompt120 & Prompt122
    ' Dim alertRestaurant As String = "You have selected to register this software as a Restaurant General Manager." & vbCrLf & vbCrLf & "Are you sure?"
    Dim alertRestaurant As String = Prompt120 & vbCrLf & vbCrLf & Prompt122

    ' Prompt121 & Prompt122
    ' Dim alertIndividual As String = "You have selected to register this software as an above restaurant leader or corporate user." & vbCrLf & vbCrLf & "Are you sure?"
    Dim alertIndividual As String = Prompt121 & vbCrLf & vbCrLf & Prompt122

    Dim result As Integer = 0

    Private Sub typeOfRegistration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        registerRestaurant.Text = Prompt123
        registerIndividual.Text = Prompt123
        label_MainPrompt.Text = Prompt124 & vbCrLf & Prompt125
        label_restaurant.Text = Prompt126 & vbCrLf & Prompt127
        label_user.Text = Prompt128 & vbCrLf & Prompt129 & vbCrLf & Prompt130


    End Sub

    Private Sub registerRestaurant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles registerRestaurant.Click


        result = MessageBox.Show(alertRestaurant, alertTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = 6 Then
            'MsgBox(result)
            registrationType = "restaurant"
            Me.Close()
            'MsgBox(registrationType)
        End If


    End Sub

    Private Sub registerIndividual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles registerIndividual.Click

        result = MessageBox.Show(alertIndividual, alertTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = 6 Then
            'MsgBox(result)
            registrationType = "individual"
            Me.Close()
            'MsgBox(registrationType)
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End
    End Sub


End Class