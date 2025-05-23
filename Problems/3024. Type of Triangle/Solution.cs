using LeetCodeDaily.Core;

namespace _3024._Type_of_Triangle;

public class Solution
{
    [ResultGenerator]
    public string TriangleType(int[] nums)
    {
        var a = nums[0];
        var b = nums[1];
        var c = nums[2];

        var halfCirc = (a + b + c) / 2.0;

        // valid triangle check - no side can be larger than the sum of the other two
        if (a >= halfCirc || b >= halfCirc || c >= halfCirc)
        {
            return "none";
        }

        // each of those three will be either 0 (if those two sides are equal)
        // or != 0 (if the sides aren't equal)
        int t = a ^ b;
        int z = b ^ c;
        int u = a ^ c;

        // this expression counts the amount of none zero values from the previous step
        var x = ((t | -t) >>> 31) + ((z | -z) >>> 31) + ((u | -u) >>> 31);

        return x == 3 ? "scalene" :
               x == 2 ? "isosceles" :
               x == 0 ? "equilateral" : "none";
    }
}