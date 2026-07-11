using System.Text;
using System.Text.RegularExpressions;

namespace LeetCodeDaily.Scaffold;

/// <summary>
/// Konvertiert das (stark eingeschränkte) HTML aus LeetCodes "content"-Feld in
/// Markdown im Stil der bestehenden READMEs dieses Repos:
/// - "Example N:" und "Constraints:" werden Überschriften
/// - Code mit Hoch-/Tiefstellung bleibt als &lt;code&gt;-HTML erhalten (inkl. Entities),
///   damit z.B. 10^9 und "&lt;=" korrekt gerendert werden
/// - eckige Klammern im Fließtext werden escaped, damit Markdown sie nicht als Links deutet
/// </summary>
public static partial class HtmlToMarkdown
{
    private const char Placeholder = '\x01';

    public static string Convert(string html)
    {
        var text = html.ReplaceLineEndings("\n");
        var preserved = new List<string>();

        // <pre>-Blöcke (klassisches Beispiel-Format) separat konvertieren und schützen
        text = PreBlockRegex().Replace(text, m => Preserve(preserved, ConvertPreBlock(m.Groups[1].Value)));

        // <code> mit sup/sub/Entities als HTML erhalten, sonst zu `Backticks`
        text = CodeRegex().Replace(text, m =>
        {
            var inner = m.Groups[1].Value;

            if (inner.Contains("<sup") || inner.Contains("<sub") || inner.Contains("&lt;") || inner.Contains("&gt;"))
                return Preserve(preserved, $"<code>{inner}</code>");

            return Preserve(preserved, $"`{DecodeEntities(inner)}`");
        });

        // Überschriften im Repo-Stil (der <br/>-Separator wird geschützt,
        // damit ihn die <br>-Regel weiter unten nicht wieder entfernt)
        text = ExampleHeadingRegex().Replace(text,
            m => $"\n{Preserve(preserved, "<br/>")}\n\n# **{m.Groups[1].Value.Trim()}**\n");
        text = ConstraintsHeadingRegex().Replace(text,
            m => $"\n{Preserve(preserved, "<br/>")}\n\n# **Constraints:**\n");

        // Listen
        text = ListItemRegex().Replace(text, m => "\n*   " + m.Groups[1].Value.Trim());
        text = Regex.Replace(text, @"</?[uo]l[^>]*>", "\n");

        // Inline-Formatierung (\b, damit <b> nicht auf <br/> matcht)
        text = Regex.Replace(text, @"<(?:strong|b)\b[^>]*>(.*?)</(?:strong|b)>", "**$1**", RegexOptions.Singleline);
        text = Regex.Replace(text, @"<(?:em|i)\b[^>]*>(.*?)</(?:em|i)>", "*$1*", RegexOptions.Singleline);
        text = ImgRegex().Replace(text, m => $"![]({m.Groups[1].Value})");

        // Sup/Sub außerhalb von <code> als HTML erhalten (GitHub rendert das)
        text = Regex.Replace(text, @"<(/?su[bp])>", m => Preserve(preserved, $"<{m.Groups[1].Value}>"));

        // Absätze & Zeilenumbrüche, restliche Tags entfernen
        text = Regex.Replace(text, @"<br\s*/?>", "\n");
        text = Regex.Replace(text, @"</p>", "\n\n");
        text = Regex.Replace(text, @"<[^>]+>", "");

        text = DecodeEntities(text);

        // Eckige Klammern escapen, damit [1,2] nicht als Markdown-Link gelesen wird
        text = text.Replace("[", "\\[").Replace("]", "\\]");

        // Geschützte Segmente wiederherstellen
        for (int i = 0; i < preserved.Count; i++)
        {
            text = text.Replace($"{Placeholder}{i}{Placeholder}", preserved[i]);
        }

        // Whitespace aufräumen; aufeinanderfolgende Listenpunkte ohne Leerzeile
        text = Regex.Replace(text, @"[ \t]+\n", "\n");
        text = Regex.Replace(text, @"\n{3,}", "\n\n");
        text = Regex.Replace(text, @"(?<=\n\*   [^\n]*)\n\n(?=\*   )", "\n");

        return text.Trim() + "\n";
    }

    private static string ConvertPreBlock(string inner)
    {
        // Klassisches Beispiel-Format:
        // <strong>Input:</strong> nums = [1,2,3]\n<strong>Output:</strong> 6 ...
        var text = Regex.Replace(inner, @"<(?:strong|b)\b[^>]*>(.*?)</(?:strong|b)>", "**$1**", RegexOptions.Singleline);
        text = Regex.Replace(text, @"<[^>]+>", "");
        text = DecodeEntities(text);
        text = text.Replace("[", "\\[").Replace("]", "\\]");

        // Leerzeile zwischen Input/Output/Explanation, damit Markdown sie nicht zusammenzieht
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
