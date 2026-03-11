using LeetCodeDaily.Core;
using System.Numerics;

namespace _1009.Complement_of_Base_10_Integer;

public class Solution
{
    [ResultGenerator]
    public int BitwiseComplement(int n)
    {
        if (n == 0)
            return 1;

        return n ^ (-1 >>> BitOperations.LeadingZeroCount((uint)n));
    }
}