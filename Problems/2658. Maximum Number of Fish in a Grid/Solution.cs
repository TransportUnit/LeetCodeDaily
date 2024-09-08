using LeetCodeDaily.Core;

namespace _2658._Maximum_Number_of_Fish_in_a_Grid;

public class Solution
{
    [ResultGenerator]
    public int FindMaxFish(int[][] grid)
    {
        int max = 0;

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 0)
                    continue;

                max = Math.Max(BFS(grid, i, j), max);
            }
        }

        return max;
    }

    private int BFS(int[][] grid, int i, int j)
    {
        if (i < 0 || j < 0 || i >= grid.Length || j >= grid[i].Length || grid[i][j] == 0)
            return 0;

        var value = grid[i][j];
        grid[i][j] = 0;
        
        value += BFS(grid, i + 1, j);
        value += BFS(grid, i - 1, j);
        value += BFS(grid, i, j + 1);
        value += BFS(grid, i, j - 1);

        return value;
    }
}