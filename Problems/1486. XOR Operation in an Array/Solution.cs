using LeetCodeDaily.Core;

public class Solution
{
    [ResultGenerator]
    public int XorOperation(int n, int start)
    {
        // if the 2nd bit is set, we start with a 0
        // if it is not set, we start with the 'start' value
        var xor = start * ((start & 2) / 2);
        // the result periodically reaches either 'start' (when the 2nd bit is set)
        // or 0 (when the 2nd bit is not set)
        // those values appear after 4 n each, but with a different offset
        // we search for the nearest 'entry point' (where the periodic value appears)
        // and start XOR-ing from that point
        int i = (n - ((n - (start & 2) / 2) % 4));

        for (; i < n; i++)
        {
            xor ^= start + 2 * i;
        }

        return xor;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public int XorOperationNaive(int n, int start)
    {
        int xor = start;

        for (int i = 1; i < n; i++)
        {
            xor ^= start + 2 * i;
        }

        return xor;
    }
}