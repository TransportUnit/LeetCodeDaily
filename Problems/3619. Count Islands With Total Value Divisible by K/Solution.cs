using LeetCodeDaily.Core;

namespace _3619.Count_Islands_With_Total_Value_Divisible_by_K;

public class Solution
{
    [ResultGenerator]
    public int CountIslands(int[][] grid, int k)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        int islandId = 1;

        Span<int> islandIds = stackalloc int[m * n];

        Span<long> islandSums = stackalloc long[(m * n / 2) + 2];

        for (int i = 0; i < m; i++)
        {
            int rowOffset = i * n;
            int prevRowOffset = (i - 1) * n;

            for (int j = 0; j < n; j++)
            {
                var val = grid[i][j];

                if (val <= 0)
                {
                    continue;
                }

                int rowConnectionGroup = i > 0 ? islandIds[prevRowOffset + j] : 0;
                int columnConnectionGroup = j > 0 ? islandIds[rowOffset + (j - 1)] : 0;

                if (rowConnectionGroup == 0)
                {
                    if (columnConnectionGroup == 0)
                    {
                        // new group
                        islandIds[rowOffset + j] = islandId;
                        islandSums[islandId] = val;
                        islandId++;
                    }
                    else
                    {
                        // previous column connects
                        islandIds[rowOffset + j] = columnConnectionGroup;
                        islandSums[columnConnectionGroup] += val;
                    }
                }
                else
                {
                    if (columnConnectionGroup == 0)
                    {
                        // previous row connects
                        islandIds[rowOffset + j] = rowConnectionGroup;
                        islandSums[rowConnectionGroup] += val;
                    }
                    else if (columnConnectionGroup != rowConnectionGroup)
                    {
                        for (int l = 0; l < j; l++)
                        {
                            int idx = rowOffset + l;
                            if (islandIds[idx] == rowConnectionGroup)
                                islandIds[idx] = columnConnectionGroup;
                        }

                        for (int l = j + 1; l < n; l++)
                        {
                            int idx = prevRowOffset + l;
                            if (islandIds[idx] == rowConnectionGroup)
                                islandIds[idx] = columnConnectionGroup;
                        }

                        islandSums[columnConnectionGroup] += islandSums[rowConnectionGroup];
                        islandSums[rowConnectionGroup] = 0; // Alte Gruppe invalidieren
                        islandIds[rowOffset + j] = columnConnectionGroup;
                        islandSums[columnConnectionGroup] += val;
                    }
                    else
                    {
                        // both connect but already share a group
                        islandIds[rowOffset + j] = rowConnectionGroup;
                        islandSums[rowConnectionGroup] += val;
                    }
                }
            }
        }

        int count = 0;
        Span<long> activeSums = islandSums.Slice(0, islandId);
        for (int id = 1; id < activeSums.Length; id++)
        {
            long sum = activeSums[id];
            if (sum > 0 && sum % k == 0)
            {
                count++;
            }
        }

        return count;
    }
}