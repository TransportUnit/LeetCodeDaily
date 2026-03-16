using LeetCodeDaily.Core;

namespace _1878.Get_Biggest_Three_Rhombus_Sums_in_a_Grid;

public class Solution
{
    [ResultGenerator]
    public int[] GetBiggestThree(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        PriorityQueue<int, int> prio = new();

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                prio.Enqueue(grid[i][j], -(grid[i][j]));

                int size = 1;
                while (true)
                {
                    int sum = Explore(grid, i, j, size, m, n);

                    if (sum <= 0)
                        break;

                    prio.Enqueue(sum, -sum);
                    size++;
                }
            }
        }

        if (prio.Count == 0)
            return Array.Empty<int>();

        List<int> list = new();
        int last = prio.Dequeue();
        list.Add(last);

        while (list.Count < 3 && prio.Count > 0)
        {
            int item = prio.Dequeue();
            if (last != item)
            {
                list.Add(item);
                last = item;
            }
        }

        return list.ToArray();
    }

    public int Explore(
        int[][] grid,
        int row,
        int col,
        int size,
        int m, // rows
        int n) // cols
    {
        if (size <= 0)
            return grid[row][col];

        if (row - size < 0 || col - size < 0 || row + size >= m || col + size >= n)
            return 0;

        int sum =
            grid[row - size][col] +
            grid[row + size][col] +
            grid[row][col - size] +
            grid[row][col + size]
        ;

        int i = 1;
        while (--size > 0)
        {
            sum +=
                grid[row - size][col - i] +
                grid[row - size][col + i] +
                grid[row + size][col - i] +
                grid[row + size][col + i];
            i++;
        }

        return sum;
    }
}