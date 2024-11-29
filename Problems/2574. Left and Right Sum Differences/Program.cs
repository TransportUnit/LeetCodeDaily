using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        "[10,4,8,3]".ParseArray<int>(),
        "[15,1,11,22]".ParseArray<int>())
    .CreateCase(
        "[1]".ParseArray<int>(),
        "[0]".ParseArray<int>())
    .Run();