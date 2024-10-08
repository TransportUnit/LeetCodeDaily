using LeetCodeDaily.Core;

namespace _179.Largest_Number;

public class Solution
{
    [ResultGenerator]
    public string LargestNumber(int[] nums)
    {
        StringComparer comparer = new();
        var result =
            string
                .Join(
                    "",
                    nums
                        .Select(x => x.ToString())
                        .OrderByDescending(x => x, comparer))
                .TrimStart('0');

        if (string.IsNullOrEmpty(result))
            return "0";

        return result;
    }
}

internal class StringComparer : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        // -1: x < y
        //  0: x == y
        // +1: x > y

        if (x == y)
            return 0;

        ReadOnlySpan<char> longer, shorter;
        int minLength, maxLength, returnValue;

        if (x.Length > y.Length)
        {
            longer = x.AsSpan();
            shorter = y.AsSpan();
            returnValue = 1;
        }
        else
        {
            longer = y.AsSpan();
            shorter = x.AsSpan();
            returnValue = -1;
        }

        maxLength = longer.Length;
        minLength = shorter.Length;

        int i = -1;
        while (++i < 2 * maxLength)
        {
            if (longer[i % maxLength] == shorter[i % minLength])
                continue;

            if (longer[i % maxLength] > shorter[i % minLength])
                return returnValue;

            return -returnValue;
        }

        return 0;
    }
}