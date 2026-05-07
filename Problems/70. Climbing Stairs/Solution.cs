using LeetCodeDaily.Core;

namespace _70.Climbing_Stairs;

public class Solution
{
    [ResultGenerator]
    public int ClimbStairs(int n)
    {
        if (n <= 1)
            return 1;

        Span<int> arr = stackalloc int[n];
        arr[0] = 1;
        arr[1] = 2;
        for (int i = 2; i < n; i++)
        {
            arr[i] = arr[i - 1] + arr[i - 2];
        }
        return arr[^1];
    }
}