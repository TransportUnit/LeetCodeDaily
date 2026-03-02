using LeetCodeDaily.Core;

namespace _1536.Minimum_Swaps_to_Arrange_a_Binary_Grid;

public class Solution
{
    [ResultGenerator]
    public int MinSwaps(int[][] grid)
    {
        int n = grid.Length;

        // handle special cases
        if (n <= 1)
            return 0;

        Span<int> maxRight = stackalloc int[n];
        Span<int> maxRightFreq = stackalloc int[n];

        // recording the rightmost 1 in each row and its frequency
        for (int i = 0; i < n; i++)
        {
            int j = n - 1;

            for (; j >= 0; j--)
            {
                if (grid[i][j] == 1)
                {
                    maxRightFreq[j]++;
                    maxRight[i] = j;
                    break;
                }
            }

            // if there is no 1 in the row, we can treat it as if there is a 1 at index 0
            if (j < 0)
            {
                maxRightFreq[0]++;
            }
        }


        // checking feasibility 
        for (int i = 0; i < n; i++)
        {
            if (maxRightFreq[i] <= 0)
            {
                int j = i - 1;

                while (j >= 0 && maxRightFreq[j] <= 0)
                {
                    j--;
                }

                if (j < 0)
                {
                    return -1;
                }

                maxRightFreq[j]--;
                continue;
            }

            maxRightFreq[i]--;
        }

        int result = 0;

        // simulating and counting swap operations
        for (int i = 0; i < n; i++)
        {
            if (maxRight[i] > i)
            {
                int j = i + 1;

                while (j < n && maxRight[j] > i)
                {
                    j++;
                }

                for (; j > i; j--)
                {
                    (maxRight[j], maxRight[j - 1]) = (maxRight[j - 1], maxRight[j]);
                    result++;
                }
            }
        }

        return result;
    }
}