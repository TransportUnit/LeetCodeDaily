using LeetCodeDaily.Core;

namespace _744.Find_Smallest_Letter_Greater_Than_Target;

public class Solution
{
    [ResultGenerator]
    public char NextGreatestLetter(char[] letters, char target)
    {
        // 'letters' is sorted in a non-decreasing order
        // if the last element is smaller than or equal to target, there is no result
        // same for letter 'z'
        // -> return first element
        if (target >= 'z' || target >= letters[^1])
            return letters[0];

        int left = 0;
        int right = letters.Length - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (letters[mid] > target)
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return letters[left];
    }
}