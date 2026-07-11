using LeetCodeDaily.Scaffold;

// LeetCodeDaily.Scaffold
//
// Legt ein komplettes Problem-Projekt an: Ordner, csproj, Solution.cs mit echter
// Methodensignatur, Program.cs mit den Beispiel-Testcases (inkl. Expected Results)
// und fertig formatierter README.md. Trägt das Projekt außerdem in die
// LeetCodeDaily.slnx (alphabetisch) und die LeetCodeDaily.Recent.slnx ein.
//
// Aufrufe:
//   scaffold                  heutige Daily Challenge
//   scaffold --pick           aus den letzten Dailies auswählen (mit Difficulty)
//   scaffold 3653             Problem per Nummer
//   scaffold two-sum          Problem per Slug
//   scaffold <leetcode-url>   Problem per URL
//   Option --force            vorhandenes Projektverzeichnis überschreiben

var force = args.Contains("--force");
var pick = args.Contains("--pick");
var identifier = args.FirstOrDefault(a => !a.StartsWith("--"));

try
{
    var repoRoot = FindRepoRoot();

    using var client = new LeetCodeClient();

    string titleSlug;

    if (pick)
    {
        var picked = await PickFromRecentDailiesAsync(client);
        if (picked is null)
            return 1;
        titleSlug = picked;
    }
    else if (identifier is null)
    {
        Console.WriteLine("Fetching today's daily challenge...");
        titleSlug = await client.GetDailyTitleSlugAsync();
    }
    else
    {
        titleSlug = await ResolveIdentifierAsync(client, identifier);
    }

    Console.WriteLine($"Fetching problem '{titleSlug}'...");
    var question = await client.GetQuestionAsync(titleSlug);
    var meta = ProblemMeta.Parse(question.MetaDataJson);

    if (question.IsPaidOnly)
        WriteWarning("Note: this is a premium-only problem; content may be incomplete.");

    var projectName = Sanitize(question.ProjectName);
    var projectDir = Path.Combine(repoRoot, "Problems", projectName);
    var projectRelativePath = $"Problems/{projectName}/{projectName}.csproj";

    if (Directory.Exists(projectDir) && !force)
    {
        WriteWarning($"'{projectDir}' already exists. Use --force to overwrite the generated files.");
        return 1;
    }

    Directory.CreateDirectory(projectDir);

    var program = CodeGenerator.GenerateProgram(question, meta);

    File.WriteAllText(Path.Combine(projectDir, $"{projectName}.csproj"), CodeGenerator.GenerateCsproj());
    File.WriteAllText(Path.Combine(projectDir, "Solution.cs"), CodeGenerator.GenerateSolution(question, meta));
    File.WriteAllText(Path.Combine(projectDir, "Program.cs"), program);
    File.WriteAllText(Path.Combine(projectDir, "README.md"), CodeGenerator.GenerateReadme(question));

    WriteSuccess($"Created {Path.Combine("Problems", projectName)} ({question.Difficulty}).");

    if (SolutionFileUpdater.AddToMainSolution(Path.Combine(repoRoot, "LeetCodeDaily.slnx"), projectRelativePath))
        Console.WriteLine("Added to LeetCodeDaily.slnx.");

    SolutionFileUpdater.UpdateRecentSolution(Path.Combine(repoRoot, "LeetCodeDaily.Recent.slnx"), projectRelativePath);
    Console.WriteLine($"Updated LeetCodeDaily.Recent.slnx (last {SolutionFileUpdater.RecentProblemCount} problems).");

    if (program.Contains("TODO"))
        WriteWarning("Program.cs contains a TODO: test cases could not be generated automatically.");

    Console.WriteLine();
    Console.WriteLine("Next: open the solution, set the project as startup project, solve, F5.");
    return 0;
}
catch (HttpRequestException ex)
{
    WriteError($"Could not reach leetcode.com: {ex.Message}");
    return 1;
}
catch (Exception ex)
{
    WriteError(ex.Message);
    return 1;
}


static async Task<string> ResolveIdentifierAsync(LeetCodeClient client, string identifier)
{
    // URL → Slug
    if (identifier.Contains("leetcode.com", StringComparison.OrdinalIgnoreCase))
    {
        var parts = identifier.Split('/', StringSplitOptions.RemoveEmptyEntries);
        var problemsIndex = Array.FindIndex(parts, p => p.Equals("problems", StringComparison.OrdinalIgnoreCase));

        if (problemsIndex >= 0 && problemsIndex + 1 < parts.Length)
            return parts[problemsIndex + 1];

        throw new ArgumentException($"Could not extract a problem slug from '{identifier}'.");
    }

    // Nummer → Slug via Suche
    if (identifier.All(char.IsDigit))
    {
        Console.WriteLine($"Looking up problem #{identifier}...");
        var slug = await client.FindTitleSlugByNumberAsync(identifier);

        return slug ?? throw new ArgumentException($"No problem with number {identifier} found.");
    }

    // sonst: ist bereits ein Slug
    return identifier;
}

static async Task<string?> PickFromRecentDailiesAsync(LeetCodeClient client)
{
    Console.WriteLine("Fetching recent daily challenges...");
    var dailies = await client.GetRecentDailiesAsync();

    if (dailies.Count == 0)
    {
        WriteError("No recent dailies found.");
        return null;
    }

    for (int i = 0; i < dailies.Count; i++)
    {
        var d = dailies[i];
        var difficultyColor = d.Difficulty switch
        {
            "Easy" => ConsoleColor.Green,
            "Medium" => ConsoleColor.Yellow,
            _ => ConsoleColor.Red,
        };

        Console.Write($"{i + 1,3}: {d.Date}  ");

        var previous = Console.ForegroundColor;
        Console.ForegroundColor = difficultyColor;
        Console.Write($"{d.Difficulty,-6}");
        Console.ForegroundColor = previous;

        Console.WriteLine($"  {d.QuestionFrontendId}. {d.Title}");
    }

    Console.Write($"Pick a problem (1-{dailies.Count}, Enter = 1): ");
    var input = Console.ReadLine()?.Trim();

    var index = string.IsNullOrEmpty(input) ? 1 : int.TryParse(input, out var parsed) ? parsed : -1;

    if (index < 1 || index > dailies.Count)
    {
        WriteError("Invalid selection.");
        return null;
    }

    return dailies[index - 1].TitleSlug;
}

static string Sanitize(string projectName)
{
    foreach (var invalid in Path.GetInvalidFileNameChars())
        projectName = projectName.Replace(invalid, '_');

    return projectName.Trim();
}

static string FindRepoRoot()
{
    var dir = new DirectoryInfo(AppContext.BaseDirectory);

    while (dir != null)
    {
        if (File.Exists(Path.Combine(dir.FullName, "LeetCodeDaily.slnx")))
            return dir.FullName;

        dir = dir.Parent!;
    }

    throw new DirectoryNotFoundException("Could not find repo root (LeetCodeDaily.slnx).");
}

static void WriteSuccess(string message) => WriteColored(message, ConsoleColor.Green);
static void WriteWarning(string message) => WriteColored(message, ConsoleColor.Yellow);
static void WriteError(string message) => WriteColored("ERROR: " + message, ConsoleColor.Red);

static void WriteColored(string message, ConsoleColor color)
{
    var previous = Console.ForegroundColor;
    Console.ForegroundColor = color;
    Console.WriteLine(message);
    Console.ForegroundColor = previous;
}
