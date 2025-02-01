using LeetCodeDaily.Core;

namespace _2578._Split_With_Minimum_Sum;

public class Solution
{
    [ResultGenerator]
    public int SplitNum(int num)
    {
        unsafe
        {
            Span<byte> freq = stackalloc byte[10];

            fixed (byte* fp0 = freq)
            {
                while (num > 0)
                {
                    (*(fp0 + (num % 10)))++;
                    num /= 10;
                }

                Span<int> num12 = stackalloc int[2];
                int i = -1;
                int j = 1;

                fixed (int* np0 = num12)
                {
                    int* np = np0;

                    while (++i < 10)
                    {
                        while (((*(fp0 + i))--) > 0)
                        {
                            *np = *np * 10 + i;
                            np += j;
                            j *= -1;
                        }
                    }

                    return *np0 + *(np0 + 1);
                }
            }
        }
    }
}