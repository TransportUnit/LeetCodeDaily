using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        ("[1,5,6]".ParseArray<int>(), 3, 11),
        "[3,3,3,3,3,3,3,3,3,2,1]".ParseArray<int>()
        )
    .CreateCase(
        ("[3,2,4,3]".ParseArray<int>(), 4, 2),
        "[6,6]".ParseArray<int>()
        )
    .CreateCase(
        ("[1,5,6]".ParseArray<int>(), 3, 4),
        "[2,3,2,2]".ParseArray<int>()
        )
    .CreateCase(
        ("[1,2,3,4]".ParseArray<int>(), 6, 4),
        "".ParseArray<int>()
        )
    .SetResultChecker(c =>
    {
        if ((c.ExpectedResult?.Any() ?? false) &&
            (c.ActualResult?.Any() ?? false))
        {
            return c.ExpectedResult.Sum().Equals(c.ActualResult.Sum()) && c.ActualResult.All(x => 1 <= x && x <= 6);
        }

        return (c.ExpectedResult == null && c.ActualResult == null) ||
               (c.ExpectedResult!.Length == 0 && c.ActualResult!.Length == 0);
    })
    .Run();