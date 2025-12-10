using LeetCodeDaily.Core;

namespace _3577.Count_the_Number_of_Computer_Unlocking_Permutations;

public class Solution
{
    [ResultGenerator]
    public int CountPermutations(int[] complexity)
    {
        // wtf?

        if (complexity.Skip(1).Any(x => x <= complexity[0]))
            return 0;

        var n = complexity.Length - 1;

        long result = 1;

        while (n > 0)
        {
            result = (result * n) % 1_000_000_007;
            n--;
        }

        return (int)result;
    }
}