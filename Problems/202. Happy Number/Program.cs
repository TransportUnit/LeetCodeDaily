using LeetCodeDaily.Core;

Console.Write("Calculate convergences? (This will take a while) [y|n]: ");
var userInput = Console.ReadLine();

if (userInput?.ToLower().FirstOrDefault() == 'y')
{
    Directory.CreateDirectory("./converger");

    var sw = System.Diagnostics.Stopwatch.StartNew();
    Converger.CalculateConvergences("./converger/result.txt");
    sw.Stop();
    Console.WriteLine("Elapsed time: {0} ({1} ms)", sw.Elapsed, sw.ElapsedMilliseconds);
}

Console.WriteLine();

Case
    .CreateCase(
        19,
        true
    )
    .CreateCase(
        2,
        false
    )
    .Detect()
    .Run();