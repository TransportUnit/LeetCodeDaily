using LeetCodeDaily.Core;

namespace _3370.Smallest_Number_With_All_Set_Bits;

public class Solution
{
    [ResultGenerator]
    public int SmallestNumber(int n)
    {
        return
            (((n & 0b_00000000001) >> 0) * 0b_00000000001) |
            (((n & 0b_00000000010) >> 1) * 0b_00000000011) |
            (((n & 0b_00000000100) >> 2) * 0b_00000000111) |
            (((n & 0b_00000001000) >> 3) * 0b_00000001111) |
            (((n & 0b_00000010000) >> 4) * 0b_00000011111) |
            (((n & 0b_00000100000) >> 5) * 0b_00000111111) |
            (((n & 0b_00001000000) >> 6) * 0b_00001111111) |
            (((n & 0b_00010000000) >> 7) * 0b_00011111111) |
            (((n & 0b_00100000000) >> 8) * 0b_00111111111) |
            (((n & 0b_01000000000) >> 9) * 0b_01111111111) |
            (((n & 0b_10000000000) >> 10) * 0b_11111111111);
    }

    [ResultGenerator(ApproachIndex = 1)]
    public int SmallestNumberFastest(int n)
    {
        // Find the position of the most significant bit
        // 31 - LeadingZeroCount gives us the MSB position
        int msb = 31 - System.Numerics.BitOperations.LeadingZeroCount((uint)n);

        // Create a number with (msb+1) bits all set to 1
        int result = (1 << (msb + 1)) - 1;

        return result;
    }
}