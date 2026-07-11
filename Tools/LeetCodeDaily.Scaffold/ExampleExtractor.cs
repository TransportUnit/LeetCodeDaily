using System.Text.RegularExpressions;

namespace LeetCodeDaily.Scaffold;

public static partial class ExampleExtractor
{
    /// <summary>
    /// Zieht die erwarteten Ergebnisse ("Output: ...") aus dem content-HTML.
    /// Unterstützt sowohl das klassische &lt;pre&gt;-Format als auch das neuere
    /// Format mit &lt;span class="example-io"&gt;.
    /// </summary>
    public static IReadOnlyList<string> ExtractExpectedOutputs(string contentHtml)
    {
        return OutputRegex()
            .Matches(contentHtml.ReplaceLineEndings("\n"))
            .Select(m => HtmlToMarkdown.DecodeEntities(m.Groups[1].Value.Trim()))
            .ToArray();
    }

    /// <summary>
    /// Baut aus den Beispiel-Inputs (exampleTestcases: eine Zeile pro Parameter,
    /// Cases direkt hintereinander) und den Outputs die Testcase-Blöcke für Program.cs.
    /// Liefert null, wenn Inputs und Outputs nicht zusammenpassen.
    /// </summary>
    public static string? BuildCaseBlocks(string exampleTestcases, int paramCount, IReadOnlyList<string> expectedOutputs)
    {
        if (paramCount <= 0)
            return null;

        var lines = exampleTestcases
            .ReplaceLineEndings("\n")
            .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        if (lines.Length == 0 || lines.Length % paramCount != 0)
            return null;

        var caseCount = lines.Length / paramCount;

        if (expectedOutputs.Count < caseCount)
            return null;

        var blocks = new List<string>();

        for (int i = 0; i < caseCount; i++)
        {
            var inputs = lines.Skip(i * paramCount).Take(paramCount);
            blocks.Add(string.Join("\n", inputs) + "\n" + expectedOutputs[i]);
        }

        return string.Join("\n\n", blocks);
    }

    [GeneratedRegex(@"<strong>Output:?\s*</strong>\s*(?:<span[^>]*>)?([^<\n]+)", RegexOptions.IgnoreCase)]
    private static partial Regex OutputRegex();
}
