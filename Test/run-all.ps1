$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path

# Der Runner baut alle Problem-Projekte selbst (ein paralleler MSBuild-Aufruf)
# und führt sie anschließend parallel aus. Argumente werden durchgereicht,
# z.B.: .\run-all.ps1 --filter 3653
dotnet run --project "$scriptDir\LeetCodeDaily.Runner" -c Release -- @args

exit $LASTEXITCODE
