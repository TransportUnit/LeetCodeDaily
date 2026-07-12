#!/usr/bin/env pwsh
# Scaffolds a LeetCode problem project. Examples:
#   .\scaffold.ps1              → today's daily
#   .\scaffold.ps1 --pick       → choose from recent dailies
#   .\scaffold.ps1 3653         → by problem number
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
dotnet run --project "$scriptDir/Tools/LeetCodeDaily.Scaffold" -c Release -- @args
exit $LASTEXITCODE
