using LeetCodeDaily.Core;

namespace _3286.Find_a_Safe_Walk_Through_a_Grid;

public class Solution
{
    [ResultGenerator]
    public bool FindSafeWalkWrapper(int[][] grid, int health)
    {
        return FindSafeWalk(grid, health);
    }

    public bool FindSafeWalk(IList<IList<int>> grid, int health)
    {
        int rows = grid.Count;
        int cols = grid[0].Count;

        if (grid[0][0] >= health)
        {
            return false;
        }

        int[,] dist = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                dist[i, j] = int.MaxValue;
            }
        }

        dist[0, 0] = grid[0][0];

        LinkedList<(int x, int y)> deque = new();
        deque.AddFirst((0, 0));

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        while (deque.Count > 0)
        {
            var current = deque.First.Value;
            deque.RemoveFirst();

            int x = current.x;
            int y = current.y;

            if (x == rows - 1 && y == cols - 1)
            {
                break;
            }

            for (int i = 0; i < 4; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];

                if (nx >= 0 && nx < rows && ny >= 0 && ny < cols)
                {
                    int cost = grid[nx][ny];

                    if (dist[x, y] + cost < dist[nx, ny])
                    {
                        dist[nx, ny] = dist[x, y] + cost;

                        if (cost == 0)
                        {
                            deque.AddFirst((nx, ny));
                        }
                        else
                        {
                            deque.AddLast((nx, ny));
                        }
                    }
                }
            }
        }

        return health - dist[rows - 1, cols - 1] >= 1;
    }
}