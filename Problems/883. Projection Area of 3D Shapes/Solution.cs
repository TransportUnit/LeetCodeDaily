using LeetCodeDaily.Core;

namespace _883.Projection_Area_of_3D_Shapes;

public class Solution
{
    [ResultGenerator]
    public int ProjectionArea(int[][] grid)
    {
        int n = grid.Length;
        int sum = 0;

        for (int i = 0; i < n; i++)
        {
            int rowMax = 0;
            int colMax = 0;

            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] > 0)
                    sum++;

                rowMax = Math.Max(grid[i][j], rowMax);
                colMax = Math.Max(grid[j][i], colMax);
            }

            sum += rowMax + colMax;
        }

        return sum;
    }
}