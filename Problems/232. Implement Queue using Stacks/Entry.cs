namespace _232.Implement_Queue_using_Stacks;

public class Entry
{
    private byte _value;
    public int Value => _value;
    public Entry Previous { get; set; }

    public Entry(int value)
    {
        _value = (byte)value;
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */