using LeetCodeDaily.Core;

namespace _3702.Longest_Subsequence_With_Non_Zero_Bitwise_XOR;

public class Solution 
{
	[ResultGenerator]
    public int LongestSubsequence(int[] nums) 
    {
        int n = nums.Length;

        int total = 0;

        int nonZero = 0;

        for (int i = 0; i < n; i++)
        {
            total ^= nums[i];
            nonZero |= total;
        }

        if (total != 0)
            return n;

        return nonZero != 0 ? n - 1 : 0;
    }
}