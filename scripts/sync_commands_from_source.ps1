# Sync remaining command sources + MainForm from original BimTools.MEPsupport (behaviour identical).
# Run once after clone if command files are missing.
$ErrorActionPreference = "Stop"
$root = Split-Path -Parent $PSScriptRoot
$srcDir = Join-Path $root "src\Hangerduct"
$orig = "https://raw.githubusercontent.com/amdghedy/BimTools.MEPsupport/main"

$files = @(
  "CableTrayHangerCommand.cs",
  "Cable_TrayREC.cs",
  "DuctHangerCommand.cs",
  "DuctHangerCommandREC.cs",
  "HangerBase.cs",
  "MainForm.cs",
  "PipeHangerBEND.cs",
  "PipeHangerCommand.cs",
  "PipeHangerclevis.cs",
  "ductCommandB.cs"
)

New-Item -ItemType Directory -Force -Path $srcDir | Out-Null
foreach ($f in $files) {
  $url = "$orig/Hangerduct/$f"
  $out = Join-Path $srcDir $f
  Write-Host "Downloading $f ..."
  Invoke-WebRequest -Uri $url -OutFile $out -UseBasicParsing
}

# MainForm.resx (large)
$resxUrl = "$orig/Hangerduct.MainForm.resx"
$resxOut = Join-Path $srcDir "MainForm.resx"
Write-Host "Downloading MainForm.resx ..."
Invoke-WebRequest -Uri $resxUrl -OutFile $resxOut -UseBasicParsing

# Icon
$iconDir = Join-Path $root "Resources"
New-Item -ItemType Directory -Force -Path $iconDir | Out-Null
Invoke-WebRequest -Uri "$orig/Hangerduct.Resources.AGG.png" -OutFile (Join-Path $iconDir "AGG.png") -UseBasicParsing

Write-Host "Done. Fix Transaction attributes if needed:"
Write-Host '  [Transaction(TransactionMode.Manual)]'
