using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

var baseCase =
    Case
        .CreateCase(
            (5, 0),
            8)
        .CreateCase(
            (4, 3),
            8)
        .CreateCase(
            (13, 11),
            11)
        .CreateCase(
            (49, 40),
            136)
        .CreateCase(
            (51, 4),
            106)
        .CreateCase(
            (3, 17),
            23)
        .CreateCase(
            (1, 0),
            0);

ResultGeneratorAttribute.Detect();
baseCase.Run();

ResultGeneratorAttribute.Detect(1);
baseCase.Run();