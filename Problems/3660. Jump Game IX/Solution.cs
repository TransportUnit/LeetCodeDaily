using LeetCodeDaily.Core;

namespace _3660.Jump_Game_IX;

public class Solution
{
    [ResultGenerator]
    public int[] MaxValue(int[] nums)
    {
        int n = nums.Length;

        if (n <= 1)
        {
            return nums;
        }

        int[] result = new int[n];

        Span<int> prefixMax = stackalloc int[n];
        Span<int> suffixMin = stackalloc int[n];

        prefixMax[0] = nums[0];
        suffixMin[^1] = nums[^1];
        result[0] = nums[0];

        int j = n - 2;

        for (int i = 1; i < n; i++, j--)
        {
            suffixMin[j] = Math.Min(nums[j], suffixMin[j + 1]);
            prefixMax[i] = Math.Max(nums[i], prefixMax[i - 1]);
            result[i] = prefixMax[i];
        }

        List<int> segments = new();

        int segmentStart = 0;
        int segmentMax = int.MinValue;

        for (int i = 0; i < n - 1; i++)
        {
            segmentMax = Math.Max(nums[i], segmentMax);

            if (prefixMax[i] <= suffixMin[i + 1])
            {
                for (int k = segmentStart; k <= i; k++)
                {
                    result[k] = segmentMax;
                }

                if (segmentMax == prefixMax[^1])
                {
                    return result;
                }

                segmentStart = i + 1;
                segmentMax = nums[i + 1];
            }
        }

        if (segmentStart < n)
        {
            for (int k = segmentStart; k < n; k++)
            {
                result[k] = segmentMax;
            }
        }

        return result;
    }
}