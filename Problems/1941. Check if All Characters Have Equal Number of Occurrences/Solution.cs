using LeetCodeDaily.Core;

namespace _1941._Check_if_All_Characters_Have_Equal_Number_of_Occurrences;

public class Solution
{
    [ResultGenerator]
    public bool AreOccurrencesEqual(string s)
    {
        var freq = new short[26];

        foreach (var c in s)
        {
            freq[c - 97]++;
        }

        //return freq.Distinct().Where(x => x > 0).Count() == 1;


        int count = -1;

        for (int i = 0; i < freq.Length; i++)
        {
            if (freq[i] == 0)
                continue;

            if (count == -1)
            {
                count = freq[i];
                continue;
            }

            if (freq[i] != count)
                return false;
        }

        return true;
    }
}