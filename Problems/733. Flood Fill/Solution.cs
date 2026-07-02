using LeetCodeDaily.Core;

namespace _733.Flood_Fill;

public class Solution
{
    [ResultGenerator]
    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        int startingColor = image[sr][sc];

        if (color == startingColor)
        {
            return image;
        }

        int m = image.Length;
        int n = image[0].Length;

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        Queue<(int x, int y)> queue = new();

        queue.Enqueue((sr, sc));

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            int x = current.x;
            int y = current.y;

            image[x][y] = color;

            for (int i = 0; i < 4; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];

                if (BoundsCheck(nx, ny, m, n) &&
                    image[nx][ny] == startingColor)
                {
                    queue.Enqueue((nx, ny));
                }
            }
        }

        return image;
    }

    private static bool BoundsCheck(int x, int y, int m, int n)
    {
        return x >= 0 &&
               x < m &&
               y >= 0 &&
               y < n;
    }
}