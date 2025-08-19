using LeetCodeDaily.Core;

namespace _2348.Number_of_Zero_Filled_Subarrays;

public class Solution
{
    [ResultGenerator]
    public long ZeroFilledSubarray(int[] nums)
    {
        long result = 0;
        long counter = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                counter++;
            }
            else if (counter > 0)
            {
                result += (counter * (counter + 1)) / 2;
                counter = 0;
            }
        }

        if (counter > 0)
        {
            result += (counter * (counter + 1)) / 2;
        }

        return result;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public long ZeroFilledSubarrayBranchless(int[] nums)
    {
        long result = 0;
        long counter = 0;

        unsafe
        {
            fixed (int* p = nums)
            {
                int n = nums.Length;
                int* pt = p;

                while (n-- > 0)
                {
                    int isZero = 1 - ((*pt | -*pt++) >>> 31);
                    counter = isZero * (counter + isZero);
                    result += counter;
                }
            }
        }

        return result;
    }
}