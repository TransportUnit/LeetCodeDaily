using LeetCodeDaily.Core;
using System.Text;

namespace _3612.Process_String_with_Special_Operations_I;

public class Solution
{
    [ResultGenerator]
    public string ProcessStr(string s)
    {
        StringBuilder sb = new();

        foreach (var l in s)
        {
            switch (l)
            {
                case '*':
                    if (sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                    break;
                case '#':
                    sb.Append(sb);
                    break;
                case '%':
                    if (sb.Length > 1)
                    {
                        sb = new StringBuilder(new string(sb.ToString().Reverse().ToArray()));
                    }
                    break;
                default:
                    sb.Append(l);
                    break;
            }
        }

        return sb.ToString();
    }
}