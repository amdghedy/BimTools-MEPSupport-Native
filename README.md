# BimTools.MEPSupport (Native)

Native Revit add-in port of [BimTools.MEPsupport](https://github.com/amdghedy/BimTools.MEPsupport).

**Ribbon location:** Revit tab **`BIM TOOLS`** → panel **`MEP Tools`** → **Hanger Generator**

All hanger generation functions, option order, and behaviour are preserved from the source project (duct / pipe / cable tray hangers, clevis, bend, base, rectangular variants).

## Quick start

```bat
git clone https://github.com/amdghedy/BimTools-MEPSupport-Native.git
cd BimTools-MEPSupport-Native
powershell -ExecutionPolicy Bypass -File scripts\sync_commands_from_source.ps1
set REVIT_API_PATH=C:\Program Files\Autodesk\Revit 2024
dotnet build BimTools.MEPSupport.csproj -c Release
```

The sync script pulls command sources + `MainForm` + icon from the original repo (identical behaviour). Ribbon registration in this repo targets **BIM TOOLS** / **MEP Tools** only.

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

Entry: `Hangerduct.CreateHanger` → `MainForm` → dispatch by `SelectedOption` (order unchanged).

## Host registration (this port)

| Item | Value |
|------|--------|
| Tab | **BIM TOOLS** (create if missing; reuse if present) |
| Panel | **MEP Tools** (create if missing; reuse if present) |
| Button | `HAN_But` / **Hanger Generator** (skip if already present) |
| Class | `Hangerduct.CreateHanger` |
| Add-in | `Deploy/BimTools.MEPSupport.addin` → `Hangerduct.Extrenal_application` |

## Requirements

- Autodesk Revit 2020–2026 (default build path: 2024)
- .NET Framework 4.8
- Windows x64

## Install

1. Build Release (`Hangerduct.dll` in `bin\Release\`).
2. Copy `Hangerduct.dll` + `Deploy\BimTools.MEPSupport.addin` to `%APPDATA%\Autodesk\Revit\Addins\<YEAR>\`.
3. Restart Revit → **BIM TOOLS** → **MEP Tools** → **Hanger Generator**.

## Uninstall

Remove the `.addin` and `Hangerduct.dll` from the Addins folder; restart Revit.

## Origin

Derived from `amdghedy/BimTools.MEPsupport`. Behaviour intentionally unchanged; packaging and ribbon host registration updated for **BIM TOOLS**.
