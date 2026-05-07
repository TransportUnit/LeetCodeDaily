using LeetCodeDaily.Core;

namespace _198.House_Robber;

public class Solution
{
    [ResultGenerator]
    public int Rob(int[] nums)
    {
        int n = nums.Length;

        if (n < 2)
            return nums[0];

        Span<int> dp = stackalloc int[n];

        dp[0] = nums[0];
        dp[1] = Math.Max(dp[0], nums[1]);

        for (int i = 2; i < n; i++)
        {
            dp[i] = Math.Max(dp[i - 1], nums[i] + dp[i - 2]);
        }

        return dp[^1];
    }
}