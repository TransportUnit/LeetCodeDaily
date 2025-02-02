using System.Collections.Concurrent;

public class Converger
{
    public static void CalculateConvergences(string path)
    {
        ConcurrentDictionary<int, int> convergences = new();

        Parallel.For(
            1,
            int.MaxValue, 
            (num) =>
        {
            var resultSet = Do(num, out bool happy);

            if (happy)
            {
                foreach(var result in resultSet)
                {
                    convergences.AddOrUpdate(result, 1, (k, v) => v + 1);
                }
            }
        });

        List<string> resultLines = new();

        var columnHeaders = new string[] { "Value", "Occurrences" };
        var firstColumnWidth = columnHeaders[0].Length + 6;

        resultLines.Add($"{columnHeaders[0].PadRight(firstColumnWidth, ' ')}{columnHeaders[1]}");

        resultLines
            .AddRange(
                convergences
                    .OrderByDescending(x => x.Value)
                    .Select(x => x.Key.ToString().PadRight(firstColumnWidth, ' ') + x.Value)
                    .ToList()
                    );
        
        File.WriteAllLines(path, resultLines);
    }

    private static HashSet<int> Do(int num, out bool happy)
    {
        HashSet<int> items = new();
        happy = false;
        bool first = true;

        while (true)
        {
            if (first)
            {
                first = false;
            }
            else
            {
                if (!items.Add(num))
                {
                    happy = false;
                    return items;
                }
            }

            if (num == 1)
            {
                happy = true;
                return items;
            }

            int res = 0;
            while (num > 0)
            {
                res += (num % 10) * (num % 10);
                num /= 10;
            }

            num = res;
        }
    }
}