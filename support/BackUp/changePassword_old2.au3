#Region ;**** Directives created by AutoIt3Wrapper_GUI ****
#AutoIt3Wrapper_icon=favicon.ico
#AutoIt3Wrapper_outfile=changePassword.exe
#AutoIt3Wrapper_Res_Comment=In-A-Flash™ Secure USB document management system.
#AutoIt3Wrapper_Res_Description=Provide automated sequence to change the password of the encrypted volume.
#AutoIt3Wrapper_Res_Fileversion=1.0.0.2
#AutoIt3Wrapper_Res_LegalCopyright=©2010 Hampton Consulting, LLC.
#AutoIt3Wrapper_Run_Tidy=y
#Tidy_Parameters=/gd
#EndRegion ;**** Directives created by AutoIt3Wrapper_GUI ****


; Establish all of the variables used in this script
Dim $encryptedTarget
Dim $oldPassword
Dim $newPassword
Dim $runtrueCrypt

; Set the encrypted file and TrueCrypt files to use on the USB drive

$runtrueCrypt = $CmdLine[1]
;MsgBox(0,"runtruecrypt",$runtrueCrypt)

$oldPassword = "whopper"
$newPassword = $CmdLine[2]
;MsgBox(0,"password",$newPassword)

$encryptedTarget = $CmdLine[3] & "bk_manuals"
;MsgBox(0,"target",$encryptedTarget)

; Run TrueCrypt.  Enter the encrypted volume in the correct box, click 'volume tools' and then
; select 'change password' from the drop down list
Run($runtrueCrypt)

; wait for the main screen to become active
WinWaitActive("TrueCrypt", "Auto-Mount Devices")
ControlSend("TrueCrypt", "Auto-Mount Devices", "[CLASS:Edit; INSTANCE:1]", "") ; Clear out the box first!
ControlSend("TrueCrypt", "Auto-Mount Devices", "[CLASS:Edit; INSTANCE:1]", $encryptedTarget) ; populate the volume selection box
Send("!t") ; click the "Volume Tools..." button
Send("{DOWN}") ; hit the 'down' key once
Send("{ENTER}") ; hit the 'enter' key to select change volume password


While 1

	; Wait for the next screen appears and then enter the existing and new passwords into the correct blocks
	; and hit the enter key on the screen
	If WinActive("Change Password or Keyfiles", "Confirm Password") Then
		WinActivate("Change Password or Keyfiles", "Confirm Password")
		ControlSend("Change Password or Keyfiles", "Confirm Password", "[CLASS:Edit; INSTANCE:1]", $oldPassword) ; enter the old password
		ControlSend("Change Password or Keyfiles", "Confirm Password", "[CLASS:Edit; INSTANCE:2]", $newPassword) ; enter the new password the first time
		ControlSend("Change Password or Keyfiles", "Confirm Password", "[CLASS:Edit; INSTANCE:3]", $newPassword) ; enter the new password the second time
		ControlClick("Change Password or Keyfiles", "Confirm Password", "[CLASS:Button; INSTANCE:7]") ; the OK button
	EndIf

	; If the short password message box appears, just hit OK to clear it off the screen and proceed
	If WinActive("TrueCrypt", "Short passwords are easy to crack") Then
		WinActivate("TrueCrypt", "Short passwords are easy to crack")
		ControlClick("TrueCrypt", "Short passwords are easy to crack", "[CLASS:Button; INSTANCE:1]") ; the YES button
	EndIf

	; Click the 'continue' button to clear this window and start the password change process
	If WinActive("TrueCrypt - Random Pool Enrichment", "Move your mouse") Then
		WinActivate("TrueCrypt - Random Pool Enrichment", "Move your mouse")
		ControlClick("TrueCrypt - Random Pool Enrichment", "", "[CLASS:Button; INSTANCE:1]") ; the CONTINUE button
	EndIf

	If WinActive("TrueCrypt", "read the section") Then
		WinActivate("TrueCrypt", "read the section")
		ControlClick("TrueCrypt", "read the section", "[CLASS:Button; INSTANCE:1]") ; the OK button
		ExitLoop
	EndIf

	; if the person enters the wrong password, TC pops up another window asking them to re-enter the
	; correct password.  If this happens it needs to be captured and then all subsequent windows closed
	; so the changePassword.vb coding can take over.
	If WinActive("TrueCrypt", "Incorrect password") Then
		WinActivate("TrueCrypt", "Incorrect password")
		ControlClick("TrueCrypt", "Incorrect password", "[CLASS:Button; INSTANCE:1]")
		WinActivate("Change Password or Keyfiles", "Confirm Password")
		ControlClick("Change Password or Keyfiles", "Confirm Password", "[CLASS:Button; INSTANCE:8]")
		WinActivate("TrueCrypt", "Volume")
		ControlClick("TrueCrypt", "Volume", "[CLASS:Button; INSTANCE:11]")
		Exit 2
	EndIf
	Sleep(150)
WEnd

; Grab the main TrueCrypt screen and send the EXIT command to close it out.
WinActivate("TrueCrypt", "Auto-Mount Devices")
ControlClick("TrueCrypt", "Auto-Mount Devices", "[CLASS:Button; INSTANCE:11]") ; the EXIT button

; MsgBox(0, "", "Just before Exit")

Exit

;EndIf