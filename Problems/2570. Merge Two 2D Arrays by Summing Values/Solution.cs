using LeetCodeDaily.Core;

namespace _2570._Merge_Two_2D_Arrays_by_Summing_Values;

public class Solution
{
    [ResultGenerator]
    public int[][] MergeArrays(int[][] nums1, int[][] nums2)
    {
        int i = 0;
        int j = 0;

        int[][] result = new int[nums1.Length + nums2.Length][];
        int index = 0;

        while (true)
        {
            if (i < nums1.Length)
            {
                if (j < nums2.Length)
                {
                    if (nums1[i][0] < nums2[j][0])
                    {
                        result[index++] = nums1[i++];
                    }
                    else if (nums1[i][0] > nums2[j][0])
                    {
                        result[index++] = nums2[j++];
                    }
                    else
                    {
                        result[index] = nums1[i];
                        result[index++][1] = nums1[i++][1] + nums2[j++][1];
                    }
                }
                else
                {
                    result[index++] = nums1[i++];
                }
            }
            else if (j < nums2.Length)
            {
                result[index++] = nums2[j++];
            }
            else
            {
                break;
            }
        }

        Array.Resize(ref result, index);
        return result;
    }
}