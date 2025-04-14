using LeetCodeDaily.Core;

namespace _1922._Count_Good_Numbers;

public class Solution
{
    [ResultGenerator]
    public int CountGoodNumbers(long n)
    {
        long modulus = 1_000_000_007;
        long x = ModularPow(5, (n + 1) / 2, modulus);
        long y = ModularPow(4, n / 2, modulus);
        long result = (x * y) % modulus;

        return (int)result;
    }

    private static long ModularPow(long baseValue, long exponent, long modulus)
    {
        if (modulus == 1)
            return 0;

        long result = 1;
        baseValue = baseValue % modulus;

        while (exponent > 0)
        {
            if (exponent % 2 == 1)
                result = (result * baseValue) % modulus;
            exponent = exponent >> 1;
            baseValue = (baseValue * baseValue) % modulus;
        }
        return result;
    }
}