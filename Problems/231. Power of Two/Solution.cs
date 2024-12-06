using LeetCodeDaily.Core;

namespace _231.Power_of_Two;

public class Solution
{
    [ResultGenerator]
    public bool IsPowerOfTwo(int n) => n > 0 && ((n & (n - 1)) == 0);
    
}