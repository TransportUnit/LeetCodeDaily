using LeetCodeDaily.Core;

namespace _1018.Binary_Prefix_Divisible_By_5;

public class Solution
{
    [ResultGenerator]
    public IList<bool> PrefixesDivBy5(int[] nums)
    {
        int mod = 0;
        bool[] result = new bool[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            mod = ((mod << 1) + nums[i]) % 5;
            result[i] = mod == 0;
        }

        // bool[] implements IList<bool> (??), no cast necessary
        return result;
    }
}