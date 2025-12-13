using LeetCodeDaily.Core;

namespace _3433.Count_Mentions_Per_User;

public class Solution
{
    [ResultGenerator]
    public int[] CountMentions(int numberOfUsers, IList<IList<string>> events)
    {
        int[] mentions = new int[numberOfUsers];

        var grouped =
            events
                .OrderByDescending(x => x[0][0])
                .GroupBy(x => int.Parse(x[1]))
                .OrderBy(x => x.Key)
                .ToList();

        Span<int> offlineAt = stackalloc int[numberOfUsers];

        for (int i = 0; i < numberOfUsers; i++)
        {
            offlineAt[i] = int.MinValue;
        }

        int allMentioned = 0;

        foreach (var group in grouped)
        {
            var time = group.Key;

            foreach (var @event in group)
            {
                if (@event[0] == "OFFLINE")
                {
                    foreach (var user in @event[2].Split(" "))
                    {
                        offlineAt[int.Parse(user)] = time;
                    }
                }
                else if (@event[0] == "MESSAGE")
                {
                    if (@event[2] == "ALL")
                    {
                        allMentioned++;
                        continue;
                    }

                    if (@event[2] == "HERE")
                    {
                        for (int i = 0; i < numberOfUsers; i++)
                        {
                            if (time >= offlineAt[i] + 60)
                            {
                                mentions[i]++;
                            }
                        }

                        continue;
                    }

                    foreach (var user in @event[2].Replace("id", "").Split(" "))
                    {
                        mentions[int.Parse(user)]++;
                    }
                }
            }
        }

        if (allMentioned > 0)
        {
            for (int i = 0; i < numberOfUsers; i++)
            {
                mentions[i] += allMentioned;
            }
        }

        return mentions;
    }
}