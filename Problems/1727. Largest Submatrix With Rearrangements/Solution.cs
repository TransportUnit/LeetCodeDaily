using LeetCodeDaily.Core;

namespace _1727.Largest_Submatrix_With_Rearrangements;

public class Solution
{
    [ResultGenerator]
    public int LargestSubmatrix(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;

        Span<int> prevHeights = stackalloc int[n];
        Span<int> prevCols = stackalloc int[n];
        int ans = 0;

        for (int row = 0; row < m; row++)
        {
            int index = 0;
            Span<int> heights = stackalloc int[n];
            Span<int> cols = stackalloc int[n];
            Span<bool> seen = stackalloc bool[n];

            for (int i = 0; i < n; i++)
            {
                if (prevHeights[i] == 0)
                {
                    break;
                }

                int col = prevCols[i];

                if (matrix[row][col] == 1)
                {
                    heights[index] = prevHeights[i] + 1;
                    cols[index] = col;
                    index++;
                    seen[col] = true;
                }
            }

            for (int col = 0; col < n; col++)
            {
                if (seen[col] == false && matrix[row][col] == 1)
                {
                    heights[index] = 1;
                    cols[index] = col;
                    index++;
                }
            }

            for (int i = 0; i < index; i++)
            {
                ans = Math.Max(ans, heights[i] * (i + 1));
            }

            prevHeights = heights;
            prevCols = cols;
        }

        return ans;
    }


    [ResultGenerator(ApproachIndex = 1)]
    public int LargestSubmatrix2(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;

        Span<int> prevHeights = stackalloc int[n];
        Span<int> prevCols = stackalloc int[n];
        int ans = 0;

        for (int row = 0; row < m; row++)
        {
            int index = 0;
            Span<int> heights = stackalloc int[n];
            Span<int> cols = stackalloc int[n];
            Span<int> seen = stackalloc int[n];

            for (int i = 0; i < n; i++)
            {
                if (prevHeights[i] == 0)
                {
                    break;
                }

                int col = prevCols[i];
                int val = matrix[row][col];
                int valInv = 1 - val;

                heights[index] =
                    valInv * heights[index] +
                    val * (prevHeights[i] + 1);

                cols[index] =
                    valInv * cols[index] +
                    val * col;

                index += val;

                seen[col] = val;

                /*
                if (matrix[row][col] == 1)
                {
                    heights[index] = prevHeights[i] + 1;
                    cols[index] = col;
                    index++;
                    seen[col] = true;
                }
                */
            }

            for (int col = 0; col < n && index < n; col++)
            {
                int iterate = (1 - seen[col]) * matrix[row][col];
                int keep = 1 - iterate;

                heights[index] = iterate + keep * heights[index];
                cols[index] = iterate * col + keep * cols[index];
                index += iterate;

                /*
                if (seen[col] == false && matrix[row][col] == 1)
                {
                    heights[index] = 1;
                    cols[index] = col;
                    index++;
                }
                */
            }

            for (int i = 0; i < index; i++)
            {
                ans = Math.Max(ans, heights[i] * (i + 1));
            }

            prevHeights = heights;
            prevCols = cols;
        }

        return ans;
    }
}