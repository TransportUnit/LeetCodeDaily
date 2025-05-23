using LeetCodeDaily.Core;
using System.Runtime.InteropServices;

namespace _1980._Find_Unique_Binary_String;

public class Solution
{
    [ResultGenerator]
    public string FindDifferentBinaryString(string[] nums)
    {
        int n = nums.Length;
        Span<char> result = stackalloc char[n + 1];

        var numsSpan = nums.AsSpan();

        unsafe
        {
            fixed (char* first = &result[0])
            {
                char* iterator = first;

                *(iterator + n) = '\0';

                while (n-- > 0)
                {
                    *(iterator + n) = (char)(97 - numsSpan[n][n]);
                }

                return Marshal.PtrToStringUni((IntPtr)first);
            }
        }
    }
}