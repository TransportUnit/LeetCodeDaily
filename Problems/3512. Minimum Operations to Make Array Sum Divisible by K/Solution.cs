using LeetCodeDaily.Core;

namespace _3512.Minimum_Operations_to_Make_Array_Sum_Divisible_by_K;

public class Solution
{
    [ResultGenerator]
    public int MinOperations(int[] nums, int k)
    {
        var sum = nums.Sum();
        return sum % k;
    }
}