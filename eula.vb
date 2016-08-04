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
Public Class eula

    Dim operationsIniFile As New iniFile(runningFrom & "\support\operations.ini")


    Private Sub eula_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Load the EULA.txt file into the text box on the form.
        Dim EULA As String = runningFrom & "\EULA.txt"

        Dim objReader As New System.IO.StreamReader(EULA)
        TextBox1.Text = objReader.ReadToEnd
        objReader.Close()

        ' Make sure that neither radio button is checked
        RadioButton1.Checked = False
        RadioButton2.Checked = False

        ' TextBox1.Select(0, 0)

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged

        ' Enable the submit button
        Button1.Enabled = True

        Button1.ForeColor = Color.DarkGreen

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged

        ' Enable the submit button
        Button1.Enabled = True

        Button1.ForeColor = Color.DarkRed

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ' set the current date/time from the users computer
        Dim currentDate As String
        Dim encryptedYes As String
        Dim encryptedNo As String
        Dim doEncryption As New encryption
        currentDate = doEncryption.Encrypt(System.DateTime.Now(), EncryptionKey)
        encryptedYes = doEncryption.Encrypt("Yes", EncryptionKey)
        encryptedNo = doEncryption.Encrypt("No", EncryptionKey)

        If RadioButton1.Checked = True Then

            operationsIniFile.WriteString("Operations", "Value07", encryptedYes)
            operationsIniFile.WriteString("Operations", "Value08", currentDate) ' current date/time

            ' close this and proceed
            Me.Close()

        End If

        ' If the user has disagreed with the license and selected that, write that
        ' information to the drive

        If RadioButton2.Checked = True Then

            operationsIniFile.WriteString("Operations", "Value07", encryptedNo) ' agreed or disagreed
            operationsIniFile.WriteString("Operations", "Value08", currentDate) ' current date/time

            ' End the program
            End

        End If

    End Sub
End Class