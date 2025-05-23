using LeetCodeDaily.Core;

namespace _3355._Zero_Array_Transformation_I;

public class Solution
{
    [ResultGenerator]
    public bool IsZeroArray(int[] nums, int[][] queries)
    {
        Span<int> diff = stackalloc int[nums.Length + 1];

        foreach (var query in queries)
        {
            diff[query[0]] += 1;
            diff[query[1] + 1] -= 1;
        }

        if (diff[0] < nums[0])
        {
            return false;
        }

        int current = 0;

        for (int i = 0; i < diff.Length - 1; i++)
        {
            current += diff[i];

            if (current < nums[i])
            {
                return false;
            }
        }

        return true;
    }
}