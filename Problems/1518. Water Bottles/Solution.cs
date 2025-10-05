using LeetCodeDaily.Core;

namespace _1518.Water_Bottles;

public class Solution
{
    [ResultGenerator]
    public int NumWaterBottles(int numBottles, int numExchange)
    {
        int result = numBottles;
        int carry = 0;
        do
        {
            carry = numBottles % numExchange;
            numBottles = numBottles / numExchange;
            result += numBottles;
            numBottles += carry;
        }
        while (numBottles >= numExchange);

        return result;
    }
}