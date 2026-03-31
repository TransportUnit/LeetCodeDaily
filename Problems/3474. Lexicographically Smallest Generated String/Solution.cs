using LeetCodeDaily.Core;

namespace _3474.Lexicographically_Smallest_Generated_String;

public class Solution
{
    [ResultGenerator]
    public string GenerateString(string str1, string str2)
    {
        int n = str1.Length;

        int m = str2.Length;

        int len = n + m - 1;

        Span<char> result = stackalloc char[len];
        Span<bool> locked = stackalloc bool[len];

        for (int i = 0; i < len; i++)
        {
            result[i] = 'a';
        }

        for (int i = 0; i < n; i++)
        {
            if (str1[i] == 'T')
            {
                for (int j = 0; j < m; j++)
                {
                    if (locked[i + j] == false)
                    {
                        result[i + j] = str2[j];
                        locked[i + j] = true;
                    }
                    else if (result[i + j] != str2[j])
                    {
                        return "";
                    }
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (str1[i] == 'F')
            {
                string sCompare = new string(result.Slice(i, m));

                if (sCompare == str2)
                {
                    bool foundUnlocked = false;

                    for (int j = m - 1; j >= 0; j--)
                    {
                        if (locked[i + j] == false)
                        {
                            foundUnlocked = true;
                            if (result[i + j] == 'z')
                            {
                                return "";
                            }
                            // This works because we only ever increase characters (monotonic change).
                            // Once a substring != str2, it can never become equal again later.
                            // Therefore fixing the current "F" window cannot break any previous ones.
                            // We modify the rightmost non-locked position to minimize lexicographic impact.
                            result[i + j]++;
                            break;
                        }
                    }

                    if (!foundUnlocked)
                    {
                        return "";
                    }
                }
            }
        }

        return new string(result).Substring(0, len);
    }
}