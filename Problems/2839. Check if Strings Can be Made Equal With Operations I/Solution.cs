using LeetCodeDaily.Core;

namespace _2839.Check_if_Strings_Can_be_Made_Equal_With_Operations_I;

public class Solution
{
    [ResultGenerator]
    public bool CanBeEqual(string s1, string s2)
    {
        return
            ((s1[0], s1[2]) == (s2[0], s2[2]) ||
            (s1[0], s1[2]) == (s2[2], s2[0])) &&
            ((s1[1], s1[3]) == (s2[1], s2[3]) ||
            (s1[1], s1[3]) == (s2[3], s2[1]));

        /*
        if (s1.Length != s2.Length)
            return false;

        // [0 - 25]: even, [26 - 51]: odd
        Span<int> freqs = stackalloc int[26 * 2];

        for (int i = 0; i < s1.Length; i++)
        {
            freqs[(i & 1) * 26 + s1[i] - 'a']++;
            freqs[(i & 1) * 26 + s2[i] - 'a']--;
        }

        for (int i = 0; i < freqs.Length; i++)
        {
            if (freqs[i] != 0)
                return false;
        }

        return true;
        */
    }
}