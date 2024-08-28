using LeetCodeDaily.Core;

namespace _200._Number_of_Islands;

public class Solution
{
    [ResultGenerator]
    public int NumIslands(char[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int islands = 0;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == '0')
                {
                    continue;
                }
                // found island -> mark island and increment count by 1
                islands += 1;
                MarkIsland(grid, i, j, m, n);
            }
        }

        return islands;
    }

    private void MarkIsland(char[][] grid, int i, int j, int m, int n)
    {
        if (i < 0 || i >= m || j < 0 || j >= n || grid[i][j] == '0')
            return;

        grid[i][j] = '0';

        MarkIsland(grid, i - 1, j, m, n);
        MarkIsland(grid, i + 1, j, m, n);
        MarkIsland(grid, i, j - 1, m, n);
        MarkIsland(grid, i, j + 1, m, n);
    }
}