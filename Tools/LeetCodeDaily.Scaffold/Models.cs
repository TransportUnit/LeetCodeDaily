using System.Text.Json;

namespace LeetCodeDaily.Scaffold;

public record QuestionSummary(
    string QuestionFrontendId,
    string Title,
    string TitleSlug,
    string Difficulty,
    string? Date = null);

public record CodeSnippet(string LangSlug, string Code);

public record QuestionDetail(
    string QuestionFrontendId,
    string Title,
    string TitleSlug,
    string Difficulty,
    bool IsPaidOnly,
    string Content,
    string ExampleTestcases,
    IReadOnlyList<CodeSnippet> CodeSnippets,
    IReadOnlyList<string> Hints,
    string MetaDataJson)
{
    public string ProjectName => $"{QuestionFrontendId}. {Title}";
}

public record ParamMeta(string Name, string Type);

/// <summary>
/// Parsed form of LeetCode's metaData JSON. For "regular" problems,
/// <see cref="Name"/>, <see cref="Params"/> and <see cref="ReturnType"/> are set;
/// for design problems (MyHashMap &amp; co.) <see cref="ClassName"/> is set.
/// </summary>
public record ProblemMeta(
    string? Name,
    string? ClassName,
    IReadOnlyList<ParamMeta> Params,
    string? ReturnType)
{
    public bool IsDesignProblem => ClassName is not null;

    public static ProblemMeta Parse(string metaDataJson)
    {
        using var doc = JsonDocument.Parse(metaDataJson);
        var root = doc.RootElement;

        string? className = root.TryGetProperty("classname", out var cls) ? cls.GetString() : null;
        string? name = root.TryGetProperty("name", out var n) ? n.GetString() : null;

        var parameters = new List<ParamMeta>();
        if (root.TryGetProperty("params", out var ps) && ps.ValueKind == JsonValueKind.Array)
        {
            foreach (var p in ps.EnumerateArray())
            {
                parameters.Add(new ParamMeta(
                    p.GetProperty("name").GetString() ?? "",
                    p.GetProperty("type").GetString() ?? ""));
            }
        }

        string? returnType = null;
        if (root.TryGetProperty("return", out var ret)
            && ret.ValueKind == JsonValueKind.Object
            && ret.TryGetProperty("type", out var rt))
        {
            returnType = rt.GetString();
        }

        return new ProblemMeta(name, className, parameters, returnType);
    }
}
