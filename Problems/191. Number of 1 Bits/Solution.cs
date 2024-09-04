using LeetCodeDaily.Core;

namespace _191._Number_of_1_Bits;

public class Solution
{
    [ResultGenerator]
    public int HammingWeight(int n)
    {
        // source: https://graphics.stanford.edu/~seander/bithacks.html#CountBitsSetNaive
        n = n - ((n >> 1) & 0x55555555);
        n = (n & 0x33333333) + ((n >> 2) & 0x33333333);
        n = ((n + (n >> 4) & 0xF0F0F0F) * 0x1010101) >> 24;
        return n;
    }

    //[ResultGenerator]
    public int HammingWeightWithIteration(int n)
    {
        int count = 0;
        while (n > 0)
        {
            count += n % 2;
            n /= 2;
        }
        return count;
    }
}