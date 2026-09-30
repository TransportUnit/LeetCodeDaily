using LeetCodeDaily.Core;

namespace _1614.Maximum_Nesting_Depth_of_the_Parentheses;

public class Solution
{
    [ResultGenerator]
    public int MaxDepth(string s)
    {
        int n = s.Length;
        int max = 0;
        int current = 0;

        // ( 40    101000
        // ) 41    101001
        // * 42    101010
        // + 43    101011
        // - 45    101101
        // / 47    101111
        // 0 48    110000
        // 1 49    110001
        // 2 50    110010
        // 3 51    110011
        // 4 52    110100
        // 5 53    110101
        // 6 54    110110
        // 7 55    110111
        // 8 56    111000
        // 9 57    111001

        for (int i = 0; i < n; i++)
        {
            // s[i]/42       -> every other character except '(' and ')' results in '1', and '(' & ')' result in '0'.
            // 1 - (s[i]/42) -> every other character except '(' and ')' results in '0', and '(' & ')' result in '1'.
            // s[i] * 2 - 81 -> -1 for '(' (decimal value: 40), and +1 for ')' (decimal value: 41)
            // we don't care about the rest of the character set since the first expression only returns 1 for parentheses
            // and we multiply both expressions

            current -= (1 - (s[i] / 42)) * (s[i] * 2 - 81);
            max = Math.Max(max, current);
        }

        return max;
    }
}