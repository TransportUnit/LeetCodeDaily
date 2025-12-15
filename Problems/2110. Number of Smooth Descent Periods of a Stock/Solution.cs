using LeetCodeDaily.Core;

namespace _2110.Number_of_Smooth_Descent_Periods_of_a_Stock;

public class Solution
{
    [ResultGenerator]
    public long GetDescentPeriods(int[] prices)
    {
        long periods = 1;
        int currentStreak = 1;

        for (int i = 1; i < prices.Length; i++)
        {
            int x = prices[i - 1] - prices[i];

            int isDiffOne = 1 - (((x - 1) | (1 - x)) >>> 31);

            currentStreak = currentStreak * isDiffOne + 1;

            periods += currentStreak;

            // if (prices[i] == prices[i - 1] - 1)
            // {
            //     currentStreak++;
            // }
            // else
            // {
            //     currentStreak = 1;
            // }
            //periods += currentStreak;
        }

        return periods;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public long GetDescentPeriodsLinqOneLiner(int[] prices)
    {
        return prices.Select((x, i) => (x, i)).Skip(1).Aggregate(0L, (a, i) => { prices[0] = i.x == prices[i.i - 1] - 1 ? (i.i == 1 ? 1 : prices[0]) + 1 : 1; return a + prices[0]; }, (c) => (c + 1));
    }
}