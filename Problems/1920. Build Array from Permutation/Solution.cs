using LeetCodeDaily.Core;

namespace _1920.Build_Array_from_Permutation;

public class Solution
{
    [ResultGenerator]
    public int[] BuildArray(int[] nums)
    {
        var sp = nums.AsSpan();

        unsafe
        {
            fixed (int* head = &sp[0])
            {
                int* it = head;

                int n = sp.Length;

                while (--n >= 0)
                {
                    *(it + n) += (*(it + *(it + n)) % 1024) * 1024;
                }

                n = sp.Length;

                while (--n >= 0)
                {
                    *(it + n) /= 1024;
                }
            }
        }

        return nums;

        /*
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] += ((nums[nums[i]] % 1000) * 1000);
        }

        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] /= 1000;
        }

        return nums;
        */
    }
}