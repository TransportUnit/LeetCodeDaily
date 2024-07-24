using LeetCodeDaily.Core;
using System.Text;

namespace _14._Longest_Common_Prefix;

public class Solution
{
    [ResultGenerator]
    public string LongestCommonPrefix(string[] strs)
    {
        var prefix = new StringBuilder();

        int minLength = strs.Min(x => x.Length);

        for (int i = 0; i < minLength; i++)
        {
            var ch = strs[0][i];
            if (!strs.All(x => x[i] == ch))
                return prefix.ToString();

            prefix.Append(ch);
        }

        return prefix.ToString();
    }
}