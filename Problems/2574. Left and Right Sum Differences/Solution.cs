using LeetCodeDaily.Core;

namespace _2574.Left_and_Right_Sum_Differences;

public class Solution
{
    [ResultGenerator]
    public int[] LeftRightDifference(int[] nums)
    {
        var result = new int[nums.Length];

        var rightSum = 0;
        var leftSum = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            rightSum += nums[i];
        }

        for (int i = 0; i < nums.Length - 1; i++)
        {
            result[i] = Math.Abs(leftSum - rightSum);
            leftSum += nums[i];
            rightSum -= nums[i + 1];
        }

        result[^1] = Math.Abs(leftSum);

        return result;
    }
}