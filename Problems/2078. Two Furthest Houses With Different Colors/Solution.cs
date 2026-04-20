using LeetCodeDaily.Core;

namespace _2078.Two_Furthest_Houses_With_Different_Colors;

public class Solution
{
    [ResultGenerator]
    public int MaxDistance(int[] colors)
    {
        int n = colors.Length;

        if (n <= 2)
        {
            return 1;
        }

        int dist = n - 1;

        int leftmostColor = colors[0];
        int rightmostColor = colors[^1];

        if (leftmostColor != rightmostColor)
        {
            return dist;
        }

        int left = 1;
        int right = n - 2;

        while (left <= right)
        {
            dist--;

            if (colors[left++] != rightmostColor ||
                colors[right--] != leftmostColor)
            {
                return dist;
            }
        }

        return 0;
    }
}