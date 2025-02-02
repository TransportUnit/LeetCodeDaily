using LeetCodeDaily.Core;

namespace _202._Happy_Number;

public class Solution
{
    [ResultGenerator]
    public bool IsHappy(int n)
    {
        int r = 0, t;
        while (n > 0)
        {
            t = n % 10;
            r += t * t;
            n /= 10;
        }

        unsafe
        {
            fixed (int* pt0 = convergences)
            {
                t = convergences.Length;
                int* pt = pt0;

                while (t-- > 0)
                {
                    if (*pt++ == r)
                        return true;
                }
                return false;
            }
        }
    }

    // this array contains every possible value a happy number will reach after one iteration,
    // sorted by number of occurrences after checking all numbers between 1 and int.MaxValue
    private readonly int[] convergences =
    {
        1,
        100,
        10,
        68,
        130,
        97,
        82,
        86,
        13,
        49,
        94,
        91,
        32,
        44,
        19,
        129,
        208,
        236,
        192,
        193,
        188,
        219,
        239,
        230,
        226,
        203,
        176,
        280,
        262,
        263,
        190,
        139,
        293,
        167,
        301,
        109,
        291,
        70,
        302,
        313,
        310,
        320,
        329,
        133,
        319,
        326,
        331,
        338,
        356,
        365,
        362,
        103,
        368,
        367,
        376,
        379,
        386,
        383,
        392,
        397,
        391,
        79,
        409,
        404,
        440,
        446,
        464,
        469,
        478,
        31,
        487,
        490,
        28,
        496,
        23,
        536,
        566,
        563,
        7,
        565,
        556,
        608,
        623,
        632,
        617,
        635,
        649,
        653,
        656,
        665,
        673,
        680
    };
}
