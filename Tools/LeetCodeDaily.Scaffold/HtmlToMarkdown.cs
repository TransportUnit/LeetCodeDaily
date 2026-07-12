using System.Text;
using System.Text.RegularExpressions;

namespace LeetCodeDaily.Scaffold;

/// <summary>
/// Converts the (heavily constrained) HTML from LeetCode's "content" field into
/// Markdown in the style of this repo's existing READMEs:
/// - "Example N:" and "Constraints:" become headings
/// - code containing super-/subscript is kept as &lt;code&gt; HTML (entities included),
///   so that e.g. 10^9 and "&lt;=" render correctly
/// - square brackets in prose are escaped so Markdown does not read them as links
/// </summary>
public static partial class HtmlToMarkdown
{
    private const char Placeholder = '\x01';

    public static string Convert(string html)
    {
        var text = html.ReplaceLineEndings("\n");
        var preserved = new List<string>();

        // convert <pre> blocks (classic example format) separately and protect them
        text = PreBlockRegex().Replace(text, m => Preserve(preserved, ConvertPreBlock(m.Groups[1].Value)));

        // keep <code> with sup/sub/entities as HTML, otherwise turn into `backticks`
        text = CodeRegex().Replace(text, m =>
        {
            var inner = m.Groups[1].Value;

            if (inner.Contains("<sup") || inner.Contains("<sub") || inner.Contains("&lt;") || inner.Contains("&gt;"))
                return Preserve(preserved, $"<code>{inner}</code>");

            return Preserve(preserved, $"`{DecodeEntities(inner)}`");
        });

        // repo-style headings (the <br/> separator is protected so the
        // <br> rule further down does not remove it again)
        text = ExampleHeadingRegex().Replace(text,
            m => $"\n{Preserve(preserved, "<br/>")}\n\n# **{m.Groups[1].Value.Trim()}**\n");
        text = ConstraintsHeadingRegex().Replace(text,
            m => $"\n{Preserve(preserved, "<br/>")}\n\n# **Constraints:**\n");

        // lists
        text = ListItemRegex().Replace(text, m => "\n*   " + m.Groups[1].Value.Trim());
        text = Regex.Replace(text, @"</?[uo]l[^>]*>", "\n");

        // inline formatting (\b so that <b> does not match <br/>)
        text = Regex.Replace(text, @"<(?:strong|b)\b[^>]*>(.*?)</(?:strong|b)>", "**$1**", RegexOptions.Singleline);
        text = Regex.Replace(text, @"<(?:em|i)\b[^>]*>(.*?)</(?:em|i)>", "*$1*", RegexOptions.Singleline);
        text = ImgRegex().Replace(text, m => $"![]({m.Groups[1].Value})");

        // keep sup/sub outside of <code> as HTML (GitHub renders it)
        text = Regex.Replace(text, @"<(/?su[bp])>", m => Preserve(preserved, $"<{m.Groups[1].Value}>"));

        // paragraphs & line breaks, strip remaining tags
        text = Regex.Replace(text, @"<br\s*/?>", "\n");
        text = Regex.Replace(text, @"</p>", "\n\n");
        text = Regex.Replace(text, @"<[^>]+>", "");

        text = DecodeEntities(text);

        // escape square brackets so [1,2] is not read as a Markdown link
        text = text.Replace("[", "\\[").Replace("]", "\\]");

        // restore protected segments
        for (int i = 0; i < preserved.Count; i++)
        {
            text = text.Replace($"{Placeholder}{i}{Placeholder}", preserved[i]);
        }

        // clean up whitespace; consecutive list items without blank lines
        text = Regex.Replace(text, @"[ \t]+\n", "\n");
        text = Regex.Replace(text, @"\n{3,}", "\n\n");
        text = Regex.Replace(text, @"(?<=\n\*   [^\n]*)\n\n(?=\*   )", "\n");

        return text.Trim() + "\n";
    }

    private static string ConvertPreBlock(string inner)
    {
        // classic example format:
        // <strong>Input:</strong> nums = [1,2,3]\n<strong>Output:</strong> 6 ...
        var text = Regex.Replace(inner, @"<(?:strong|b)\b[^>]*>(.*?)</(?:strong|b)>", "**$1**", RegexOptions.Singleline);
        text = Regex.Replace(text, @"<[^>]+>", "");
        text = DecodeEntities(text);
        text = text.Replace("[", "\\[").Replace("]", "\\]");

        // blank line between Input/Output/Explanation so Markdown does not merge them
        text = Regex.Replace(text.Trim(), @"\n(?=\S)", "\n\n");

        return text + "\n";
    }

    private static string Preserve(List<string> preserved, string value)
    {
        preserved.Add(value);
        return $"{Placeholder}{preserved.Count - 1}{Placeholder}";
    }

    public static string DecodeEntities(string text)
    {
        return text
            .Replace("&nbsp;", " ")
            .Replace("&quot;", "\"")
            .Replace("&#39;", "'")
            .Replace("&lt;", "<")
            .Replace("&gt;", ">")
            .Replace("&le;", "≤")
            .Replace("&ge;", "≥")
            .Replace("&amp;", "&");
    }

    [GeneratedRegex(@"<pre[^>]*>(.*?)</pre>", RegexOptions.Singleline)]
    private static partial Regex PreBlockRegex();

    [GeneratedRegex(@"<code[^>]*>(.*?)</code>", RegexOptions.Singleline)]
    private static partial Regex CodeRegex();

    [GeneratedRegex(@"<p>\s*<strong[^>]*>\s*(Example\s*\d*:?)\s*</strong>\s*</p>", RegexOptions.IgnoreCase)]
    private static partial Regex ExampleHeadingRegex();

    [GeneratedRegex(@"<p>\s*<strong[^>]*>\s*Constraints:?\s*</strong>\s*</p>", RegexOptions.IgnoreCase)]
    private static partial Regex ConstraintsHeadingRegex();

    [GeneratedRegex(@"<img[^>]*src=""([^""]+)""[^>]*/?>", RegexOptions.IgnoreCase)]
    private static partial Regex ImgRegex();

    [GeneratedRegex(@"<li[^>]*>(.*?)</li>", RegexOptions.Singleline)]
    private static partial Regex ListItemRegex();
}
