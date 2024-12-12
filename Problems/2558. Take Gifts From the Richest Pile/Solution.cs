using LeetCodeDaily.Core;

namespace _2558.Take_Gifts_From_the_Richest_Pile;

public class Solution
{
    [ResultGenerator]
    public long PickGifts(int[] gifts, int k)
    {
        long sum = 0;
        int n = gifts.Length;

        var priorityQueue = new PriorityQueue<int, int>(n);

        foreach (var gift in gifts)
        {
            sum += gift;
            priorityQueue.Enqueue(gift, -gift);
        }

        while(k-- > 0 && sum > n)
        {
            var element = priorityQueue.Dequeue();
            sum -= element;
            element = (int)Math.Sqrt(element);
            sum += element;
            priorityQueue.Enqueue(element, -element);
        }

        return sum;
    }
}