namespace LeetCodeDaily.Scaffold;

public static class TypeMapper
{
    /// <summary>
    /// Übersetzt einen LeetCode-metaData-Typ (z.B. "integer[][]", "list&lt;list&lt;integer&gt;&gt;")
    /// in den C#-Typ für ParseCases. Liefert null für Typen, die der Parser nicht unterstützt.
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
