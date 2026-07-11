using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

namespace LeetCodeDaily.Tests;

// Note: Case<TInput, TResult> holds ResultGenerator/ResultChecker statically per
// closed generic type. To keep tests from affecting each other, every test here
// uses its own type combination.
public class CaseRunTests
{
    [Fact]
    public void Run_WithMatchingResult_Passes()
    {
        Case.SetResultGenerator<int, long>(x => x * 2L);

        var result = Case.CreateCase(21, 42L).Run(printResult: false);

        Assert.True(result.Passed);
    }

    [Fact]
    public void Run_WithNestedEnumerables_ComparesDeeply()
    {
        Case.SetResultGenerator<int, int[][]>(x => new[] { new[] { x, 2 }, new[] { 3 } });

        Assert.True(Case.CreateCase(1, new[] { new[] { 1, 2 }, new[] { 3 } }).Run(printResult: false).Passed);
        Assert.False(Case.CreateCase(1, new[] { new[] { 2, 1 }, new[] { 3 } }).Run(printResult: false).Passed);
    }

    [Fact]
    public void Run_WithTreeNodeResult_ComparesStructurally()
    {
        Case.SetResultGenerator<string, TreeNode>(s => TreeNode.Deserialize(s)!);

        var passed = Case
            .CreateCase("[1,2,3]", TreeNode.Deserialize("[1,2,3]")!)
            .Run(printResult: false)
            .Passed;

        Assert.True(passed);

        var failed = Case
            .CreateCase("[1,2,3]", TreeNode.Deserialize("[1,3,2]")!)
            .Run(printResult: false)
            .Passed;

        Assert.False(failed);
    }

    [Fact]
    public void IgnoreResultOrder_AcceptsPermutedTopLevel_ButKeepsInnerOrder()
    {
        Case.SetResultGenerator<int, IList<IList<int>>>(_ => new List<IList<int>>
        {
            new List<int> { 3, 4 },
            new List<int> { 1, 2 },
        });

        var expected = new List<IList<int>>
        {
            new List<int> { 1, 2 },
            new List<int> { 3, 4 },
        };

        var permutedTopLevel = Case
            .CreateCase(0, (IList<IList<int>>)expected)
            .IgnoreResultOrder()
            .Run(printResult: false)
            .Passed;

        Assert.True(permutedTopLevel);

        var permutedInner = Case
            .CreateCase(0, (IList<IList<int>>)new List<IList<int>>
            {
                new List<int> { 2, 1 },
                new List<int> { 4, 3 },
            })
            .IgnoreResultOrder()
            .Run(printResult: false)
            .Passed;

        Assert.False(permutedInner);
    }

    [Fact]
    public void Run_WithWarmup_StillMeasuresAndPasses()
    {
        Case.SetResultGenerator<long, long>(x => x + 1);

        var result = Case.CreateCase(1L, 2L).Run(printResult: false, warmup: true);

        Assert.True(result.Passed);
        Assert.True(result.ExecutionTime >= TimeSpan.Zero);
    }
}
