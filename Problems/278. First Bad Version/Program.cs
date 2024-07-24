using LeetCodeDaily.Core;

ResultGeneratorAttribute.Detect();

var solution = ResultGeneratorAttribute.SolutionInstance as _278._First_Bad_Version.Solution;

solution!.SetBadVersion(4);
Case
    .CreateCase(
        5,
        4)
    .Run();


solution.SetBadVersion(1);
Case
    .CreateCase(
        1,
        1)
    .Run();


solution.SetBadVersion(1702766719);
Case
    .CreateCase(
        2126753390,
        1702766719)
    .Run();