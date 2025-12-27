using LeetCodeDaily.Core;

namespace _2483.Minimum_Penalty_for_a_Shop;

public class Solution
{
    [ResultGenerator]
    public int BestClosingTimeNaive(string customers)
    {
        int n = customers.Length;
        Span<int> prefix = stackalloc int[n + 1];
        Span<int> suffix = stackalloc int[n + 1];

        int p = 1;
        int s = n - 1;

        for (int i = 0; i < n; i++)
        {
            prefix[p] = prefix[p - 1] + ((customers[i] & 2) >>> 1);
            suffix[s] = suffix[s + 1] + (customers[n - i - 1] & 1);

            p++;
            s--;
        }

        var min = int.MaxValue;
        var index = 0;

        for (int i = 0; i < n + 1; i++)
        {
            var current = prefix[i] + suffix[i];
            if (current < min)
            {
                index = i;
                min = current;
            }
        }

        return index;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public int BestClosingTime(string customers)
    {
        int bestTime = 0;
        int bestScore = 0;
        int score = 0;

        for (int t = 0; t < customers.Length; t++)
        {
            if (customers[t] == 'Y')
                score += 1;     // opening this hour avoids a missed customer
            else
                score -= 1;     // opening this hour incurs idle cost

            // if score is better, closing AFTER this hour is optimal
            if (score > bestScore)
            {
                bestScore = score;
                bestTime = t + 1;   // close AFTER t
            }
        }

        return bestTime;
    }
}