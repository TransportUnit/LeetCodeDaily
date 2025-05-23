using LeetCodeDaily.Core;

namespace _2460._Apply_Operations_to_an_Array;

public class Solution
{
    [ResultGenerator]
    public int[] ApplyOperations(int[] nums)
    {
        int n = nums.Length - 1;
        int zeroCount = 0;
        int j = 0;

        for (int i = 0; i < n; i++)
        {
            if (nums[i] == 0)
            {
                zeroCount++;
                continue;
            }

            if (nums[i] == nums[i + 1])
            {
                nums[j++] = nums[i++] * 2;
                zeroCount++;
            }
            else
            {
                nums[j++] = nums[i];
            }
        }

        if (nums[n] != 0)
        {
            nums[j] = nums[n];
        }
        else
        {
            zeroCount++;
        }

        if (zeroCount == nums.Length)
        {
            return nums;
        }

        while (zeroCount-- > 0)
        {
            nums[n--] = 0;
        }

        return nums;
    }
}