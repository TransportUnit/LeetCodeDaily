using LeetCodeDaily.Core;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        "Hello World",
        5)
    .CreateCase(
        "   fly me   to   the moon  ",
        4)
    .CreateCase(
        "luffy is still joyboy",
        6)
    .Run();