using LeetCodeDaily.Core;

Case
    .CreateCase(
        "abcabcbb",
        3)
    .CreateCase(
        "bbbbb",
        1)
    .CreateCase(
        "pwwkew",
        3)
    .CreateCase(
        " ",
        1)
    .CreateCase(
        "dvdf",
        3)
    .CreateCase(
        "ckilbkd",
        5)
    .CreateCase(
        "tmmzuxt",
        5)
    .CreateCase(
        "abababababababababababababababababababababababababababababababab",
        2)
    .Detect(0)
    .Run()
    .Detect(1)
    .Run()
    .Detect(2)
    .Run()
    .Detect(3)
    .Run();