using LeetCodeDaily.Core;

namespace _3375.Minimum_Operations_to_Make_Array_Values_Equal_to_K;

public class Solution
{
    [ResultGenerator]
    public int MinOperations(int[] nums, int k)
    {
        // approach: count distinct values that are greater than k
        // if any number is less than k, it is impossible for all values to reach k

        int operations = 0;
        // this is where we store if a value has already occurred
        Span<bool> occ = stackalloc bool[101];
        Span<int> numsSpan = nums.AsSpan();

        unsafe
        {
            fixed (bool* op = occ)
            fixed (int* np = numsSpan)
            {
                bool* o = op;

                // presetting the k-th element so we don't count that as an operation
                *(o + k) = true;

                int* n = np;

                int i = numsSpan.Length;

                while (--i >= 0)
                {
                    // if any number is less than k, it is impossible for all values to reach k 
                    if (*n < k)
                    {
                        return -1;
                    }

                    // we only increment our operations counter for values that have not occurred yet
                    operations += 1 - Convert.ToInt32((*(o + *(n))));
                    *(o + *(n++)) = true;
                }
            }
        }
        return operations;
    }
}