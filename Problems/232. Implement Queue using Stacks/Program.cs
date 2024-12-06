using _232.Implement_Queue_using_Stacks;
using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase<Func<MyQueue, object>, object>(
        queue =>
        {
            queue.Push(1);
            queue.Push(2);
            return queue.Peek();
        },
        1)
    .CreateCase(
        queue =>
        {
            return queue.Pop();
        },
        1)
    .CreateCase(
        queue =>
        {
            return queue.Empty();
        },
        false)
    .CreateCase(
        queue =>
        {
            queue.Push(5);
            return queue.Pop();
        },
        2)
    .CreateCase(
        queue =>
        {
            return queue.Empty();
        },
        false)
    .CreateCase(
        queue =>
        {
            return queue.Pop();
        },
        5)
    .CreateCase(
        queue =>
        {
            return queue.Empty();
        },
        true)
    .Run();