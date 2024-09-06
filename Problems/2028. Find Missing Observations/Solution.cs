using LeetCodeDaily.Core;

namespace _2028._Find_Missing_Observations;

public class Solution
{
    [ResultGenerator]
    public int[] MissingRolls(int[] rolls, int mean, int n)
    {
        // mean_value * total_rolls = total_result to hit with n + m rolls
        // total_result - observed_total = difference that has to be totaled in n rolls
        int sumDiff = mean * (rolls.Length + n) - rolls.Sum();

        // the average value that has to be hit with n rolls
        double nAverage = sumDiff / (double)n;

        // average value with n rolls is not feasible because we are limited to
        // using values between 1 and 6 -> return empty array
        if (nAverage < 1 || nAverage > 6)
            return Array.Empty<int>();

        // this serves as our template placeholder in the result array
        var roundedNAverage = (int)Math.Round(nAverage);

        var resultArr = Enumerable.Repeat(roundedNAverage, n).ToArray();

        // we have to modify our template result array by this amount in order to hit
        // the desired total in n rolls
        sumDiff = sumDiff - roundedNAverage * n;

        int factor;
        int maxDiff;

        if (sumDiff < 0)
        {
            factor = -1;
            maxDiff = roundedNAverage - 1;
            sumDiff *= -1;
        }
        else
        {
            factor = 1;
            maxDiff = 6 - roundedNAverage;
        }

        // modifying our result array until the difference to the desired total is 0

        int i = 0;
        while (sumDiff != 0)
        {
            var diff = Math.Min(maxDiff, sumDiff);
            resultArr[i++] += diff * factor;
            sumDiff -= diff;
        }

        return resultArr;
    }
}