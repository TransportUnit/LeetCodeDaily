using LeetCodeDaily.Core;
using System.Text;

namespace _6._Zigzag_Conversion;

public class Solution
{
    [ResultGenerator]
    public string Convert(string s, int numRows)
    {
        int n = s.Length;

        if (numRows >= n || numRows == 1)
            return s;

        int rowLength = ((n + 1) / 2);
        Span<int> indexes = stackalloc int[numRows];
        Span<int> rows = stackalloc int[rowLength * numRows];

        int max = numRows - 1;

        for (int i = 0; i < n; i++)
        {
            int row = Math.Abs((i + max) % (2 * max) - max);
            int offset = indexes[row]++;
            rows[row * rowLength + offset] = i;
        }

        var sb = new StringBuilder();

        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < indexes[i]; j++)
            {
                sb.Append(s[rows[i * rowLength + j]]);
            }
        }

        return sb.ToString();
    }

    [ResultGenerator(ApproachIndex = 1)]
    public string ConvertFastest(string s, int numRows)
    {
        if (numRows == 1)
        {
            return s;
        }

        Span<char> result = stackalloc char[s.Length];

        var resultIndex = 0;
        var period = numRows * 2 - 2;

        for (int row = 0; row < numRows; row++)
        {
            var increment = 2 * row;

            for (int i = row; i < s.Length; i += increment)
            {
                result[resultIndex++] = s[i];

                if (increment != period)
                {
                    increment = period - increment;
                }
            }
        }

        return result.ToString();
    }
}