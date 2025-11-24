using LeetCodeDaily.Core;

namespace _69.Sqrt_x_;

public class Solution
{
    [ResultGenerator]
    public int MySqrt(int x)
    {
        int left = 0;
        int right = x;

        while (left <= right)
        {
            long mid = left + (right - left) / 2;

            if (mid * mid == x)
            {
                return (int)mid;
            }
            if (mid * mid > x)
            {
                right = (int)mid - 1;
            }
            else
            {
                left = (int)mid + 1;
            }
        }

        return right;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public int MyOtherSqrt(int x)
    {
        if (x == 0)
            return 0;

        int bitlen = 32 - int.LeadingZeroCount(x);
        double x_k = 1 << ((bitlen + 1) / 2);

        double tmp = double.MinValue;

        while(Math.Abs(x_k - tmp) >= 0.5)
        {
            tmp = x_k;
            x_k = 0.5 * (x_k + (x/x_k));
        }

        return (int)x_k;
    }

    [ResultGenerator(ApproachIndex = 2)]
    public int AISqrt(int n)
    {
        if (n < 2)
            return n;

        // 2^{ceil(bitlen/2)}
        int bitlen = 32 - int.LeadingZeroCount(n);
        int x = 1 << ((bitlen + 1) / 2);

        while (true)
        {
            int y = (x + n / x) / 2;
            if (y >= x)
                break;
            x = y;
        }

        // correction (1-2 steps max)
        while ((long)x * x > n) x--;
        while ((long)(x + 1) * (x + 1) <= n) x++;

        return x;
    }
}