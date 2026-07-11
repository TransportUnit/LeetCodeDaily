$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path

# The runner builds all problem projects itself (one parallel MSBuild pass)
# and then executes them in parallel. Arguments are passed through,
# e.g.: .\run-all.ps1 --filter 3653
dotnet run --project "$scriptDir\LeetCodeDaily.Runner" -c Release -- @args

exit $LASTEXITCODE
