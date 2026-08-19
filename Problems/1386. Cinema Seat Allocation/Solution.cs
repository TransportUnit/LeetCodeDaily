using LeetCodeDaily.Core;

namespace _1386.Cinema_Seat_Allocation;

public class Solution
{
    [ResultGenerator]
    public int MaxNumberOfFamilies(int n, int[][] reservedSeats)
    {
        Dictionary<int, byte> rows = new();

        foreach (var reservedSeat in reservedSeats)
        {
            var row = reservedSeat[0];
            var seat = reservedSeat[1];

            if (seat == 1 || seat == 10)
            {
                continue;
            }

            if (rows.ContainsKey(row) == false)
            {
                rows.Add(row, 0);
            }

            rows[row] |= (byte)(1 << (seat - 2));
        }

        int totalGroups = 2 * n;

        const byte mask1 = 15; // seats 2, 3, 4, 5
        const byte mask2 = 60; // seats 4, 5, 6 ,7
        const byte mask3 = 240; // seats 6, 7, 8, 9

        foreach (var row in rows)
        {
            var groups = 0;

            var maskedVal = row.Value;

            if ((maskedVal & mask1) == 0)
            {
                groups++;

                if ((maskedVal & mask3) == 0)
                {
                    groups++;
                }
            }
            else if ((maskedVal & mask3) == 0 || (maskedVal & mask2) == 0)
            {
                groups++;
            }

            totalGroups -= (2 - groups);
        }

        return totalGroups;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public int MaxNumberOfFamiliesFaster(int n, int[][] reservedSeats)
    {
        Dictionary<int, int> rows = new Dictionary<int, int>();

        foreach (int[] seat in reservedSeats)
        {
            int row = seat[0];
            int s = seat[1];

            // Only seats 2-9 affect the three possible blocks.
            if (s >= 2 && s <= 9)
            {
                if (!rows.ContainsKey(row))
                    rows[row] = 0;

                rows[row] |= 1 << s;
            }
        }

        long result = (long)(n - rows.Count) * 2;

        foreach (int mask in rows.Values)
        {
            bool left = (mask & ((1 << 2) | (1 << 3) | (1 << 4) | (1 << 5))) == 0;
            bool middle = (mask & ((1 << 4) | (1 << 5) | (1 << 6) | (1 << 7))) == 0;
            bool right = (mask & ((1 << 6) | (1 << 7) | (1 << 8) | (1 << 9))) == 0;

            if (left && right)
                result += 2;
            else if (left || middle || right)
                result += 1;
        }

        return (int)result;
    }
}