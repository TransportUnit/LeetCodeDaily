using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;
using System.Text;

namespace _706._Design_HashMap;

public class Solution
{
    [ResultGenerator]
    public string PerformActions(string actionsInput, string valuesInput)
    {
        StringBuilder sb = new();
        sb.Append("[");

        MyHashMap? hash = null;

        List<Func<int?>> actions = new();

        var actionsStrings = actionsInput.ParseArray<string>(removeQuotes: true);

        int valuePointer = 0;

        foreach (var action in actionsStrings)
        {
            var vals = GetValue();

            switch (action.ToLower())
            {
                case "myhashmap":
                    {
                        actions.Add(() => { hash = new MyHashMap(); return null; });
                        break;
                    }
                case "put":
                    {
                        actions.Add(() => { hash!.Put(vals[0], vals[1]); return null; });
                        break;
                    }
                case "get":
                    {
                        actions.Add(() => { return hash!.Get(vals[0]); });
                        break;
                    }
                case "remove":
                    {
                        actions.Add(() => { hash!.Remove(vals[0]); return null; });
                        break;
                    }
            }
        }

        bool first = true;
        foreach (var action in actions)
        {
            if (first)
            {
                first = false;
            }
            else
            {
                sb.Append(",");
            }

            int? result = action();
            sb.Append(result?.ToString() ?? "null");
        }

        sb.Append("]");
        return sb.ToString();

        int[] GetValue()
        {
            string curr = "";
            List<int> vals = new();

            while (valuePointer < valuesInput.Length &&
                   valuesInput[valuePointer] != ']')
            {
                if (valuesInput[valuePointer] >= '0' &&
                    valuesInput[valuePointer] <= '9')
                {
                    curr += valuesInput[valuePointer];
                }
                else
                {
                    if (curr.Length > 0)
                    {
                        vals.Add(int.Parse(curr));
                    }
                    curr = "";
                }

                valuePointer++;
            }
            if (curr.Length > 0)
            {
                vals.Add(int.Parse(curr));
            }
            valuePointer++;

            return vals.ToArray();
        }
    }
}