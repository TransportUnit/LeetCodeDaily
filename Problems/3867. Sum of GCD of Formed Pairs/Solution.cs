using LeetCodeDaily.Core;

namespace _3867.Sum_of_GCD_of_Formed_Pairs;

public class Solution 
{
	[ResultGenerator]
    public long GcdSum(int[] nums) 
    {
        int n = nums.Length;
        Span<int> prefixGcd = stackalloc int[n];
        int max = int.MinValue;

        for (int i = 0; i < n; i++)
        {
            if (nums[i] > max)
            {
                max = nums[i];
                prefixGcd[i] = max;
            }
            else
            {
                prefixGcd[i] = GCD(max, nums[i]);
            }
        }

        MemoryExtensions.Sort(prefixGcd);

        int l = 0;
        int r = n - 1;
        long sum = 0;

        while(l < r)
        {
            sum += GCD(prefixGcd[r--], prefixGcd[l++]);
        }

        return sum;
    }

    // euclid's algo
    private static int GCD(int a, int b)
    {
        // if b > a, both will automatically swap places
        // within one iteration since:
        // a % b = a for a < b
        while (b != 0)
        {
            (a, b) = (b, a % b);
        }
        return a;
    }
}