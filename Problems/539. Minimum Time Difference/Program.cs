using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        // Apparently, arrays in C# already implement the IList interface,
        // so we don't need to cast this to a list ('.ToList()') before passing it.
        "[\"23:59\",\"00:00\"]".ParseArray<string>().ToIList(),
        1)
    .CreateCase(
        "[\"00:00\",\"23:59\",\"00:00\"]".ParseArray<string>().ToIList(),
        0)
    .Run();