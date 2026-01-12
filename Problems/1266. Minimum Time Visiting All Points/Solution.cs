using LeetCodeDaily.Core;

namespace _1266.Minimum_Time_Visiting_All_Points;

public class Solution
{
    [ResultGenerator]
    public int MinTimeToVisitAllPoints(int[][] points)
    {
        int result = 0;
        int x = points[0][0];
        int y = points[0][1];

        for (int i = 1; i < points.Length; i++)
        {
            var diffx = Math.Abs(points[i][0] - x);
            var diffy = Math.Abs(points[i][1] - y);

            var min = Math.Min(diffx, diffy);
            var max = Math.Max(diffx, diffy);

            result += min + (max - min);

            x = points[i][0];
            y = points[i][1];
        }

        return result;
    }
}