#define MyAppName "Opener"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Daniel Strayker Nowak"
#define MyAppURL "https://straykerpl.github.io"
#define MyAppExeName "Opener.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{822CC883-E0F2-494C-A854-7FB033938F2C}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
UninstallDisplayIcon={app}\{#MyAppExeName}
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
PrivilegesRequiredOverridesAllowed=dialog
OutputBaseFilename=opener-setup
SetupIconFile=Opener\signet.ico
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "polish"; MessagesFile: "compiler:Languages\Polish.isl"

[Messages]
english.ConfigFilePrompt=The configuration file %1 already exists. Do you want to replace it with the new one?
polish.ConfigFilePrompt=Plik konfiguracyjny %1 już istnieje. Czy chcesz zastąpić go nowym?

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "keepconfig"; Description: "Keep existing configuration files"; GroupDescription: "Configuration:"; Flags: unchecked

[Files]
Source: "Opener\bin\x64\Release\net8.0\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "Opener\bin\x64\Release\net8.0\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs; Excludes: "*.config,appsettings.json,settings.xml"

Source: "Opener\bin\x64\Release\net8.0\websites.txt"; DestDir: "{app}"; Flags: ignoreversion onlyifdoesntexist; Tasks: keepconfig
Source: "Opener\bin\x64\Release\net8.0\websites.txt"; DestDir: "{app}"; Flags: ignoreversion confirmoverwrite; Tasks: not keepconfig

Source: "Opener\bin\x64\Release\net8.0\apps.txt"; DestDir: "{app}"; Flags: ignoreversion onlyifdoesntexist; Tasks: keepconfig
Source: "Opener\bin\x64\Release\net8.0\apps.txt"; DestDir: "{app}"; Flags: ignoreversion confirmoverwrite; Tasks: not keepconfig

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

