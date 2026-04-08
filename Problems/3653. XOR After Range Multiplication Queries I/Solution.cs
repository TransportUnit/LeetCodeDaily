using LeetCodeDaily.Core;

namespace _3653.XOR_After_Range_Multiplication_Queries_I;

public class Solution
{
    [ResultGenerator]
    public int XorAfterQueries(int[] nums, int[][] queries)
    {
        int mod = 1_000_000_007;

        foreach (var query in queries)
        {
            int idx = query[0];

            while (idx <= query[1])
            {
                long newVal = ((long)nums[idx] * query[3]) % mod;
                nums[idx] = (int)newVal;
                idx += query[2];
            }
        }

        int xor = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            xor ^= nums[i];
        }

        return xor;
    }
}