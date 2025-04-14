using LeetCodeDaily.Core;

Case
    .CreateCase(
        (long)1, // this cast is necessary so the method signature matches
        5)
    .CreateCase(
        4,
        400)
    .CreateCase(
        50,
        564908303)
    .Detect()
    .Run();