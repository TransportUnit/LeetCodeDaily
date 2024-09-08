using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        ("[\"cd\",\"ac\",\"dc\",\"ca\",\"zz\"]".ParseArray<string>()),
        2)
    .CreateCase(
        ("[\"ab\",\"ba\",\"cc\"]".ParseArray<string>()),
        1)
    .CreateCase(
        ("[\"aa\",\"ab\"]".ParseArray<string>()),
        0)
    .Run();