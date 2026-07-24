using LeetCodeDaily.Core;

namespace _3513.Number_of_Unique_XOR_Triplets_I;

public class Solution
{
    [ResultGenerator]
    public int UniqueXorTriplets(int[] nums)
    {
        uint v = (uint)nums.Length; // compute the next highest power of 2 of 32-bit v

        v--;
        v |= v >> 1;
        v |= v >> 2;
        v |= v >> 4;
        v |= v >> 8;
        v |= v >> 16;
        v++;

        if (nums.Length > 2 &&
            v == nums.Length)
        {
            v *= 2;
        }

        return (int)v;
    }
}

/*

1	-> 1
2	-> 2
3	-> 4
4	-> 8
5	-> 8
6	-> 8
7	-> 8
8	-> 16
9	-> 16
10	-> 16
11	-> 16
12	-> 16
13	-> 16
14	-> 16
15	-> 16
16	-> 32
17	-> 32
18	-> 32
19	-> 32
20	-> 32
21	-> 32
22	-> 32
23	-> 32
24	-> 32
25	-> 32
26	-> 32
27	-> 32
28	-> 32
29	-> 32
30	-> 32
31	-> 32
32	-> 64

*/