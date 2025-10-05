using LeetCodeDaily.Core;

namespace _417.Pacific_Atlantic_Water_Flow;

public class Solution
{
    [ResultGenerator]
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        int m = heights.Length;
        int n = heights[0].Length;

        List<IList<int>> result = new();

        bool[][] pacific = new bool[m][];
        bool[][] atlantic = new bool[m][];

        for (int i = 0; i < m; i++)
        {
            pacific[i] = new bool[n];
            atlantic[i] = new bool[n];
        }

        for (int i = 0; i < m; i++)
        {
            DFS(i, 0, heights, pacific);
            DFS(i, n - 1, heights, atlantic);
        }

        for (int j = 0; j < n; j++)
        {
            DFS(0, j, heights, pacific);
            DFS(m - 1, j, heights, atlantic);
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (pacific[i][j] && atlantic[i][j])
                {
                    result.Add(new List<int>() { i, j });
                }
            }
        }

        return result;
    }

    private void DFS(int i, int j, int[][] heights, bool[][] visited)
    {
        visited[i][j] = true;

        int n = -3;

        while (n++ < 2)
        {
            int x = i + n / 2;
            int y = j + n % 2;

            if (x < 0 || x >= heights.Length || y < 0 || y >= heights[0].Length)
                continue;
            if (visited[x][y])
                continue;
            if (heights[i][j] > heights[x][y])
                continue;

            DFS(x, y, heights, visited);
        }
    }
}