using LeetCodeDaily.Core;

namespace _232.Implement_Queue_using_Stacks;

public class Solution
{
    private readonly MyQueue _myQueue;

    public Solution()
    {
        _myQueue = new MyQueue();
    }

    [ResultGenerator]
    public object Do(Func<MyQueue, object> action)
    {
        return action(_myQueue);
    }
}