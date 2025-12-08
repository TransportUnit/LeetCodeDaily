using LeetCodeDaily.Extensions;
using System.Collections;
using System.Diagnostics;

namespace LeetCodeDaily.Core;

public class Case<TInput, TResult>
{
    public static string ApproachName { get; set; } = string.Empty;
    public static Func<TInput, TResult>? ResultGenerator { get; set; }
    public static Func<Case<TInput, TResult>, bool>? ResultChecker { get; set; }

    public string InputString { get; set; } = string.Empty;
    public TInput Input { get; set; }
    public TResult ExpectedResult { get; set; }
    public TResult? ActualResult { get; set; }
    public bool Passed { get; set; }
    public IList<Case<TInput, TResult>>? SubCases { get; set; }
    public TimeSpan ExecutionTime { get; set; }

    static Case()
    {
        Case.SetResultChecker<TInput, TResult>(c =>
        {
            // this is sufficient for value types (such as int, string, etc.)
            if (
                c.ExpectedResult is IEnumerable expectedEnumerable &&
                c.ActualResult is IEnumerable resultEnumerable)
            {
                var expectedEnumerator = expectedEnumerable.GetEnumerator();
                var resultEnumerator = resultEnumerable.GetEnumerator();

                try
                {
                    // basically a copy of the System.Linq.Enumerable.SequenceEqual extension method that uses
                    // the generic IEnumerable type instead of IEnumerable<TSource>
                    while (expectedEnumerator.MoveNext())
                    {
                        if (!resultEnumerator.MoveNext() || !expectedEnumerator.Current.Equals(resultEnumerator.Current))
                        {
                            return false;
                        }
                    }

                    if (resultEnumerator.MoveNext())
                    {
                        return false;
                    }

                    return true;
                }
                finally
                {
                    if (expectedEnumerator is IDisposable expectedDisposable)
                    {
                        expectedDisposable.Dispose();
                    }
                    if (resultEnumerator is IDisposable resultDisposable)
                    {
                        resultDisposable.Dispose();
                    }
                }
            }

            return c.ActualResult switch
            {
                null => c.ExpectedResult is null,
                not null => c.ActualResult.Equals(c.ExpectedResult)
            };
        });
    }

    public Case(TInput input, TResult expectedResult)
    {
        Input = input;
        ExpectedResult = expectedResult;
    }

    public Case<TInput, TResult> GenerateResult()
    {
        if (ResultGenerator is null)
        {
            throw new InvalidOperationException("ResultGenerator delegate was not set.");
        }

        var stopwatch = Stopwatch.StartNew();
        ActualResult = ResultGenerator(Input);
        stopwatch.Stop();
        ExecutionTime = stopwatch.Elapsed;
        return this;
    }

    public bool ResultAsExpected()
    {
        if (ResultChecker is null)
        {
            throw new InvalidOperationException("ResultChecker delegate was not set.");
        }

        return ResultChecker(this);
    }

    public Case<TInput, TResult> Run(bool printResult = true)
    {
        GenerateResult();
        Passed = ResultAsExpected();
        if (printResult)
            PrintResult();

        if (SubCases is not null)
        {
            foreach (var subCase in SubCases)
            {
                subCase.Run(printResult);
            }
        }
        return this;
    }

    public Case<TInput, TResult> PrintResult()
    {
        var approachNameExists = !string.IsNullOrEmpty(ApproachName);

        if (approachNameExists)
        {
            $"{ApproachName} ".Print(newLine: true, color: ConsoleColor.White);
        }
        "Test ".Print(newLine: false, indent: approachNameExists);
        $"{(Passed ? "PASSED" : "FAILED")}".Print(newLine: false, color: Passed ? ConsoleColor.Green : ConsoleColor.Red);
        ".".Print();
        $"Input: {Input.TryGetObjectString()}".Print(indent: approachNameExists);
        $"Result: {ActualResult.TryGetObjectString()}".Print(indent: approachNameExists);
        $"Expected: {ExpectedResult.TryGetObjectString()}".Print(indent: approachNameExists);
        $"Time: {ExecutionTime.TotalMilliseconds.TryGetObjectString()} ms".Print(indent: approachNameExists);
        Environment.NewLine.Print();
        return this;
    }

    public Case<TInput, TResult> CreateCase(TInput input, TResult expectedResult)
    {
        if (SubCases is null)
            SubCases = new List<Case<TInput, TResult>>();

        var subCase = new Case<TInput, TResult>(input, expectedResult);
        SubCases.Add(subCase);
        return this;
    }

    public Case<TInput, TResult> SetResultChecker(Func<Case<TInput, TResult>, bool> resultChecker)
    {
        ResultChecker = resultChecker;
        return this;
    }

    public Case<TInput, TResult> Detect(int approachIndex = 0)
    {
        ResultGeneratorAttribute.Detect(approachIndex);
        return this;
    }

    public Case<TInput, TResult> DetectAndRun(int approachIndex = 0, bool printResult = true)
    {
        return Detect(approachIndex).Run(printResult);
    }
}
