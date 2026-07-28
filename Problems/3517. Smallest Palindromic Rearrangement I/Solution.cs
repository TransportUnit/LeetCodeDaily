using LeetCodeDaily.Core;
using System.Text;

namespace _3517.Smallest_Palindromic_Rearrangement_I;


public class Solution
{
    [ResultGenerator]
    public string SmallestPalindrome(string s)
    {
        int n = s.Length;
        Span<int> freq = stackalloc int[26];

        for (int i = 0; i < n; i++)
        {
            freq[s[i] - 'a']++;
        }

        char mid = '.';
        int oddCount = 0;
        StringBuilder sbb = new();
        StringBuilder sbe = new();

        for (char c = 'a'; c <= 'z'; c++)
        {
            var count = freq[c - 'a'];
            if (count % 2 != 0)
            {
                mid = c;
            }
            sbb.Append(c, count / 2);
            sbe.Insert(0, new string(c, count / 2));
        }

        if (mid != '.')
        {
            sbb.Append(mid, 1);
        }

        sbb.Append(sbe);

        return sbb.ToString();
    }
}