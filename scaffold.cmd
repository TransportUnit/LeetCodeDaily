@echo off
rem Legt ein LeetCode-Problem-Projekt an (siehe scaffold.ps1 fuer Beispiele).
dotnet run --project "%~dp0Tools\LeetCodeDaily.Scaffold" -c Release -- %*
exit /b %ERRORLEVEL%
