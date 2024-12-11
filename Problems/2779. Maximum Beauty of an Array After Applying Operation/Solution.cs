using LeetCodeDaily.Core;

namespace _2779.Maximum_Beauty_of_an_Array_After_Applying_Operation;

public class Solution
{
    [ResultGenerator]
    public int MaximumBeauty(int[] nums, int k)
    {
        // idea:
        // - create an array that tracks the number of occurrences for each number in nums
        // - then, move through that array with a sliding window (sized 2 * k + 1) and find the
        //   maximum sum within each sliding window in the occurrences array
        // - the order of the original array isn't relevant because we can create any subsequence 
        //   by just deleting the elements that don't fit into the targeted range
        // - thus, only the number of elements that fit into the target range is relevant

        var numsSpan = nums.AsSpan();
        int min = 100_000;
        int max = 0;
        int i;

        // find the minimum and the maximum value
        for (i = 0; i < numsSpan.Length; i++)
        {
            max = Math.Max(numsSpan[i], max);
            min = Math.Min(numsSpan[i], min);
        }

        int j = 2 * k + 1;

        var range = max - min + 1;

        // if 2 * k + 1 is equal to or bigger than the total range of values,
        // we can assume that the operation can be applied to every element within nums
        if (j >= range)
        {
            return numsSpan.Length;
        }

        // this is where we store the amount of occurrences for each number
        // the index within the array represents the number (with an negative offset of the minimum value within nums)
        Span<int> freq = stackalloc int[range];

        for (i = 0; i < numsSpan.Length; i++)
        {
            freq[numsSpan[i] - min]++;
        }

        int sum = 0;

        // we start our sliding window off on the left end of our occurrence tracking array and move up until 2 * k + 1
        // within this window, every value can be reached by either adding or subtracting k from it
        // for instance, if k = 2 then one possible window is [0..4], because all of the values within that range can be modified to equal 2
        // the next window would be [1..5] (all values can be 3 after the operation) and so on
        for (i = 0; i < j; i++)
        {
            sum += freq[i];
        }

        i = 0;

        int result = sum;

        // after we calculated the sum of elements within our initial window, we move to the next window
        // by subtracting the first value within the window and adding the next value
        // while doing that, we calculate the absolute maximum sum within all possible windows
        while (j < freq.Length)
        {
            sum += freq[j++] - freq[i++];
            result = Math.Max(sum, result);
        }

        return result;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public int MaximumBeautyOptimized(int[] nums, int k)
    {
        // If there's only one element, the maximum beauty is 1
        if (nums.Length == 1) return 1;

        int maxBeauty = 0;
        int maxValue = 0;

        // Find the maximum value in the array
        foreach (int num in nums) maxValue = Math.Max(maxValue, num);

        // Create an array to keep track of the count changes
        int[] count = new int[maxValue + 1];

        // Update the count array for each value's range [val - k, val + k]
        foreach (int num in nums)
        {
            count[Math.Max(num - k, 0)]++; // Increment at the start of the range
            count[Math.Min(num + k + 1, maxValue)]--; // Decrement after the range
        }

        int currentSum = 0; // Tracks the running sum of counts
        // Calculate the prefix sum and find the maximum value
        foreach (int val in count)
        {
            currentSum += val;
            maxBeauty = Math.Max(maxBeauty, currentSum);
        }

        return maxBeauty;
    }
}