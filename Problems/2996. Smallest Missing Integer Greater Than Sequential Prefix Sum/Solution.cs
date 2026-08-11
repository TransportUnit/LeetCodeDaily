using LeetCodeDaily.Core;

namespace _2996.Smallest_Missing_Integer_Greater_Than_Sequential_Prefix_Sum;

public class Solution
{
    [ResultGenerator]
    public int MissingInteger(int[] nums)
    {
        int n = nums.Length;

        if (n == 1)
        {
            return nums[0] + 1;
        }

        Span<bool> freq = stackalloc bool[52];

        int sum = nums[0];
        int activeStreak = 1;
        freq[nums[0]] = true;

        for (int i = 1; i < n; i++)
        {
            var diff = nums[i] - nums[i - 1];
            activeStreak = diff == 1 && activeStreak == 1 ? 1 : 0;
            sum += activeStreak * nums[i];
            freq[nums[i]] = true;
        }

        if (sum > 50)
            return sum;

        for (int i = sum; i <= 51; i++)
        {
            if (freq[i] == false)
            {
                return i;
            }
        }

        return -1;
    }
}