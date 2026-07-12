namespace LeetCodeDaily.Scaffold;

public static class TypeMapper
{
    /// <summary>
    /// Translates a LeetCode metaData type (e.g. "integer[][]", "list&lt;list&lt;integer&gt;&gt;")
    /// into the C# type for ParseCases. Returns null for types the parser does not support.
    /// </summary>
    public static string? ToCSharpType(string leetCodeType)
    {
        var type = leetCodeType.Trim();

        if (type.EndsWith("[]"))
        {
            var element = ToCSharpType(type[..^2]);
            return element is null ? null : element + "[]";
        }

        if (type.StartsWith("list<") && type.EndsWith(">"))
        {
            var element = ToCSharpType(type[5..^1]);
            return element is null ? null : $"IList<{element}>";
        }

        return type switch
        {
            "integer" => "int",
            "long" => "long",
            "double" => "double",
            "boolean" => "bool",
            "string" => "string",
            "character" => "char",
            "TreeNode" => "TreeNode",
            "ListNode" => "ListNode",
            _ => null,
        };
    }
}
