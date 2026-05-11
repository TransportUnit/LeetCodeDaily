using LeetCodeDaily.Core;

namespace _2553.Separate_the_Digits_in_an_Array;

public class Solution
{
    [ResultGenerator]
    public int[] SeparateDigits(int[] nums)
    {
        int n = nums.Length;
        var maxSize = n * 6;

        Span<int> output = stackalloc int[maxSize];
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            var val = nums[i];

            if (val < 10)
            {
                output[count] = val;
                count++;
            }
            else if (val < 100)
            {
                output[count] = val / 10;
                output[count + 1] = val % 10;
                count += 2;
            }
            else if (val < 1_000)
            {
                output[count] = val / 100;
                output[count + 1] = (val / 10) % 10;
                output[count + 2] = val % 10;
                count += 3;
            }
            else if (val < 10_000)
            {
                output[count] = val / 1_000;
                output[count + 1] = (val / 100) % 10;
                output[count + 2] = (val / 10) % 10;
                output[count + 3] = val % 10;
                count += 4;
            }
            else if (val < 100_000)
            {
                output[count] = val / 10_000;
                output[count + 1] = (val / 1_000) % 10;
                output[count + 2] = (val / 100) % 10;
                output[count + 3] = (val / 10) % 10;
                output[count + 4] = val % 10;
                count += 5;
            }
            else
            {
                output[count] = 1;
                output[count + 1] = 0;
                output[count + 2] = 0;
                output[count + 3] = 0;
                output[count + 4] = 0;
                output[count + 5] = 0;
                count += 6;
            }
        }

        return output.Slice(0, count).ToArray();
    }
}