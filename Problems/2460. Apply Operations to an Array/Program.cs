using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

Case
    .CreateCase(
        "[1,2,2,1,1,0]".ParseArray<int>(),
        "[1,4,2,0,0,0]".ParseArray<int>())
    .CreateCase(
        "[0,1]".ParseArray<int>(),
        "[1,0]".ParseArray<int>())
    .Detect()
    .Run();