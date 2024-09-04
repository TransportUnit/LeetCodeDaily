using LeetCodeDaily.Core;

namespace _137._Single_Number_II;

public class Solution
{
    [ResultGenerator]
    public int SingleNumber(int[] nums)
    {
        var one = 0;
        var two = 0;

        foreach (var num in nums)
        {
            one = (one ^ num) & ~two;
            two = (two ^ num) & ~one;
        }
        return one;
    }
}