using LeetCodeDaily.Core;

namespace _1437.Check_If_All_1_s_Are_at_Least_Length_K_Places_Away;

public class Solution
{
    [ResultGenerator]
    public bool KLengthApart(int[] nums, int k)
    {
        int last = -k - 1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                if (i - last <= k)
                {
                    return false;
                }

                last = i;
            }
        }

        return true;
    }
}