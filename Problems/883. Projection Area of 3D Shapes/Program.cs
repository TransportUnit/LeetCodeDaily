using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        "[[1,2],[3,4]]".ParseMatrix<int>(),
        17)
    .CreateCase(
        "[[2]]".ParseMatrix<int>(),
        5)
    .CreateCase(
        "[[1,0],[0,2]]".ParseMatrix<int>(),
        8)
    .Run();