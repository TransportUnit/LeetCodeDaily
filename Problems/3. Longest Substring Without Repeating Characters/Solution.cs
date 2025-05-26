using LeetCodeDaily.Core;
using System.Runtime.CompilerServices;

namespace _3._Longest_Substring_Without_Repeating_Characters;

public class Solution
{
    [ResultGenerator(ApproachIndex = 0)]
    public int LengthOfLongestSubstringHashSet(string s)
    {
        int n = s.Length;

        if (n < 2)
            return n;

        HashSet<char> hashSet = new();
        int l = 0;
        int r = 0;
        int max = 0;

        while (r < n)
        {
            if (hashSet.Contains(s[r]))
            {
                hashSet.Remove(s[l++]);
            }
            else
            {
                hashSet.Add(s[r++]);
                max = Math.Max(max, r - l);
            }
        }

        return max;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public int LengthOfLongestSubstringFreq1(string s)
    {
        int n = s.Length;

        if (n < 2)
            return n;

        Span<ushort> freq = stackalloc ushort[128];

        int l = 0;
        int r = 0;
        int max = 0;

        while (r < n)
        {
            if (freq[s[r]] > 0)
            {
                freq[s[l++]]--;
            }
            else
            {
                freq[s[r++]]++;
                max = Math.Max(max, r - l);
            }
        }

        return max;
    }

    [ResultGenerator(ApproachIndex = 2)]
    public unsafe int LengthOfLongestSubstringFreq2(string s)
    {
        int n = s.Length;

        if (n < 2)
            return n;

        ushort* freq = stackalloc ushort[128];
        Unsafe.InitBlock(freq, 0, 128 * sizeof(ushort));

        int l = 0, r = 0, max = 0;

        fixed (char* str = s)
        {
            while (r < n)
            {
                int set = -((int)freq[str[r]]) >>> 31;
                freq[str[l]] -= (ushort)set;
                l += set;
                freq[str[r]] += (ushort)(1 - set);
                r += (ushort)(1 - set);
                max = Math.Max(max, r - l);
            }
        }

        return max;
    }

    [ResultGenerator(ApproachIndex = 3)]
    public int LengthOfLongestSubstringLastIndex(string s)
    {
        Span<int> chars = stackalloc int[256];
        int maxLen = 0, current = 0, left = 0;
        for (int i = 0; i < s.Length; i++)
        {
            current = s[i];
            if (chars[current] > 0)
            {

                left = Math.Max(left, chars[current]);
            }

            maxLen = Math.Max(maxLen, i - left + 1);
            chars[current] = i + 1;
        }

        return maxLen;
    }
}