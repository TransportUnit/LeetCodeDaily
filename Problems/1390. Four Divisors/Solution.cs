using LeetCodeDaily.Core;
using System.Runtime.CompilerServices;

namespace _1390.Four_Divisors;

public class Solution
{
    [ResultGenerator]
    public int SumFourDivisors(int[] nums)
    {
        // ###############################
        // Linq = ~16ms
        //return nums.Sum(n => DivSum(n));

        // ###############################
        // Memo = ~20ms

        /*
        Span<int> memo = stackalloc int[100_001];

        int result = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (memo[nums[i]] == 0)
            {
                var sum = DivSum(nums[i]);
                result += sum;
                memo[nums[i]] = sum - 1;
            }
            else if (memo[nums[i]] > 0)
            {
                result += memo[nums[i]] + 1;
            }
        }

        return result;
        */

        // ###############################
        // Simple iteration = ~14ms
        int result = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            result += DivSum(nums[i]);
        }

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int DivSum(int n)
    {
        // For any number n, if i is a divisor, then n/i is also a divisor 
        // (e.g., for 12, if 2 divides 12, then 12/2 = 6 is also a divisor

        // One number in each pair will always be <= sqrt(n) and the other >= sqrt(n)

        // By checking only up to sqrt(n), you find all the smaller divisors;
        // their corresponding larger partners (n/i) are automatically found
        // without needing to iterate further

        // initially, every number (except 1) has 2 distinct divisors - 1 and n
        int divisors = 2;
        int sum = n + 1;

        for (int i = 2; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                int otherDivisor = n / i;

                if (i != otherDivisor)
                {
                    divisors += 2;
                    sum += i + otherDivisor;
                }
                // we encountered an even square root
                // -> only add one divisor
                else
                {
                    divisors++;
                    sum += i;
                }

                if (divisors > 4)
                {
                    return 0;
                }
            }
        }

        if (divisors != 4)
            return 0;

        return sum;
    }
}