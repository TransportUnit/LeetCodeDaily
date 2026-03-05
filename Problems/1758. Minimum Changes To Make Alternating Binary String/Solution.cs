using LeetCodeDaily.Core;

namespace _1758.Minimum_Changes_To_Make_Alternating_Binary_String;

public class Solution
{
    [ResultGenerator]
    public int MinOperations(string s)
    {
        int mismatchesStartingWithZero = 0;
        int mismatchesStartingWithOne = 0;

        for (int i = 0; i < s.Length; i++)
        {
            // approach three
            mismatchesStartingWithZero += (1 - (i & 1)) * (s[i] - '0') + (i & 1) * ('1' - s[i]);


            /*
            // approach two

            int isOne = s[i] - '0';
            int isZero = 1 - isOne; // '1' - s[i]
            int odd = i & 1;
            int even = 1 - odd; //(1 - (i & 1));

            mismatchesStartingWithZero += even * isOne + odd * isZero;
            mismatchesStartingWithOne += even * isZero + odd * isOne;
            */


            // approach one
            // mismatchesStartingWithZero += (1 - (i & 1)) * (s[i] - '0') + (i & 1) * ('1' - s[i]);
            // mismatchesStartingWithOne += (1 - (i & 1)) * ('1' - s[i]) + (i & 1) * (s[i] - '0');
        }

        // approach three
        mismatchesStartingWithOne = s.Length - mismatchesStartingWithZero;

        return Math.Min(mismatchesStartingWithZero, mismatchesStartingWithOne);
    }
}