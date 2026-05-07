using LeetCodeDaily.Core;

namespace _509.Fibonacci_Number;

public class Solution
{
    [ResultGenerator]
    public int Fib(int n)
    {
        if (n <= 0)
            return 0;

        if (n <= 2)
            return 1;

        int[] dic = new int[31];
        return FibInt(n, dic);
    }

    private static int FibInt(int n, int[] dic)
    {
        if (n <= 2)
            return 1;

        if (dic[n] > 0)
        {
            return dic[n];
        }

        dic[n] = FibInt(n - 1, dic) + FibInt(n - 2, dic);
        return dic[n];
    }
}