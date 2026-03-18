using LeetCodeDaily.Core;

namespace _3070.Count_Submatrices_with_Top_Left_Element_and_Sum_Less_Than_k;

public class Solution
{
    [ResultGenerator]
    public int CountSubmatrices(int[][] grid, int k)
    {
        if (grid[0][0] > k)
            return 0;

        int count = 0;

        int m = grid.Length;
        int n = grid[0].Length;
        int maxCol = n;

        // Since including the top left element means including all the elements from the previous row up to the current column,
        // we can keep track of the cumulative sum for each column and update it as we iterate through the rows.
        // Additionally, if one column exceeds the sum limit k, we can stop checking further columns for that row and all subsequent rows,
        // since they will also exceed the limit.

        // iteration order:

        // X 0 0 0 -> X X 0 0 -> X X X 0 -> X X X X -> X 0 0 0 -> X X 0 0 -> X X X 0 -> X X X X -> X 0 0 0 -> X X 0 0 -> X X X 0 -> X X X X
        // 0 0 0 0 -> 0 0 0 0 -> 0 0 0 0 -> 0 0 0 0 -> X 0 0 0 -> X X 0 0 -> X X X 0 -> X X X X -> X 0 0 0 -> X X 0 0 -> X X X 0 -> X X X X
        // 0 0 0 0 -> 0 0 0 0 -> 0 0 0 0 -> 0 0 0 0 -> 0 0 0 0 -> 0 0 0 0 -> 0 0 0 0 -> 0 0 0 0 -> X 0 0 0 -> X X 0 0 -> X X X 0 -> X X X X

        for (int row = 0; row < m; row++)
        {
            // resetting sum for each row, since we already added
            // the cumulative sum from the previous row to the current row in the previous iteration
            int sum = 0;

            for (int col = 0; col < maxCol; col++)
            {
                sum += grid[row][col];

                if (sum <= k)
                {
                    count++;
                }
                else
                {
                    // special case: this column exceeds k, so inlcuding it in further iteration will also exceed k,
                    // -> setting new column limit for subsequent iterations
                    maxCol = col;
                    break;
                }

                // we store the cumulative sum for the current column in the next row,
                // so that when we move to the next row, we can easily calculate the sum
                // for the submatrix that includes the top left element and extends down to the current row and column.
                if (row < m - 1)
                {
                    grid[row + 1][col] += grid[row][col];
                }
            }
        }


        return count;
    }
}