using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

Case
    .CreateCase(
        "[5]".ParseArray<int>(),
        5)
    .CreateCase(
        "[3,7]".ParseArray<int>(),
        0)
    .CreateCase(
        "[9,9,9,9,9]".ParseArray<int>(),
        4)
    .CreateCase(
        "[0,0,0,0,0,0]".ParseArray<int>(),
        0)
    .CreateCase(
        "[1,2,3,4,5,6,7,8,9]".ParseArray<int>(),
        0)
    .CreateCase(
        "[9,0,9,0,9,0,9,0,9,0]".ParseArray<int>(),
        4)
    .CreateCase(
        "[8,7,6,5,4,3,2,1]".ParseArray<int>(),
        6)
    .CreateCase(
        "[1,1,1,1,1,1,1,1,1,1]".ParseArray<int>(),
        2)
    .Detect()
    .Run();