using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        ("this apple is sweet", "this apple is sour"),
        "[\"sweet\",\"sour\"]".ParseArray<string>())
    .CreateCase(
        ("apple apple", "banana"),
        "[\"banana\"]".ParseArray<string>())
    .Run();