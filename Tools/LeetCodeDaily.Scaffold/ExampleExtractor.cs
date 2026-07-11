using System.Text.RegularExpressions;

namespace LeetCodeDaily.Scaffold;

public static partial class ExampleExtractor
{
    /// <summary>
    /// Extracts the expected results ("Output: ...") from the content HTML.
    /// Supports both the classic &lt;pre&gt; format and the newer format
    /// with &lt;span class="example-io"&gt;.
    /// </summary>
    public static IReadOnlyList<string> ExtractExpectedOutputs(string contentHtml)
    {
        return OutputRegex()
            .Matches(contentHtml.ReplaceLineEndings("\n"))
            .Select(m => HtmlToMarkdown.DecodeEntities(m.Groups[1].Value.Trim()))
            .ToArray();
    }

    /// <summary>
    /// Builds the test-case blocks for Program.cs from the example inputs
    /// (exampleTestcases: one line per parameter, cases back to back) and the
    /// outputs. Returns null when inputs and outputs do not line up.
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
