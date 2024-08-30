using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        ("[1,3,5,6]".ParseArray<int>(), 5),
        2)
    .CreateCase(
        ("[1,3,5,6]".ParseArray<int>(), 2),
        1)
    .CreateCase(
        ("[1,3,5,6]".ParseArray<int>(), 7),
        4)
     .CreateCase(
        ("[1]".ParseArray<int>(), 0),
        0)
     .CreateCase(
        ("[1]".ParseArray<int>(), 2),
        1)
     .CreateCase(
        ("[1,3,5,6,8]".ParseArray<int>(), 7),
        4)
     .CreateCase(
        ("[1,3]".ParseArray<int>(), 2),
        1)
    .Run();