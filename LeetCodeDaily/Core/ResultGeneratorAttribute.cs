using System.Linq.Expressions;
using System.Reflection;

namespace LeetCodeDaily.Core;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class ResultGeneratorAttribute : Attribute
{
    public static object? SolutionInstance { get; private set; } = null;

    /// <summary>
    /// Can be used to differentiate between different approaches for the same task.<br/>
    /// <see cref="Detect(int)"/> presets the case to be run with the provided approach.<br/>
    /// Default value: 0.
    /// </summary>
    public int ApproachIndex { get; set; } = 0;

    /// <summary>
    /// Searches for a method with the <see cref="ResultGeneratorAttribute"/> and the provided approachIndex and presets the generic <see cref="Case{TInput, TResult}"/> for the selected method.
    /// </summary>
    /// <param name="approachIndex"></param>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static void Detect(int approachIndex = 0)
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
                .FirstOrDefault(x => x.GetCustomAttributes(typeof(ResultGeneratorAttribute)).Any(x => ((ResultGeneratorAttribute)x).ApproachIndex == approachIndex));

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