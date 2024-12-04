using LeetCodeDaily.Core;

namespace _2825.Make_String_a_Subsequence_Using_Cyclic_Increments;

public class Solution
{
    [ResultGenerator]
    public bool CanMakeSubsequence(string str1, string str2)
    {
        // we can only modify str1
        // str2 might be longer than str1 -> cannot be a subsquence
        // we can only increment the letters in str1, and if we increment 'z', it becomes 'a' again (-> modulo operation)
        // we can increment each letter in str1 at most once
        // we only have to handle lowercase english letters, so ascii values range from 97 dec ('a') to 122 dec ('z')
        // the strings can become quite large (10_000 characters)
        // maybe we can use Span<char> to slightly increase performance?

        // two pointer approach:
        //
        // iterate through str1 and str2 with indexes [i] and [j]
        //     for each element, check the distance between str1[i] and str2[j]
        //     if the distance is too big (> 1 operation needed), we move to the next index [i] in str1
        //     if letter at index [j] in str2 can be created through at most one operation, we increment both indexes
        //     if index [j] reaches the end of str2, we return true
        //     otherwise, we return false

        if (str2.Length > str1.Length)
            return false;

        int i = 0;
        int j = 0;

        var str1Span = str1.AsSpan();
        var str2Span = str2.AsSpan();

        while (j < str2Span.Length && i < str1Span.Length)
        {
            if (!CanBeReachedByIteration(str1Span[i++], str2Span[j]))
            {
                continue;
            }
            j++;
        }

        return j >= str2Span.Length;
    }

    private static bool CanBeReachedByIteration(char source, char target)
    {
        // either both chars already match or we can increment source by one (with modulo) to create target
        return source == target || ((source - 96) % 26) == target - 97;
    }
}