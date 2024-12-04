using LeetCodeDaily.Core;

namespace _1455.Check_If_a_Word_Occurs_As_a_Prefix_of_Any_Word_in_a_Sentence;

public class Solution
{
    [ResultGenerator]
    public int IsPrefixOfWord(string sentence, string searchWord)
    {
        var sentenceSpan = sentence.AsSpan();
        var searchWordSpan = searchWord.AsSpan();

        int word = 1;
        int startOfWord = 0;
        int j = 0;

        for (int i = 0; i < sentenceSpan.Length; i++)
        {
            j = i - startOfWord;

            if (j + 1 >= searchWordSpan.Length &&
                sentenceSpan[i] == searchWordSpan[j])
            {
                return word;
            }

            if (sentenceSpan[i] != searchWordSpan[j])
            {
                while (i < sentenceSpan.Length && sentenceSpan[i] != ' ')
                {
                    i++;
                }
                startOfWord = i + 1;
                word++;
            }
        }

        return -1;
    }
}