using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        "[abc,car,ada,racecar,cool]".ParseArray<string>(),
        "ada")
    .CreateCase(
        "[notapalindrome,racecar]".ParseArray<string>(),
        "racecar")
    .CreateCase(
        "[def,ghi]".ParseArray<string>(),
        string.Empty)
    .CreateCase(
        "[po,zsz]".ParseArray<string>(),
        "zsz")
    .CreateCase(
        "[cqllrtyhw,swwisru,gpzmbders,wqibjuqvs,pp,usewxryy,ybqfuh,hqwwqftgyu,jggmatpk]".ParseArray<string>(),
        "pp")
    .Run();