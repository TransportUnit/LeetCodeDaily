using LeetCodeDaily.Core;

namespace _1358.Number_of_Substrings_Containing_All_Three_Characters;

public class Solution
{
    [ResultGenerator]
    public int NumberOfSubstrings(string s)
    {
        int n = s.Length;

        int[] freq = new int[3];

        int r = 0;
        int l = 0;

        freq[s[r] - 'a']++;

        int count = 0;

        while ((r + 1) < n && l < n)
        {
            while (f() == 0 && (r + 1) < n)
            {
                r++;
                freq[s[r] - 'a']++;
            }

            if (f() != 0)
            {
                count += (n - r);
            }

            while (f() != 0 && l < n)
            {
                freq[s[l] - 'a']--;
                l++;
                if (f() != 0)
                {
                    count += (n - r);
                }
            }
        }

        int f()
        {
            return freq[0] * freq[1] * freq[2];
        }

        return count;
    }
}

/*
 * Use two pointers: left and right.
 * - Move right to the right until you have 1 of each chars. 
 *   This means that all substrings [left, right], [left, right +1] , ..[left, s.length() -1] will contain all 3 chars. 
 *   So add 1 + s.length() - right to a total
 *   
 * - Now move left(increment) until your window does not have 3 chars anymore. 
 *   While moving it, you might have 3 chars in your substring 
 *   (eg: aaaaaaaabc...: your left is at 0 and right at 9. ; 
 *   when you move left to 1, you still have 3 chars, so you need to count them, same as #1
 *   
 * - Stop when right reaches s.length();
 */