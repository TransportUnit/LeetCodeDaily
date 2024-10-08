using LeetCodeDaily.Core;

namespace _884.Uncommon_Words_from_Two_Sentences;

public class Solution
{
    [ResultGenerator]
    public string[] UncommonFromSentences(string s1, string s2)
    {
        var split1 = s1.Split();
        var split2 = s2.Split();
        return split1.Concat(split2).GroupBy(x => x).Where(x => x.Count() == 1).Select(x => x.Key).ToArray();
    }
}