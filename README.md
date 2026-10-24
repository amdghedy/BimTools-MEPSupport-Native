# BimTools.MEPSupport

Native Revit add-in port of [BimTools.MEPsupport](https://github.com/amdghedy/BimTools.MEPsupport).

**Ribbon location:** Revit tab **`BIM TOOLS`** → panel **`MEP Tools`** → **Hanger Generator**

All hanger generation functions, option order, and behaviour are preserved from the source project (duct / pipe / cable tray hangers, clevis, bend, base, rectangular variants).

## Features

| Option | Command class | Description |
|--------|---------------|-------------|
| Pipe | `PipeHangerCommand` | Standard pipe hangers |
| Pipec | `PipeHangerclevis` | Pipe clevis hangers |
| Pipeb | `PipeHangerBEND` | Pipe bend hangers |
| Pipebase | `HangerBase` | Pipe base hangers |
| Duct | `DuctHangerCommand` | Standard duct hangers |
| DuctBase | `ductCommandB` | Duct base hangers |
| DuctR | `DuctHangerCommandREC` | Rectangular duct hangers |
| CableTray | `CableTrayHangerCommand` | Cable tray hangers |
| Cable_TrayREC | `Cable_TrayREC` | Rectangular cable tray hangers |

Entry command: `Hangerduct.CreateHanger` (opens `MainForm`, then dispatches by selected option).

## Requirements

- Autodesk Revit 2020–2026 (API compatible; default build path targets 2024)
- .NET Framework 4.8
- Windows x64

## Project tree

```
BimTools.MEPSupport/
├── BimTools.MEPSupport.sln
├── BimTools.MEPSupport.csproj
├── README.md
├── Deploy/
│   └── BimTools.MEPSupport.addin
├── Resources/
│   └── AGG.png
└── src/
    ├── Hangerduct/          # Commands, filters, MainForm, External Application
    └── Properties/          # AssemblyInfo, Resources
```

## Build

```bat
REM Optional: set Revit API path (default: C:\Program Files\Autodesk\Revit 2024)
set REVIT_API_PATH=C:\Program Files\Autodesk\Revit 2024

dotnet build BimTools.MEPSupport.csproj -c Release
```

Or in Visual Studio: open `BimTools.MEPSupport.sln`, set configuration to Release, build.

Output: `bin\Release\Hangerduct.dll` (+ `.addin` copy).

### Validate references

```bat
dir "%REVIT_API_PATH%\RevitAPI.dll"
dir "%REVIT_API_PATH%\RevitAPIUI.dll"
```

## Install

1. Build Release.
2. Copy `Hangerduct.dll` and `Deploy\BimTools.MEPSupport.addin` to one of:
   - `%APPDATA%\Autodesk\Revit\Addins\2024\`
   - or a folder referenced by the `.addin` `Assembly` path (use full path in `.addin` if preferred).
3. Edit `.addin` if the DLL is not beside the addin file:
   ```xml
   <Assembly>C:\Path\To\Hangerduct.dll</Assembly>
   ```
4. Restart Revit.
5. Open tab **BIM TOOLS** → panel **MEP Tools** → **Hanger Generator**.

### Portable install (no admin)

User Addins folder only (`%APPDATA%\Autodesk\Revit\Addins\<YEAR>\`).

## Uninstall

Delete `BimTools.MEPSupport.addin` and `Hangerduct.dll` from the Addins folder, restart Revit.

## Host registration notes

- Tab name: **`BIM TOOLS`** (created if missing; existing tab reused).
- Panel name: **`MEP Tools`** (created if missing; existing panel reused).
- Button id: `HAN_But` — skipped if already present (no duplicates).

## Limitations

- Source logic was recovered from a decompiled tree; UI layout relies on embedded `MainForm.resx`.
- Family files used by hangers must be available as in the original workflow.
- Contextual help points to the original AG Hanger Generator help path if present.

## License / origin

Derived from `amdghedy/BimTools.MEPsupport`. Behaviour intentionally unchanged; only project packaging and ribbon host registration updated for **BIM TOOLS**.
