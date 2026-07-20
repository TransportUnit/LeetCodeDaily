using LeetCodeDaily.Core;

namespace _1260.Shift_2D_Grid;

public class Solution
{
    [ResultGenerator]
    public IList<IList<int>> ShiftGrid(int[][] grid, int k)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int total = m * n;

        k = k % total;

        int[][] result = new int[m][];

        for (int i = 0; i < m; i++)
        {
            result[i] = new int[n];
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int newI = (i + ((j + k) / n)) % m;
                int newJ = (j + k) % n;

                result[newI][newJ] = grid[i][j];
            }
        }

        return result;

        // xnew -> (x + ((y + k) / n)) % m
        // ynew -> (y + k) % n
    }
}