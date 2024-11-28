using LeetCodeDaily.Core;

namespace _2287.Rearrange_Characters_to_Make_Target_String;

public class Solution
{
    [ResultGenerator]
    public int RearrangeCharacters(string s, string target)
    {
        Span<byte> sFreq = stackalloc byte[26];
        Span<byte> targetFreq = stackalloc byte[26];

        var sSpan = s.AsSpan();
        var targetSpan = target.AsSpan();

        for (int i = 0; i < sSpan.Length; i++)
        {
            sFreq[sSpan[i] - 'a']++;
        }

        for (int i = 0; i < targetSpan.Length; i++)
        {
            targetFreq[targetSpan[i] - 'a']++;
        }

        var max = int.MaxValue;

        for (int i = 0; i < targetFreq.Length; i++)
        {
            if (targetFreq[i] == 0)
                continue;

            max = Math.Min(max, sFreq[i] / targetFreq[i]);
        }

        return max;
    }
}