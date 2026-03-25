using LeetCodeDaily.Core;

namespace _3546.Equal_Sum_Grid_Partition_I;

public class Solution
{
    [ResultGenerator]
    public bool CanPartitionGrid(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        if (m < 2 && n < 2)
            return false;

        Span<long> rowSums = stackalloc long[m];
        Span<long> colSums = stackalloc long[n];

        for (int row = 0; row < m; row++)
        {
            if (row > 0)
            {
                rowSums[row] += rowSums[row - 1];
            }

            for (int col = 0; col < n; col++)
            {
                rowSums[row] += grid[row][col];
                colSums[col] += grid[row][col];
            }
        }

        var total = rowSums[m - 1];

        if (total <= 0 || total % 2 != 0)
        {
            return false;
        }

        long target = total / 2;

        for (int row = 0; row < m - 1; row++)
        {
            if (rowSums[row] == target)
            {
                return true;
            }
            if (rowSums[row] > target)
            {
                break;
            }
        }

        for (int col = 0; col < n - 1; col++)
        {
            if (col > 0)
            {
                colSums[col] += colSums[col - 1];
            }

            if (colSums[col] == target)
            {
                return true;
            }
            if (colSums[col] > target)
            {
                break;
            }
        }

        return false;
    }
}