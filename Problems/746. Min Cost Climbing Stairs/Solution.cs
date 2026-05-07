using LeetCodeDaily.Core;

namespace _746.Min_Cost_Climbing_Stairs;

public class Solution
{
    [ResultGenerator]
    public int MinCostClimbingStairs(int[] cost)
    {
        var dp = new int[cost.Length + 2];

        for (int i = cost.Length - 1; i >= 0; i--)
        {
            dp[i] = cost[i] + Math.Min(dp[i + 1], dp[i + 2]);
        }

        return Math.Min(dp[0], dp[1]);
    }
}