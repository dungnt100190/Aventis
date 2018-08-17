Option Explicit

Const READ_ONLY = 1

Dim wshShell : Set wshShell = WScript.CreateObject ("WScript.Shell")
Dim objFSO : Set objFSO = WScript.CreateObject("Scripting.FileSystemObject")
Dim envName

' Find MSI Package
Dim SetupName, file : SetupName = "KiSS4"
For Each file in objFSO.GetFolder("Debug").Files
	If Right(file, 4) = ".msi" Then
		SetupName = Mid(file, 1, Len(file) - 4)
		SetupName = Mid(SetupName, InStrRev(SetupName, "\") + 1)
		Exit For
	End If
Next

Call objFSO.CopyFile("Debug\" + SetupName + ".msi", SetupName + ".msi")
If objFSO.FileExists("Release\" + SetupName + ".msi") Then
	Dim debugMSI : Set debugMSI = objFSO.GetFile(SetupName + ".msi")
	Dim releaseMSI : Set releaseMSI = objFSO.GetFile("Release\" + SetupName + ".msi")

	If releaseMSI.DateLastModified > debugMSI.DateLastModified Then
		Call objFSO.CopyFile("Release\" + SetupName + ".msi", SetupName + ".msi")
	End If
End If


Call RunMSIQuery(SetupName + ".msi", "UPDATE `Property` SET `Property`.`Value` = 1 WHERE `Property` = 'ALLUSERS'")

Dim configFile : configFile = "KiSS4.exe.config"
On Error Resume Next
configFile = RunMSIQuery(SetupName + ".msi", "SELECT `File` FROM `File` WHERE `FileName` = 'KISS4E~1.CON|KiSS4.exe.config'").StringData(1)
On Error Goto 0

Dim productVersion : productVersion = RunMSIQuery(SetupName + ".msi", "SELECT `Value` FROM `Property` WHERE `Property` = 'ProductVersion'").StringData(1)
Dim Upgrade

' Update IBANKernel.dll
If objFSO.FileExists("IBANKernel.DLL") Then
	Dim ibanKernelVersion : ibanKernelVersion = RunMSIQuery(SetupName + ".msi", "SELECT `Version` FROM `File` WHERE `FileName` = 'IBANKE~1.DLL|IBANKernel.dll'").StringData(1)
	Dim ibanKernelVersionNew : ibanKernelVersionNew = objFSO.GetFileVersion("IBANKernel.DLL")

	If ibanKernelVersion < ibanKernelVersionNew Then
		Call MsgBox("Update IBANKernel.DLL " + ibanKernelVersion + " to " + ibanKernelVersionNew)
		
		Call RunMSIQuery(SetupName + ".msi", "UPDATE `File` SET `File`.`Version` = '" + ibanKernelVersionNew + "'  WHERE `FileName` = 'IBANKE~1.DLL|IBANKernel.dll'")

		' Extract MSI
		Call wshShell.Run("msi2xml.exe -c files -o msi.xml " + SetupName + ".msi", 1, true)

		Dim ibanKernelFile : ibanKernelFile = RunMSIQuery(SetupName + ".msi", "SELECT `File` FROM `File` WHERE `FileName` = 'IBANKE~1.DLL|IBANKernel.dll'").StringData(1)
		Call objFSO.CopyFile("IBANKernel.DLL", ".\files\" + ibanKernelFile)

		Call objFSO.DeleteFile(SetupName + ".msi")
		Call wshShell.Run("xml2msi.exe -c -d -m -o " + SetupName + ".msi msi.xml", 1, true)
	End If
End If

' Extract MSI
If Not objFSO.FileExists("msi.xml") Then
	Call wshShell.Run("msi2xml.exe -c files -o msi.xml " + SetupName + ".msi", 1, true)
End If

' MSI Integration
If SetupName = "KiSS4_FAMOZ" Then
	Call CreateMSI(SetupName + "_Entwicklung.msi",     "Entwicklung",     "{C8B303FF-8EB9-4128-8F1A-642AEEC50E4A}")

	Call CreateMSI(SetupName + "_Schulungsmaster.msi", "Schulungsmaster", "{351F370C-5B32-46be-AA38-BA92F71674AD}")
'	Call CreateMSI(SetupName + "_Spielwiese.msi",      "Spielwiese",      "{1196D739-E92D-452c-AE6B-D3505DB40F55}")
End If

Call CreateMSI(SetupName + "_Test.msi",        "Test",        "{6D46D4FF-5D39-40f8-96A3-488F75370A2A}")
Call CreateMSI(SetupName + "_Integration.msi", "Integration", "{BCE7A7DF-D05C-4fa6-9C68-C3BF62EA721E}")
Call CreateMSI(SetupName + "_Schulung.msi",    "Schulung",    "{F8C91165-7976-4185-92A7-283C44E597FB}")


' ClreanUp
Call objFSO.DeleteFile("msi.xml")
Call objFSO.DeleteFile("msi.xsl")
Call objFSO.DeleteFile(".\files\*")
Call objFSO.DeleteFolder(".\files")

Set wshShell = nothing
Set objFSO = nothing

Call MsgBox("MSI Package successfully created")


Sub CreateMSI(msiFile, envName, upgradeCode)
	If objFSO.FileExists(".\files\" + configFile) AND objFSO.FileExists("KiSS4_" + envName + ".exe.config") Then
		Call objFSO.CopyFile("KiSS4_" + envName + ".exe.config", ".\files\" + configFile)

		Dim objFile : Set objFile = objFSO.GetFile(".\files\" + configFile)
		objFile.Attributes = objFile.Attributes AND NOT READ_ONLY
		Set objFile = nothing
	End If

	Call wshShell.Run("xml2msi.exe -c -d -m -o " + msiFile + " msi.xml", 1, true)
	Call RunMSIQuery(msiFile, "UPDATE `CustomAction` SET `CustomAction`.`Target` = '[ProgramFilesFolder][Manufacturer]\KiSS4_" + envName + "'  WHERE `Source` = 'TARGETDIR'")
	Call RunMSIQuery(msiFile, "UPDATE `Property`     SET `Property`.`Value` = 'KiSS 4 - " + envName + "'                                       WHERE `Property` = 'ProductName'")
	Call RunMSIQuery(msiFile, "UPDATE `Shortcut`     SET `Shortcut`.`Name` = 'KISS4~1|KiSS 4 - " + envName + "'                                WHERE `Name` = 'KISS4~1|KiSS 4'")
	Call RunMSIQuery(msiFile, "UPDATE `Shortcut`     SET `Shortcut`.`Name` = 'KISS4~2|KiSS 4 - " + envName + "'                                WHERE `Name` = 'KISS4~2|KiSS 4'")

	Call RunMSIQuery(msiFile, "UPDATE `Property`     SET `Property`.`Value` = '" + upgradeCode + "'                                            WHERE `Property` = 'UpgradeCode'")
	Call RunMSIQuery(msiFile, "DELETE FROM `Upgrade`")
	Call RunMSIQuery(msiFile, "INSERT INTO `Upgrade` (`UpgradeCode`, `VersionMin`, `VersionMax`, `Attributes`, `ActionProperty`) VALUES ('" + upgradeCode + "', '1.0.0.0', '" + ProductVersion + "', 256, 'PREVIOUSVERSIONSINSTALLED')")
	Call RunMSIQuery(msiFile, "INSERT INTO `Upgrade` (`UpgradeCode`, `VersionMin`, `Attributes`, `ActionProperty`) VALUES ('" + upgradeCode + "', '" + ProductVersion + "', 258, 'NEWERPRODUCTFOUND')")
End Sub


' *****************************************************************************
' *** GenerateGUID()                                                        ***
' *****************************************************************************
Function GenerateGUID()
	Dim TypeLib : Set TypeLib = CreateObject("Scriptlet.TypeLib")
	GenerateGUID = TypeLib.Guid
End Function

' *****************************************************************************
' *** RunMSIQuery(msiFile, msiQuery)                                        ***
' *****************************************************************************
Const msiOpenDatabaseModeReadOnly = 0
Const msiOpenDatabaseModeTransact = 1

Function RunMSIQuery(msiFile, msiQuery)
	'On Error Resume Next
	Dim installer : Set installer = Nothing
	Set installer = Wscript.CreateObject("WindowsInstaller.Installer") : CheckError

	' Scan arguments for valid SQL keyword and to determine if any update operations
	Dim openMode : openMode = msiOpenDatabaseModeReadOnly

	Dim keyword : keyword = msiQuery
	Dim keywordLen : keywordLen = InStr(1, keyword, " ", vbTextCompare)
	If (keywordLen) Then keyword = UCase(Left(keyword, keywordLen - 1))
	If InStr(1, "UPDATE INSERT DELETE CREATE ALTER DROP", keyword, vbTextCompare) Then
		openMode = msiOpenDatabaseModeTransact
	End If

	' Open database
	Dim database : Set database = installer.OpenDatabase(msiFile, openMode) : CheckError

	' Process SQL statements
	Dim view

	Set view = database.OpenView(msiQuery) : CheckError
	view.Execute : CheckError
	If Ucase(Left(msiQuery, 6)) = "SELECT" Then
		Set RunMSIQuery = view.Fetch
	End If

	If openMode = msiOpenDatabaseModeTransact Then database.Commit
End Function

Sub CheckError
	Dim message, errRec
	If Err = 0 Then Exit Sub
	message = Err.Source & " " & Hex(Err) & ": " & Err.Description
	If Not installer Is Nothing Then
		Set errRec = installer.LastErrorRecord
		If Not errRec Is Nothing Then message = message & vbLf & errRec.FormatText
	End If
	MsgBox message
End Sub