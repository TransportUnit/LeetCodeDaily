using LeetCodeDaily.Core;

namespace _1351.Count_Negative_Numbers_in_a_Sorted_Matrix;

public class Solution
{
    [ResultGenerator]
    public int CountNegatives(int[][] grid)
    {
        int result = 0;
        int i = grid.Length - 1;
        int j = 0;

        while (i >= 0 && j < grid[0].Length)
        {
            if (grid[i][j] < 0)
            {
                result += grid[0].Length - j;
                i--;
            }
            else
            {
                j++;
            }
        }

        return result;
    }
}