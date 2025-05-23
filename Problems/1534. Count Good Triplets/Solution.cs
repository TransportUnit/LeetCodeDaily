using LeetCodeDaily.Core;

namespace _1534._Count_Good_Triplets;

public class Solution
{
    [ResultGenerator]
    public int CountGoodTriplets(int[] arr, int a, int b, int c)
    {
        int count = 0;

        for (int i = 0; i < arr.Length - 2; i++)
        {
            for (int j = i + 1; j < arr.Length - 1; j++)
            {
                if (Math.Abs(arr[i] - arr[j]) > a)
                    continue;

                for (int k = j + 1; k < arr.Length; k++)
                {
                    if (Math.Abs(arr[j] - arr[k]) > b ||
                        Math.Abs(arr[i] - arr[k]) > c)
                        continue;

                    count++;
                }
            }
        }

        return count;
    }
}