using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

var baseCase =
    Case
        .CreateCase(
            ("[4,6,1,2]".ParseArray<int>(), 2),
            3)
        .CreateCase(
            ("[1,1,1,1]".ParseArray<int>(), 10),
            4)
        .CreateCase(
            ("[0]".ParseArray<int>(), 1),
            1)
        .CreateCase(
            ("[100000]".ParseArray<int>(), 0),
            1)
        .CreateCase(
            ("[49,26]".ParseArray<int>(), 12),
            2)
        .CreateCase(
            ("[52,34]".ParseArray<int>(), 21),
            2)
        .CreateCase(
            ("[89,54,44,54]".ParseArray<int>(), 5),
            3)
        .CreateCase(
            ("[30,74,64,4,85,81,10]".ParseArray<int>(), 21),
            4)
        // edge case
        //.CreateCase(
        //    ("[0,100000]".ParseArray<int>().Concat(Enumerable.Repeat(45, 20000)).Concat(Enumerable.Repeat(46, 20000)).Concat(Enumerable.Repeat(47, 20000)).ToArray(), 3),
        //    60000)
        ;

ResultGeneratorAttribute.Detect(0);

baseCase.Run();

ResultGeneratorAttribute.Detect(1);

baseCase.Run();