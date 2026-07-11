using System.Net.Http.Json;
using System.Text.Json;

namespace LeetCodeDaily.Scaffold;

/// <summary>Dünner Client für LeetCodes öffentliche GraphQL-API (kein Login nötig).</summary>
public sealed class LeetCodeClient : IDisposable
{
    private readonly HttpClient _http;

    public LeetCodeClient()
    {
        _http = new HttpClient { BaseAddress = new Uri("https://leetcode.com") };
        _http.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (LeetCodeDaily-Scaffold)");
        _http.DefaultRequestHeaders.Referrer = new Uri("https://leetcode.com/problemset/");
    }

    public async Task<string> GetDailyTitleSlugAsync()
    {
        var data = await QueryAsync(
            """
            query questionOfToday {
              activeDailyCodingChallengeQuestion {
                question { titleSlug }
              }
            }
            """);

        return data
            .GetProperty("activeDailyCodingChallengeQuestion")
            .GetProperty("question")
            .GetProperty("titleSlug")
            .GetString()!;
    }

    /// <summary>Liefert die Dailies des aktuellen und des Vormonats, neueste zuerst.</summary>
    public async Task<IReadOnlyList<QuestionSummary>> GetRecentDailiesAsync()
    {
        var today = DateTime.UtcNow;
        var previousMonth = today.AddMonths(-1);

        var challenges = new List<QuestionSummary>();
        challenges.AddRange(await GetMonthDailiesAsync(today.Year, today.Month));
        challenges.AddRange(await GetMonthDailiesAsync(previousMonth.Year, previousMonth.Month));

        return challenges
            .Where(c => string.Compare(c.Date, today.ToString("yyyy-MM-dd"), StringComparison.Ordinal) <= 0)
            .OrderByDescending(c => c.Date, StringComparer.Ordinal)
            .ToArray();
    }

    private async Task<IReadOnlyList<QuestionSummary>> GetMonthDailiesAsync(int year, int month)
    {
        var data = await QueryAsync(
            """
            query dailyCodingChallengeV2($year: Int!, $month: Int!) {
              dailyCodingChallengeV2(year: $year, month: $month) {
                challenges {
                  date
                  question { questionFrontendId title titleSlug difficulty }
                }
              }
            }
            """,
            new { year, month });

        return data
            .GetProperty("dailyCodingChallengeV2")
            .GetProperty("challenges")
            .EnumerateArray()
            .Select(c =>
            {
                var q = c.GetProperty("question");
                return new QuestionSummary(
                    q.GetProperty("questionFrontendId").GetString()!,
                    q.GetProperty("title").GetString()!,
                    q.GetProperty("titleSlug").GetString()!,
                    q.GetProperty("difficulty").GetString()!,
                    c.GetProperty("date").GetString());
            })
            .ToArray();
    }

    /// <summary>Sucht den titleSlug zu einer Aufgabennummer (questionFrontendId).</summary>
    public async Task<string?> FindTitleSlugByNumberAsync(string frontendId)
    {
        var data = await QueryAsync(
            """
            query problemsetQuestionList($categorySlug: String, $limit: Int, $skip: Int, $filters: QuestionListFilterInput) {
              problemsetQuestionList: questionList(
                categorySlug: $categorySlug
                limit: $limit
                skip: $skip
                filters: $filters
              ) {
                questions: data { questionFrontendId titleSlug }
              }
            }
            """,
            new { categorySlug = "", limit = 20, skip = 0, filters = new { searchKeywords = frontendId } });

        return data
            .GetProperty("problemsetQuestionList")
            .GetProperty("questions")
            .EnumerateArray()
            .Where(q => q.GetProperty("questionFrontendId").GetString() == frontendId)
            .Select(q => q.GetProperty("titleSlug").GetString())
            .FirstOrDefault();
    }

    public async Task<QuestionDetail> GetQuestionAsync(string titleSlug)
    {
        var data = await QueryAsync(
            """
            query questionData($titleSlug: String!) {
              question(titleSlug: $titleSlug) {
                questionFrontendId
                title
                titleSlug
                difficulty
                isPaidOnly
                content
                exampleTestcases
                codeSnippets { langSlug code }
                hints
                metaData
              }
            }
            """,
            new { titleSlug });

        var q = data.GetProperty("question");

        if (q.ValueKind == JsonValueKind.Null)
            throw new InvalidOperationException($"Problem '{titleSlug}' was not found on LeetCode.");

        return new QuestionDetail(
            q.GetProperty("questionFrontendId").GetString()!,
            q.GetProperty("title").GetString()!,
            q.GetProperty("titleSlug").GetString()!,
            q.GetProperty("difficulty").GetString()!,
            q.GetProperty("isPaidOnly").GetBoolean(),
            q.GetProperty("content").GetString()
                ?? throw new InvalidOperationException($"No content for '{titleSlug}' (premium-only problem?)."),
            q.GetProperty("exampleTestcases").GetString() ?? "",
            q.GetProperty("codeSnippets").EnumerateArray()
                .Select(s => new CodeSnippet(s.GetProperty("langSlug").GetString()!, s.GetProperty("code").GetString()!))
                .ToArray(),
            q.GetProperty("hints").EnumerateArray().Select(h => h.GetString()!).ToArray(),
            q.GetProperty("metaData").GetString() ?? "{}");
    }

    private async Task<JsonElement> QueryAsync(string query, object? variables = null)
    {
        var response = await _http.PostAsJsonAsync("/graphql", new { query, variables });
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);

        if (doc.RootElement.TryGetProperty("errors", out var errors))
            throw new InvalidOperationException($"LeetCode API error: {errors.GetRawText()}");

        return doc.RootElement.GetProperty("data").Clone();
    }

    public void Dispose() => _http.Dispose();
}
