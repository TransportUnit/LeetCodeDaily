using LeetCodeDaily.Core;

namespace _769.Max_Chunks_To_Make_Sorted;

public class Solution
{
    [ResultGenerator]
    public int MaxChunksToSorted(int[] arr)
    {
        int n = arr.Length;

        int chunks = 0;

        int max = 0;

        unsafe
        {
            fixed (int* ptr = &arr[0])
            {
                int i = -1;
                int* it = ptr;

                while(++i < n)
                {
                    max = max - ((max - *it) & (max - *it++) >> 31);
                    chunks += max == i ? 1 : 0;
                }
            }
        }

        return chunks;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public int MaxChunksToSortedNoPointers(int[] arr)
    {
        int n = arr.Length;

        int chunks = 0;

        int max = 0;

        for (int i = 0; i < n; i++)
        {
            max = Math.Max(max, arr[i]);

            if (max == i)
            {
                chunks++;
            }
        }

        return chunks;
    }
}