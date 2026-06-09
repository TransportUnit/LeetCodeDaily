using LeetCodeDaily.Core;

namespace _3689.Maximum_Total_Subarray_Value_I
{
    public class Solution
    {
        [ResultGenerator]
        public long MaxTotalValue(int[] nums, int k)
        {
            int n = nums.Length;

            long min = int.MaxValue;
            long max = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                min = Math.Min(min, nums[i]);
                max = Math.Max(max, nums[i]);
            }

            return (max - min) * (long)k;
        }
    }
}