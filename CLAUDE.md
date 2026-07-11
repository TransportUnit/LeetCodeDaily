# LeetCodeDaily — notes for Claude

C# sandbox for solving and archiving LeetCode problems. One project per
problem under `Problems/`, a core library with the test-case runner, a
scaffolder CLI, unit tests and an archive runner. See README.md for the
user-facing docs.

## Commands

```bash
dotnet test Test/LeetCodeDaily.Tests                      # unit tests (core + scaffolder)
dotnet run --project Test/LeetCodeDaily.Runner -c Release # run ALL problems (slow-ish)
dotnet run --project Test/LeetCodeDaily.Runner -c Release -- --filter <substr>
dotnet run --project Tools/LeetCodeDaily.Scaffold -- 3653 # scaffold a problem (needs network)
```

## Conventions

- TargetFramework net10.0 everywhere. Problem projects inherit everything from
  `Problems/Directory.Build.props`; their csprojs are intentionally empty hulls.
  Per-project extras allowed: `RootNamespace`, `AllowUnsafeBlocks`.
- Problem folder/project name: `<frontendId>. <Title>` (with spaces).
  Namespace in Solution.cs: `_<frontendId>.<Title_with_underscores>`
  (see `CodeGenerator.BuildNamespace`).
- Program.cs test-case format: one line per parameter, then the expected
  result, blank line between cases; parsed by `ParseCases<TIn..., TResult>()`.
- `Case<TInput,TResult>` holds ResultGenerator/ResultChecker **statically per
  closed generic type** — in tests, use distinct type combinations to avoid
  cross-test pollution.
- `LeetCodeDaily.slnx`: problems sorted alphabetically in the /Problems/
  folder. `LeetCodeDaily.Recent.slnx` is fully rewritten by
  `SolutionFileUpdater` (newest first, max 15) — do not hand-edit.
- Commit author must be the anonymous GitHub identity
  (`TransportUnit <65557505+TransportUnit@users.noreply.github.com>`), never a
  real e-mail address.

## Gotchas

- Test-case strings inside Program.cs files must be split line-ending
  independently (`ReplaceLineEndings`); `Split("\r\n")` breaks on LF checkouts.
- The Macros/ VSIX project is not buildable with `dotnet` (old-style csproj,
  Windows/VS only) — never add it to CI builds; the runner/tests don't touch it.
- The runner treats a problem as failed on exit code != 0 or "FAILED" in
  stdout; stderr alone is not a failure.
- LeetCode GraphQL fixtures for scaffolder tests live in
  `Test/LeetCodeDaily.Tests/ScaffoldFixtures.cs`; the live API cannot be
  reached from CI/sandboxes, so keep scaffolder logic testable offline.
