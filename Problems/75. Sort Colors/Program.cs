using LeetCodeDaily.Core;

const int N = 20;

var random = new Random();

var original = new int[N];

for (int i = 0; i < original.Length; i++)
{
    original[i] = random.Next(0, 3);
}

for (int i = 0; i < 3; i++)
{
    var nums = new int[original.Length];
    var expected = new int[original.Length];
    Array.Copy(original, nums, N);
    Array.Copy(original, expected, N);

    Array.Sort(expected);

    var @case = 
        Case
            .CreateCase(
                nums,
                expected)
            .Detect(i)
            .Run();
}