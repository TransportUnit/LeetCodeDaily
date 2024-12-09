using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        ("[3,4,1,2,6]".ParseArray<int>(), "[[0,4]]".ParseMatrix<int>()),
        "[false]".ParseArray<bool>())
    .CreateCase(
        ("[4,3,1,6]".ParseArray<int>(), "[[0,2],[2,3]]".ParseMatrix<int>()),
        "[false,true]".ParseArray<bool>())
    .Run();