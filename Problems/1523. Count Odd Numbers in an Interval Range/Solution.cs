using LeetCodeDaily.Core;

namespace _1523.Count_Odd_Numbers_in_an_Interval_Range;

public class Solution
{
    [ResultGenerator]
    public int CountOdds(int low, int high)
    {
        return
            (high - low + 1) / 2 +
            (high % 2 + low % 2) / 2;


        // Explanation:
        // (result - 1) <= ((high - low + 1) / 2)  <= result
        // Add '1' to ((high - low + 1) / 2) when both 'low' and 'high' have parity = 1
    }
}