using LeetCodeDaily.Core;

namespace _2778._Sum_of_Squares_of_Special_Elements;

public class Solution
{
    [ResultGenerator]
    public int SumOfSquares(int[] nums)
    {
        return
            nums
                .Where((x, i) => nums.Length % (i + 1) == 0)
                .Select(x => x * x)
                .Sum();
    }
}