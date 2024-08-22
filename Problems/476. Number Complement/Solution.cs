using LeetCodeDaily.Core;

namespace _476._Number_Complement;

public class Solution
{
    [ResultGenerator]
    public int FindComplement(int num)
    {
        return ~num & ((1 << (int)(Math.Log2(num) + 1)) - 1);
    }
}