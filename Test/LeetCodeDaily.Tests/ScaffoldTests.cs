using LeetCodeDaily.Scaffold;

namespace LeetCodeDaily.Tests;

public class TypeMapperTests
{
    [Theory]
    [InlineData("integer", "int")]
    [InlineData("integer[]", "int[]")]
    [InlineData("integer[][]", "int[][]")]
    [InlineData("string", "string")]
    [InlineData("string[]", "string[]")]
    [InlineData("character", "char")]
    [InlineData("character[][]", "char[][]")]
    [InlineData("boolean", "bool")]
    [InlineData("long", "long")]
    [InlineData("double", "double")]
    [InlineData("list<integer>", "IList<int>")]
    [InlineData("list<list<integer>>", "IList<IList<int>>")]
    [InlineData("list<string>", "IList<string>")]
    [InlineData("TreeNode", "TreeNode")]
    [InlineData("ListNode", "ListNode")]
    public void ToCSharpType_MapsKnownTypes(string leetCodeType, string expected)
    {
        Assert.Equal(expected, TypeMapper.ToCSharpType(leetCodeType));
    }

    [Theory]
    [InlineData("void")]
    [InlineData("NestedInteger")]
    public void ToCSharpType_ReturnsNullForUnsupportedTypes(string leetCodeType)
    {
        Assert.Null(TypeMapper.ToCSharpType(leetCodeType));
    }
}

public class ProblemMetaTests
{
    [Fact]
    public void Parse_FunctionProblem_ExposesParamsAndReturnType()
    {
        var meta = ProblemMeta.Parse(ScaffoldFixtures.MetaDataJson);

        Assert.False(meta.IsDesignProblem);
        Assert.Equal("xorAfterQueries", meta.Name);
        Assert.Equal(2, meta.Params.Count);
        Assert.Equal("integer[]", meta.Params[0].Type);
        Assert.Equal("integer", meta.ReturnType);
    }

    [Fact]
    public void Parse_DesignProblem_IsDetected()
    {
        var meta = ProblemMeta.Parse(ScaffoldFixtures.DesignMetaDataJson);

        Assert.True(meta.IsDesignProblem);
        Assert.Equal("MyHashMap", meta.ClassName);
    }
}

public class ExampleExtractorTests
{
    [Fact]
    public void ExtractExpectedOutputs_NewFormat_FindsAllOutputs()
    {
        var outputs = ExampleExtractor.ExtractExpectedOutputs(ScaffoldFixtures.ContentHtml);

        Assert.Equal(["4", "31"], outputs);
    }

    [Fact]
    public void ExtractExpectedOutputs_ClassicPreFormat_FindsOutput()
    {
        var outputs = ExampleExtractor.ExtractExpectedOutputs(ScaffoldFixtures.ClassicContentHtml);

        Assert.Equal(["6"], outputs);
    }

    [Fact]
    public void BuildCaseBlocks_GroupsInputsByParamCount()
    {
        var blocks = ExampleExtractor.BuildCaseBlocks(
            ScaffoldFixtures.ExampleTestcases, paramCount: 2, expectedOutputs: ["4", "31"]);

        Assert.Equal("""
            [1,1,1]
            [[0,2,1,4]]
            4

            [2,3,1,5,4]
            [[1,4,2,3],[0,2,1,2]]
            31
            """.ReplaceLineEndings("\n"), blocks);
    }

    [Fact]
    public void BuildCaseBlocks_MismatchedCounts_ReturnsNull()
    {
        Assert.Null(ExampleExtractor.BuildCaseBlocks("[1]\n[2]\n[3]", paramCount: 2, expectedOutputs: ["4"]));
        Assert.Null(ExampleExtractor.BuildCaseBlocks("[1]\n[2]", paramCount: 2, expectedOutputs: []));
    }
}

public class CodeGeneratorTests
{
    [Theory]
    [InlineData("3653", "XOR After Range Multiplication Queries I", "_3653.XOR_After_Range_Multiplication_Queries_I")]
    [InlineData("8", "String to Integer (atoi)", "_8.String_to_Integer__atoi_")]
    [InlineData("15", "3Sum", "_15._3Sum")]
    [InlineData("1411", "Number of Ways to Paint N × 3 Grid", "_1411.Number_of_Ways_to_Paint_N___3_Grid")]
    public void BuildNamespace_MatchesRepoConvention(string id, string title, string expected)
    {
        Assert.Equal(expected, CodeGenerator.BuildNamespace(id, title));
    }

    [Fact]
    public void GenerateSolution_UsesFileScopedNamespaceAndInjectsAttribute()
    {
        var solution = CodeGenerator.GenerateSolution(
            ScaffoldFixtures.Question, ProblemMeta.Parse(ScaffoldFixtures.MetaDataJson));

        Assert.Contains("using LeetCodeDaily.Core;", solution);
        Assert.Contains("namespace _3653.XOR_After_Range_Multiplication_Queries_I;", solution);
        Assert.Contains("[ResultGenerator]", solution);

        // Attribut steht direkt über der Methode
        var attributeIndex = solution.IndexOf("[ResultGenerator]");
        var methodIndex = solution.IndexOf("public int XorAfterQueries");
        Assert.True(attributeIndex >= 0 && attributeIndex < methodIndex);
    }

