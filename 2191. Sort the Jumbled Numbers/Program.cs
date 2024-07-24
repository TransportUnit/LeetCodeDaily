using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        ("[8,9,4,0,2,1,3,5,7,6]".ParseArray<int>(), "[991,338,38]".ParseArray<int>()),
        "[338,38,991]".ParseArray<int>())
    .CreateCase(
        ("[0,1,2,3,4,5,6,7,8,9]".ParseArray<int>(), "[789,456,123]".ParseArray<int>()),
        "[123,456,789]".ParseArray<int>())
    .Run();