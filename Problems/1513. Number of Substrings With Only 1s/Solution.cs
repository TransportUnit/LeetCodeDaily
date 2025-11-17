using LeetCodeDaily.Core;

namespace _1513.Number_of_Substrings_With_Only_1s;

public class Solution
{
    [ResultGenerator]
    public int NumSub(string s)
    {
        int result = 0;

        unsafe
        {
            int group = 0;
            int n = s.Length;

            fixed (char* start = s)
            {
                char* pt = start;

                while (n-- > 0)
                {
                    group = (group + ((*pt) - 48)) * ((*pt++) - 48);
                    result = (result + group) % 1_000_000_007;
                }
            }
        }

        return result;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public int NumSubComprehensive(string s)
    {
        // Idea: Count consecutive '1's and add up the amount of possible substrings
        // For each '1' encountered, the number of substrings ending at that position increases by the length of the current group of consecutive '1's
        // For example, in "111", the substrings are: 3x "1", 2x "11", 1x "111" (3 substrings) = 6 substrings in total
        // This can also be calculated while iterating through the string
        // First '1': group = 1, result = 1
        // Second '1': group = 2, result = 1 + 2 = 3
        // Third '1': group = 3, result = 3 + 3 = 6

        int result = 0;
        int group = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '1')
            {
                group += 1;
            }
            else
            {
                group = 0;
            }

            result = (result + group) % 1_000_000_007;
        }

        return result;
    }
}