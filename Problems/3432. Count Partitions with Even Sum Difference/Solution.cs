using LeetCodeDaily.Core;

namespace _3432.Count_Partitions_with_Even_Sum_Difference;

public class Solution
{
    [ResultGenerator]
    public int CountPartitions(int[] nums)
    {
        // If sum = total sum of array, x = left partition sum and y = right partition sum
        // -> if sum is odd, then either x or y is odd -> difference (x - y) is odd
        // -> if sum is even, then either both x and y are odd or both are even -> difference (x - y) is even

        return nums.Sum() % 2 == 0 ? nums.Length - 1 : 0;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public int CountPartitionsNaive(int[] nums)
    {
        var sum = nums.Sum();

        if (sum % 2 != 0)
            return 0;

        var sumLeft = 0;

        var count = 0;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            sumLeft += nums[i];
            sum -= nums[i];
            count += 1 - (sum - sumLeft) % 2;
        }

        return count;
    }
}