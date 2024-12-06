namespace _232.Implement_Queue_using_Stacks;

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */

public class MyQueue
{
    // item in front of the queue -> first item to remove
    private Entry? _front = null;
    // last added item
    private Entry? _back = null;

    public MyQueue() { }

    public void Push(int x)
    {
        if (Empty())
        {
            _front = new Entry(x);
            _back = _front;
        }
        else
        {
            var entry = new Entry(x);
            _back.Previous = entry;
            _back = entry;
        }
    }

    public int Pop()
    {
        var previous = _front?.Previous;
        var value = _front?.Value ?? 0;
        _front = previous;
        if (_front is null)
        {
            _back = null;
        }
        return value;
    }

    public int Peek() => _front?.Value ?? 0;

    public bool Empty() => _front is null;
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */