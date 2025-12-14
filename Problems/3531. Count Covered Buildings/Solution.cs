using LeetCodeDaily.Core;

namespace _3531.Count_Covered_Buildings;

public class Solution
{
    [ResultGenerator]
    public int CountCoveredBuildings(int n, int[][] buildings)
    {
        Span<int> rowMin = stackalloc int[n + 1];
        Span<int> rowMax = stackalloc int[n + 1];
        Span<int> columnMin = stackalloc int[n + 1];
        Span<int> columnMax = stackalloc int[n + 1];

        for (int i = 0; i < n + 1; i++)
        {
            rowMin[i] = int.MaxValue;
            columnMin[i] = int.MaxValue;
            rowMax[i] = int.MinValue;
            columnMax[i] = int.MinValue;
        }

        for (int i = 0; i < buildings.Length; i++)
        {
            var row = buildings[i][0];
            var column = buildings[i][1];
            rowMin[column] = Math.Min(rowMin[column], row);
            rowMax[column] = Math.Max(rowMax[column], row);
            columnMin[row] = Math.Min(columnMin[row], column);
            columnMax[row] = Math.Max(columnMax[row], column);
        }

        int count = 0;

        for (int i = 0; i < buildings.Length; i++)
        {
            var row = buildings[i][0];
            var column = buildings[i][1];

            if (rowMin[column] < row &&
                rowMax[column] > row &&
                columnMin[row] < column &&
                columnMax[row] > column)
            {
                count++;
            }
        }

        return count;
    }
}