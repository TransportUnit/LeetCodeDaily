using System.Linq.Expressions;
using System.Reflection;

namespace LeetCodeDaily.Core;

public class Case
{
    public static Case<TInput, TResult> CreateCase<TInput, TResult>(TInput input, TResult expectedResult)
    {
        return new Case<TInput, TResult>(input, expectedResult);
    }

    public static void SetResultGenerator(Delegate @delegate)
    {
        var returnType = @delegate.Method.ReturnType;
        if (returnType == typeof(void))
            throw new InvalidOperationException("Delegate with return type 'void' is not supported.");

        var parameters = @delegate.Method.GetParameters();
        if (parameters.Count() > 8)
            throw new InvalidOperationException("Too many input parameters (max 8).");

        Type inputType = parameters.First().ParameterType;

        bool usedTuple = false;

        if (parameters.Count() > 1)
        {
            inputType =
                typeof(System.ValueTuple)
                .Assembly
                .GetTypes()
                .First(
                    x => x.Name.StartsWith(nameof(ValueTuple))
                    &&
                    x.GetGenericArguments().Length == parameters.Count())
                .MakeGenericType(parameters.Select(x => x.ParameterType).ToArray());

            usedTuple = true;
        }

        var inputExpression = Expression.Parameter(inputType);

        var inputProperties = new List<Expression>();

        if (usedTuple)
        {
            for (int i = 1; i <= parameters.Count(); i++)
            {
                inputProperties.Add(Expression.PropertyOrField(inputExpression, $"Item{i}"));
            }
        }
        else
        {
            inputProperties.Add(inputExpression);
        }

        // this creates a new instance of the solution class
        //var call = Expression.Call(Expression.New(@delegate.Target.GetType()), @delegate.Method, inputProperties);

        // this uses the provided instance instead
        var target = Expression.Constant(@delegate.Target);
        var call = Expression.Call(target, @delegate.Method, inputProperties);


        var convertedDelegate = Expression.Lambda(call, inputExpression).Compile();

        var genericSetResultGeneratorMethod =
            typeof(Case)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .First(m => m.IsGenericMethod && m.Name == nameof(Case.SetResultGenerator))
                .MakeGenericMethod(inputType, returnType);

        genericSetResultGeneratorMethod.Invoke(null, new object[] { @convertedDelegate });
    }

    public static void SetResultGenerator<TInput, TResult>(Func<TInput, TResult> resultGenerator)
    {
        Case<TInput, TResult>.ResultGenerator = resultGenerator;
    }

    public static void SetResultChecker<TInput, TResult>(Func<Case<TInput, TResult>, bool> resultChecker)
    {
        Case<TInput, TResult>.ResultChecker = resultChecker;
    }

    private static Func<TInput, TResult, bool> CastResultChecker<TInput, TResult>(Delegate @delegate)
    {
        var castedDelegate = (Func<TInput, TResult, bool>)@delegate;
        return castedDelegate;
    }
}
