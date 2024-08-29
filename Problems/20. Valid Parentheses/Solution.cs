using LeetCodeDaily.Core;

public class Solution
{
    [ResultGenerator]
    public bool IsValid(string s)
    {
        if (s.Length < 2)
            return false;

        var stack = new Stack<char>();

        foreach (var ch in s)
        {
            if (ch == '(' || ch == '[' || ch == '{')
            {
                stack.Push(ch);
            }
            else if (stack.Count > 0)
            {
                var top = stack.Pop();
                if (ch != top + 1 &&
                    ch != top + 2)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        return stack.Count == 0;
    }
}