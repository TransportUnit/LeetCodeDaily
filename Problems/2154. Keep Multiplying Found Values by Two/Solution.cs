using LeetCodeDaily.Core;

namespace _2154.Keep_Multiplying_Found_Values_by_Two;

public class Solution
{
    [ResultGenerator]
    public int FindFinalValue(int[] nums, int original)
    {
        // Idea:
        // use a bitmask to track factors that match powers of two

        ulong freq = 0;
        ulong factor = 0;

        foreach (var num in nums)
        {
            if (num % original == 0)
            {
                factor = (ulong)(num / original);

                if ((factor & (factor - 1)) == 0)
                {
                    freq |= factor;
                }
            }
        }

        // Then iterate over the found factors and calculate the maximum 'original' value

        int bit = 0;
        while (bit <= 63)
        {
            if ((freq & (1UL << bit++)) == 0)
                return original;

            original *= 2;
        }

        return original;
    }
}