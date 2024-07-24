using LeetCodeDaily.Core;

namespace _706._Design_HashMap;

public class Solution
{
    private readonly MyHashMap _myHashMap;

    public Solution()
    {
        _myHashMap = new MyHashMap();
    }

    [ResultGenerator]
    public int Do(Func<MyHashMap, int> action)
    {
        return action(_myHashMap);
    }
}