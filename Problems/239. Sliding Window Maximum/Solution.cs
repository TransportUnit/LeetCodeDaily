using LeetCodeDaily.Core;

namespace _239.Sliding_Window_Maximum;

public class Solution
{
    [ResultGenerator]
    public int[] MaxSlidingWindowPriorityQueue(int[] nums, int k)
    {
        int n = nums.Length;
        int nResult = n - k + 1;

        int[] result = new int[nResult];

        PriorityQueue<int, int> maxQueue = new(k);

        for (int i = 0; i < k; i++)
        {
            maxQueue.Enqueue(i, -(nums[i]));
        }

        int dequeueAt = 0;
        int enqueueAt = k;

        for (int i = 0; i < nResult; i++)
        {
            var index = maxQueue.Peek();

            while (index < dequeueAt)
            {
                maxQueue.Dequeue();
                index = maxQueue.Peek();
            }
            dequeueAt++;
            result[i] = nums[index];

            if (enqueueAt < n)
            {
                maxQueue.Enqueue(enqueueAt, -(nums[enqueueAt]));
                enqueueAt++;
            }
        }

        return result;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public int[] MaxSlidingWindowDeque(int[] nums, int k)
    {
        int[] result = new int[nums.Length + 1 - k];
        LinkedList<int> dq = new();

        int index = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (dq.First?.Value <= i - k)
            {
                dq.RemoveFirst();
            }

            while (dq.Count > 0 && nums[i] > nums[dq.Last!.Value])
            {
                dq.RemoveLast();
            }

            dq.AddLast(i);

            if (i >= k - 1)
            {
                result[index++] = nums[dq.First!.Value];
            }
        }

        return result;
    }

    [ResultGenerator(ApproachIndex = 2)]
    public int[] MaxSlidingWindowArray(int[] nums, int k)
    {
        int[] result = new int[nums.Length + 1 - k];
        Span<int> dq = stackalloc int[nums.Length];

        int index = 0;

        // start points to the front of the deque
        // the front is also the max element / candidate for the current window
        int start = 0;
        // end - 1 points to the last added element in the back
        int end = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            // start < end => dq has elements
            // remove the oldest candidates if they are out of the window bounds
            // by moving start forward
            if (start < end && dq[start] <= i - k)
            {
                start++;
            }

            // start < end => dq has elements
            // then, remove all the newer elements if the newest addition is larger
            // because they cannot ever be the max for the current or future windows (newest item is larger)
            // this way, we maintain a decreasing order in the deque
            while (start < end && nums[dq[end - 1]] < nums[i])
            {
                // we move the end pointer back to "remove" the last element
                end--;
            }

            // we add the newest element at the end
            // if it is the largest element for the current window, it will also be the first element
            // (because we removed all smaller elements before it)
            dq[end++] = i;

            // once we have filled the first window, we can start recording results
            // until then, we just build up the deque
            if (i >= k - 1)
            {
                result[index++] = nums[dq[start]];
            }
        }

        return result;
    }

    //[ResultGenerator(ApproachIndex = 2)]
    //public int[] MaxSlidingWindowOptimized(int[] nums, int k)
    //{
    //    int[] result = new int[nums.Length + 1 - k];
    //    int tail = 0;
    //    int head = 0;
    //    int count = 0;
    //    Span<int> dq = stackalloc int[nums.Length];
    //    for (int i = 0; i < nums.Length; i++)
    //    {
    //        if (head < tail && dq[head] <= i - k)
    //        {
    //            head++;
    //        }

    //        while (head < tail && nums[i] >= nums[dq[tail - 1]])
    //        {
    //            tail--;
    //        }

    //        //add
    //        dq[tail++] = i;

    //        if (i >= k - 1)
    //        {
    //            result[count++] = nums[dq[head]];
    //        }
    //    }
    //    return result;
    //}
}