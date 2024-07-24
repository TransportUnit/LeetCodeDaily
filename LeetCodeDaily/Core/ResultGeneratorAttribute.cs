using System.Linq.Expressions;
using System.Reflection;

namespace LeetCodeDaily.Core;

public class ResultGeneratorAttribute : Attribute
{
    public static object? SolutionInstance { get; private set; } = null;

    public static void Detect()
    {
        var entryAssembly = Assembly.GetEntryAssembly();

        if (entryAssembly is null)
        {
            throw new NullReferenceException("Entry assembly was null");
        }

        var solutionType =
            entryAssembly
                .GetTypes()
                .FirstOrDefault(
                    x => x.GetMethods().Any(y => y.GetCustomAttributes(typeof(ResultGeneratorAttribute)).Any()));

        if (solutionType == null)
        {
            throw new InvalidOperationException("Could not find solution class type.");
        }

        SolutionInstance = Activator.CreateInstance(solutionType);

        if (SolutionInstance is null)
        {
            throw new InvalidOperationException("Could not create an instance of the solution class");
        }

        var resultGeneratorMethodInfo =
            solutionType
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.GetCustomAttributes(typeof(ResultGeneratorAttribute)).Any());

        if (resultGeneratorMethodInfo == null)
        {
            throw new InvalidOperationException("Could not find result generator method.");
        }

        var @delegate = CreateDelegate(resultGeneratorMethodInfo, SolutionInstance);
        Case.SetResultGenerator(@delegate);
    }

    private static Delegate CreateDelegate(MethodInfo methodInfo, object target)
    {
        var parmTypes = methodInfo.GetParameters().Select(parm => parm.ParameterType);
        var parmAndReturnTypes = parmTypes.Append(methodInfo.ReturnType).ToArray();
        var delegateType = Expression.GetDelegateType(parmAndReturnTypes);

        if (methodInfo.IsStatic)
            return methodInfo.CreateDelegate(delegateType);
        return methodInfo.CreateDelegate(delegateType, target);
    }
}