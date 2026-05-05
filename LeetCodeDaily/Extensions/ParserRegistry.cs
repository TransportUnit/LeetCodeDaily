namespace LeetCodeDaily.Extensions;

public static class ParserRegistry
{
    private static readonly Dictionary<Type, Func<string, object>> _parsers = new();

    public static void Register<T>(Func<string, T> parser)
    {
        _parsers[typeof(T)] = s => parser(s)!;
    }

    public static bool TryParse(string input, Type targetType, out object result)
    {
        if (_parsers.TryGetValue(targetType, out var parser))
        {
            result = parser(input);
            return true;
        }

        result = default!;
        return false;
    }
}