using LeetCodeDaily.Core;

namespace _3228.Maximum_Number_of_Operations_to_Move_Ones_to_the_End;

public class Solution
{
    [ResultGenerator]
    public int MaxOperations(string s)
    {
        int ones = 0;
        int result = 0;

        for (int i = 1; i < s.Length; i++)
        {
            ones += s[i - 1] - 48;

            result += ones * (49 - s[i]) * ((s[i] - 48) ^ (s[i - 1] - 48));
        }

        return result;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public int MaxOperationsComprehensive(string s)
    {
        int ones = 0;
        int result = 0;
        int last = s[0];

        for (int i = 1; i < s.Length; i++)
        {
            ones += last - 48;

            if (s[i] != last && s[i] == 48)
            {
                result += ones;
            }

            last = s[i];
        }

        return result;
    }
}