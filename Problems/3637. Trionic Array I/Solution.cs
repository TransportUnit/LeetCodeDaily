using LeetCodeDaily.Core;

namespace _3637.Trionic_Array_I;

public class Solution
{
    [ResultGenerator]
    public bool IsTrionic(int[] nums)
    {
        int n = nums.Length;

        if (n < 4)
        {
            return false;
        }

        if (nums[1] <= nums[0] || nums[^1] <= nums[^2])
        {
            return false;
        }

        int p = 1;

        for (; p < n - 1; p++)
        {
            if (nums[p] > nums[p + 1])
            {
                break;
            }

            if (nums[p] == nums[p + 1])
            {
                return false;
            }
        }

        if (p > n - 3)
        {
            return false;
        }

        int q = p + 1;

        for (; q < n - 1; q++)
        {
            if (nums[q] < nums[q + 1])
            {
                break;
            }

            if (nums[q] == nums[q + 1])
            {
                return false;
            }
        }

        if (q > n - 2)
        {
            return false;
        }

        int i = q + 1;

        for (; i < n - 1; i++)
        {
            if (nums[i] >= nums[i + 1])
            {
                return false;
            }
        }

        return true;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public bool IsTrionicBoundaryCheck(int[] nums)
    {
        int n = nums.Length, i = 1;
        while (i < n && nums[i - 1] < nums[i])
        {
            i++;
        }
        int p = i - 1;
        while (i < n && nums[i - 1] > nums[i])
        {
            i++;
        }
        int q = i - 1;
        while (i < n && nums[i - 1] < nums[i])
        {
            i++;
        }
        int flag = i - 1;
        return (p != 0) && (q != p) && (flag == n - 1 && flag != q);
    }

    [ResultGenerator(ApproachIndex = 2)]
    public bool IsTrionicCountTurningPoints(int[] nums)
    {
        int n = nums.Length;
        if (nums[0] >= nums[1])
        {
            return false;
        }
        int count = 1;
        for (int i = 2; i < n; i++)
        {
            if (nums[i - 1] == nums[i])
            {
                return false;
            }
            if ((nums[i - 2] - nums[i - 1]) * (nums[i - 1] - nums[i]) < 0)
            {
                count++;
            }
        }
        return count == 3;
    }
}