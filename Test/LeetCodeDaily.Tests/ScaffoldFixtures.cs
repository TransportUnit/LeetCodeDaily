using LeetCodeDaily.Scaffold;

namespace LeetCodeDaily.Tests;

/// <summary>
/// Recreated API responses in the format of LeetCode's GraphQL API
/// (problem 3653, whose hand-written README in this repo serves as the style reference).
/// </summary>
public static class ScaffoldFixtures
{
    public const string ContentHtml = """
        <p>You are given an integer array <code>nums</code> of length <code>n</code> and a 2D integer array <code>queries</code> of size <code>q</code>, where <code>queries[i] = [l<sub>i</sub>, r<sub>i</sub>, k<sub>i</sub>, v<sub>i</sub>]</code>.</p>

        <p>For each query, you must apply the following operations in order:</p>

        <ul>
        	<li>Set <code>idx = l<sub>i</sub></code>.</li>
        	<li>Update: <code>nums[idx] = (nums[idx] * v<sub>i</sub>) % (10<sup>9</sup> + 7)</code></li>
        </ul>

        <p>Return the <strong>bitwise XOR</strong> of all elements in <code>nums</code> after processing all queries.</p>

        <p>&nbsp;</p>
        <p><strong class="example">Example 1:</strong></p>

        <div class="example-block">
        <p><strong>Input:</strong> <span class="example-io">nums = [1,1,1], queries = [[0,2,1,4]]</span></p>

        <p><strong>Output:</strong> <span class="example-io">4</span></p>

        <p><strong>Explanation:</strong></p>

        <p>The array changes from <code>[1, 1, 1]</code> to <code>[4, 4, 4]</code>.</p>
        </div>

        <p><strong class="example">Example 2:</strong></p>

        <div class="example-block">
        <p><strong>Input:</strong> <span class="example-io">nums = [2,3,1,5,4], queries = [[1,4,2,3],[0,2,1,2]]</span></p>

        <p><strong>Output:</strong> <span class="example-io">31</span></p>
        </div>

        <p>&nbsp;</p>
        <p><strong>Constraints:</strong></p>

        <ul>
        	<li><code>1 &lt;= n == nums.length &lt;= 10<sup>3</sup></code></li>
        	<li><code>1 &lt;= nums[i] &lt;= 10<sup>9</sup></code></li>
        </ul>
        """;

    public const string ClassicContentHtml = """
        <p>Given a string <code>s</code>, count the letters.</p>

        <p><strong>Example 1:</strong></p>

        <pre>
        <strong>Input:</strong> s = "Leetcode"
        <strong>Output:</strong> 6
        <strong>Explanation:</strong> Six distinct letters.
        </pre>
        """;

    public const string MetaDataJson = """
        {"name":"xorAfterQueries","params":[{"name":"nums","type":"integer[]"},{"name":"queries","type":"integer[][]"}],"return":{"type":"integer"}}
        """;

    public const string DesignMetaDataJson = """
        {"classname":"MyHashMap","constructor":{"params":[]},"methods":[{"name":"put","params":[{"name":"key","type":"integer"},{"name":"value","type":"integer"}],"return":{"type":"void"}}],"systemdesign":true}
        """;

    public const string CSharpSnippet = """
        public class Solution {
            public int XorAfterQueries(int[] nums, int[][] queries) {

            }
        }
        """;

    public const string ExampleTestcases = "[1,1,1]\n[[0,2,1,4]]\n[2,3,1,5,4]\n[[1,4,2,3],[0,2,1,2]]";

    public static QuestionDetail Question => new(
        QuestionFrontendId: "3653",
        Title: "XOR After Range Multiplication Queries I",
        TitleSlug: "xor-after-range-multiplication-queries-i",
        Difficulty: "Medium",
        IsPaidOnly: false,
        Content: ContentHtml,
        ExampleTestcases: ExampleTestcases,
        CodeSnippets: [new CodeSnippet("csharp", CSharpSnippet)],
        Hints: ["Use <code>bruteforce</code>"],
        MetaDataJson: MetaDataJson);
}
