using System.Collections;
using System.Reflection;

namespace LeetCodeDaily.Extensions;

public static class Extensions
{
    public static IList<T> ToIList<T>(this IList<T> list)
    {
        return (IList<T>)list;
    }

    public static T[][] ParseMatrix<T>(
        this string matrixString,
        bool addEmpty = true,
        bool ignoreQuotes = true)
    {
        return matrixString.ParseList<T>(addEmpty, ignoreQuotes).Select(x => x.ToArray()).ToArray();
    }

    public static IList<IList<T>> ParseList<T>(
        this string listString,
        bool addEmpty = true,
        bool ignoreQuotes = true)
    {
        var result = new List<IList<T>>();

        if (listString.StartsWith("[["))
            listString = listString.Substring(1, listString.Length - 1);

        if (listString.EndsWith("]]"))
            listString = listString.Substring(0, listString.Length - 1);

        bool started = false;

        var current = new List<T>();
        var currentItem = string.Empty;
        for (int i = 0; i < listString.Length; i++)
        {
            if (listString[i] == '[')
            {
                current = new List<T>();
                currentItem = string.Empty;
                started = true;
                continue;
            }
            if (listString[i] == ']')
            {
                if (!string.IsNullOrEmpty(currentItem) || addEmpty)
                {
                    current.Add((T)Convert.ChangeType(currentItem, typeof(T)));
                    currentItem = string.Empty;
                }
                started = false;
                result.Add(current);
                continue;
            }
            if (started)
            {
                if (listString[i] == ' ' || (ignoreQuotes && listString[i] == '"'))
                    continue;

                if (listString[i] == ',')
                {
                    if (!string.IsNullOrEmpty(currentItem) || addEmpty)
                    {
                        current.Add((T)Convert.ChangeType(currentItem, typeof(T)));
                        currentItem = string.Empty;
                    }
                }
                else
                {
                    currentItem += listString[i];
                }
            }
        }

        return result;
    }

    public static T[] ParseArray<T>(this string arrayString, char delimiter = ',', bool removeQuotes = true)
    {
        arrayString = removeQuotes ? arrayString.Replace("\"", "") : arrayString;

        arrayString = arrayString.Trim(new[] { '[', ']' });
        var split = arrayString.Split(delimiter);
        return split.Select(x => (T)Convert.ChangeType(x, typeof(T))).ToArray();
    }

    public static void Print(this object obj, bool newLine = true, ConsoleColor? color = null)
    {
        bool setColor = false;
        try
        {
            if (color is not null)
            {
                Console.ForegroundColor = color.Value;
                setColor = true;
            }

            if (newLine)
            {
                Console.WriteLine(obj.TryGetObjectString());
            }
            else
            {
                Console.Write(obj.TryGetObjectString());
            }
        }
        finally
        {
            if (setColor)
                Console.ResetColor();
        }
    }

    public static string TryGetObjectString(this object? input)
    {
        if (input is null)
            return "null";

        if (input is not IEnumerable someEnumerable || input is string)
        {
            if (!(input.GetType().Name.Contains(nameof(ValueTuple))))
                return input.ToString()!;

            someEnumerable = input.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Select(x => x.GetValue(input)) as IEnumerable;
        }

        var result = "[";
        var first = true;
        foreach (var item in someEnumerable)
        {
            if (first)
            {
                first = false;
            }
            else
            {
                result += ", ";
            }

            result += TryGetObjectString(item);
        }
        result += "]";
        return result;
    }

    public static T[] SubArray<T>(this T[] data, int index, int length)
    {
        T[] result = new T[length];
        Array.Copy(data, index, result, 0, length);
        return result;
    }
}
