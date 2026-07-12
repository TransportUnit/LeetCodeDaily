using LeetCodeDaily.Core;

namespace _3754.Concatenate_Non_Zero_Digits_and_Multiply_by_Sum_I;

public class Solution
{
    [ResultGenerator]
    public long SumAndMultiply(int n)
    {
        long x = 0;
        long sum = 0;
        long mag = 1;

        while (n != 0)
        {
            int mod = n % 10;
            if (mod > 0)
            {
                x += mod * mag;
                mag *= 10;
                sum += mod;
            }
            n /= 10;
        }

        return sum * x;
    }
}