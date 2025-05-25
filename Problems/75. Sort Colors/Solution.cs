using LeetCodeDaily.Core;
using System.Runtime.CompilerServices;

namespace _75._Sort_Colors;

public class Solution
{
    [ResultGenerator(ApproachIndex = 0)]
    public int[] SortColorsDutchFlagBranchless(int[] nums)
    {
        // Slowest out of the three (technically O(n))
        BranchlessDutchFlag(nums);
        return nums;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public int[] SortColorsDutchFlag(int[] nums)
    {
        // Faster (technically O(n))
        DutchFlag(nums);
        return nums;
    }

    [ResultGenerator(ApproachIndex = 2)]
    public int[] SortColorsCountingSort(int[] nums)
    {
        // Fastest, even though it is technically O(2*n)
        CountingSort(nums);
        return nums;
    }

    private void BranchlessDutchFlag(int[] nums)
    {
        int l = 0; // left partition pointer (0)
        int m = 0; // mid partition pointer (1)
        int r = nums.Length - 1; // right partition pointer

        // dutch flag algorithm
        while (m <= r)
        {
            int x = nums[m];

            int isTwo = x / 2;
            int isZero = 1 - ((x | -x) >>> 31);

            // swaps index m with:
            //     r if nums[m] is 2
            //     l if nums[m] is 0
            //     m (itself) if nums[m] is 1
            int swapWith = r * isTwo + l * isZero + m * (x & 1);

            nums[m] = nums[swapWith];
            nums[swapWith] = x;

            m += (~x & 2) >> 1; // increment m if nums[m] is either 0 or 1
            r -= isTwo; // decrement r is nums[m] is 2
            l += isZero; // increment l if nums[m] is 0
        }
    }

    private void DutchFlag(int[] nums)
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static void Swap(int[] arr, int i1, int i2)
        {
            var tmp = arr[i1];
            arr[i1] = arr[i2];
            arr[i2] = tmp;
        }

        int l = 0;
        int m = 0;
        int r = nums.Length - 1;

        while (m <= r)
        {
            switch (nums[m])
            {
                case 2:
                    Swap(nums, m, r);
                    r--;
                    break;
                case 1:
                    m++;
                    break;
                case 0:
                    Swap(nums, m, l);
                    l++;
                    m++;
                    break;
            }
        }
    }

    private void CountingSort(int[] nums)
    {
        var l = 0;

        int[] freq = new int[3];

        while (l < nums.Length)
        {
            freq[nums[l++]]++;
        }
        l = 0;
        while (freq[0]-- > 0)
        {
            nums[l++] = 0;
        }
        while (freq[1]-- > 0)
        {
            nums[l++] = 1;
        }
        while (freq[2]-- > 0)
        {
            nums[l++] = 2;
        }
    }
}