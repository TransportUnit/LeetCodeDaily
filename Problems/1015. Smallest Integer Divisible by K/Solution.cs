using LeetCodeDaily.Core;

namespace _1015.Smallest_Integer_Divisible_by_K;

public class Solution
{
    [ResultGenerator]
    public int SmallestRepunitDivByK(int k)
    {
        if ((k & 1) == 0 || k % 5 == 0)
            return -1;

        int length = 1;
        int mod = 1;

        // No need to check last remainders for recurrence
        //var lastMods = new HashSet<int>();

        while (true)
        {
            mod = mod % k;

            if (mod == 0)
            {
                return length;
            }

            /*
            if (lastMods.Contains(mod))
            {
                return -1;
            }
            */

            //lastMods.Add(mod);
            mod = mod * 10 + 1;
            length++;
        }
    }
}