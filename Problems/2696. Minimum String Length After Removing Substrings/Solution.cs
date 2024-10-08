using LeetCodeDaily.Core;

namespace _2696.Minimum_String_Length_After_Removing_Substrings;

public class Solution
{
    [ResultGenerator]
    public int MinLength(string s)
    {
        Stack<char> stack = new();

        foreach (var c in s)
        {
            if (stack.Count == 0)
            {
                stack.Push(c);
                continue;
            }

            if (c == 'B' && stack.Peek() == 'A' ||
                c == 'D' && stack.Peek() == 'C')
            {
                stack.Pop();
            }
            else
            {
                stack.Push(c);
            }
        }

        return stack.Count;
    }
}