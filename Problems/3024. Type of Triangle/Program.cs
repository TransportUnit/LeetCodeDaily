using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

Case
    .CreateCase(
        "[9,4,9]".ParseArray<int>(),
        "isosceles")
    .CreateCase(
        "[3,4,5]".ParseArray<int>(),
        "scalene")
    .CreateCase(
        "[1,1,1]".ParseArray<int>(),
        "equilateral")
    .CreateCase(
        "[3,1,2]".ParseArray<int>(),
        "none")
    .CreateCase(
        "[2,5,2]".ParseArray<int>(),
        "none")
    .CreateCase(
        "[3,3,1]".ParseArray<int>(),
        "isosceles")
    .CreateCase(
        "[1,1,2]".ParseArray<int>(),
        "none")
    .CreateCase(
        "[2,3,4]".ParseArray<int>(),
        "scalene")
    .Detect()
    .Run();