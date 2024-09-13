using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

var baseCase =
    Case
        .CreateCase(
            ("ab", "[\"ad\",\"bd\",\"aaab\",\"baa\",\"badab\"]".ParseArray<string>()),
            2)
        .CreateCase(
            ("abc", "[\"a\",\"b\",\"c\",\"ab\",\"ac\",\"bc\",\"abc\"]".ParseArray<string>()),
            7)
        .CreateCase(
            ("cad", "[\"cc\",\"acd\",\"b\",\"ba\",\"bac\",\"bad\",\"ac\",\"d\"]".ParseArray<string>()),
            4);

ResultGeneratorAttribute.Detect();
baseCase.Run();

ResultGeneratorAttribute.Detect(1);
baseCase.Run();