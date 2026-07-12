using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

namespace LeetCodeDaily.Tests;

public class CaseParsingTests
{
    [Fact]
    public void ParseCases_SingleIntInput_ParsesInputAndExpectedResult()
    {
        var baseCase = """
            5
            7

            3
            4
            """.ParseCases<int, int>();

        Assert.Equal(5, baseCase.Input);
        Assert.Equal(7, baseCase.ExpectedResult);

        var sub = Assert.Single(baseCase.SubCases!);
        Assert.Equal(3, sub.Input);
        Assert.Equal(4, sub.ExpectedResult);
    }

    [Fact]
    public void ParseCases_TupleInput_ParsesArrayAndMatrix()
    {
        var baseCase = """
            [1,1,1]
            [[0,2,1,4]]
            4
            """.ParseCases<int[], int[][], int>();

        Assert.Equal(new[] { 1, 1, 1 }, baseCase.Input.Item1);
        Assert.Equal(new[] { new[] { 0, 2, 1, 4 } }, baseCase.Input.Item2);
        Assert.Equal(4, baseCase.ExpectedResult);
    }

    [Fact]
    public void ParseCases_QuotedString_StripsSurroundingQuotes()
    {
        var baseCase = """
            "Leetcode"
            6
            """.ParseCases<string, int>();

        Assert.Equal("Leetcode", baseCase.Input);
    }

    [Fact]
    public void ParseCases_UnquotedString_IsKeptAsIs()
    {
        var baseCase = """
            Leetcode
            6
            """.ParseCases<string, int>();

        Assert.Equal("Leetcode", baseCase.Input);
    }

    [Fact]
    public void ParseCases_StringExpectedResult_StripsQuotes()
    {
        var baseCase = """
            2
            "ab"
            """.ParseCases<int, string>();

        Assert.Equal("ab", baseCase.ExpectedResult);
    }

    [Fact]
    public void ParseCases_CharInput_AcceptsQuotedAndBareForms()
    {
        Assert.Equal('a', """
            "a"
            1
            """.ParseCases<char, int>().Input);

        Assert.Equal('a', """
            'a'
            1
            """.ParseCases<char, int>().Input);

        Assert.Equal('a', """
            a
            1
            """.ParseCases<char, int>().Input);
    }

    [Fact]
    public void ParseCases_StringArray_ParsesQuotedElements()
    {
        var baseCase = """
            ["abc","de,f",""]
            0
            """.ParseCases<string[], int>();

        Assert.Equal(new[] { "abc", "de,f", "" }, baseCase.Input);
    }

    [Fact]
    public void ParseCases_IListOfIList_IsSupported()
    {
        var baseCase = """
            [[1,2],[3,4]]
            0
            """.ParseCases<IList<IList<int>>, int>();

        Assert.Equal(2, baseCase.Input.Count);
        Assert.Equal(new[] { 1, 2 }, baseCase.Input[0]);
        Assert.Equal(new[] { 3, 4 }, baseCase.Input[1]);
    }

    [Fact]
    public void ParseCases_IListOfInt_IsSupported()
    {
        var baseCase = """
            [1,2,3]
            0
            """.ParseCases<IList<int>, int>();

        Assert.Equal(new[] { 1, 2, 3 }, baseCase.Input);
    }

    [Fact]
    public void ParseCases_TreeNodeInput_IsDeserialized()
    {
        var baseCase = """
            [1,null,2,3]
            0
            """.ParseCases<TreeNode, int>();

        Assert.Equal(1, baseCase.Input.val);
        Assert.Null(baseCase.Input.left);
        Assert.Equal(2, baseCase.Input.right!.val);
        Assert.Equal(3, baseCase.Input.right.left!.val);
    }

    [Fact]
    public void ParseCases_ListNodeInput_IsDeserialized()
    {
        var baseCase = """
            [1,2,3]
            0
            """.ParseCases<ListNode, int>();

        Assert.Equal("[1,2,3]", baseCase.Input.ToString());
    }

    [Fact]
    public void ParseCases_NullLiteral_YieldsNullForReferenceTypes()
    {
        var baseCase = """
            null
            0
            """.ParseCases<TreeNode, int>();

        Assert.Null(baseCase.Input);
    }

    [Fact]
    public void ParseCases_WrongLineCount_Throws()
    {
        Assert.Throws<InvalidOperationException>(() => """
            1
            2
            3
            """.ParseCases<int, int>());
    }

    [Fact]
    public void ParseCases_BooleanAndDouble_AreParsed()
    {
        var boolCase = """
            true
            false
            """.ParseCases<bool, bool>();
        Assert.True(boolCase.Input);
        Assert.False(boolCase.ExpectedResult);

        var doubleCase = """
            2.5
            7.25
            """.ParseCases<double, double>();
        Assert.Equal(2.5, doubleCase.Input);
        Assert.Equal(7.25, doubleCase.ExpectedResult);
    }
}
