using LeetCodeDaily.Core;
using System.Runtime.CompilerServices;

namespace _2586.Count_the_Number_of_Vowel_Strings_in_Range;

public class Solution
{
    [ResultGenerator]
    public int VowelStrings(string[] words, int left, int right)
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static int IsVowel(char c)
        {
            //int mask = (1 << ('a' - 'a')) | (1 << ('e' - 'a')) | (1 << ('i' - 'a')) | (1 << ('o' - 'a')) | (1 << ('u' - 'a'));
            //int mask = 1065233;
            return ((1 << (c - 'a')) & 1065233) != 0 ? 1 : 0;
        }

        int count = 0;

        while (left <= right)
        {
            count += (IsVowel(words[left][0]) + IsVowel(words[left++][^1])) / 2;
        }

        return count;
    }
}