using LeetCodeDaily.Core;

namespace _2089.Find_Target_Indices_After_Sorting_Array;

public class Solution
{
    [ResultGenerator]
    public IList<int> TargetIndices(int[] nums, int target)
    {
        int n = nums.Length;
        int start = 0;
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            if (nums[i] < target)
            {
                start++;
            }
            else if (nums[i] == target)
            {
                count++;
            }
        }

        List<int> result = new();
        for (int i = start; i < start + count; i++)
        {
            result.Add(i);
        }

        return result;
    }
}