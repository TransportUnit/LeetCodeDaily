#!/usr/bin/env pwsh
# Legt ein LeetCode-Problem-Projekt an. Beispiele:
#   .\scaffold.ps1              → heutige Daily
#   .\scaffold.ps1 --pick       → aus den letzten Dailies wählen
#   .\scaffold.ps1 3653         → per Aufgabennummer
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
dotnet run --project "$scriptDir/Tools/LeetCodeDaily.Scaffold" -c Release -- @args
exit $LASTEXITCODE
