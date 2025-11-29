using LeetCodeDaily.Core;

namespace _53.Maximum_Subarray;

public class Solution
{
    [ResultGenerator]
    public int MaxSubArray(int[] nums)
    {
        // Kadane's Algorithm

        // Stores the result (maximum sum found so far)
        int res = nums[0];

        // Maximum sum of subarray ending at current position
        int maxEnding = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            // Either extend the previous subarray or start 
            // new from current element
            maxEnding = Math.Max(nums[i], maxEnding + nums[i]);

            // Update result if the new subarray sum is larger
            res = Math.Max(res, maxEnding);
        }
        return res;
    }
}