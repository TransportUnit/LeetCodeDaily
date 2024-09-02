using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        ("[5,1,5]".ParseArray<int>(), 22),
        0)
    .CreateCase(
        ("[3,4,1,2]".ParseArray<int>(), 25),
        1)
    .Run();