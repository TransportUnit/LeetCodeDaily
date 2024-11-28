using LeetCodeDaily.Core;

namespace _2283.Check_if_Number_Has_Equal_Digit_Count_and_Digit_Value;

public class Solution
{
    [ResultGenerator]
    public bool DigitCount(string num)
    {
        Span<byte> freq = stackalloc byte[10];
        var numSpan = num.AsSpan();

        for (int i = 0; i < numSpan.Length; i++)
        {
            freq[numSpan[i] - '0']++;
        }

        for (int i = 0; i < numSpan.Length; i++)
        {
            if ((numSpan[i] - '0') != freq[i])
                return false;
        }

        return true;
    }
}