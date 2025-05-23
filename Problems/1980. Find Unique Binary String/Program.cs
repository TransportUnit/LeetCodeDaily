using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

Case
    .CreateCase(
        "[\"01\",\"10\"]".ParseArray<string>(),
        "00")
    .CreateCase(
        "[\"00\",\"01\"]".ParseArray<string>(),
        "10")
    .CreateCase(
        "[\"111\",\"011\",\"001\"]".ParseArray<string>(),
        "000")
    .Detect()
    .SetResultChecker(Check)
    .Run();


static bool Check(Case<string[], string> c)
{
    if (string.IsNullOrEmpty(c.ActualResult))
        throw new InvalidOperationException("Huh?");

    return
        c.ActualResult.Length == c.Input.Length &&
        c.Input.All(num => num != c.ActualResult) &&
        c.ActualResult.All(ch => ch == '0' || ch == '1');
}