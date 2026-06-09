using LeetCodeDaily.Core;

namespace _2144.Minimum_Cost_of_Buying_Candies_With_Discount;

public class Solution
{
    [ResultGenerator]
    public int MinimumCost(int[] cost)
    {
        int n = cost.Length;

        Span<int> costOrdered = stackalloc int[101];

        for (int i = 0; i < n; i++)
        {
            costOrdered[cost[i]]++;
        }

        int total = 0;
        int j = 0;

        for (int i = 100; i > 0; i--)
        {
            while (costOrdered[i]-- > 0)
            {
                total += i - (j / 2) * i;
                j = (j + 1) % 3;
            }
        }

        return total;
    }
}