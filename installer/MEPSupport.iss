#define ProductName "BimTools MEP Support"
#define ProductVersion "1.0.0"
#define Publisher "amdghedy"

[Setup]
AppId={{E91B38C7-AB41-4B13-93E4-4B8C5C9A7D31}
AppName={#ProductName} for Autodesk Revit
AppVersion={#ProductVersion}
AppPublisher={#Publisher}
DefaultDirName={userappdata}\Autodesk\Revit\Addins
DisableProgramGroupPage=yes
PrivilegesRequired=lowest
OutputDir=..\Release
OutputBaseFilename=MEPSupport-Installer
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
ArchitecturesInstallIn64BitMode=x64
Uninstallable=yes
UninstallDisplayName=BimTools MEP Support for Autodesk Revit

[Types]
Name: "full"; Description: "Install for all supported Revit versions"
Name: "custom"; Description: "Choose Revit versions"; Flags: iscustom

[Components]
Name: "rv2020"; Description: "Revit 2020"; Types: full custom
Name: "rv2021"; Description: "Revit 2021"; Types: full custom
Name: "rv2022"; Description: "Revit 2022"; Types: full custom
Name: "rv2023"; Description: "Revit 2023"; Types: full custom
Name: "rv2024"; Description: "Revit 2024"; Types: full custom
Name: "rv2025"; Description: "Revit 2025"; Types: full custom
Name: "rv2026"; Description: "Revit 2026"; Types: full custom
Name: "rv2027"; Description: "Revit 2027"; Types: full custom

[Files]
#define AddVersionFiles(V, C) Source: "..\Release\RevitVersions\" + V + "\Hangerduct.dll"; DestDir: "{userappdata}\Autodesk\Revit\Addins\" + V; Components: C; Flags: ignoreversion; Source: "..\Release\RevitVersions\" + V + "\BimTools.MEPSupport.addin"; DestDir: "{userappdata}\Autodesk\Revit\Addins\" + V; Components: C; Flags: ignoreversion

AddVersionFiles("2020", "rv2020")
AddVersionFiles("2021", "rv2021")
AddVersionFiles("2022", "rv2022")
AddVersionFiles("2023", "rv2023")
AddVersionFiles("2024", "rv2024")
AddVersionFiles("2025", "rv2025")
AddVersionFiles("2026", "rv2026")
AddVersionFiles("2027", "rv2027")
