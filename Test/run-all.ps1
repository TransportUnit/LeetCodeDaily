$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$problemsDir = Join-Path $scriptDir "..\Problems"

Write-Host "Building problem projects (Release)..."

$projects = Get-ChildItem -Path $problemsDir -Recurse -Filter *.csproj

foreach ($proj in $projects) {
    Write-Host "Building $($proj.Name)..."

    dotnet build "$($proj.FullName)" -c Release

    if ($LASTEXITCODE -ne 0) {
        Write-Host "❌ Build failed: $($proj.Name)" -ForegroundColor Red
        exit 1
    }
}

Write-Host ""
Write-Host "Building runner (Release)..."

dotnet build "$scriptDir\LeetCodeDaily.Runner" -c Release

if ($LASTEXITCODE -ne 0) {
    Write-Host "❌ Runner build failed" -ForegroundColor Red
    exit 1
}

Write-Host ""
Write-Host "Running all problems..." -ForegroundColor Cyan
Write-Host ""

dotnet run --project "$scriptDir\LeetCodeDaily.Runner" -c Release

exit $LASTEXITCODE