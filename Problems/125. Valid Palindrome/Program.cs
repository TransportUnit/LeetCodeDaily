using LeetCodeDaily.Core;

Case
    .CreateCase(
        "0p",
        false)
    .CreateCase(
        "A man, a plan, a canal: Panama",
        true)
    .CreateCase(
        "race a car",
        false)
    .CreateCase(
        " ",
        true)
    .CreateCase(
        ".....",
        true)
    .CreateCase(
        "...,..",
        true)
    .CreateCase(
        "0P", // this test case is 0P
        false)
    .Detect()
    .Run();