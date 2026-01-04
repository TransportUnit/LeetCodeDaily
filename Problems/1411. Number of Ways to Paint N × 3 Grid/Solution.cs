using LeetCodeDaily.Core;

namespace _1411.Number_of_Ways_to_Paint_N___3_Grid;

public class Solution
{
    [ResultGenerator]
    public int NumOfWays(int n)
    {
        long z = 6;
        long d = 6;
        while (n-- > 1)
        {
            long zn = (3 * z + 2 * d) % 1_000_000_007;
            long dn = (2 * z + 2 * d) % 1_000_000_007;

            z = zn;
            d = dn;
        }

        return (int)((z + d) % 1_000_000_007);
    }
}