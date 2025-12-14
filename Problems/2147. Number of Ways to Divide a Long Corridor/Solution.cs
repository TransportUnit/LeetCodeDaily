using LeetCodeDaily.Core;

namespace _2147.Number_of_Ways_to_Divide_a_Long_Corridor;

public class Solution
{
    [ResultGenerator]
    public int NumberOfWays(string corridor)
    {
        long result = 1;

        int seats = 0;
        int plants = 0;
        int seatsTotal = 0;
        int i = 0;

        while (i < corridor.Length)
        {
            if (corridor[i++] == 'S')
            {
                seatsTotal++;

                int seatsTwo = ((seats & 2) >> 1);

                seats = seatsTwo * 1 + (seats + 1) * (1 - seatsTwo);
                result = (1 - seatsTwo) * result + (seatsTwo * (result * (plants + 1)) % 1_000_000_007);
                plants = (1 - seatsTwo) * plants;

                //if (seats == 2)
                //{
                //    seats = 1;
                //    result = (result * (plants + 1)) % 1_000_000_007;
                //    plants = 0;
                //}
                //else
                //{
                //    seats++;
                //}
            }
            else
            {
                plants += ((seats & 2) >> 1);
                //if (seats == 2)
                //{
                //    plants++;
                //}
            }
        }

        if (seatsTotal % 2 != 0 || seatsTotal == 0)
        {
            return 0;
        }

        return (int)result;
    }
}