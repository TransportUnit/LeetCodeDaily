using LeetCodeDaily.Core;

namespace _628.Maximum_Product_of_Three_Numbers;

public class Solution
{
    [ResultGenerator]
    public int MaximumProduct(int[] nums)
    {
        Array.Sort(nums);

        return Math.Max(nums[0] * nums[1] * nums[^1], nums[^1] * nums[^2] * nums[^3]);
    }
}