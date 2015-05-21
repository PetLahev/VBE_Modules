; Installs the VBE Components add-in to end user machine
[Setup]
; ensure that you use your OWN APP ID
#define APP_ID "59507bb9-1380-406e-929d-ed5030f7b1bf"

#define APP_NAME "VBE Components Manager"
#define DEST_SUB_DIR "VBEComponentsManager"
#define CONNECT_CLASS_FULL_NAME "VbeComponents.Connect"
#define COMPANY_NAME "PetLahev"
#define RUNTIME_VERSION "v4.0.30319"
#define COPYRIGHT_YEAR "2015"
#define DLL_FILE_NAME "VbeComponents.dll"
#define LICENSE_FILE "License.rtf"
#define SETUP_FILE_NAME "VBE Components Setup"
#define VERSION "1.0.0"
#define CONNECT_PROGID "VbeComponents.Connect"
#define CONNECT_CLSID "59507bb9-1380-406e-929d-ed5030f7b1bf"
#define ASSEMBLY_FULL_NAME ""

ArchitecturesAllowed=x86 x64
ArchitecturesInstallIn64BitMode=x64

AppId={#APP_ID}
VersionInfoVersion={#VERSION}
OutputBaseFilename={#SETUP_FILE_NAME}
LicenseFile=.\Sources\{#LICENSE_FILE}
PrivilegesRequired=lowest
AppName={#APP_NAME}
AppVerName={#APP_NAME}
DefaultGroupName={#APP_NAME}
AppPublisher={#COMPANY_NAME}
DefaultDirName={localappdata}\{#COMPANY_NAME}\{#DEST_SUB_DIR}
Compression=lzma/Max
SolidCompression=true
DisableReadyPage=true
ShowLanguageDialog=no
UninstallLogMode=append
DisableProgramGroupPage=true
VersionInfoCompany={#COMPANY_NAME}
AppCopyright=Copyright {#COPYRIGHT_YEAR} {#COMPANY_NAME}
AlwaysUsePersonalGroup=true
InternalCompressLevel=Ultra
AllowNoIcons=true
DisableDirPage=true
LanguageDetectionMethod=locale

[Languages]
Name: English; MessagesFile: compiler:Default.isl

[Types]
Name: Custom; Description: Custom; Flags: iscustom

[Files]
Source: Sources\{#LICENSE_FILE}; DestDir:{app}; Flags: ignoreversion;
Source: Sources\{#DLL_FILE_NAME}; DestDir:{app}; Flags: ignoreversion; AfterInstall:RegisterAddin()

[UninstallDelete]
Name: {app}; Type: filesandordirs

[CustomMessages]
English.NetFrameworkNotInstalled=Microsoft .NET Framework 4.0 was not detected

[Run]
; http://stackoverflow.com/questions/5618337/how-to-register-a-net-dll-using-inno-setup
Filename: "{dotnet4032}\RegAsm.exe"; Parameters: "/codebase {#DLL_FILE_NAME}"; WorkingDir: "{app}"; Flags: runascurrentuser runminimized; StatusMsg: "Registering Controls..."; Check: Is32BitOfficeInstalled
Filename: "{dotnet4064}\RegAsm.exe"; Parameters: "/codebase {#DLL_FILE_NAME}"; WorkingDir: "{app}"; Flags: runascurrentuser runminimized; StatusMsg: "Registering Controls..."; Check: Is64BitOfficeInstalled

[UninstallRun]
Filename: "{dotnet4032}\RegAsm.exe"; Parameters: "/u {#DLL_FILE_NAME}"; WorkingDir: "{app}"; StatusMsg: "Unregistering Controls..."; Flags: runascurrentuser runminimized; Check: Is32BitOfficeInstalled
Filename: "{dotnet4064}\RegAsm.exe"; Parameters: "/u {#DLL_FILE_NAME}"; WorkingDir: "{app}"; StatusMsg: "Unregistering Controls..."; Flags: runascurrentuser runminimized; Check: Is64BitOfficeInstalled


[Code]
// The following code is adapted from: http://stackoverflow.com/a/11651515/2301065
const
  SCS_32BIT_BINARY = 0;
  SCS_64BIT_BINARY = 6;
  // There are other values that GetBinaryType can return, but we're not interested in them.
  OfficeNotFound = -1;
  
var
  HasCheckedOfficeBitness: Boolean;
  OfficeIs64Bit: Boolean;

function GetBinaryType(lpApplicationName: AnsiString; var lpBinaryType: Integer): Boolean;
external 'GetBinaryTypeA@kernel32.dll stdcall';

function GetOfficeAppBitness(exeName: string): Integer;
var
  appPath: String;
  binaryType: Integer;
begin
  Result := OfficeNotFound;  // Default value.

  if RegQueryStringValue(HKEY_LOCAL_MACHINE,
    'SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\' + exeName,
    '', appPath) then begin
    try
      if GetBinaryType(appPath, binaryType) then Result := binaryType;
    except
    end;
  end;
end;

function GetOfficeBitness(): Integer;
var
  appBitness: Integer;
  officeExeNames: array[0..4] of String;
  i: Integer;
begin
  officeExeNames[0] := 'excel.exe';
  officeExeNames[1] := 'msaccess.exe';
  officeExeNames[2] := 'winword.exe';
  officeExeNames[3] := 'outlook.exe';
  officeExeNames[4] := 'powerpnt.exe';

  for i := 0 to 4 do begin
    appBitness := GetOfficeAppBitness(officeExeNames[i]);
    if appBitness <> OfficeNotFound then begin
      Result := appBitness;
      exit;
    end;
  end;
  // Note if we get to here then we haven't found any Office versions.  Should
  Result := -1;  
end;

function Is64BitOfficeInstalled(): Boolean;
begin
  if (not HasCheckedOfficeBitness) then 
    OfficeIs64Bit := (GetOfficeBitness() = SCS_64BIT_BINARY);
  Result := OfficeIs64Bit;
end;

function Is32BitOfficeInstalled(): Boolean;
begin
  Result := (not Is64BitOfficeInstalled());
end;

// http://kynosarges.org/DotNetVersion.html
function IsDotNetDetected(version: string; service: cardinal): boolean;
// Indicates whether the specified version and service pack of the .NET Framework is installed.
//
// version -- Specify one of these strings for the required .NET Framework version:
//    'v1.1.4322'     .NET Framework 1.1
//    'v2.0.50727'    .NET Framework 2.0
//    'v3.0'          .NET Framework 3.0
//    'v3.5'          .NET Framework 3.5
//    'v4\Client'     .NET Framework 4.0 Client Profile
//    'v4\Full'       .NET Framework 4.0 Full Installation
//    'v4.5'          .NET Framework 4.5
//
// service -- Specify any non-negative integer for the required service pack level:
//    0               No service packs required
//    1, 2, etc.      Service pack 1, 2, etc. required
var
    key: string;
    install, release, serviceCount: cardinal;
    check45, success: boolean;
begin
    // .NET 4.5 installs as update to .NET 4.0 Full
    if version = 'v4.5' then begin
        version := 'v4\Full';
        check45 := true;
    end else
        check45 := false;

    // installation key group for all .NET versions
    key := 'SOFTWARE\Microsoft\NET Framework Setup\NDP\' + version;

    // .NET 3.0 uses value InstallSuccess in subkey Setup
    if Pos('v3.0', version) = 1 then begin
        success := RegQueryDWordValue(HKLM, key + '\Setup', 'InstallSuccess', install);
    end else begin
        success := RegQueryDWordValue(HKLM, key, 'Install', install);
    end;

    // .NET 4.0/4.5 uses value Servicing instead of SP
    if Pos('v4', version) = 1 then begin
        success := success and RegQueryDWordValue(HKLM, key, 'Servicing', serviceCount);
    end else begin
        success := success and RegQueryDWordValue(HKLM, key, 'SP', serviceCount);
    end;

    // .NET 4.5 uses additional value Release
    if check45 then begin
        success := success and RegQueryDWordValue(HKLM, key, 'Release', release);
        success := success and (release >= 378389);
    end;

    result := success and (install = 1) and (serviceCount >= service);
end;

function InitializeSetup(): Boolean;
var
   iErrorCode: Integer;
begin
  // MS .NET Framework 4.0 must be installed for this application to work.
  if not IsDotNetDetected('v4\Full', 0) then
  begin
    MsgBox(ExpandConstant('{cm:NetFrameworkNotInstalled}'), mbCriticalError, mb_Ok);
    ShellExec('open', 'http://download.microsoft.com/download/9/5/A/95A9616B-7A37-4AF6-BC36-D6EA96C8DAAE/dotNetFx40_Full_x86_x64.exe', '', '', SW_SHOW, ewNoWait, iErrorCode) 
    Result := False;
  end
  else
    Result := True;
end;

procedure RegisterAddinForIDE(const iRootKey: Integer; const sAddinSubKey: String; const sProgIDConnect: String);
begin
   RegWriteStringValue(iRootKey, sAddinSubKey + '\' + sProgIDConnect, 'FriendlyName', '{#APP_NAME}');
   RegWriteStringValue(iRootKey, sAddinSubKey + '\' + sProgIDConnect, 'Description' , '{#APP_NAME}');
   RegWriteDWordValue (iRootKey, sAddinSubKey + '\' + sProgIDConnect, 'LoadBehavior', 3);
end;

procedure UnregisterAddinForIDE(const iRootKey: Integer; const sAddinSubKey: String; const sProgIDConnect: String);
begin
   if RegKeyExists(iRootKey, sAddinSubKey + '\' + sProgIDConnect) then
      RegDeleteKeyIncludingSubkeys(iRootKey, sAddinSubKey + '\' + sProgIDConnect);
end;

procedure RegisterAddin();
begin
  if Is32BitOfficeInstalled() then
    RegisterAddinForIDE(HKCU32, 'Software\Microsoft\VBA\VBE\6.0\Addins', '{#CONNECT_PROGID}');

  if Is64BitOfficeInstalled() then 
    RegisterAddinForIDE(HKCU64, 'Software\Microsoft\VBA\VBE\6.0\Addins64', '{#CONNECT_PROGID}');
end;

procedure UnregisterAddin();
begin
  UnregisterAddinForIDE(HKCU32, 'Software\Microsoft\VBA\VBE\6.0\Addins', '{#CONNECT_PROGID}');
  if IsWin64() then 
    UnregisterAddinForIDE(HKCU64, 'Software\Microsoft\VBA\VBE\6.0\Addins64', '{#CONNECT_PROGID}');
end;

procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
begin
  if CurUninstallStep = usUninstall then UnregisterAddin();
end;
