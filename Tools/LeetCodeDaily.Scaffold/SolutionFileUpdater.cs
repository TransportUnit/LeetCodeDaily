using System.Text.RegularExpressions;

namespace LeetCodeDaily.Scaffold;

/// <summary>
/// Maintains the .slnx files text-based (deliberately no XML rewrite, so the
/// formatting and GUIDs of existing entries stay untouched).
/// </summary>
public static partial class SolutionFileUpdater
{
    public const int RecentProblemCount = 15;

    /// <summary>Inserts the project alphabetically into the /Problems/ folder of the main solution.</summary>
    public static bool AddToMainSolution(string slnxPath, string projectRelativePath)
    {
        var lines = File.ReadAllLines(slnxPath).ToList();
        var entry = $"    <Project Path=\"{XmlEscape(projectRelativePath)}\" />";

        if (lines.Any(l => l.Contains($"Path=\"{XmlEscape(projectRelativePath)}\"")))
            return false;

        var folderStart = lines.FindIndex(l => l.Contains("<Folder Name=\"/Problems/\">"));
        if (folderStart < 0)
            throw new InvalidOperationException($"Folder '/Problems/' not found in {slnxPath}.");

        var folderEnd = lines.FindIndex(folderStart, l => l.TrimStart().StartsWith("</Folder>"));

        var insertAt = folderEnd;
        for (int i = folderStart + 1; i < folderEnd; i++)
        {
            var existingPath = ExtractProjectPath(lines[i]);
            if (existingPath is not null
                && string.Compare(projectRelativePath, existingPath, StringComparison.OrdinalIgnoreCase) < 0)
            {
                insertAt = i;
                break;
            }
        }

        lines.Insert(insertAt, entry);
        File.WriteAllLines(slnxPath, lines);
        return true;
    }

    /// <summary>
    /// Maintains the fast-loading "Recent" solution: newest problem on top,
    /// at most <see cref="RecentProblemCount"/> entries, core + tests always included.
    /// </summary>
    public static void UpdateRecentSolution(string recentSlnxPath, string projectRelativePath)
    {
        var recentProjects = new List<string>();

        if (File.Exists(recentSlnxPath))
        {
            recentProjects = File.ReadAllLines(recentSlnxPath)
                .Select(ExtractProjectPath)
                .Where(p => p is not null && p.StartsWith("Problems/"))
                .Select(p => p!)
                .ToList();
        }

        recentProjects.Remove(projectRelativePath);
        recentProjects.Insert(0, projectRelativePath);

        if (recentProjects.Count > RecentProblemCount)
            recentProjects = recentProjects.Take(RecentProblemCount).ToList();

        var projectLines = string.Join(
            Environment.NewLine,
            recentProjects.Select(p => $"    <Project Path=\"{XmlEscape(p)}\" />"));

        File.WriteAllText(recentSlnxPath, $"""
            <Solution>
              <Folder Name="/Problems/">
            {projectLines}
              </Folder>
              <Folder Name="/Test/">
                <Project Path="Test/LeetCodeDaily.Runner/LeetCodeDaily.Runner.csproj" />
                <Project Path="Test/LeetCodeDaily.Tests/LeetCodeDaily.Tests.csproj" />
              </Folder>
              <Folder Name="/Tools/">
                <Project Path="Tools/LeetCodeDaily.Scaffold/LeetCodeDaily.Scaffold.csproj" />
              </Folder>
              <Project Path="LeetCodeDaily/LeetCodeDaily.csproj" />
            </Solution>

            """.ReplaceLineEndings(Environment.NewLine));
    }

    private static string? ExtractProjectPath(string line)
    {
        var match = ProjectPathRegex().Match(line);
        return match.Success ? XmlUnescape(match.Groups[1].Value) : null;
    }

    private static string XmlEscape(string value) =>
        value.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;");

    private static string XmlUnescape(string value) =>
        value.Replace("&quot;", "\"").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&");

    [GeneratedRegex(@"<Project Path=""([^""]+)""")]
    private static partial Regex ProjectPathRegex();
}
