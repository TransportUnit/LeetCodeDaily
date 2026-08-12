using LeetCodeDaily.Core;

namespace _2958.Length_of_Longest_Subarray_With_at_Most_K_Frequency;

public class Solution
{
    [ResultGenerator]
    public int MaxSubarrayLength(int[] nums, int k)
    {
        int n = nums.Length;

        int max = 0;
        int l = 0;

        Dictionary<int, int> dic = new();

        for (int i = 0; i < n; i++)
        {
            var num = nums[i];

            if (dic.ContainsKey(num))
            {
                dic[num]++;

                if (dic[num] > k)
                {
                    do
                    {
                        dic[nums[l]]--;
                        l++;
                    }
                    while (nums[l - 1] != num);
                }
            }
            else
            {
                dic[num] = 1;
            }

            max = Math.Max(max, i - l + 1);
        }

        return max;
    }
}