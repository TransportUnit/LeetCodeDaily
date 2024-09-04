using LeetCodeDaily.Core;

namespace _136._Single_Number;

public class Solution
{
    [ResultGenerator]
    public int SingleNumber(int[] nums)
    {
        var result = 0;
        foreach (var num in nums)
        {
            result ^= num;
        }
        return result;
    }
}