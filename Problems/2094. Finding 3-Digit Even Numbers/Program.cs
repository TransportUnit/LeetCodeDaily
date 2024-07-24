using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        "[2,1,3,0]".ParseArray<int>(),
        "[102,120,130,132,210,230,302,310,312,320]".ParseArray<int>())
    .CreateCase(
        "[2,2,8,8,2]".ParseArray<int>(),
        "[222,228,282,288,822,828,882]".ParseArray<int>())
    .CreateCase(
        "[3,7,5]".ParseArray<int>(),
        Array.Empty<int>())
    .Run();