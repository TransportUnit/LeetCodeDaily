using LeetCodeDaily.Core;

namespace _1975.Maximum_Matrix_Sum;

public class Solution
{
    [ResultGenerator]
    public long MaxMatrixSum(int[][] matrix)
    {
        // Since we can perform the operation any number of times, 
        // we can easily move and eliminate negative values by "bubbling"
        // them through the grid.
        // This also means that we can make any previously positive value negative.
        // If the amount of negative values is not even, there will be one
        // remaining negative value.
        // To maximize the resulting sum, we choose the minimum absolute value as
        // our last remaining negative value if the amount of negative values is uneven.

        // So, in summary, we first add all absolute values to our result and keep track
        // of the amount of negative values and the minimum absolute value element.
        // Then, if the total amount of negatives is uneven, we subtract 
        // the minimum absolute value (*2) from the result.

        int negatives = 0;
        int n = matrix.Length;
        long result = 0;
        long minAbs = long.MaxValue;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i][j] >= 0)
                {
                    result += matrix[i][j];
                    minAbs = Math.Min(minAbs, matrix[i][j]);
                }
                else
                {
                    result += (matrix[i][j] * (-1));
                    negatives++;
                    minAbs = Math.Min(minAbs, (matrix[i][j] * (-1)));
                }
            }
        }

        if (negatives > 0 && ((negatives % 2) != 0))
        {
            // remove the minimum absolute value two times
            // because not only did we greedily add it to our result
            // we now also need to subtract it again because it will remain
            // the only negative value within the grid
            result -= 2 * minAbs;
        }

        return result;
    }
}