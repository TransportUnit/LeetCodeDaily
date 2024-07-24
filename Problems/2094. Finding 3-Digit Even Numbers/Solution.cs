using LeetCodeDaily.Core;

namespace _2094._Finding_3_Digit_Even_Numbers;

public class Solution
{
    [ResultGenerator]
    public int[] FindEvenNumbers(int[] digits)
    {
        int[] freq = new int[10];
        foreach (var digit in digits)
        {
            freq[digit]++;
        }

        var result = new List<int>();
        int i, j, k;

        for (i = 1; i < 10; i++)
        {
            if (freq[i] == 0)
            {
                continue;
            }

            freq[i]--;

            for (j = 0; j < 10; j++)
            {
                if (freq[j] == 0)
                {
                    continue;
                }

                freq[j]--;

                for (k = 0; k < 10; k += 2)
                {
                    if (freq[k] == 0)
                        continue;

                    result.Add(i * 100 + j * 10 + k);
                }

                freq[j]++;
            }

            freq[i]++;
        }

        return result.ToArray();
    }
}