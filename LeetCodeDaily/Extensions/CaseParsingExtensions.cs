using LeetCodeDaily.Core;
using System.Text.RegularExpressions;

namespace LeetCodeDaily.Extensions;

public static class CaseParsingExtensions
{
    public static Case<TInput, TResult> ParseCases<TInput, TResult>(this string rawInput)
    {
        var caseBlocks = Regex
            .Split(rawInput.Trim(), @"\r?\n\s*\r?\n")
            .Where(block => !string.IsNullOrWhiteSpace(block))
            .ToArray();

        if (caseBlocks.Length == 0)
            throw new ArgumentException("No valid cases found.");

        var inputType = typeof(TInput);
        var isTuple = inputType.IsValueTuple();

        Type[] tupleTypes = isTuple ? inputType.GetGenericArguments() : new[] { inputType };

        Case<TInput, TResult>? baseCase = null;

        foreach (var block in caseBlocks)
        {
            var lines = block
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(l => l.Trim())
                .ToArray();

            if (lines.Length != tupleTypes.Length + 1)
            {
                throw new InvalidOperationException(
                    $"Expected {tupleTypes.Length} input line(s) and 1 expected result line, but got {lines.Length}.");
            }

            var parsedInputs = new object[tupleTypes.Length];
            for (int i = 0; i < tupleTypes.Length; i++)
            {
                parsedInputs[i] = ParseLine(lines[i], tupleTypes[i]);
            }

            object finalInput = isTuple
                ? Activator.CreateInstance(typeof(ValueTuple<>).Assembly
                      .GetType("System.ValueTuple`" + tupleTypes.Length)!
                      .MakeGenericType(tupleTypes), parsedInputs)!
                : parsedInputs[0];

            var expectedResult = (TResult)ParseLine(lines.Last(), typeof(TResult));

            if (baseCase == null)
                baseCase = new Case<TInput, TResult>((TInput)finalInput, expectedResult);
            else
                baseCase.CreateCase((TInput)finalInput, expectedResult);
        }

        return baseCase!;
    }

    private static object ParseLine(string line, Type targetType)
    {
        if (targetType.IsArray)
        {
            var elemType = targetType.GetElementType()!;

            // Spezialfall: string[]
            if (elemType == typeof(string))
            {
                return Regex.Matches(line, "\"(.*?)\"")
                    .Cast<Match>()
                    .Select(m => m.Groups[1].Value)
                    .ToArray();
            }

            // Standardfall für int[], double[], etc.
            var rawValues = line
                .Trim('[', ']')
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => Convert.ChangeType(s.Trim(), elemType))
                .ToArray();

            return rawValues.ToArrayOfType(elemType);
        }

        return Convert.ChangeType(line, targetType);
    }

    private static Array ToArrayOfType(this IEnumerable<object> source, Type elementType)
    {
        var array = Array.CreateInstance(elementType, source.Count());
        int i = 0;
        foreach (var item in source)
            array.SetValue(item, i++);
        return array;
    }

    public static bool IsValueTuple(this Type type)
    {
        if (!type.IsGenericType) return false;

        var def = type.GetGenericTypeDefinition();
        return def == typeof(ValueTuple<>) || def == typeof(ValueTuple<,>) ||
               def == typeof(ValueTuple<,,>) || def == typeof(ValueTuple<,,,>) ||
               def == typeof(ValueTuple<,,,,>) || def == typeof(ValueTuple<,,,,,>) ||
               def == typeof(ValueTuple<,,,,,,>) || def == typeof(ValueTuple<,,,,,,,>);
    }
}