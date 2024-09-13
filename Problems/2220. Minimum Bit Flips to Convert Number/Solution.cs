using LeetCodeDaily.Core;

namespace _2220._Minimum_Bit_Flips_to_Convert_Number;

public class Solution
{
    [ResultGenerator]
    public int MinBitFlips(int start, int goal)
    {
        // intuition:
        // After performing start XOR goal, you are left with a value that has every bit set that is different between start and goal.
        // So afterwards, you simply need to count the set bits within that resulting value in order to know how many bits you would need to flip to go from start to goal.
        // There are various ways to count the set bits within a value; this one does not use any loops and should therefore perform quite fast.
        // Reference: https://graphics.stanford.edu/~seander/bithacks.html#CountBitsSetParallel

        start = start ^ goal;
        start = start - ((start >> 1) & 0x55555555);
        start = (start & 0x33333333) + ((start >> 2) & 0x33333333);
        return ((start + (start >> 4) & 0xF0F0F0F) * 0x1010101) >> 24;
    }
}