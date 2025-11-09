using LeetCodeDaily.Core;

namespace _2169.Count_Operations_to_Obtain_Zero;

public class Solution
{
    [ResultGenerator]
    public int CountOperations(int num1, int num2)
    {
        var operations = 0;

        while (num2 != 0 && num1 != 0)
        {
            if (num1 < num2)
            {
                var tmp = num1;
                num1 = num2;
                num2 = tmp;
            }

            operations += num1 / num2;
            num1 = num1 % num2;
        }

        return operations;
    }
}