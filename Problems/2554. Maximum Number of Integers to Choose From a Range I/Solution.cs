using LeetCodeDaily.Core;

namespace _2554.Maximum_Number_of_Integers_to_Choose_From_a_Range_I;

public class Solution
{
    [ResultGenerator]
    public int MaxCount(int[] banned, int n, int maxSum)
    {
        // without considering the banned items:
        // what is the maximum 'n' we can reach with 'maxSum' as limitation?
        // 1 + 2 + ... + maxNFromLimit <= maxSum
        var maxNFromLimit = ReverseTriangularNumber(maxSum);

        // we set our current maximum 'n' to the lowest value between 'n' and 'maxNFromLimit'
        var currentN = Math.Min(n, maxNFromLimit);

        // without having considered the banned items, this is the maximum number we can currently reach
        // currentSum = 1 + 2 + ... + currentN
        var currentSum = TriangularNumber(currentN);

        // this is the amount of items from 1 to currentN we can use
        var currentCount = currentN;

        // i don't know if this really improves performance, lol
        var bannedSpan = banned.AsSpan();

        // we use this to keep track of our banned items (because using a HashSet turned out to decrease performance by quite a lot)
        // each value between 1 and 10^4 is represented by a bit at a specific index within the array
        // value '1' will be encoded as the least significant (first) bit within 'bannedSet[0]'
        // value '32' -> most significant (highest) bit at 'bannedSet[0]'
        // value '33' -> first bit at 'bannedSet[1]'
        // and so on ...
        // 313 * 32 bit = 10016 bits to use, which is enough for the given constraints
        // also, by using a span we avoid heap allocations
        Span<int> bannedSet = stackalloc int[313];

        // first, we subtract all banned items below 'currentN' from 'currentSum' 
        // and decrement 'currentCount' for each banned item we subtracted
        foreach (var b in bannedSpan)
        {
            // we encode value 'b' into an index within the array and the bit we want to use
            var index = (b - 1) / 32;
            var bit = (b - 1) % 32;

            // we check if that bit has already been set (i.E. that value has already occurred and should not be subtracted)
            var removed = ((bannedSet[index] & (1 << bit)) >>> bit) ^ 1;

            // we set the bit within the array to mark value 'b' as used
            bannedSet[index] |= 1 << bit;

            // at this point, 'removed' will be 0 if the value already occurred and 1 if this is the first occurrence
            // for this iteration, we only want to subtract values <= 'currentN', so we set removed to 0 if the value is bigger
            removed &= Convert.ToInt32(b <= currentN);

            // we update our currently reached sum and our used items counter
            currentSum -= b * removed;
            currentCount -= removed;
        }

        // now, with all banned items below currentN subtracted, 
        // we try to move towards our initially passed 'n' parameter and we
        // try to add each value (as long as we don't exceed our initially passed 'maxSum')
        while ((++currentN) <= n && (currentSum + currentN) <= maxSum)
        {
            // again, we encode 'currentN' into an index within the array and the bit within that value
            var index = (currentN - 1) / 32;
            var bit = (currentN - 1) % 32;

            // we check if the value we are considering is banned
            // if not, the value is free to use and we set 'isNotBanned' to 1
            var isNotBanned = ((bannedSet[index] & (1 << bit)) >>> bit) ^ 1;

            // we update our currently reached sum and our used items counter
            currentSum += currentN * isNotBanned;
            currentCount += isNotBanned;
        }

        return currentCount;
    }

    // Reverse triangular number -> calculates the max possible 'n' from a given limit
    private static int ReverseTriangularNumber(int limit) => (int)(Math.Sqrt(0.25 + 2 * limit) - 0.5);

    // Triangular number -> calculates 1 + 2 + ... + n
    private static int TriangularNumber(int n) => (n * n + n) / 2;
}