using LeetCodeDaily.Core;

namespace _2091.Removing_Minimum_and_Maximum_From_Array;

public class Solution 
{
	[ResultGenerator]
    public int MinimumDeletions(int[] nums) 
    {
        int n = nums.Length;

        (int val, int ind) min= (int.MaxValue, -1);
        (int val, int ind) max= (int.MinValue, -1);

        for (int i = 0; i < n; i++)
        {
            min = nums[i] < min.val ? (nums[i], i) : min;
            max = nums[i] > max.val ? (nums[i], i) : max;
        }

        var leftInd = Math.Min(min.ind, max.ind);
        var rightInd = Math.Max(min.ind, max.ind);
        
        var delLeft  = rightInd + 1;
        var delRight = n - leftInd;
        var delBoth = leftInd + 1 + (n - rightInd);

        return Math.Min(Math.Min(delLeft, delRight), delBoth);
    }
}