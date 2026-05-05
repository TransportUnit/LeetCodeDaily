using LeetCodeDaily.Core;

namespace _48.Rotate_Image;

public class Solution
{
    [ResultGenerator]
    public int[][] RotateWrapper(int[][] matrix)
    {
        Rotate(matrix);
        return matrix;
    }

    public void Rotate(int[][] matrix)
    {
        var n = matrix.Length;

        Span<int> cache = stackalloc int[n * n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                cache[i * n + j] = matrix[i][j];
            }
        }

        int nSquare = n * n;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int offset = nSquare - (n - i + j * n);
                matrix[i][j] = cache[offset];
            }
        }
    }
}