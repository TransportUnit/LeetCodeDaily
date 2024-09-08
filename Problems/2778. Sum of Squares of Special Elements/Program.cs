using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        ("[1,2,3,4]".ParseArray<int>()),
        21)
    .CreateCase(
        ("[2,7,1,19,18,3]".ParseArray<int>()),
        63)
    .Run();