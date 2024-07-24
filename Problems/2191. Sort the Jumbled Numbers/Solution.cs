using LeetCodeDaily.Core;

namespace _2191._Sort_the_Jumbled_Numbers;

public class Solution
{
    private int[] _mapping = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];

    [ResultGenerator]
    public int[] SortJumbled(int[] mapping, int[] nums)
    {
        _mapping = mapping;
        Array.Sort(nums, Compare);
        return nums;
    }

    private int Compare(int x, int y)
    {
        return GetMappedNumber(x).CompareTo(GetMappedNumber(y));
        // x > y    -> 1
        // x = y   -> 0
        // x < y    -> -1
    }

    private int GetMappedNumber(int x)
    {
        int mapped = 0;
        int magnitude = 1;
        do
        {
            mapped += _mapping[x % 10] * magnitude;
            x /= 10;
            magnitude *= 10;
        }
        while (x > 0);
        return mapped;
    }
}