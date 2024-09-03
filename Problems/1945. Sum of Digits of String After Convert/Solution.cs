using LeetCodeDaily.Core;

public class Solution
{
    [ResultGenerator]
    private int GetLucky(string s, int k)
    {
        // offset: -96 (ASCII 'a': dec '97')
        var digitSum = s.Sum(c => ((c - 96) / 10) + ((c - 96) % 10));

        while (--k > 0 && digitSum > 9)
        {
            digitSum = DigitSum(digitSum);
        }

        return digitSum;
    }

    private int DigitSum(int i)
    {
        var sum = 0;
        while (i > 0)
        {
            sum += i % 10;
            i /= 10;
        }
        return sum;
    }
}