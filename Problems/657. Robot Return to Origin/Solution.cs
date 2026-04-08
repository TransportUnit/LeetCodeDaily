using LeetCodeDaily.Core;

namespace _657.Robot_Return_to_Origin;

public class Solution
{
    [ResultGenerator]
    public bool JudgeCircle(string moves)
    {
        Span<int> freq = stackalloc int[26];

        for (int i = 0; i < moves.Length; i++)
        {
            freq[moves[i] - 'A']++;
        }

        return
            freq['U' - 'A'] == freq['D' - 'A'] &&
            freq['L' - 'A'] == freq['R' - 'A'];
    }
}