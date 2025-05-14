using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

Case
    .CreateCase(
        "[0,2,1,5,3,4]".ParseArray<int>(),
        "[0,1,2,4,5,3]".ParseArray<int>())
    .CreateCase(
        "[5,0,1,2,3,4]".ParseArray<int>(),
        "[4,5,0,1,2,3]".ParseArray<int>())
    .Detect()
    .Run();