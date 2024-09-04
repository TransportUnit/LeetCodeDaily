using LeetCodeDaily.Core;

namespace _137._Single_Number_II;

public class Solution
{
    [ResultGenerator]
    public int SingleNumber(int[] nums)
    {
        // this SO answer explains this approach pretty well:
        // https://stackoverflow.com/a/59867358/20120008

        var one = 0;
        var two = 0;

        foreach (var num in nums)
        {
            one = (one ^ num) & ~two;
            two = (two ^ num) & ~one;
        }
        return one;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public int SingleNumberNaive(int[] nums)
    {
        int ans = 0;
        // Iterate through each bit position (0 to 31)
        for (int i = 31; i >= 0; i--)
        {
            int sum = 0;
            // Count how many numbers have the ith bit set
            foreach (int num in nums)
            {
                int n = (num >> i);
                if ((n & 1) == 1)
                {
                    sum++;
                }
            }
            // If sum is not a multiple of 3, the unique number has this bit set
            sum = sum % 3;
            // Shift ans left before adding the bit
            ans = (ans << 1);
            if (sum != 0)
            {
                ans += 1;
            }
        }
        return ans;
    }
}