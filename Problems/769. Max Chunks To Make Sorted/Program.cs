using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

Case
    .CreateCase(
        "[0,1,2,3,4]".ParseArray<int>(),
        5)
    .CreateCase(
        "[4,3,2,1,0]".ParseArray<int>(),
        1)
    .CreateCase(
        "[1,0,2,3,4]".ParseArray<int>(),
        4)
    .CreateCase(
        "[0]".ParseArray<int>(),
        1)
    .CreateCase(
        "[1,0]".ParseArray<int>(),
        1)
    .CreateCase(
        "[0,2,1]".ParseArray<int>(),
        2)
    .CreateCase(
        "[1,2,0,3,5,4]".ParseArray<int>(),
        3)
    .CreateCase(
        "[2,3,4,1,5,0,6,7]".ParseArray<int>(),
        3)
    .CreateCase(
        "[1,4,3,6,0,7,8,2,5]".ParseArray<int>(),
        1)
    .Detect()
    .Run();