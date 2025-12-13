using LeetCodeDaily.Core;

namespace _3606.Coupon_Code_Validator;

public class Solution
{
    [ResultGenerator]
    public IList<string> ValidateCoupons(
        string[] code,
        string[] businessLine,
        bool[] isActive
    )
    {
        return
            code
                .Select((c, i) => new Coupon(c, businessLine[i], isActive[i]))
                .Where(c => c.IsValid)
                .OrderBy(c => c.BusinessLine[0])
                // lexico-what? is that a country
                .ThenBy(c => c.Code, StringComparer.Ordinal)
                .Select(x => x.Code)
                .ToArray();
    }

    public readonly record struct Coupon(string Code, string BusinessLine, bool IsActive)
    {
        public bool IsValid => IsActive && BusinessLineValid && CodeValid;

        public bool BusinessLineValid =>
            BusinessLine == "electronics" ||
            BusinessLine == "grocery" ||
            BusinessLine == "pharmacy" ||
            BusinessLine == "restaurant";

        public bool CodeValid =>
            Code.Length > 0 &&
            Code.All(c =>
                ('a' <= c && c <= 'z') ||
                ('A' <= c && c <= 'Z') ||
                ('0' <= c && c <= '9') ||
                c == '_');
    }
}