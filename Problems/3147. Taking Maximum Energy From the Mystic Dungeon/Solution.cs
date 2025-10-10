using LeetCodeDaily.Core;

namespace _3147.Taking_Maximum_Energy_From_the_Mystic_Dungeon;

public class Solution
{
    [ResultGenerator]
    public int MaximumEnergy(int[] energy, int k) 
    {
        int[] sums = new int[k];
        int max = int.MinValue; // this cost me a submission
        int j = 0;
        for (int i = energy.Length - 1; i >= 0; i--)
        {
            sums[j] += energy[i];
            max = Math.Max(max, sums[j]);
            j = (j + 1) % k;
        }

        return max;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public int MaximumEnergyUnsafe(int[] energy, int k)
    {
        Span<int> sums = stackalloc int[k];
        int max = int.MinValue; // this cost me a submission
        int j = 0;

        unsafe
        {
            fixed (int* end = &energy[^1])
            {
                int* it = end;
                int n = energy.Length;

                while (n-- >= 0)
                {
                    sums[j] += *(it--);
                    max = Math.Max(max, sums[j]);
                    j = (j + 1) % k;
                }
            }
        }

        return max;
    }
}