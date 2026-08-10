using LeetCodeDaily.Core;

namespace _3014.Minimum_Number_of_Pushes_to_Type_Word_I;

public class Solution
{
    [ResultGenerator]
    public int MinimumPushes(string word)
    {
        int n = word.Length;

        int num = 0;
        int fac = 1;

        while (n > 0)
        {
            num += Math.Min(n, 8) * fac++;
            n -= 8;
        }
        return num;
    }
}