using System.Text;
using System.Text.RegularExpressions;

namespace LeetCodeDaily.Scaffold;

/// <summary>Erzeugt Solution.cs, Program.cs und README.md für ein Problem.</summary>
public static class CodeGenerator
{
    /// <summary>
    /// Baut den Namespace im Stil der bestehenden Projekte,
    /// z.B. "3653. XOR After Range Multiplication Queries I"
    /// → "_3653.XOR_After_Range_Multiplication_Queries_I".
    /// </summary>
    public static string BuildNamespace(string frontendId, string title)
    {
        var titleSegment = Regex.Replace(title.Trim(), @"[^A-Za-z0-9]", "_");

        if (titleSegment.Length == 0 || char.IsDigit(titleSegment[0]))
            titleSegment = "_" + titleSegment;

        return $"_{frontendId}.{titleSegment}";
    }

    public static string GenerateSolution(QuestionDetail question, ProblemMeta meta)
    {
        var snippet = question.CodeSnippets.FirstOrDefault(s => s.LangSlug == "csharp")?.Code
            ?? DefaultSnippet();

        snippet = snippet.ReplaceLineEndings("\n").Trim();

        // [ResultGenerator] vor die Solution-Methode setzen (nicht bei Design-Aufgaben)
        if (!meta.IsDesignProblem && meta.Name is not null)
        {
            var methodName = char.ToUpperInvariant(meta.Name[0]) + meta.Name[1..];
            var methodLine = new Regex($@"(\n([ \t]*))(public\s[^\n]*\s{Regex.Escape(methodName)}\s*\()");
            snippet = methodLine.Replace(snippet, "$1[ResultGenerator]$1$3", 1);
        }

        return $"""
            using LeetCodeDaily.Core;

            namespace {BuildNamespace(question.QuestionFrontendId, question.Title)};

            {snippet}

            """.ReplaceLineEndings("\n");
    }

    public static string GenerateProgram(QuestionDetail question, ProblemMeta meta)
    {
        var expectedOutputs = ExampleExtractor.ExtractExpectedOutputs(question.Content);

        if (!meta.IsDesignProblem && meta.ReturnType is not null && meta.ReturnType != "void")
        {
            var parameterTypes = meta.Params.Select(p => TypeMapper.ToCSharpType(p.Type)).ToArray();
            var returnType = TypeMapper.ToCSharpType(meta.ReturnType);

            var caseBlocks = ExampleExtractor.BuildCaseBlocks(
                question.ExampleTestcases, meta.Params.Count, expectedOutputs);

            if (returnType is not null && parameterTypes.All(t => t is not null) && caseBlocks is not null)
            {
                var typeArguments = string.Join(", ", parameterTypes.Append(returnType));

                return $""""
                    using LeetCodeDaily.Core;
                    using LeetCodeDaily.Extensions;

                    """
                    {caseBlocks}
                    """
                    .ParseCases<{typeArguments}>()
                    .DetectAndRun();

                    """".ReplaceLineEndings("\n");
            }
        }

        return GenerateFallbackProgram(question, meta);
    }

    private static string GenerateFallbackProgram(QuestionDetail question, ProblemMeta meta)
    {
        var reason = meta.IsDesignProblem
            ? $"Design-Aufgabe ({meta.ClassName}): Cases müssen manuell aufgebaut werden."
            : "Die Cases konnten nicht automatisch generiert werden (Typ oder Format nicht unterstützt).";

        var rawCases = question.ExampleTestcases.ReplaceLineEndings("\n").Trim();

        return $"""
            using LeetCodeDaily.Core;
            using LeetCodeDaily.Extensions;

            // TODO: {reason}
            //
            // Beispiel-Inputs von LeetCode:
            {Comment(rawCases)}
            //
            // Varianten:
            //   1. "<cases>".ParseCases<TIn..., TResult>().DetectAndRun();
            //   2. Case.CreateCase(input, expected).Detect().Run();
            //   3. eigener Checker: .SetResultChecker(c => ...) für In-Place-Aufgaben

            Console.WriteLine("TODO: Testcases anlegen ({question.ProjectName})");

            """.ReplaceLineEndings("\n");
    }

    public static string GenerateReadme(QuestionDetail question)
    {
        var sb = new StringBuilder();

        sb.AppendLine($"# {question.QuestionFrontendId}. {question.Title}");
        sb.AppendLine();
        sb.AppendLine(HtmlToMarkdown.Convert(question.Content).TrimEnd());

        if (question.Hints.Count > 0)
        {
            sb.AppendLine();
            sb.AppendLine("<br/>");
            sb.AppendLine();

            for (int i = 0; i < question.Hints.Count; i++)
            {
                var hint = HtmlToMarkdown.Convert(question.Hints[i]).Trim().ReplaceLineEndings(" ");
                sb.AppendLine($"<details><summary>Hint {i + 1}</summary>{hint}</details>");
            }
        }

        return sb.ToString().ReplaceLineEndings("\n");
    }

    public static string GenerateCsproj()
    {
        return """
            <Project Sdk="Microsoft.NET.Sdk">

              <!-- Common settings come from Problems/Directory.Build.props -->

            </Project>

            """.ReplaceLineEndings("\n");
    }

    private static string DefaultSnippet()
    {
        return """
            public class Solution
            {
                // TODO: kein C#-Snippet von LeetCode erhalten
            }
            """;
    }

    private static string Comment(string text)
    {
        return string.Join("\n", text.Split('\n').Select(l => "// " + l));
    }
}
