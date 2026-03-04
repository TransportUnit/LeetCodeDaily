using LeetCodeDaily.Core;

namespace _1582.Special_Positions_in_a_Binary_Matrix;

public class Solution
{
    [ResultGenerator]
    public int NumSpecial(int[][] mat)
    {
        int m = mat.Length;
        int n = mat[0].Length;

        int result = 0;

        Span<int> colCount = stackalloc int[n];
        Span<bool> addedCols = stackalloc bool[n];

        for (int i = 0; i < m; i++)
        {
            int rowCount = 0;
            int index = -1;

            for (int j = 0; j < n; j++)
            {
                if (mat[i][j] == 1)
                {
                    rowCount++;
                    colCount[j]++;
                    index = j;

                    if (colCount[j] > 1 && addedCols[j])
                    {
                        addedCols[j] = false;
                        result--;
                    }
                }
            }

            if (rowCount == 1 && colCount[index] == 1)
            {
                result++;
                addedCols[index] = true;
            }
        }

        return result;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public int NumSpecialNoExtraSpace(int[][] mat)
    {
        int m = mat.Length;
        int n = mat[0].Length;

        int result = 0;

        for (int i = 0; i < m; i++)
        {
            int rowCount = 0;
            int index = -1;

            for (int j = 0; j < n; j++)
            {
                if (mat[i][j] == 1)
                {
                    mat[i][j] = 0;
                    mat[0][j]++;
                    rowCount++;
                    index = j;

                    if (mat[0][j] < 0)
                    {
                        mat[0][j] = 2;
                        result--;
                    }
                }
            }

            if (rowCount == 1 && mat[0][index] == 1)
            {
                result++;
                mat[0][index] = int.MinValue;
            }
        }

        return result;
    }
}