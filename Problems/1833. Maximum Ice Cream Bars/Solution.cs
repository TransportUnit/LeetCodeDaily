using LeetCodeDaily.Core;

namespace _1833.Maximum_Ice_Cream_Bars;

public class Solution
{
    [ResultGenerator]
    public int MaxIceCream(int[] costs, int coins)
    {
        Span<int> freq = stackalloc int[100_000 + 1];

        foreach (var c in costs)
        {
            freq[c]++;
        }

        int result = 0;

        for (int i = 0; i < 100_000 + 1; i++)
        {
            if (coins > freq[i] * i)
            {
                result += freq[i];
                coins -= freq[i] * i;
            }
            else
            {
                result += coins / i;
                return result;
            }
        }

        return result;
    }
}
