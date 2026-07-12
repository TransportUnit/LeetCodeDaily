@echo off
rem Scaffolds a LeetCode problem project (see scaffold.ps1 for examples).
dotnet run --project "%~dp0Tools\LeetCodeDaily.Scaffold" -c Release -- %*
exit /b %ERRORLEVEL%
