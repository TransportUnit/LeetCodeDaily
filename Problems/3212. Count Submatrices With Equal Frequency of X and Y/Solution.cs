using LeetCodeDaily.Core;
using System.Runtime.CompilerServices;

namespace _3212.Count_Submatrices_With_Equal_Frequency_of_X_and_Y;

public class Solution
{
    [ResultGenerator]
    public int NumberOfSubmatrices(char[][] grid)
    {
        // similar to 3070: Count Submatrices with Top-Left Element and Sum Less Than k

        int count = 0;

        int m = grid.Length;
        int n = grid[0].Length;

        // keeping track of occurrences in previous rows for each column
        Span<int> lastRowX = stackalloc int[n];
        Span<int> lastRowY = stackalloc int[n];

        // iteration order:

        // X 0 0 0 -> X X 0 0 -> X X X 0 -> X X X X -> X 0 0 0 -> X X 0 0 ->
        // 0 0 0 0 -> 0 0 0 0 -> 0 0 0 0 -> 0 0 0 0 -> X 0 0 0 -> X X 0 0 ->
        // 0 0 0 0 -> 0 0 0 0 -> 0 0 0 0 -> 0 0 0 0 -> 0 0 0 0 -> 0 0 0 0 ->

        //         -> X X X 0 -> X X X X -> X 0 0 0 -> X X 0 0 -> X X X 0 -> X X X X
        //         -> X X X 0 -> X X X X -> X 0 0 0 -> X X 0 0 -> X X X 0 -> X X X X
        //         -> 0 0 0 0 -> 0 0 0 0 -> X 0 0 0 -> X X 0 0 -> X X X 0 -> X X X X

        for (int row = 0; row < m; row++)
        {
            int xs = 0;
            int ys = 0;

            // '.' = 46 DEC
            // 'X' = 88 DEC
            // 'Y' = 89 DEC

            for (int col = 0; col < n; col++)
            {
                // c will be:
                // - 0 for '.'
                // - 1 for 'X'
                // - 2 for 'Y'
                int c = (grid[row][col] - 46) % 41;

                // Add 1 to lastRowX if c is 1 (for 'X'), otherwise add 0.
                lastRowX[col] += c % 2;
                // Add 1 to lastRowY if c is 2 (for 'Y'), otherwise add 0.
                lastRowY[col] += c / 2;

                // keep track of the cumulative count of 'X' and 'Y'
                // for the current submatrix defined by the top-left corner and the current position.
                xs += lastRowX[col];
                ys += lastRowY[col];

                // Increment count if current submatrix has at least 1 'X' and the count of 'X' is equal to the count of 'Y'.
                bool cond = xs > 0 && xs == ys;
                count += Unsafe.As<bool, byte>(ref cond);



                // Readable version:

                /*
                if (grid[row][col] == 'X')
                {
                    lastRowX[col]++;
                }
                else if (grid[row][col] == 'Y')
                {
                    lastRowY[col]++;
                }

                xs += lastRowX[col];
                ys += lastRowY[col];

                if (xs > 0 && xs == ys)
                {
                    count++;
                }
                */
            }
        }


        return count;
    }
}