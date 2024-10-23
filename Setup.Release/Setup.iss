; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Fractals"
#define MyAppVersion "1.0"
#define MyAppPublisher "Group 5"
#define MyAppExeName "lab2.exe"
#define MyAppAssocName MyAppName + " File"
#define MyAppAssocExt ".myp"
#define MyAppAssocKey StringChange(MyAppAssocName, " ", "") + MyAppAssocExt

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{B0BEC850-4AB9-44E6-830C-611C590C6AA6}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={userdesktop}\AlgorithmsFractals\AlgorithmsFractals
; "ArchitecturesAllowed=x64compatible" specifies that Setup cannot run
; on anything but x64 and Windows 11 on Arm.
ArchitecturesAllowed=x64compatible
; "ArchitecturesInstallIn64BitMode=x64compatible" requests that the
; install be done in "64-bit mode" on x64 or Windows 11 on Arm,
; meaning it should use the native 64-bit Program Files directory and
; the 64-bit view of the registry.
ArchitecturesInstallIn64BitMode=x64compatible
ChangesAssociations=yes
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
; Remove the following line to run in administrative install mode (install for all users.)
PrivilegesRequired=lowest
OutputBaseFilename=mysetup
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\sozvezdie\Desktop\Algorithms Labs\AlgorithmsSecondLab\lab2\bin\Release\net8.0-windows\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\sozvezdie\Desktop\Algorithms Labs\AlgorithmsSecondLab\lab2\bin\Release\net8.0-windows\lab2.deps.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\sozvezdie\Desktop\Algorithms Labs\AlgorithmsSecondLab\lab2\bin\Release\net8.0-windows\lab2.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\sozvezdie\Desktop\Algorithms Labs\AlgorithmsSecondLab\lab2\bin\Release\net8.0-windows\lab2.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\sozvezdie\Desktop\Algorithms Labs\AlgorithmsSecondLab\lab2\bin\Release\net8.0-windows\lab2.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\sozvezdie\Desktop\Algorithms Labs\AlgorithmsSecondLab\lab2\bin\Release\net8.0-windows\lab2.runtimeconfig.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\sozvezdie\Desktop\Algorithms Labs\AlgorithmsSecondLab\lab2\bin\Release\net8.0-windows\OxyPlot.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\sozvezdie\Desktop\Algorithms Labs\AlgorithmsSecondLab\lab2\bin\Release\net8.0-windows\OxyPlot.Wpf.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\sozvezdie\Desktop\Algorithms Labs\AlgorithmsSecondLab\lab2\bin\Release\net8.0-windows\OxyPlot.Wpf.Shared.dll"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Registry]
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocExt}\OpenWithProgids"; ValueType: string; ValueName: "{#MyAppAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}"; ValueType: string; ValueName: ""; ValueData: "{#MyAppAssocName}"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#MyAppExeName},0"
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""
Root: HKA; Subkey: "Software\Classes\Applications\{#MyAppExeName}\SupportedTypes"; ValueType: string; ValueName: ".myp"; ValueData: ""

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
