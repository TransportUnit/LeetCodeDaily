

using LeetCodeDaily.Core;

Case
    .CreateCase(
        "-115579378e25",
        -115579378)
    .CreateCase(
        "   -042",
        -42)
    .CreateCase(
        "1337c0d3",
        1337)
    .CreateCase(
        "0-1",
        0)
    .CreateCase(
        "words and 987",
        0)
    .CreateCase(
        "+-42",
        0)
    .CreateCase(
        "-1123u3761867",
        -1123)
    .CreateCase(
        "2147483648",
        2147483647)
    .Detect()
    .Run();