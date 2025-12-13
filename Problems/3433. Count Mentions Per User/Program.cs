using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

Case
    .CreateCase(
        (3,
        "[[MESSAGE,5,id0 id1],[OFFLINE,10,0],[OFFLINE,15,1],[MESSAGE,20,ALL],[OFFLINE,30,2],[MESSAGE,40,HERE]]".ParseThisFuckingShit()),
        "[2,2,1]".ParseArray<int>())
    .CreateCase(
        (5, "[[MESSAGE,96,id0],[MESSAGE,98,ALL],[OFFLINE,22,0],[MESSAGE,25,id0],[OFFLINE,40,4],[OFFLINE,54,1],[MESSAGE,41,id2 id2 id1 id4 id4],[OFFLINE,85,0],[MESSAGE,86,HERE]]".ParseThisFuckingShit()),
        "[3,2,4,2,3]".ParseArray<int>())
    .CreateCase(
        (3, "[[MESSAGE,1,ALL],[OFFLINE,66,1],[MESSAGE,66,HERE],[OFFLINE,5,1]]".ParseThisFuckingShit()),
        "[2,1,2]".ParseArray<int>())
    .CreateCase(
        (3, "[[MESSAGE,2,HERE],[OFFLINE,2,1],[OFFLINE,1,0],[MESSAGE,61,HERE]]".ParseThisFuckingShit()),
        "[1,0,2]".ParseArray<int>())
    .CreateCase(
        (3, "[[MESSAGE,1,id0 id1],[MESSAGE,5,id2],[MESSAGE,6,ALL],[OFFLINE,5,2]]".ParseThisFuckingShit()),
        "[2,2,2]".ParseArray<int>())
    .CreateCase(
        (2, "[[MESSAGE,70,HERE],[OFFLINE,10,0],[OFFLINE,71,0]]".ParseThisFuckingShit()),
        "[1,1]".ParseArray<int>())
    .DetectAndRun();

public static class CountMentionsPerUserExtensions
{
    public static IList<IList<string>> ParseThisFuckingShit(this string fuckingInput)
    {
        // Getting tired of this shit
        var fuckingMoron = new List<IList<string>>();
        var fuckingSplit = fuckingInput.Split("],");

        foreach (var fuckhead in fuckingSplit)
        {
            var motherFucker = fuckhead.TrimStart('[').TrimEnd(']').Split(',');
            fuckingMoron.Add(motherFucker);
        }

        return fuckingMoron;
    }
}