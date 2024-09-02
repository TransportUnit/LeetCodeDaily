using LeetCodeDaily.Core;

namespace _1894._Find_the_Student_that_Will_Replace_the_Chalk;

public class Solution
{
    [ResultGenerator]
    public int ChalkReplacer(int[] chalk, int k)
    {
        long sumChalkConsumption = 0;
        long k_ = k;

        for (int i = 0; i < chalk.Length; i++)
        {
            sumChalkConsumption += chalk[i];

            if (sumChalkConsumption > k_)
            {
                return i;
            }
        }

        k_ = k_ % sumChalkConsumption;

        for (int i = 0; i < chalk.Length; i++)
        {
            if (k_ < chalk[i])
                return i;

            k_ -= chalk[i];
        }

        return -1;
    }
}