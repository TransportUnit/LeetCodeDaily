using LeetCodeDaily.Core;

namespace _3871.Count_Commas_in_Range_II;

public class Solution
{
    [ResultGenerator]
    public long CountCommas(long n)
    {
        const long range1Commas = 999_000;
        const long range2Commas = 999_000_000 * 2;
        const long range3Commas = 999_000_000_000 * 3;
        const long range4Commas = 999_000_000_000_000 * 4;

        // 1,000 - 999,999 -> 1 comma -> total of 999,000 commas in that range
        // 1,000,000 - 999,999,999 -> 2 commas -> total of 999,000,000 commas in that range
        // 1,000,000,000 - 999,999,999,999 -> 3 commas
        // 1,000,000,000,000 - 999,999,999,999,999 -> 4 commas
        // 1,000,000,000,000,000 -> 5 commas

        if (n >= 1_000_000_000_000_000)
        {
            return
                range1Commas +
                range2Commas +
                range3Commas +
                range4Commas +
                5;
        }

        if (n >= 1_000_000_000_000)
        {
            return
                range1Commas +
                range2Commas +
                range3Commas +
                (n - 999_999_999_999) * 4;
        }

        if (n >= 1_000_000_000)
        {
            return
                range1Commas +
                range2Commas +
                (n - 999_999_999) * 3;
        }

        if (n >= 1_000_000)
        {
            return
                range1Commas +
                (n - 999_999) * 2;
        }

        if (n >= 1_000)
        {
            return
                (n - 999) * 1;
        }

        return 0;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public long CountCommasEditorial(long n)
    {
        long p = 1000, res = 0;
        while (p <= n)
        {
            res += n - p + 1;
            p *= 1000;
        }
        return res;
    }
}