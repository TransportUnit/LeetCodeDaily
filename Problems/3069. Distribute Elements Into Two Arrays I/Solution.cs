using LeetCodeDaily.Core;

namespace _3069.Distribute_Elements_Into_Two_Arrays_I;

public class Solution
{
    [ResultGenerator]
    public int[] ResultArray(int[] nums)
    {
        List<int> arr1 = new() { nums[0] };
        List<int> arr2 = new() { nums[1] };

        int lastAdded1 = nums[0];
        int lastAdded2 = nums[1];

        for (int i = 2; i < nums.Length; i++)
        {
            if (lastAdded1 > lastAdded2)
            {
                arr1.Add(nums[i]);
                lastAdded1 = nums[i];
            }
            else
            {
                arr2.Add(nums[i]);
                lastAdded2 = nums[i];
            }
        }

        return arr1.Concat(arr2).ToArray();
    }
}