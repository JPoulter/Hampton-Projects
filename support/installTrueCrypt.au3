#Region ;**** Directives created by AutoIt3Wrapper_GUI ****
#AutoIt3Wrapper_icon=favicon.ico
#AutoIt3Wrapper_outfile=installTrueCrypt.exe
#AutoIt3Wrapper_Res_Comment=In-A-Flash™ Secure USB document management system.
#AutoIt3Wrapper_Res_Description=Install the necessary encryption program to use the USB drive
#AutoIt3Wrapper_Res_Fileversion=1.0.0.2
#AutoIt3Wrapper_Res_LegalCopyright=©2010 Hampton Consulting, LLC.
#EndRegion ;**** Directives created by AutoIt3Wrapper_GUI ****


;#################################################################################################
;#
;# In-A-Flash™ is a trademark of Hampton Consulting, LLC, all rights reserved
;# In-A-Flash™ programming is copyrighted 2010 by Michael Potratz, Urbandale, Iowa
;#
;# This program is not public domain and unauthorized use is strictly prohibited
;#
;#################################################################################################

; Declare the variables for use
dim $TrueCryptInstallationFile
dim $runningDirectory
dim $currentTCVersion

; Get the variables passed to this program

$runningDirectory = $CmdLine[1]
$currentTCVersion = $CmdLine[2]

; Set the source program for installing TrueCrypt for BK
$TrueCryptInstallationFile = $runningDirectory & $currentTCVersion

; MsgBox(0,"testing",$runningDirectory)
; MsgBox(0,"testing",$currentTCVersion)
; MsgBox(0,"testing",$TrueCryptInstallationFile)

; These next two entries are for testing the script outside of the BK
; program.  Need to REM out the $runningDirectory, $currentTCVErsion and
; $TrueCryptInstallationFile to use these.  Otherwise keep these REM'd
; out so they don't effect program operation

;$TrueCryptInstallationFile = @WorkingDir & "\TrueCrypt_Setup_6.2a.exe"
;$TrueCryptInstallationFile = @WorkingDir & "\TrueCrypt_Setup_6.3a.exe"

; Run the TrueCrypt installation program from the USB drive
Run($TrueCryptInstallationFile)

; Handle the licensing screen when it pops up.
; This works on V6.2a on Windows 7 / V6.3a on Windows 7
;               V6.2a on Windows XP /

WinActivate("TrueCrypt Setup","You must accept these license terms")
Sleep(500)
ControlClick("TrueCrypt Setup","","[CLASS:Button; INSTANCE:5]") ; "I Accept..." checkbox
Sleep(500)
; Send("!a") ; Accept button
ControlClick("TrueCrypt Setup","","[CLASS:Button; INSTANCE:3]") ; Accept button

; During testing the installation script using WinActive and WinActivate worked differently
; between Vista and XP and Windows 7.  Because of that the actions for those OS systems were
; split out into two sections.

if @OSVersion = "WIN_VISTA" Then

	while 1

		; Select the installation mode and then click 'next'
		; This works on V6.2a on Windows 7 / V6.3a on Windows 7
		;               V6.2a on Windows XP /

		if WinActive("TrueCrypt Setup","Select one of the modes") Then
			WinActivate("TrueCrypt Setup","Select one of the modes")
			ControlClick("TrueCrypt Setup","Select one of the modes","[CLASS:Button; INSTANCE:5]") ; Install radio button
			; send("!n") ; Next> button
			ControlClick("TrueCrypt Setup","Select one of the modes","[CLASS:Button; INSTANCE:3]") ; Next> button
		EndIf

		; Warning that V6.2a doesn't fully work with a Windows 7 installation
		; This works on V6.2a on Windows 7

		IF WinActive("TrueCrypt Setup","Windows 7") Then
			WinActivate("TrueCrypt Setup","Windows 7")
			ControlClick("TrueCrypt Setup","Windows 7","[CLASS:Button; INSTANCE:1]") ; OK button
		EndIf

		; Uncheck the 'create desktop icon' and 'create system restore point' on the options
		; screen and then hit install
		; This works on V6.2a on Windows 7 / V6.3a on Windows 7
		;               V6.2a on Windows XP /

		If WinActive("TrueCrypt Setup","Setup Options") Then
			WinActivate("TrueCrypt Setup","Setup Options")
			ControlClick("TrueCrypt Setup","Setup Options","[CLASS:Button; INSTANCE:10]") ; Add TC icon to desktop checkbox
			ControlClick("TrueCrypt Setup","Setup Options","[CLASS:Button; INSTANCE:9]")  ; Create system restore point checkbox
			; Send("!i") ; Install button
			ControlClick("TrueCrypt Setup","Setup Options","[CLASS:Button; INSTANCE:3]")  ; Install button
		EndIf

		; The installation then goes into installation mode, first by setting a system restore point and
		; then copying all of the files into place and installing the drivers.

		; After the installation process is done, it shows a prompt that it's done.
		; This works on V6.2a on Windows 7 / V6.3a on Windows 7
		;               V6.2a on Windows XP /

		; This is the specific section where Vista handles the automated script differently from
		; XP or Windows 7.  This doesn't work under W7 in the current While/Wend loop
		WinWaitActive("TrueCrypt Setup", "TrueCrypt has been successfully installed.")
		ControlClick("TrueCrypt Setup", "TrueCrypt has been successfully installed.", "[CLASS:Button; INSTANCE:1]") ; OK button
		ExitLoop

	WEnd

