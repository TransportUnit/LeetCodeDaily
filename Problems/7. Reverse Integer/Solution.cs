using LeetCodeDaily.Core;

namespace _7._Reverse_Integer;

public class Solution
{
    [ResultGenerator]
    public int Reverse(int x)
    {
        int result = 0;

        const int max = int.MaxValue / 10;
        const int min = int.MinValue / 10;

        while (x != 0)
        {
            if (result > max || result < min)
            {
                return 0;
            }

            result = result * 10 + x % 10;
            x /= 10;
        }

        return result;
    }
}