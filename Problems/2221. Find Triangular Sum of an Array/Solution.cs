using LeetCodeDaily.Core;

namespace _2221.Find_Triangular_Sum_of_an_Array;

public class Solution
{
    [ResultGenerator]
    public int TriangularSum(int[] nums)
    {
        var n = nums.Length;

        if (n == 1)
            return nums[0];

        long result = 0;
        result += nums[0];
        result += nums[^1];

        n -= 1;

        for (int i = 1; i < n; i++)
        {
            result += nums[i] * GetBinomial(n, Math.Min(i, n - i));
        }

        result %= 10;

        return (int)result;
    }

    private static readonly int[,] smallBinom =
    {
        {1, 0, 0, 0, 0},
        {1, 1, 0, 0, 0},
        {1, 2, 1, 0, 0},
        {1, 3, 3, 1, 0},
        {1, 4, 1, 4, 1}
    };

    private static int GetBinomial(int n, int k)
    {
        var mod2 = (k & ~n) == 0 ? 1 : 0;

        int mod5 = 1;
        int nn = n, kk = k;
        while (nn > 0 || kk > 0)
        {
            int ni = nn % 5;
            int ki = kk % 5;

            if (ki > ni)
            {
                mod5 = 0;
                break;
            }

            mod5 = (mod5 * smallBinom[ni, ki]) % 5;

            nn /= 5;
            kk /= 5;
        }

        for (int x = 0; x < 10; x++)
        {
            if (x % 2 == mod2 && x % 5 == mod5)
                return x;
        }

        throw new Exception("CRT error");
    }
}