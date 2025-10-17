using LeetCodeDaily.Core;

namespace _2598.Smallest_Missing_Non_negative_Integer_After_Operations;

public class Solution
{
    [ResultGenerator]
    public int FindSmallestInteger(int[] nums, int value)
    {
        Span<int> mp = stackalloc int[value];

        int n = nums.Length;

        unsafe
        {
            fixed (int* pt = nums)
            {
                int* it = pt;

                while (n-- > 0)
                {
                    // turning negative values into positive mods
                    mp[((*(it++) % value) + value) % value]++;
                }
            }

            int minValue = nums.Length;

            for (int i = 0; i < value; i++)
            {
                int curr = mp[i] * value + i;
                if (curr < minValue)
                    minValue = curr;
            }

            return minValue;
        }
    }

    [ResultGenerator(ApproachIndex = 1)]
    public int FindSmallestIntegerSlow(int[] nums, int value)
    {
        var freqDic = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            var val = num % value;
            if (val < 0)
            {
                val += value;
            }

            if (!freqDic.ContainsKey(val))
            {
                freqDic.Add(val, 1);
            }
            else
            {
                freqDic[val]++;
            }
        }

        int mex = 0;

        while (freqDic.ContainsKey(mex % value) && freqDic[mex % value] > 0)
        {
            freqDic[mex % value]--;
            mex++;
        }

        return mex;

        int n = nums.Length;

        for (int i = 0; i <= n; i++)
        {
            bool found = false;

            for (int j = 0; j <= (n / value) + 1; j++)
            {
                var val = (i % value) + j * value;

                if (freqDic.ContainsKey(val) && freqDic[val] > 0)
                {
                    freqDic[val]--;
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                return i;
            }
        }

        return n;
    }
}