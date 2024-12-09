using LeetCodeDaily.Core;

namespace _3152.Special_Array_II;

public class Solution
{
    [ResultGenerator]
    public bool[] IsArraySpecial(int[] nums, int[][] queries)
    {
        // idea:
        // go through nums and mark every special subarray by replacing all the values
        // within that area with a unique number (1 for the first area, 2 for the 2nd area and so on)
        // then, quen querying, check if the entries at those indices have the same value 
        // (belong to the same contiguous special area)

        var answer = new bool[queries.Length];
        var last = nums[0];
        var group = 0;
        nums[0] = group;

        for (int i = 1; i < nums.Length; i++)
        {
            group += 1 - ((last ^ nums[i]) & 1);
            last = nums[i];
            nums[i] = group;
        }

        for (int i = 0; i < queries.Length; i++)
        {
            answer[i] = nums[queries[i][0]] == nums[queries[i][1]];
        }

        return answer;
    }
}