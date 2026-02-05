using LeetCodeDaily.Core;

namespace _3379.Transformed_Array;

public class Solution
{
    [ResultGenerator]
    public int[] ConstructTransformedArray(int[] nums)
    {
        int n = nums.Length;
        int[] result = new int[n];

        for (int i = 0; i < n; i++)
        {
            // add n * 100 to i and nums[i] before performing modulo n for left shift / avoids negative modulo
            int index = ((n * 100) + i + nums[i]) % n;
            result[i] = nums[index];
        }

        return result;
    }
}