using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

Case
    .CreateCase(
        ("[[1,2],[2,3],[4,5]]".ParseMatrix<int>(), "[[1,4],[3,2],[4,1]]".ParseMatrix<int>()),
        "[[1,6],[2,3],[3,2],[4,6]]".ParseMatrix<int>())
    .CreateCase(
        ("[[2,4],[3,6],[5,5]]".ParseMatrix<int>(), "[[1,3],[4,3]]".ParseMatrix<int>()),
        "[[1,3],[2,4],[3,6],[4,3],[5,5]]".ParseMatrix<int>())
    .Detect()
    .SetResultChecker(Check)
    .Run();

static bool Check(Case<(int[][], int[][]), int[][]> c)
{
    int i = 0;
    foreach (var a in c.ExpectedResult)
    {
        if (!c.ActualResult[i].SequenceEqual(a))
        {
            return false;
        }
        i++;
    }

    return true;
}