Else

	while 1

		; Select the installation mode and then click 'next'
		; This works on V6.2a on Windows 7 / V6.3a on Windows 7
		;               V6.2a on Windows XP /

		if WinActive("TrueCrypt Setup","Select one of the modes") Then
			WinActivate("TrueCrypt Setup","Select one of the modes")
			ControlClick("TrueCrypt Setup","Select one of the modes","[CLASS:Button; INSTANCE:5]") ; Install radio button
			; send("!n") ; Next> button
			ControlClick("TrueCrypt Setup","Select one of the modes","[CLASS:Button; INSTANCE:3]") ; Next> button
		EndIf

		; Warning that V6.2a doesn't fully work with a Windows 7 installation
		; This works on V6.2a on Windows 7

		IF WinActive("TrueCrypt Setup","Windows 7") Then
			WinActivate("TrueCrypt Setup","Windows 7")
			ControlClick("TrueCrypt Setup","Windows 7","[CLASS:Button; INSTANCE:1]") ; OK button
		EndIf

		; Uncheck the 'create desktop icon' and 'create system restore point' on the options
		; screen and then hit install
		; This works on V6.2a on Windows 7 / V6.3a on Windows 7
		;               V6.2a on Windows XP /

		If WinActive("TrueCrypt Setup","Setup Options") Then
			WinActivate("TrueCrypt Setup","Setup Options")
			ControlClick("TrueCrypt Setup","Setup Options","[CLASS:Button; INSTANCE:10]") ; Add TC icon to desktop checkbox
			ControlClick("TrueCrypt Setup","Setup Options","[CLASS:Button; INSTANCE:9]")  ; Create system restore point checkbox
			; Send("!i") ; Install button
			ControlClick("TrueCrypt Setup","Setup Options","[CLASS:Button; INSTANCE:3]")  ; Install button
		EndIf

		; The installation then goes into installation mode, first by setting a system restore point and
		; then copying all of the files into place and installing the drivers.

		; After the installation process is done, it shows a prompt that it's done.
		; This works on V6.2a on Windows 7 / V6.3a on Windows 7
		;               V6.2a on Windows XP /

		; This is the specific section where Vista handles the automated script differently from
		; XP or Windows 7.  This window is never activated under Vista...

		If WinActive("TrueCrypt Setup", "TrueCrypt has been successfully installed.") Then
			WinActivate("TrueCrypt Setup", "TrueCrypt has been successfully installed.")
			ControlClick("TrueCrypt Setup", "TrueCrypt has been successfully installed.", "[CLASS:Button; INSTANCE:1]") ; OK button
			ExitLoop
		EndIf

	WEnd

EndIf

; it shows a message box asking if they want to see the users guide.  Just click the "No" button
; This works on V6.2a on Windows 7 / V6.3a on Windows 7
;               V6.2a on Windows XP /
;if WinActive("TrueCrypt Setup","TrueCrypt User Guide") Then
;	WinActivate("TrueCrypt Setup","TrueCrypt User Guide")
;	; Send("!n") ; NO button
;	ControlClick("TrueCrypt Setup","TrueCrypt User Guide","[CLASS:Button; INSTANCE:2]") ; NO button

;EndIf

WinWaitActive("TrueCrypt Setup","TrueCrypt User Guide")
ControlClick("TrueCrypt Setup","TrueCrypt User Guide","[CLASS:Button; INSTANCE:2]") ; NO button


; At this point we're back at the main installation window.  Close it out.
; This works on V6.2a on Windows 7 / V6.3a on Windows 7
;               V6.2a on Windows XP /

;if WinActive("TrueCrypt Setup","TrueCrypt has been successfully installed") Then
;	WinActivate("TrueCrypt Setup","TrueCrypt has been successfully installed")
	; send("!f") ; Finish button
;	ControlClick("TrueCrypt Setup","TrueCrypt has been successfully installed","[CLASS:Button; INSTANCE:3]") ; Finish button

	; ExitLoop
;EndIf

WinWaitActive("TrueCrypt Setup","TrueCrypt has been successfully installed")
ControlClick("TrueCrypt Setup","TrueCrypt has been successfully installed","[CLASS:Button; INSTANCE:3]") ; Finish button


; Exit the installation routine
Exit
