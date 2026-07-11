# LeetCodeDaily

A C# sandbox for solving LeetCode problems in a real IDE with a real debugger —
and for archiving solved problems so you can revisit approaches later.

One command scaffolds a ready-to-run project for any problem: description as
README, example test cases wired up, the official method signature in place.
Open it, solve it, press F5.

## Prerequisites

- [.NET SDK 10](https://dotnet.microsoft.com/download) (included with Visual Studio 2026)
- Visual Studio 2026 (or any editor — everything works from the CLI too)
- No LeetCode account or API key needed: the scaffolder uses LeetCode's public
  GraphQL API. You only need an account for submitting solutions in the browser.

## Quick start

```powershell
git clone https://github.com/TransportUnit/LeetCodeDaily.git
cd LeetCodeDaily

# scaffold today's daily challenge
.\scaffold.ps1

# open the fast-loading solution with the most recent problems
start LeetCodeDaily.Recent.slnx
```

Set the new project as startup project, write your solution in `Solution.cs`,
press F5. The example test cases run against your code and print
PASSED/FAILED with input, actual/expected result and execution time.

## The scaffolder

```text
scaffold                 today's daily challenge
scaffold --pick          choose from the recent dailies (shows difficulty)
scaffold 3653            a specific problem by number
scaffold two-sum         ... by slug
scaffold <leetcode-url>  ... by URL
scaffold ... --force     overwrite an existing project directory
```

(`scaffold.ps1` for PowerShell, `scaffold.cmd` for cmd, `scaffold.sh` for bash.)

Each run generates under `Problems/<nr>. <title>/`:

- **README.md** — the full problem description converted to Markdown
  (examples, constraints, hints as collapsible spoilers)
- **Solution.cs** — the official C# method signature, decorated with
  `[ResultGenerator]`, in a file-scoped namespace so the class body can be
  copied to/from the LeetCode editor as a single block
- **Program.cs** — the example test cases *including expected outputs*,
  parsed and executed via the core library
- **csproj** — a three-line hull; all build settings come from
  `Problems/Directory.Build.props`

The project is also inserted (alphabetically) into `LeetCodeDaily.slnx` and
into `LeetCodeDaily.Recent.slnx`, which always contains the 15 most recent
problems and loads instantly. Use the full solution only when browsing the
archive.

For *design problems* (`MyHashMap` etc.) and exotic input types the scaffolder
generates a TODO template instead of guessing wrong.

## Anatomy of a problem

`Program.cs` — test cases are a plain string: one line per parameter, then the
expected result, blank line between cases. Quotes around strings are optional.

```csharp
using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

"""
[1,1,1]
[[0,2,1,4]]
4

[2,3,1,5,4]
[[1,4,2,3],[0,2,1,2]]
31
"""
.ParseCases<int[], int[][], int>()
.DetectAndRun();
```

Supported types: primitives, `string`, `char`, arrays (`int[]`, `int[][]`, …),
`IList<T>` / `IList<IList<T>>`, `TreeNode`, `ListNode`, `null` literals.
Custom types can be plugged in via `ParserRegistry.Register<T>(...)`.

`Solution.cs` — the class LeetCode expects, plus one attribute:

```csharp
using LeetCodeDaily.Core;

namespace _3653.XOR_After_Range_Multiplication_Queries_I;

public class Solution
{
    [ResultGenerator]
    public int XorAfterQueries(int[] nums, int[][] queries) { ... }
}
```

Useful extras:

- **Multiple approaches**: add more methods with
  `[ResultGenerator(ApproachIndex = 1)]` and run them via
  `.DetectAndRun(1)` — handy for comparing runtimes.
- **Fair timing**: `.DetectAndRun(warmup: true)` runs the solution once before
  measuring, so the first case doesn't pay the JIT cost. Don't combine with
  solutions that mutate their input.
- **"Return in any order"** problems: append `.IgnoreResultOrder()` before
  `.DetectAndRun()`.
- **`UnsafeRun()`**: infers the `ParseCases` type arguments from the solution
  method via reflection — `"...cases...".UnsafeRun();` is all you need.
- **Custom checking** (in-place problems etc.): `.SetResultChecker(c => ...)`.

## Testing

```powershell
dotnet test Test/LeetCodeDaily.Tests          # unit tests: core parsing + scaffolder
Test\run-all.ps1                              # build & run every archived problem
Test\run-all.ps1 --filter 3653                # ... or a subset
```

The runner builds all problems in one parallel MSBuild pass, executes them in
parallel and fails if any problem prints FAILED or crashes. Both suites run in
GitHub Actions on every push (`.github/workflows/ci.yml`), so a change to the
core library that breaks an archived solution is caught immediately.

## Repository layout

```text
LeetCodeDaily/            core library: Case runner, parsers, TreeNode/ListNode
Problems/<nr>. <title>/   one project per solved problem (the archive)
Problems/Directory.Build.props   shared build settings for all problems
Tools/LeetCodeDaily.Scaffold/    the scaffolder CLI
Test/LeetCodeDaily.Tests/        unit tests (xUnit)
Test/LeetCodeDaily.Runner/       runs the whole archive
Templates/, Macros/       legacy: VS project template + VSIX markup macros,
                          superseded by the scaffolder
```

## Notes

- `LeetCodeDaily.Recent.slnx` is rewritten by the scaffolder; don't edit it by
  hand. `LeetCodeDaily.slnx` is only ever appended to (alphabetically).
- If you previously installed the VS project template: it is no longer needed.
  Visual Studio keeps its own copy under
  `Documents\Visual Studio\Templates\ProjectTemplates` — delete it there if VS
  still offers the old version.
