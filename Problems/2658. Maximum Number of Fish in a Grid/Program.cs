using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        ("[[0,2,1,0],[4,0,0,3],[1,0,0,4],[0,3,2,0]]".ParseMatrix<int>()),
        7)
    .CreateCase(
        ("[[1,0,0,0],[0,0,0,0],[0,0,0,0],[0,0,0,1]]".ParseMatrix<int>()),
        1)
    .CreateCase(
        ("[[0,4]]".ParseMatrix<int>()),
        4)
    .CreateCase(
        ("[[4,5,5],[0,10,0]]".ParseMatrix<int>()),
        24)
    .Run();