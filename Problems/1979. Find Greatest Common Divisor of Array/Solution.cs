using LeetCodeDaily.Core;

namespace _1979.Find_Greatest_Common_Divisor_of_Array;

public class Solution
{
    [ResultGenerator]
    public int FindGCD(int[] nums)
    {
        int n = nums.Length;
        int min = int.MaxValue;
        int max = int.MinValue;

        for (int i = 0; i < n; i++)
        {
            min = Math.Min(nums[i], min);
            max = Math.Max(nums[i], max);
        }
        return GCD(max, min);
    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            (a, b) = (b, a % b);
        }
        return a;
    }
}