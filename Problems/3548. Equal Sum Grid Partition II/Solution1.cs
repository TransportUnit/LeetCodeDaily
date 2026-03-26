using LeetCodeDaily.Core;

namespace _3548.Equal_Sum_Grid_Partition_II;

// AI generated
public class Solution1
{
    [ResultGenerator(ApproachIndex = 1)]
    public bool CanPartitionGrid(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;

        if (m > 1 && Check(grid, m, n, true))
            return true;

        if (n > 1 && Check(grid, m, n, false))
            return true;

        return false;
    }

    private bool Check(int[][] grid, int m, int n, bool horizontal)
    {
        long total = 0;

        foreach (var row in grid)
            foreach (var v in row)
                total += v;

        var bottom = new Dictionary<int, int>();
        foreach (var row in grid)
            foreach (var v in row)
                bottom[v] = bottom.GetValueOrDefault(v) + 1;

        var top = new Dictionary<int, int>();
        long topSum = 0;

        int outer = horizontal ? m : n;
        int inner = horizontal ? n : m;

        for (int i = 0; i < outer - 1; i++)
        {
            for (int j = 0; j < inner; j++)
            {
                int val = horizontal ? grid[i][j] : grid[j][i];

                top[val] = top.GetValueOrDefault(val) + 1;
                if (--bottom[val] == 0)
                    bottom.Remove(val);

                topSum += val;
            }

            long bottomSum = total - topSum;

            if (topSum == bottomSum)
                return true;

            long diff = bottomSum - topSum;

            int topH = horizontal ? i + 1 : m;
            int topW = horizontal ? n : i + 1;

            int botH = horizontal ? m - i - 1 : m;
            int botW = horizontal ? n : n - i - 1;

            // remove from bottom
            if (diff > 0 && diff <= 100_000)
            {
                if (botH > 1 && botW > 1)
                {
                    if (bottom.ContainsKey((int)diff))
                        return true;
                }
                else
                {
                    if (Check1DEndpoints(grid, i + 1, outer - 1, (int)diff, horizontal))
                        return true;
                }
            }

            // remove from top
            if (diff < 0 && -diff <= 100_000)
            {
                int target = (int)(-diff);

                if (topH > 1 && topW > 1)
                {
                    if (top.ContainsKey(target))
                        return true;
                }
                else
                {
                    if (Check1DEndpoints(grid, 0, i, target, horizontal))
                        return true;
                }
            }
        }

        return false;
    }

    private bool Check1DEndpoints(
        int[][] grid,
        int startOuter,
        int endOuter,
        int target,
        bool horizontal)
    {
        if (horizontal)
        {
            // section is rows [startOuter..endOuter], single column
            int col = 0;

            return grid[startOuter][col] == target ||
                   grid[endOuter][col] == target;
        }
        else
        {
            // section is columns [startOuter..endOuter], single row
            int row = 0;

            return grid[row][startOuter] == target ||
                   grid[row][endOuter] == target;
        }
    }
}