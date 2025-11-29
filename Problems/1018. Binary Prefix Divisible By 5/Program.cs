using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

string cases =
"""
[1,0,1,0,0,1,1,0,0,1,0,1,1,0,1,0,0,1]
[false,false,true,true,true,false,false,false,false,true,true,false,false,false,false,false,false,true]

[0,1,0,1,1,0,0,1,1,0,1,0,0,1,0,1]
[true,false,false,true,false,false,false,false,false,false,false,false,false,false,false,false]

[1,1,0,0,1,0,1,0,0,1,1,0,1,1,0,0,1,0,1]
[false,false,false,false,true,true,false,false,false,false,false,false,false,true,true,true,false,false,true]

[0,0,1,1,0,1,0,0,1,0,1,1,0,0,1,1,0]
[true,true,false,false,false,false,false,false,true,true,false,false,false,false,true,false,false]

[1,0,1,1,0,0,1,1,0,1,0,0,1,0,1,1,0,0,1,1]
[false,false,true,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]

[0,1,1,0,1,0,0,1,0,1,1,0,0,1,1,0,1,0]
[true,false,false,false,false,false,false,true,true,false,false,false,false,true,false,false,true,true]

[1,0,0,1,0,1,1,0,1,0,0,1,1,0,0,1,0,1,1,0,1]
[false,false,false,false,false,false,true,true,false,false,false,false,false,false,false,false,false,false,false,false,false]

[0,0,0,1,1,0,1,0,1,1,0,0,1,0,1,0,1,1,0]
[true,true,true,false,false,false,false,false,false,false,false,false,false,false,false,false,false,true,true]
""";

var inputs = new List<int[]>();
var expectedOutputs = new List<IList<bool>>();
var lines = cases.Split("\r\n");

for(int i = 0; i < lines.Length; i++)
{
    if (string.IsNullOrWhiteSpace(lines[i]))
        continue;

    if (i % 3 == 0)
    {
        var input = lines[i].ParseArray<int>();
        inputs.Add(input);
    }
    else if (i % 3 == 1)
    {
        var expectedOutput = lines[i].ParseArray<bool>();
        expectedOutputs.Add(expectedOutput);
    }
}

Case<int[], IList<bool>> baseCase = null!;

for (int i = 0; i < inputs.Count; i++)
{
    if (baseCase is null)
    {
        baseCase = Case.CreateCase(inputs[i], expectedOutputs[i]);
    }
    else
    {
        baseCase.CreateCase(inputs[i], expectedOutputs[i]);
    }
}

baseCase?
    .Detect()
    .Run();