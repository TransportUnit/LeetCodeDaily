using LeetCodeDaily.Core;

namespace _812.Largest_Triangle_Area;

public class Solution
{
    [ResultGenerator]
    public double LargestTriangleArea(int[][] points)
    {
        int n = points.Length;

        double maxArea = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                for (int k = j; k < n; k++)
                {
                    maxArea = Math.Max(maxArea, Shoelace(points[i], points[j], points[k]));
                }
            }
        }

        return maxArea;
    }

    public double Shoelace(int[] p1, int[] p2, int[] p3)
    {
        // Area = 1/2 * ​∣x1​(y2​−y3​)+x2​(y3​−y1​)+x3​(y1​−y2​)∣
        return 0.5 * Math.Abs(p1[0] * (p2[1] - p3[1]) + p2[0] * (p3[1] - p1[1]) + p3[0] * (p1[1] - p2[1]));
    }
}