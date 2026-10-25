# BimTools MEP Support (Native) — Release packages

## Downloads

- **Installer:** [MEPSupport-Installer.exe](MEPSupport-Installer.exe)
- **Version-specific builds:** [RevitVersions](RevitVersions/)

Each version folder contains a separately compiled `Hangerduct.dll`, `BimTools.MEPSupport.addin`, and build information for Revit 2020–2027. Do not reuse a DLL built for a different Revit major version.

## Install

1. Download and run `MEPSupport-Installer.exe`.
2. Select all supported Revit versions or choose only the versions installed on your computer.
3. Close and restart Revit.
4. Open **BIM TOOLS → MEP Tools → Hanger Generator**.

The installer uses per-user Addins folders and does not require administrator privileges.

## Manual installation

Copy the two files from `RevitVersions/<year>/` into:
`%APPDATA%\Autodesk\Revit\Addins\<year>\`

## Build and verification

GitHub Actions builds each version independently using the corresponding Revit API reference packages, validates that the DLL and manifest exist, then compiles the installer only after all eight builds succeed. Successful compilation is not the same as runtime smoke-testing in a live Revit installation.

## Supported functions

The native add-in preserves the Hanger Generator workflows documented in the source project, including pipe, pipe clevis, pipe bend, pipe base, duct, duct base, rectangular duct, cable tray, and rectangular cable tray hangers.
