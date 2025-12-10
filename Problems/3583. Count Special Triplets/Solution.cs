using LeetCodeDaily.Core;

namespace _3583.Count_Special_Triplets;

public class Solution
{
    [ResultGenerator]
    public int SpecialTriplets(int[] nums)
    {
        Span<int> freqRight = stackalloc int[100_001];
        Span<int> freqLeft = stackalloc int[100_001];

        freqLeft[nums[0]] = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            freqRight[nums[i]]++;
        }

        long result = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            var numj = nums[i];
            var numik = numj * 2;
            freqRight[numj]--;

            if (numik > 100000)
            {
                freqLeft[numj]++;
                continue;
            }

            result = (result + ((long)freqLeft[numik] * freqRight[numik])) % 1_000_000_007;

            freqLeft[numj]++;
        }

        return (int)result;
    }
}