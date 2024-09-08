using LeetCodeDaily.Core;

namespace _2744._Find_Maximum_Number_of_String_Pairs;

public class Solution
{
    [ResultGenerator]
    public int MaximumNumberOfStringPairs(string[] words)
    {
        if (words.Length <= 1)
            return 0;

        int pairs = 0;

        Span<string> arr = words;

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i][0] != arr[j][1] ||
                    arr[i][1] != arr[j][0])
                    continue;

                pairs++;
                break;
            }
        }

        return pairs;
    }
}