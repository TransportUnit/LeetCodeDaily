using LeetCodeDaily.Core;

namespace _242._Valid_Anagram;

public class Solution
{
    [ResultGenerator]
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        Span<int> freq = stackalloc int[26];
        ReadOnlySpan<char> ss = s.AsSpan();
        ReadOnlySpan<char> ts = t.AsSpan();

        int n = ss.Length;
        unsafe
        {
            fixed (int* sp0 = freq)
            {
                fixed (char* ssp0 = ss, tsp0 = ts)
                {
                    char* sp = ssp0;
                    char* tp = tsp0;

                    while (--n >= 0)
                    {
                        (*(sp0 + *(sp++) - 'a'))++;
                        (*(sp0 + *(tp++) - 'a'))--;
                    }
                }

                n = 26;
                while (--n >= 0)
                {
                    if (*(sp0 + n) != 0)
                        return false;
                }

                return true;
            }
        }
    }
}