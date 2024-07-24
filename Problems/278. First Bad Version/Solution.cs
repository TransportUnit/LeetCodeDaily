using LeetCodeDaily.Core;

namespace _278._First_Bad_Version;

public class Solution : VersionControl
{
    [ResultGenerator]
    public int FirstBadVersion(int n)
    {
        // basically binary search

        int left = 1;
        int right = n;
        int mid = 0;

        while (left <= right)
        {
            // ducking overflow >:(
            mid = left + (right - left) / 2;

            if (base.IsBadVersion(mid))
            {
                right = mid - 1;
                /*
                if (mid == 1 || !base.IsBadVersion(mid - 1))
                {
                    return mid;
                }
                else
                {
                    right = mid - 1;
                }
				*/
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }
}