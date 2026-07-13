public static class Precompute
{
    public static void Do()
    {

        List<int> res = new();

        for (int i = 10; i <= 1_000_000_000; i++)
        {
            if (CheckIsSequential(i))
            {
                res.Add(i);
            }
        }


        foreach (var r in res)
        {
            Console.WriteLine(r);
        }
    }

    public static bool CheckIsSequential(int num)
    {
        int prev = num % 10;
        num /= 10;

        while (num > 0)
        {
            var dig = num % 10;
            if (dig != prev - 1)
            {
                return false;
            }
            num /= 10;
            prev = dig;
        }

        return true;
    }
}


