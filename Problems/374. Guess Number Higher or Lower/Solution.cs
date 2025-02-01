using LeetCodeDaily.Core;

namespace _374._Guess_Number_Higher_or_Lower;

public class GuessGame
{
    protected int _pick;

    protected int guess(int num)
    {
        if (num == _pick)
            return 0;
        else if (num < _pick)
            return 1;
        else
            return -1;
    }
}

/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is higher than the picked number
 *			      1 if num is lower than the picked number
 *               otherwise return 0
 * int guess(int num);
 */

public class Solution : GuessGame
{
    [ResultGenerator]
    public int GuessNumberDo(int n, int pick)
    {
        _pick = pick;
        return GuessNumber(n);
    }

    public int GuessNumber(int n)
    {
        Span<int> rml = stackalloc int[3];

        unsafe
        {
            fixed (int* r = rml, m = &rml[1], l = &rml[2])
            {
                *l = 1; // left
                *r = n; // right

                int g; // guess

                while (*l <= *r)
                {
                    *m = (*l + *r) >>> 1;

                    g = guess(*m);

                    if (g == 0)
                    {
                        return *m;
                    }

                    // all this effort just to avoid branching between g = 1 and g = -1, lol
                    *(m + g) = (*m) + g;
                }

                return *l;
            }
        }
    }
}