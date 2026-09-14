using LeetCodeDaily.Core;

namespace _836.Rectangle_Overlap;

public class Solution
{
    [ResultGenerator]
    public bool IsRectangleOverlap(int[] rec1, int[] rec2)
    {
        var rect1 = new Rect(rec1);
        var rect2 = new Rect(rec2);

        return rect1.HasOverlap(rect2);
    }

    private record struct Rect
    {
        public int[] XRange;
        public int[] YRange;

        public Rect(int[] rec)
        {
            XRange = new int[]
            {
                rec[0],
                rec[2],
            };
            YRange = new int[]
            {
                rec[1],
                rec[3],
            };
        }

        public bool HasOverlap(Rect other)
        {
            return
                XRangeOverlap(other.XRange) &&
                YRangeOverlap(other.YRange);
        }

        public bool XRangeOverlap(int[] other) => XRange[0] < other[1] && other[0] < XRange[1];

        public bool YRangeOverlap(int[] other) => YRange[0] < other[1] && other[0] < YRange[1];

    }
}