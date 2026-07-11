using System.Collections.Concurrent;
using System.Diagnostics;

// LeetCodeDaily.Runner
//
// Baut alle Problem-Projekte einmal (ein MSBuild-Aufruf, parallel) und führt
// anschließend die gebauten DLLs parallel aus. Ein Problem gilt als fehlgeschlagen,
// wenn der Prozess einen ExitCode != 0 liefert oder "FAILED" ausgibt.
//
// Aufruf:
//   dotnet run --project Test/LeetCodeDaily.Runner [-- --filter <Teilstring>] [--debug]

const string configurationDefault = "Release";

var filter = string.Empty;
var configuration = configurationDefault;

for (int i = 0; i < args.Length; i++)
{
    switch (args[i])
    {
        case "--filter" when i + 1 < args.Length:
            filter = args[++i];
            break;
        case "--debug":
            configuration = "Debug";
            break;
        default:
            Console.Error.WriteLine($"Unknown argument: {args[i]}");
            Console.Error.WriteLine("Usage: LeetCodeDaily.Runner [--filter <substring>] [--debug]");
            return 2;
    }
}

var problemsDir = FindProblemsDirectory();

var projects = Directory
    .GetDirectories(problemsDir)
    .Where(dir => File.Exists(Path.Combine(dir, $"{Path.GetFileName(dir)}.csproj")))
    .Where(dir => Path.GetFileName(dir).Contains(filter, StringComparison.OrdinalIgnoreCase))
    .OrderBy(dir => Path.GetFileName(dir), StringComparer.OrdinalIgnoreCase)
    .ToArray();

if (projects.Length == 0)
{
    Console.WriteLine($"No problem projects found{(filter.Length > 0 ? $" matching '{filter}'" : "")}.");
    return 1;
}

Console.WriteLine($"Building {projects.Length} problem project(s) ({configuration})...");

var buildStopwatch = Stopwatch.StartNew();

if (!BuildAll(projects, configuration))
{
    WriteColored("BUILD FAILED", ConsoleColor.Red);
    Console.WriteLine();
    return 1;
}

buildStopwatch.Stop();
Console.WriteLine($"Build finished in {buildStopwatch.Elapsed.TotalSeconds:F1}s. Running...");
Console.WriteLine();

var results = new ConcurrentBag<(string Name, bool Passed, string Output)>();

await Parallel.ForEachAsync(
    projects,
    new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
    async (project, cancellationToken) =>
    {
        var name = Path.GetFileName(project);
        var (passed, output) = await RunProblemAsync(project, configuration, cancellationToken);
        results.Add((name, passed, output));
    });

var failed = 0;

foreach (var result in results.OrderBy(r => r.Name, StringComparer.OrdinalIgnoreCase))
{
    Console.Write($"{result.Name}... ");
    WriteColored(result.Passed ? "PASSED" : "FAILED", result.Passed ? ConsoleColor.Green : ConsoleColor.Red);
    Console.WriteLine();

    if (!result.Passed)
    {
        Console.WriteLine(result.Output);
        failed++;
    }
}

Console.WriteLine();
Console.WriteLine($"Done. Total: {results.Count}, Failed: {failed}");
return failed > 0 ? 1 : 0;


bool BuildAll(string[] projectDirs, string config)
{
    // Traversal-Projekt: ein einziger MSBuild-Aufruf baut alle Projekte parallel.
    var traversalPath = Path.Combine(Path.GetTempPath(), $"leetcode-runner-{Guid.NewGuid():N}.proj");

    var items = string.Join(
        Environment.NewLine,
        projectDirs.Select(dir =>
        {
            var csproj = Path.Combine(dir, $"{Path.GetFileName(dir)}.csproj");
            return $"""    <P Include="{System.Security.SecurityElement.Escape(csproj)}" />""";
        }));

    File.WriteAllText(traversalPath, $"""
        <Project>
          <ItemGroup>
        {items}
          </ItemGroup>
          <Target Name="Restore">
            <MSBuild Projects="@(P)" Targets="Restore" BuildInParallel="true" Properties="Configuration={config}" />
          </Target>
          <Target Name="Build">
            <MSBuild Projects="@(P)" Targets="Build" BuildInParallel="true" Properties="Configuration={config}" />
          </Target>
        </Project>
        """);

    try
    {
        return RunDotnet($"msbuild \"{traversalPath}\" -t:Restore -m -v:q --nologo")
            && RunDotnet($"msbuild \"{traversalPath}\" -t:Build -m -v:q --nologo");
    }
    finally
    {
        File.Delete(traversalPath);
    }
}

bool RunDotnet(string arguments)
{
    var process = Process.Start(new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = arguments,
        UseShellExecute = false,
    })!;

    process.WaitForExit();
    return process.ExitCode == 0;
}

async Task<(bool Passed, string Output)> RunProblemAsync(string projectDir, string config, CancellationToken cancellationToken)
{
    var name = Path.GetFileName(projectDir);
    var dllPath = Directory
        .GetFiles(projectDir, $"{name}.dll", SearchOption.AllDirectories)
        .Where(p => p.Contains($"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}{config}{Path.DirectorySeparatorChar}"))
        .OrderByDescending(File.GetLastWriteTimeUtc)
        .FirstOrDefault();

    if (dllPath is null)
        return (false, $"No built assembly found for '{name}' ({config}).");

    var psi = new ProcessStartInfo
    {
        FileName = "dotnet",
        WorkingDirectory = projectDir,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false,
    };
    psi.ArgumentList.Add(dllPath);

    var process = Process.Start(psi)!;

    var outputTask = process.StandardOutput.ReadToEndAsync(cancellationToken);
    var errorTask = process.StandardError.ReadToEndAsync(cancellationToken);

    await process.WaitForExitAsync(cancellationToken);

    var output = await outputTask;
    var error = await errorTask;

    // Fehlerkriterium: ExitCode oder ein FAILED-Testcase. stderr allein ist kein
    // Fehler mehr (Warnungen führten früher zu falschen "FAILED"-Meldungen).
    var passed = process.ExitCode == 0 && !output.Contains("FAILED");

    return (passed, string.IsNullOrWhiteSpace(error) ? output : output + Environment.NewLine + error);
}

void WriteColored(string text, ConsoleColor color)
{
    var prev = Console.ForegroundColor;
    Console.ForegroundColor = color;
    Console.Write(text);
    Console.ForegroundColor = prev;
}

string FindProblemsDirectory()
{
    var dir = new DirectoryInfo(AppContext.BaseDirectory);

    while (dir != null)
    {
        var candidate = Path.Combine(dir.FullName, "Problems");
        if (Directory.Exists(candidate))
            return candidate;

        dir = dir.Parent!;
    }

    throw new DirectoryNotFoundException("Could not find 'Problems' directory.");
}
