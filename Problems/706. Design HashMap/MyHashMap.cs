namespace _706._Design_HashMap;

public class MyHashMap
{
    private readonly int _cap;
    private readonly Slot[] _slots;
    private int _slotCount;

    public MyHashMap(int cap = 10000)
    {
        _cap = cap;
        _slots = new Slot[_cap];
    }

    private int Hash(int key)
    {
        return key % _cap;
    }

    public void Put(int key, int value)
    {
        var slotIndex = Hash(key);
        var slot = _slots[slotIndex];

        if (slot == null)
        {
            _slots[slotIndex] =
                new Slot()
                {
                    Key = key,
                    Value = value
                };
            return;
        }

        Slot? previous = null;
        while (slot != null && slot.Key != key)
        {
            previous = slot;
            slot = slot.Next;
        }

        if (slot == null)
        {
            previous!.Next =
                new Slot()
                {
                    Key = key,
                    Value = value
                };
            return;
        }

        slot.Value = value;
    }

    public int Get(int key)
    {
        var slot = _slots[Hash(key)];

        while (slot != null && slot.Key != key)
        {
            slot = slot.Next;
        }

        return slot?.Value ?? -1;
    }

    public void Remove(int key)
    {
        var slotIndex = Hash(key);
        var slot = _slots[slotIndex];

        if (slot == null)
            return;

        if (slot.Key == key)
        {
            _slots[slotIndex] = slot.Next!;
            return;
        }

        Slot? previous = null;
        while (slot != null && slot.Key != key)
        {
            previous = slot;
            slot = slot.Next;
        }

        if (slot == null)
            return;

        previous!.Next = slot.Next;
    }
}
