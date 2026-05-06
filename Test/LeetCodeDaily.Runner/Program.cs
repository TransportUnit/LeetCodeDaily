using System.Diagnostics;

var problemsDir = FindProblemsDirectory();

var projects = Directory
    .GetDirectories(problemsDir)
    .Where(dir => File.Exists(Path.Combine(dir, $"{Path.GetFileName(dir)}.csproj")));

int failed = 0;

foreach (var project in projects)
{
    var name = Path.GetFileName(project);

    Console.Write($"Running {name}... ");

    var psi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = $"run --configuration Release --project \"{project}\"",
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        RedirectStandardInput = true,
        UseShellExecute = false
    };

    var process = Process.Start(psi)!;

    string output = process.StandardOutput.ReadToEnd();
    string error = process.StandardError.ReadToEnd();

    process.WaitForExit();

    if (process.ExitCode != 0 || output.Contains("FAILED") || !string.IsNullOrWhiteSpace(error))
    {
        WriteColored("FAILED", ConsoleColor.Red);
        Console.WriteLine();

        Console.WriteLine(output);
        Console.WriteLine(error);

        failed++;
    }
    else
    {
        WriteColored("PASSED", ConsoleColor.Green);
        Console.WriteLine();
    }

    Console.WriteLine();
}

Console.WriteLine($"Done. Failed: {failed}");
Environment.Exit(failed > 0 ? 1 : 0);


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