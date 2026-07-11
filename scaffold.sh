#!/usr/bin/env bash
# Legt ein LeetCode-Problem-Projekt an (siehe scaffold.ps1 für Beispiele).
set -e
exec dotnet run --project "$(dirname "$0")/Tools/LeetCodeDaily.Scaffold" -c Release -- "$@"
