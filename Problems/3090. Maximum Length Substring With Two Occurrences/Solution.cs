using LeetCodeDaily.Core;

namespace _3090.Maximum_Length_Substring_With_Two_Occurrences;

public class Solution
{
    [ResultGenerator]
    public int MaximumLengthSubstring(string s)
    {
        int n = s.Length;

        int max = 0;
        int l = 0;

        Dictionary<char, int> dic = new();

        for (int i = 0; i < n; i++)
        {
            var c = s[i];

            if (dic.ContainsKey(c))
            {
                dic[c]++;

                if (dic[c] > 2)
                {
                    do
                    {
                        dic[s[l]]--;
                        l++;
                    }
                    while (s[l - 1] != c);
                }
            }
            else
            {
                dic[c] = 1;
            }

            max = Math.Max(max, i - l + 1);
        }

        return max;
    }
}