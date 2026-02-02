using LeetCodeDaily.Core;

namespace _3010.Divide_an_Array_Into_Subarrays_With_Minimum_Cost_I;

public class Solution
{
    [ResultGenerator]
    public int MinimumCost(int[] nums)
    {
        // the first element is always part of the resulting sum
        // the other two indices can be chosen as the two smallest elements from the rest of the array

        return nums[0] + nums.Skip(1).OrderBy(x => x).Take(2).Sum();
    }
}