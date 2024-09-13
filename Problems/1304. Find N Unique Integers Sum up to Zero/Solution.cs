using LeetCodeDaily.Core;

namespace _1304.Find_N_Unique_Integers_Sum_up_to_Zero;

public class Solution
{
    [ResultGenerator]
    public int[] SumZero(int n) 
    {
        var result = new int[n];

        for (int i = 0; i < n / 2; i++)
        {
            result[i * 2] = i + 1;
            result[i * 2 + 1] = -(i + 1);
        }

        if (n % 2 != 0)
        {
            result[^1] = 0;
        }

        return result;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public int[] SumZeroLinq(int n)
    {
        var arr = Enumerable.Range(-n / 2, n).ToArray();
        if (n % 2 == 0)
        {
            arr[n / 2] = n / 2;
        }
        return arr;
    }
}