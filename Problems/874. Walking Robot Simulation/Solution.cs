using LeetCodeDaily.Core;

namespace _874._Walking_Robot_Simulation;

public class Solution
{
    [ResultGenerator]
    public int RobotSim(int[] commands, int[][] obstacles)
    {
        var obstHash = new HashSet<(int, int)>(obstacles.Select(x => (x[0], x[1])));

        int[] pos = new[] { 0, 0 };

        int maxDistance = 0;

        int direction = 0;

        var directions = new (int X, int Y)[]
        {
            ( 0,  1), // north
            ( 1,  0), // east
            ( 0, -1), // south
            (-1,  0), // west
        };

        for (int i = 0; i < commands.Length; i++)
        {
            if (commands[i] == -1)
            {
                direction = (direction + 1) % 4;
            }
            else if (commands[i] == -2)
            {
                direction = direction == 0 ? 3 : direction - 1;
            }
            else
            {
                var dx = directions[direction].X;
                var dy = directions[direction].Y;

                while (commands[i]-- > 0)
                {
                    if (obstHash.Contains((pos[0] + dx, pos[1] + dy)))
                    {
                        break;
                    }

                    pos[0] += dx;
                    pos[1] += dy;
                }

                maxDistance = Math.Max(maxDistance, pos[0] * pos[0] + pos[1] * pos[1]);
            }
        }

        return maxDistance;
    }
}