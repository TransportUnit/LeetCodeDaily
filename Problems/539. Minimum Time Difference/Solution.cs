using LeetCodeDaily.Core;

namespace _539.Minimum_Time_Difference;

public class Solution
{
    [ResultGenerator]
    public int FindMinDifference(IList<string> timePoints)
    {
        int minDiff = int.MaxValue;

        var sortedMinutes =
            timePoints
                .Select(x => GetMinutes(x))
                .OrderBy(x => x)
                .ToList();

        for (int i = 0; i < sortedMinutes.Count - 1; i++)
        {
            minDiff = Math.Min(sortedMinutes[i + 1] - sortedMinutes[i], minDiff);

            if (minDiff == 0)
                return 0;
        }

        return Math.Min((1440 - sortedMinutes.Last()) + sortedMinutes.First(), minDiff);
    }

    private int GetMinutes(string timePoint)
    {
        return
            (timePoint[0] - '0') * 600 +
            (timePoint[1] - '0') * 60 +
            (timePoint[3] - '0') * 10 +
            (timePoint[4] - '0');
    }
}