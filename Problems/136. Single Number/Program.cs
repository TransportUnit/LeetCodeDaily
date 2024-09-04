using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        "[2,2,1]".ParseArray<int>(),
        1)
    .CreateCase(
        "[4,1,2,1,2]".ParseArray<int>(),
        4)
    .CreateCase(
        "[1]".ParseArray<int>(),
        1)
    .Run();