using LeetCodeDaily.Core;

namespace _1189.Maximum_Number_of_Balloons;

public class Solution
{
    [ResultGenerator]
    public int MaxNumberOfBalloons(string text)
    {
        Span<short> freq = stackalloc short[26];

        foreach (var letter in text)
        {
            freq[letter - 'a']++;
        }

        var bFreq = new[]
        {
            freq['b' - 'a'],
            freq['a' - 'a'],
            freq['l' - 'a'] / 2,
            freq['o' - 'a'] / 2,
            freq['n' - 'a'],
        };

        return bFreq.Min();
    }
}