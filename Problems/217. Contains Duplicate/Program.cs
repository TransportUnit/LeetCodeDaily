using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        "[1,2,3,1]".ParseArray<int>(),
        true)
    .CreateCase(
        "[1,2,3,4]".ParseArray<int>(),
        false)
    .CreateCase(
        "[1,1,1,3,3,4,3,2,4,2]".ParseArray<int>(),
        true)
    .Run();