    [Fact]
    public void GenerateProgram_BuildsParseCasesWithMappedTypes()
    {
        var program = CodeGenerator.GenerateProgram(
            ScaffoldFixtures.Question, ProblemMeta.Parse(ScaffoldFixtures.MetaDataJson));

        Assert.Contains(".ParseCases<int[], int[][], int>()", program);
        Assert.Contains(".DetectAndRun();", program);
        Assert.Contains("[[1,4,2,3],[0,2,1,2]]", program);
        Assert.Contains("31", program);
        Assert.DoesNotContain("TODO", program);
    }

    [Fact]
    public void GenerateProgram_DesignProblem_FallsBackToTodoTemplate()
    {
        var question = ScaffoldFixtures.Question with { MetaDataJson = ScaffoldFixtures.DesignMetaDataJson };
        var program = CodeGenerator.GenerateProgram(question, ProblemMeta.Parse(question.MetaDataJson));

        Assert.Contains("TODO", program);
        Assert.Contains("MyHashMap", program);
    }

    [Fact]
    public void GenerateReadme_ProducesRepoStyleMarkdown()
    {
        var readme = CodeGenerator.GenerateReadme(ScaffoldFixtures.Question);

        Assert.StartsWith("# 3653. XOR After Range Multiplication Queries I", readme);
        Assert.Contains("# **Example 1:**", readme);
        Assert.Contains("# **Example 2:**", readme);
        Assert.Contains("# **Constraints:**", readme);

        // Code mit sup/sub bleibt HTML (inkl. Entities), damit 10^9 korrekt gerendert wird
        Assert.Contains("<code>1 &lt;= nums[i] &lt;= 10<sup>9</sup></code>", readme);

        // Beispielzeilen: Klammern escaped, Bold-Marker vorhanden
        Assert.Contains("**Input:** nums = \\[1,1,1\\], queries = \\[\\[0,2,1,4\\]\\]", readme);
        Assert.Contains("**Output:** 4", readme);

        // Hints als aufklappbare Details
        Assert.Contains("<details><summary>Hint 1</summary>", readme);

        // kein rohes HTML-Gerüst übrig
        Assert.DoesNotContain("<p>", readme);
        Assert.DoesNotContain("<div", readme);
        Assert.DoesNotContain("<span", readme);
    }

    [Fact]
    public void GenerateReadme_ClassicPreFormat_SeparatesInputOutputLines()
    {
        var question = ScaffoldFixtures.Question with
        {
            Content = ScaffoldFixtures.ClassicContentHtml,
            Hints = [],
        };

        var readme = CodeGenerator.GenerateReadme(question);

        Assert.Contains("**Input:** s = \"Leetcode\"\n\n**Output:** 6", readme);
    }
}

public class SolutionFileUpdaterTests : IDisposable
{
    private readonly string _tempDir = Directory.CreateTempSubdirectory("slnx-tests").FullName;

    public void Dispose() => Directory.Delete(_tempDir, recursive: true);

    private string WriteMainSlnx()
    {
        var path = Path.Combine(_tempDir, "LeetCodeDaily.slnx");
        File.WriteAllText(path, """
            <Solution>
              <Folder Name="/Problems/">
                <Project Path="Problems/1. A/1. A.csproj" />
                <Project Path="Problems/3. C/3. C.csproj" />
              </Folder>
              <Project Path="LeetCodeDaily/LeetCodeDaily.csproj" />
            </Solution>
            """);
        return path;
    }

    [Fact]
    public void AddToMainSolution_InsertsAlphabetically()
    {
        var path = WriteMainSlnx();

        var added = SolutionFileUpdater.AddToMainSolution(path, "Problems/2. B/2. B.csproj");

        Assert.True(added);
        var lines = File.ReadAllLines(path);
        var index1 = Array.FindIndex(lines, l => l.Contains("1. A.csproj"));
        var index2 = Array.FindIndex(lines, l => l.Contains("2. B.csproj"));
        var index3 = Array.FindIndex(lines, l => l.Contains("3. C.csproj"));
        Assert.True(index1 < index2 && index2 < index3);
    }

    [Fact]
    public void AddToMainSolution_ExistingProject_IsNotDuplicated()
    {
        var path = WriteMainSlnx();

        var added = SolutionFileUpdater.AddToMainSolution(path, "Problems/1. A/1. A.csproj");

        Assert.False(added);
        Assert.Single(File.ReadAllLines(path), l => l.Contains("1. A.csproj"));
    }

    [Fact]
    public void UpdateRecentSolution_CreatesPrependsAndTrims()
    {
        var path = Path.Combine(_tempDir, "LeetCodeDaily.Recent.slnx");

        for (int i = 1; i <= SolutionFileUpdater.RecentProblemCount + 2; i++)
        {
            SolutionFileUpdater.UpdateRecentSolution(path, $"Problems/{i}. P/{i}. P.csproj");
        }

        var content = File.ReadAllText(path);
        var problemLines = File.ReadAllLines(path).Where(l => l.Contains("<Project Path=\"Problems/")).ToArray();

        Assert.Equal(SolutionFileUpdater.RecentProblemCount, problemLines.Length);

        // neuestes Projekt oben, älteste rausgetrimmt
        Assert.Contains($"Problems/{SolutionFileUpdater.RecentProblemCount + 2}. P", problemLines[0]);
        Assert.DoesNotContain("Problems/1. P/", content);
        Assert.DoesNotContain("Problems/2. P/", content);

        // Core immer enthalten
        Assert.Contains("LeetCodeDaily/LeetCodeDaily.csproj", content);
    }
}
