REM #################################################################################################
REM #
REM # In-A-Flash™ is a trademark of Hampton Consulting, LLC, all rights reserved
REM # In-A-Flash™ programming is copyrighted 2010 by Michael Potratz, Urbandale, Iowa
REM #
REM # This program is not public domain and unauthorized use is strictly prohibited
REM #
REM #################################################################################################

'########################################################################
' these were added to try and get the text to print out correctly
Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Threading
' enables the "start" command for opening a file with it's associated program.
Imports System.Diagnostics
Imports System.Diagnostics.Process
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Resources
Imports System.Globalization
'########################################################################

Public Class iniFile
    ' API functions
    Private Declare Ansi Function GetPrivateProfileString _
              Lib "kernel32.dll" Alias "GetPrivateProfileStringA" _
              (ByVal lpApplicationName As String, _
               ByVal lpKeyName As String, ByVal lpDefault As String, _
               ByVal lpReturnedString As System.Text.StringBuilder, _
               ByVal nSize As Integer, ByVal lpFileName As String) _
               As Integer
    Private Declare Ansi Function WritePrivateProfileString _
              Lib "kernel32.dll" Alias "WritePrivateProfileStringA" _
              (ByVal lpApplicationName As String, _
               ByVal lpKeyName As String, ByVal lpString As String, _
               ByVal lpFileName As String) As Integer
    Private Declare Ansi Function GetPrivateProfileInt _
              Lib "kernel32.dll" Alias "GetPrivateProfileIntA" _
              (ByVal lpApplicationName As String, _
               ByVal lpKeyName As String, ByVal nDefault As Integer, _
               ByVal lpFileName As String) As Integer
    Private Declare Ansi Function FlushPrivateProfileString _
              Lib "kernel32.dll" Alias "WritePrivateProfileStringA" _
              (ByVal lpApplicationName As Integer, _
               ByVal lpKeyName As Integer, ByVal lpString As Integer, _
               ByVal lpFileName As String) As Integer
    Dim strFilename As String

    ' Constructor, accepting a filename
    Public Sub New(ByVal Filename As String)
        strFilename = Filename
    End Sub

    ' Read-only filename property
    ReadOnly Property FileName() As String
        Get
            Return strFilename
        End Get
    End Property

    '###########################################################################
    '# this is the orginal function in this class
    '###########################################################################

    Public Function GetString(ByVal Section As String, _
      ByVal Key As String, ByVal [Default] As String) As String
        ' Returns a string from your INI file
        Dim intCharCount As Integer
        Dim objResult As New System.Text.StringBuilder(512)
        intCharCount = GetPrivateProfileString(Section, Key, [Default], objResult, objResult.Capacity, strFilename)
        If intCharCount > 0 Then GetString = Left(objResult.ToString, intCharCount)
    End Function

    '###########################################################################
    ' this is the modified coding to try to get things to print right.
    '###########################################################################



    Public Function GetInteger(ByVal Section As String, ByVal Key As String, ByVal [Default] As Integer) As Integer
        ' Returns an integer from your INI file
        Return GetPrivateProfileInt(Section, Key, [Default], strFilename)
    End Function

    Public Function GetBoolean(ByVal Section As String, ByVal Key As String, ByVal [Default] As Boolean) As Boolean
        ' Returns a boolean from your INI file
        Return (GetPrivateProfileInt(Section, Key, CInt([Default]), strFilename) = 1)
    End Function

    Public Sub WriteString(ByVal Section As String, ByVal Key As String, ByVal Value As String)
        Dim tempstring As String = Trim(Value)
        ' Writes a string to your INI file
        WritePrivateProfileString(Section, Key, Value, strFilename)
        Flush()
    End Sub

    Public Sub WriteInteger(ByVal Section As String, ByVal Key As String, ByVal Value As Integer)
        ' Writes an integer to your INI file
        WriteString(Section, Key, CStr(Value))
        Flush()
    End Sub

    Public Sub WriteBoolean(ByVal Section As String, ByVal Key As String, ByVal Value As Boolean)
        ' Writes a boolean to your INI file
        WriteString(Section, Key, CStr(CInt(Value)))
        Flush()
    End Sub

    Private Sub Flush()
        ' Stores all the cached changes to your INI file
        FlushPrivateProfileString(0, 0, 0, strFilename)
    End Sub
End Class
