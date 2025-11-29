using LeetCodeDaily.Core;

namespace _1262.Greatest_Sum_Divisible_by_Three;

public class Solution
{
    [ResultGenerator]
    public int MaxSumDivThree(int[] nums)
    {
        // Increment greedily, but keep track of the 4 smallest elements with remainders of 1 or two,
        // and then decide which one to subtract from the greedy sum later.

        // smallest element with remainder == 1
        int smallest1_1 = 10_001;
        // second smallest element with remainder == 1
        int smallest1_2 = 10_001;

        // smallest element with remainder == 2
        int smallest2_1 = 10_001;
        // second smallest element with remainder == 2
        int smallest2_2 = 10_001;

        int sum = 0;

        foreach (var num in nums)
        {
            sum += num;

            if (num % 3 == 1)
            {
                if (num < smallest1_1)
                {
                    smallest1_2 = smallest1_1;
                    smallest1_1 = num;
                }
                else if (num < smallest1_2)
                {
                    smallest1_2 = num;
                }
            }
            else if (num % 3 == 2)
            {
                if (num < smallest2_1)
                {
                    smallest2_2 = smallest2_1;
                    smallest2_1 = num;
                }
                else if (num < smallest2_2)
                {
                    smallest2_2 = num;
                }
            }
        }

        var remainder = sum % 3;
        int subtract = 0;

        if (remainder == 0)
        {
            return sum;
        }
        // if the remainder is 1, there either has to be a smallest element with remainder == 1
        // or two smallest elements with remainder == 2
        // the smaller of both is then subtracted from the greedy sum
        else if (remainder == 1)
        {
            subtract = Math.Min(smallest1_1, (smallest2_1 + smallest2_2));
        }
        // if the remainder is 2, there either has to be a smallest element with remainder == 2
        // or two smallest elements with remainder == 1
        // the smaller of both is then subtracted from the greedy sum
        else
        {
            subtract = Math.Min(smallest2_1, (smallest1_1 + smallest1_2));
        }

        sum -= subtract;

        return sum;
    }
}