using LeetCodeDaily.Core;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

namespace LeetCodeDaily.Extensions;

public static class CaseParsingExtensions
{
    public static void UnsafeRun(this string input, int approachIndex = 0)
    {
        var entryAssembly = Assembly.GetEntryAssembly();

        var solutionType =
            entryAssembly!
                .GetTypes()
                .FirstOrDefault(
                    x =>
                        x.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                        .Any(y =>
                            y.GetCustomAttributes<ResultGeneratorAttribute>()
                             .Any(z => z.ApproachIndex == approachIndex)));

        var resultGeneratorMethodInfo =
            solutionType!
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.GetCustomAttributes(typeof(ResultGeneratorAttribute)).Any(x => ((ResultGeneratorAttribute)x).ApproachIndex == approachIndex));

        var returnType = resultGeneratorMethodInfo!.ReturnType;

        var parameters = resultGeneratorMethodInfo.GetParameters();

        var parameterTypes = parameters.Select(p => p.ParameterType).ToArray();

        if (parameterTypes.Length > 8)
        {
            throw new InvalidOperationException("Too many input parameters (max 8).");
        }

        var typeArguments = new List<Type>();

        if (parameterTypes.Length == 1)
        {
            typeArguments.Add(parameterTypes[0]);
        }
        else if (parameterTypes.Length > 1)
        {
            var tupleType =
                typeof(ValueTuple<>).Assembly
                    .GetType("System.ValueTuple`" + parameterTypes.Length)!
                    .MakeGenericType(parameterTypes);

            typeArguments.Add(tupleType);
        }
        else
        {
            typeArguments.Add((Type)null!);
        }

        typeArguments.Add(returnType);

        var methodCall =
            typeof(CaseParsingExtensions)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .First(m => m.IsGenericMethod && m.Name == nameof(CaseParsingExtensions.ParseCases))
            .MakeGenericMethod(typeArguments.ToArray());

        var baseCase = methodCall.Invoke(null, new object[] { input });
        (baseCase as dynamic)!.DetectAndRun(approachIndex);
    }

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

    public static Case<(TInput1, TInput2), TResult> ParseCases<TInput1, TInput2, TResult>(this string rawInput)
    {
        return rawInput.ParseCases<(TInput1, TInput2), TResult>();
    }

    public static Case<(TInput1, TInput2, TInput3), TResult> ParseCases<TInput1, TInput2, TInput3, TResult>(this string rawInput)
    {
        return rawInput.ParseCases<(TInput1, TInput2, TInput3), TResult>();
    }

    public static Case<(TInput1, TInput2, TInput3, TInput4), TResult> ParseCases<TInput1, TInput2, TInput3, TInput4, TResult>(this string rawInput)
    {
        return rawInput.ParseCases<(TInput1, TInput2, TInput3, TInput4), TResult>();
    }

    public static Case<(TInput1, TInput2, TInput3, TInput4, TInput5), TResult> ParseCases<TInput1, TInput2, TInput3, TInput4, TInput5, TResult>(this string rawInput)
    {
        return rawInput.ParseCases<(TInput1, TInput2, TInput3, TInput4, TInput5), TResult>();
    }

    public static Case<(TInput1, TInput2, TInput3, TInput4, TInput5, TInput6), TResult> ParseCases<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TResult>(this string rawInput)
    {
        return rawInput.ParseCases<(TInput1, TInput2, TInput3, TInput4, TInput5, TInput6), TResult>();
    }

    public static Case<(TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TInput7), TResult> ParseCases<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TInput7, TResult>(this string rawInput)
    {
        return rawInput.ParseCases<(TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TInput7), TResult>();
    }

    public static Case<(TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TInput7, TInput8), TResult> ParseCases<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TInput7, TInput8, TResult>(this string rawInput)
    {
        return rawInput.ParseCases<(TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TInput7, TInput8), TResult>();
    }

    private static object ParseLine(string line, Type targetType)
    {
        if (ParserRegistry.TryParse(line, targetType, out var custom))
            return custom;

        if (line == "null" && !targetType.IsValueType)
            return null!;

        if (targetType == typeof(TreeNode))
            return TreeNode.Deserialize(line)!;

        if (targetType == typeof(ListNode))
            return ListNode.Parse(line)!;

        // IList<T> / IList<IList<T>> (LeetCode loves these)
        if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(IList<>))
        {
            var itemType = targetType.GetGenericArguments()[0];

            if (itemType.IsGenericType && itemType.GetGenericTypeDefinition() == typeof(IList<>))
            {
                var parseListMethod =
                    typeof(Extensions)
                    .GetMethods(BindingFlags.Public | BindingFlags.Static)
                    .First(m => m.IsGenericMethod && m.Name == nameof(Extensions.ParseList))
                    .MakeGenericMethod(itemType.GetGenericArguments()[0]);

                return parseListMethod.Invoke(null, new object[] { line, Type.Missing, Type.Missing })!;
            }

            var arrayType = itemType.MakeArrayType();
            return ParseLine(line, arrayType);
        }

        if (targetType == typeof(string))
            return StripSurroundingQuotes(line);

        if (targetType == typeof(char))
        {
            var trimmed = StripSurroundingQuotes(line.Trim('\''));
            if (trimmed.Length != 1)
                throw new FormatException($"Cannot parse '{line}' as char.");
            return trimmed[0];
        }

        if (targetType.IsArray)
        {
            var elemType = targetType.GetElementType()!;

            if (elemType.IsArray)
            {
                var castMethod = 
                    typeof(Extensions)
                    .GetMethods(BindingFlags.Public | BindingFlags.Static)
                    .First(m => m.IsGenericMethod && m.Name == nameof(Extensions.ParseMatrix))
                    .MakeGenericMethod(elemType.GetElementType()!);

                //var parameters = castMethod.GetParameters();

                //var args = new List<object>(parameters.Length);



                return castMethod.Invoke(null, new object[] { line, Type.Missing, Type.Missing })!;
            }

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
                .Select(s => Convert.ChangeType(s.Trim(), elemType, CultureInfo.InvariantCulture))
                .ToArray();

            return rawValues.ToArrayOfType(elemType);
        }

        return Convert.ChangeType(line, targetType, CultureInfo.InvariantCulture);
    }

    private static string StripSurroundingQuotes(string line)
    {
        if (line.Length >= 2 && line.StartsWith('"') && line.EndsWith('"'))
            return line.Substring(1, line.Length - 2);

        return line;
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