using LeetCodeDaily.Core;

namespace _263._Ugly_Number;

public class Solution
{
    // inefficiency is key
    [ResultGenerator]
    public bool IsUgly(int n)
    {
        long num = 0;

        for (uint i = 0; i < 32; i++)
        {
            for (uint j = 0; j < 20; j++)
            {
                for (uint k = 0; k < 14; k++)
                {
                    num = IntPow(2, i) * IntPow(3, j) * IntPow(5, k);

                    if (num > 0 && num <= int.MaxValue)
                    {
                        if (num == n)
                            return true;
                    }
                    else
                        break;
                }
            }
        }

        return false;
    }

    static long IntPow(long x, uint pow)
    {
        long ret = 1;
        while (pow != 0)
        {
            if ((pow & 1) == 1)
                ret *= x;
            x *= x;
            pow >>= 1;
        }
        return ret;
    }
}
