using LeetCodeDaily.Core;

namespace _3453.Separate_Squares_I;

public class Solution
{
    [ResultGenerator]
    public double SeparateSquaresBinary(int[][] squares)
    {
        int n = squares.Length;
        long total = 0;
        int minY = int.MaxValue;
        int maxY = int.MinValue;

        Span<long> area = stackalloc long[n];
        Span<int> min = stackalloc int[n];
        Span<int> max = stackalloc int[n];

        for (int i = 0; i < n; i++)
        {
            area[i] = squares[i][2] * (long)squares[i][2];
            total += area[i];
            min[i] = squares[i][1];
            max[i] = squares[i][1] + squares[i][2];
            minY = Math.Min(minY, min[i]);
            maxY = Math.Max(maxY, max[i]);
        }

        double target = total / 2.0;

        double left = minY;
        double right = maxY;

        while (right - left > 1e-6)
        {
            double mid = left + (right - left) / 2.0;

            double a = 0;

            for (int i = 0; i < n; i++)
            {
                if (min[i] >= mid)
                    continue;

                if (max[i] <= mid)
                {
                    a += area[i];
                    continue;
                }

                var sideA = max[i] - min[i];
                var sideB = mid - min[i];

                a += sideA * sideB;
            }

            if (a >= target)
            {
                right = mid;
            }
            else
            {
                left = mid;
            }
        }

        return right;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public double SeparateSquares(int[][] squares)
    {
        long totalArea = 0;
        List<int[]> events = new List<int[]>();

        foreach (var sq in squares)
        {
            int y = sq[1], l = sq[2];
            totalArea += (long)l * l;
            events.Add(new int[] { y, l, 1 });
            events.Add(new int[] { y + l, l, -1 });
        }

        // sort by y-coordinate
        events.Sort((a, b) => a[0].CompareTo(b[0]));

        double coveredWidth =
            0;  // sum of all bottom edges under the current scanning line
        double currArea = 0;    // current cumulative area
        double prevHeight = 0;  // height of the previous scanning line

        foreach (var eventItem in events)
        {
            int y = eventItem[0];
            int l = eventItem[1];
            int delta = eventItem[2];

            int diff = y - (int)prevHeight;
            // additional area between two scanning lines
            double area = coveredWidth * diff;
            // if this part of the area exceeds more than half of the total area
            if (2L * (currArea + area) >= totalArea)
            {
                return prevHeight +
                       (totalArea - 2.0 * currArea) / (2.0 * coveredWidth);
            }
            // update width: add width at the start event, subtract width at the
            // end event
            coveredWidth += delta * l;
            currArea += area;
            prevHeight = y;
        }

        return 0.0;
    }
}
