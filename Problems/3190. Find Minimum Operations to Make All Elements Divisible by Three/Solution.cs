using LeetCodeDaily.Core;

namespace _3190.Find_Minimum_Operations_to_Make_All_Elements_Divisible_by_Three;

public class Solution
{
    [ResultGenerator]
    public int MinimumOperations(int[] nums)
    {
        //return nums.Sum(x => x % 3 == 0 ? 0 : 1/*Math.Min(3 - (x % 3), x % 3)*/);

        int result = 0;

        foreach (var num in nums)
        {
            result += ((num % 3) >> 1) | ((num % 3) & 1);
        }

        return result;
    }
}