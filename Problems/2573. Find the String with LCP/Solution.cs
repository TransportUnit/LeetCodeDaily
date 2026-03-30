using LeetCodeDaily.Core;

namespace _2573.Find_the_String_with_LCP;

public class Solution
{
    [ResultGenerator]
    public string FindTheStringWrapper(int[][] lcp)
    {
        // can't be bothered with empty strings in the test cases
        var result = FindTheString(lcp);
        if (result == "")
        {
            result = "-";
        }
        return result;
    }

    public string FindTheString(int[][] lcp)
    {
        int n = lcp.Length;

        Span<char> result = stackalloc char[n];

        for (int i = 0; i < n; i++)
        {
            result[i] = 'a';
        }

        if (lcp[0][0] != n)
        {
            return "";
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                if (lcp[i][j] != lcp[j][i] ||
                    lcp[i][j] > n - Math.Max(i, j) ||
                    (lcp[i][j] > 0 && i + 1 < n && j + 1 < n && lcp[i][j] != lcp[i + 1][j + 1] + 1))
                {
                    return "";
                }

                if (lcp[i][j] == 0)
                {
                    if (result[j] == result[i])
                    {
                        result[j]++;

                        if (result[j] > 'z')
                        {
                            return "";
                        }
                    }
                }
                else if (result[i] != result[j])
                {
                    return "";
                }
            }
        }

        return new string(result);
    }
}