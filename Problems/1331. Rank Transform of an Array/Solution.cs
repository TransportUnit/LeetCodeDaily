using LeetCodeDaily.Core;

namespace _1331.Rank_Transform_of_an_Array;

public class Solution
{
    [ResultGenerator]
    public int[] ArrayRankTransform(int[] arr)
    {
        int[] copy = new int[arr.Length];
        Array.Copy(arr, copy, arr.Length);
        Array.Sort(copy);
        Dictionary<int, int> dic = new();

        int j = 1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (dic.ContainsKey(copy[i]))
                continue;

            dic[copy[i]] = j++;
        }

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = dic[arr[i]];
        }

        return arr;
    }
}
