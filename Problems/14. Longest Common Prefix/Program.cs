using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        "[flower,flow,flight]".ParseArray<string>(),
        "fl")
    .CreateCase(
        "[dog,racecar,car]".ParseArray<string>(),
        "")
    .Run();