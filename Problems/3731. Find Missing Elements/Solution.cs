using LeetCodeDaily.Core;

namespace _3731.Find_Missing_Elements;

public class Solution
{
    [ResultGenerator]
    public IList<int> FindMissingElements(int[] nums)
    {
        Span<bool> occurrence = stackalloc bool[101];
        int min = int.MaxValue;
        int max = int.MinValue;

        foreach (var num in nums)
        {
            occurrence[num] = true;
            min = Math.Min(min, num);
            max = Math.Max(max, num);
        }

        List<int> result = new();

        for (int i = min + 1; i < max; i++)
        {
            if (occurrence[i] == false)
            {
                result.Add(i);
            }
        }

        return result;
    }
}