using LeetCodeDaily.Core;

namespace _2900.Longest_Unequal_Adjacent_Groups_Subsequence_I;

public class Solution
{
    [ResultGenerator]
    public IList<string> GetLongestSubsequence(string[] words, int[] groups)
    {
        if (words.Length <= 1)
            return words.ToList();

        var result = new List<string>
        {
            words[0]
        };
        int last = groups[0];
        int i = 0;

        while (++i < groups.Length)
        {
            if (groups[i] != last)
            {
                result.Add(words[i]);
                last = groups[i];
            }
        }

        return result;
    }
}