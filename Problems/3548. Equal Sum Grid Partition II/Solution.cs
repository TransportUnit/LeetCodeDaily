using LeetCodeDaily.Core;
using System.Runtime.CompilerServices;

namespace _3548.Equal_Sum_Grid_Partition_II;

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

        if (total <= 0)
        {
            return false;
        }

        bool totalEven = total % 2 == 0;

        long target = total / 2;

        Dictionary<int, int> rowDiffs = new();

        for (int row = 0; row < m - 1; row++)
        {
            if (totalEven && rowSums[row] == target)
            {
                return true;
            }

            long diff = total - rowSums[row] - rowSums[row];

            if (diff > 100_000 || diff < -100_000)
                continue;

            rowDiffs[(int)diff] = row;
        }

        Dictionary<int, int> colDiffs = new();

        for (int col = 0; col < n - 1; col++)
        {
            if (col > 0)
            {
                colSums[col] += colSums[col - 1];
            }

            if (totalEven && colSums[col] == target)
            {
                return true;
            }

            long diff = total - colSums[col] - colSums[col];

            if (diff > 100_000 || diff < -100_000)
                continue;

            colDiffs[(int)diff] = col;
        }

        for (int row = 0; row < m; row++)
        {
            for (int col = 0; col < n; col++)
            {
                int val = grid[row][col];

                // delete in section after (below) cut
                if (rowDiffs.ContainsKey(val))
                {
                    int cutRow = rowDiffs[val];

                    if (row > cutRow)
                    {
                        if (IsAllowed(m - cutRow - 1, n, row - cutRow - 1, col))
                        {
                            return true;
                        }
                    }
                }
                // delete in section before (above) cut
                if (rowDiffs.ContainsKey(-(val)))
                {
                    int cutRow = rowDiffs[-(val)];

                    if (row <= cutRow)
                    {
                        if (IsAllowed(cutRow + 1, n, row, col))
                        {
                            return true;
                        }
                    }
                }
                // delete in section after cut (on righthand side)
                if (colDiffs.ContainsKey(val))
                {
                    int cutCol = colDiffs[val];

                    if (col > cutCol)
                    {
                        if (IsAllowed(m, n - cutCol - 1, row, col - cutCol - 1))
                        {
                            return true;
                        }
                    }
                }
                // delete in section before cut (on lefthand side)
                if (colDiffs.ContainsKey(-(val)))
                {
                    int cutCol = colDiffs[-(val)];

                    if (col <= cutCol)
                    {
                        if (IsAllowed(m, cutCol + 1, row, col))
                        {
                            return true;
                        }
                    }
                }

            }
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsAllowed(int sectionHeight, int sectionWidth, int rowRel, int colRel)
    {
        if (sectionHeight > 1 && sectionWidth > 1)
        {
            return true;
        }

        if (sectionHeight == 1)
        {
            if (sectionWidth > 1 && (colRel == 0 || colRel == sectionWidth - 1))
            {
                return true;
            }
        }
        // sectionWidth == 1
        else if (rowRel == 0 || rowRel == sectionHeight - 1)
        {
            return true;
        }

        return false;
    }
}
