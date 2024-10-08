using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        "[10,2]".ParseArray<int>(),
        "210")
    .CreateCase(
        "[3,30,34,5,9]".ParseArray<int>(),
        "9534330")
    .Run();