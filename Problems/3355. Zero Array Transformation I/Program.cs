using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

Case
    .CreateCase(
        ("[1,0,1]".ParseArray<int>(), "[[0,2]]".ParseMatrix<int>()),
        true)
    .CreateCase(
        ("[4,3,2,1]".ParseArray<int>(), "[[1,3],[0,2]]".ParseMatrix<int>()),
        false)
    .CreateCase(
        ("[4,3,2,1]".ParseArray<int>(), "[[1,3],[0,2],[0,2],[0,2],[0,2]]".ParseMatrix<int>()),
        true)
    .CreateCase(
        ("[1,2,1,0,0,0]".ParseArray<int>(), "[[0,3],[2,4]]".ParseMatrix<int>()),
        false)
    .CreateCase(
        ("[6,9]".ParseArray<int>(), "[[1,1],[1,1],[0,1],[1,1],[1,1],[1,1],[1,1],[1,1],[1,1],[1,1],[1,1],[0,1]]".ParseMatrix<int>()),
        false)
    .Detect()
    .Run();