using LeetCodeDaily.Core;

Case
    .CreateCase(
        ("anagram", "nagaram"),
        true)
    .CreateCase(
        ("rat", "car"),
        false)
    .CreateCase(
        ("ggii", "eekk"),
        false)
    .Detect()
    .Run();