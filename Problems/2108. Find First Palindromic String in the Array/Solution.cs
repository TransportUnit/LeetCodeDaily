using LeetCodeDaily.Core;

namespace _2108._Find_First_Palindromic_String_in_the_Array;

public class Solution
{
    [ResultGenerator]
    public string FirstPalindrome(string[] words)
    {
        int l, r;
        foreach (var word in words)
        {
            l = 0;
            r = word.Length - 1;

            while (l <= r)
            {
                if (word[l] != word[r])
                    break;

                l++;
                r--;
            }

            if (l > r)
                return word;
        }
        return string.Empty;
    }
}