using LeetCodeDaily.Core;

namespace _3614.Process_String_with_Special_Operations_II;

public class Solution
{
    [ResultGenerator]
    public char ProcessStr(string s, long k)
    {
        int n = s.Length;

        long length = 0;
        Span<long> lengths = stackalloc long[n + 1];
        lengths[0] = 0;

        for (int i = 0; i < n; i++)
        {
            if ('a' <= s[i] && s[i] <= 'z')
            {
                length += 1;
            }
            else if (s[i] == '*')
            {
                if (length > 0)
                {
                    length--;
                }
            }
            else if (s[i] == '#')
            {
                length *= 2;
            }

            lengths[i + 1] = length;
        }

        if (k >= length)
        {
            return '.';
        }

        for (int i = n - 1; i >= 0; i--)
        {
            if ('a' <= s[i] && s[i] <= 'z')
            {
                if (k == lengths[i])
                {
                    return s[i];
                }
            }
            else if (s[i] == '#')
            {
                // division by 0 possible?
                // /feasible at this point?
                if (lengths[i] > 0)
                {
                    k = k % lengths[i];
                }
            }
            else if (s[i] == '%')
            {
                k = lengths[i] - 1 - k;
            }
        }

        return '.';
    }

    [ResultGenerator(ApproachIndex = 1)]
    public char ProcessStrCleanSolution(string s, long k)
    {
        int n = s.Length;
        long len = 0;
        int[] a = new int[128];
        int[] b = new int[128];
        for (int i = 'a'; i <= 'z'; i++) a[i] = 1;
        b['#'] = 1;
        a['*'] = -1;
        for (int i = 0; i < n; i++)
        {
            len = len + a[s[i]] + b[s[i]] * len;
            if (len < 0) len = 0;
        }
        if (len <= k) return '.';
        for (int i = n - 1; ; i--)
        {
            switch (s[i])
            {
                case '#': { len /= 2; k %= len; break; }
                case '*': len++; break;
                case '%': { k = len - 1 - k; break; }
                default: { len--; if (len == k) return s[i]; break; }
            }
        }

    }
}

