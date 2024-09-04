using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        ("[4,-1,3]".ParseArray<int>(), "".ParseMatrix<int>(true)),
        25)
    .CreateCase(
        ("[4,-1,4,-2,4]".ParseArray<int>(), "[[2,4]]".ParseMatrix<int>()),
        65)
    .CreateCase(
        ("[6,-1,-1,6]".ParseArray<int>(), "".ParseMatrix<int>(false)),
        36)
    .Run();