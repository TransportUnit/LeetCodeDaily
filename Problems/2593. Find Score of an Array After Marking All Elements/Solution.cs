using LeetCodeDaily.Core;

namespace _2593.Find_Score_of_an_Array_After_Marking_All_Elements;

public class Solution
{
    [ResultGenerator]
    public long FindScore(int[] nums)
    {
        // idea:
        // create an enumerator with linq that returns the elements within nums
        // the primary order is the value itself, the secondary order is the index within the array
        // (so when there are multiple entries with the same value, they appear in the same order as in the array)
        // then, go through each entry in the ordered enumerator and check if the index has already been marked.
        // if it has already been marked, we move to the next entry
        // if not, we add the value to our total score and mark it (by setting it to 0) 
        // we also try to mark the adjacent indices
        // meanwhile, we keep track of the amount of indices we marked
        // if the amount of marked indices matches the total array length, we break the loop
        // and return with the total score

        int n = nums.Length;

        var ordered =
            nums
                .Select((x, i) => (x, i))
                .OrderBy(x => x.Item1)
                .ThenBy(x => x.Item2);

        long score = 0;
        int index = 0;
        int marked = 0;

        foreach (var item in ordered)
        {
            if (marked >= n)
                break;

            index = item.Item2;

            if (nums[index] <= 0)
                continue;

            score += nums[index];
            nums[index] = 0;
            marked++;

            if (index > 0 && nums[index - 1] > 0)
            {
                nums[index - 1] = 0;
                marked++;
            }

            if (index + 1 < n && nums[index + 1] > 0)
            {
                nums[index + 1] = 0;
                marked++;
            }
        }

        return score;
    }
}