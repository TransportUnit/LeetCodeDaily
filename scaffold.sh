#!/usr/bin/env bash
# Scaffolds a LeetCode problem project (see scaffold.ps1 for examples).
set -e
exec dotnet run --project "$(dirname "$0")/Tools/LeetCodeDaily.Scaffold" -c Release -- "$@"
