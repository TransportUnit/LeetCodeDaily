using LeetCodeDaily.Core;

namespace _1137.N_th_Tribonacci_Number;

public class Solution
{
    [ResultGenerator]
    public int Tribonacci(int n)
    {
        if (n <= 0)
            return 0;

        if (n <= 2)
            return 1;

        int[] dic = new int[38];
        return TribInt(n, dic);
    }

    private static int TribInt(int n, int[] dic)
    {
        if (n <= 2)
            return 1;

        if (n <= 3)
            return 2;

        if (dic[n] > 0)
        {
            return dic[n];
        }

        dic[n] = TribInt(n - 1, dic) + TribInt(n - 2, dic) + TribInt(n - 3, dic);
        return dic[n];
    }
}