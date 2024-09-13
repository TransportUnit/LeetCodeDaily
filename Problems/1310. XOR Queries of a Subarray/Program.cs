using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        ("[1,3,4,8]".ParseArray<int>(), "[[0,1],[1,2],[0,3],[3,3]]".ParseMatrix<int>()),
        "[2,7,14,8]".ParseArray<int>())
    .CreateCase(
        ("[4,8,2,10]".ParseArray<int>(), "[[2,3],[1,3],[0,0],[0,3]]".ParseMatrix<int>()),
        "[8,0,4,4]".ParseArray<int>())
    .Run();