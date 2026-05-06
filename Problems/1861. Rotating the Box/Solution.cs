using LeetCodeDaily.Core;

namespace _1861.Rotating_the_Box;

public class Solution
{
    [ResultGenerator]
    public char[][] RotateTheBox(char[][] boxGrid)
    {
        int m = boxGrid.Length;
        int n = boxGrid[0].Length;

        char[][] result = new char[n][];

        for (int i = 0; i < n; i++)
        {
            result[i] = new char[m];
        }

        int jptr = m - 1;

        for (int i = 0; i < m; i++)
        {
            int iptr = n - 1;

            for (int j = n - 1; j >= 0; j--)
            {
                result[j][jptr] = '.';

                if (boxGrid[i][j] == '*')
                {
                    result[j][jptr] = '*';
                    iptr = j - 1;
                }
                else if (boxGrid[i][j] == '#')
                {
                    result[iptr][jptr] = '#';
                    iptr--;
                }
            }

            jptr--;
        }

        return result;
    }
}