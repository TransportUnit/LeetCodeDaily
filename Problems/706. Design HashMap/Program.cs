using _706._Design_HashMap;
using LeetCodeDaily.Core;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase<Func<MyHashMap, int>, int>(
        hashMap =>
        {
            hashMap.Put(1, 1);
            hashMap.Put(2, 2);
            return hashMap.Get(1);
        },
        1)
    .CreateCase(
        hashMap =>
        {
            return hashMap.Get(3);
        },
        -1)
    .CreateCase(
        hashMap =>
        {
            hashMap.Put(2, 1);
            return hashMap.Get(2);
        },
        1)
    .CreateCase(
        hashMap =>
        {
            hashMap.Remove(2);
            return hashMap.Get(2);
        },
        -1)
    .Run();