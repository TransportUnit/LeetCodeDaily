using LeetCodeDaily.Core;

namespace _1310.XOR_Queries_of_a_Subarray;

public class Solution
{
    [ResultGenerator]
    public int[] XorQueries(int[] arr, int[][] queries)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            arr[i] ^= arr[i - 1];
        }

        var result = new int[queries.Length];

        for (int i = 0; i < queries.Length; i++)
        {
            result[i] = queries[i][0] == 0 ? arr[queries[i][1]] : arr[queries[i][0] - 1] ^ arr[queries[i][1]];
        }

        return result;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public int[] XorQueriesSlower(int[] arr, int[][] queries)
    {
        var prefix = new int[arr.Length];
        prefix[0] = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            prefix[i] = prefix[i - 1] ^ arr[i];
        }

        var result = new int[queries.Length];

        for (int i = 0; i < queries.Length; i++)
        {
            result[i] = prefix[queries[i][0]] ^ prefix[queries[i][1]] ^ arr[queries[i][0]];
        }

        return result;
    }
}