using LeetCodeDaily.Core;

namespace _2432.The_Employee_That_Worked_on_the_Longest_Task;

public class Solution
{
    [ResultGenerator]
    public int HardestWorker(int n, int[][] logs)
    {
        int time = 0;
        int longestInterval = int.MinValue;
        int id = int.MaxValue;

        for (int i = 0; i < logs.Length; i++)
        {
            int interval = logs[i][1] - time;

            if (interval > longestInterval)
            {
                longestInterval = interval;
                id = logs[i][0];
            }
            else if (interval == longestInterval)
            {
                id = Math.Min(id, logs[i][0]);
            }

            time = logs[i][1];
        }

        return id;
    }
}