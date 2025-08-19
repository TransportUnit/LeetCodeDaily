using LeetCodeDaily.Core;

namespace _8._String_to_Integer__atoi_;

public class Solution
{
    [ResultGenerator]
    public int MyAtoi(string s)
    {
        long result = 0;
        bool negative = false;
        int i = 0;
        int n = s.Length;

        // '+' -> 43
        // '-' -> 45
        // '0'-'9' -> 48 - 57

        // skip leading whitespaces
        while (i < n && s[i] == ' ')
        {
            i++;
        }

        // we check if there's a sign (only one allowed)
        if (i < n)
        {
            if (s[i] == '+')
            {
                i++;
            }
            else if (s[i] == '-')
            {
                i++;
                negative = true;
            }
        }

        // reading characters
        while (i < n && 48 <= s[i] && s[i] <= 57)
        {
            result = result * 10 + (s[i++] - 48);

            // outside bounds
            if (result > int.MaxValue)
            {
                if (!negative)
                {
                    return int.MaxValue;
                }

                if (-result < int.MinValue)
                {
                    return int.MinValue;
                }
            }
        }

        return (int)(result * (negative ? -1 : 1));
    }
}