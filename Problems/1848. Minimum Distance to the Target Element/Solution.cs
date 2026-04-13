using LeetCodeDaily.Core;

namespace _1848.Minimum_Distance_to_the_Target_Element;

public class Solution
{
    [ResultGenerator]
    public int GetMinDistance(int[] nums, int target, int start)
    {
        if (nums[start] == target)
            return 0;

        int forward = start + 1;
        int backward = start - 1;
        int i = 1;

        while (true)
        {
            if (backward >= 0 && nums[backward] == target)
            {
                return i;
            }
            backward--;

            if (forward < nums.Length && nums[forward] == target)
            {
                return i;
            }
            forward++;

            i++;
        }

        return 0;
    }
}