using LeetCodeDaily.Core;

namespace _217._Contains_Duplicate;

public class Solution
{
    // O(n) time, O(n) space
    [ResultGenerator]
    public bool ContainsDuplicate(int[] nums)
    {
        var hash = new HashSet<int>();
        hash.Add(nums[0]);

        for (int i = 1; i < nums.Length; i++)
        {
            if (!hash.Add(nums[i]))
                return true;
        }

        return false;
    }

    /*
	// O(n*log(n) + n) time, O(1) space
    public bool ContainsDuplicate(int[] nums) 
    {
        Array.Sort(nums);

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1])
            {
                return true;
            }
        }

        return false;
    }
    */
}