using LeetCodeDaily.Core;

namespace _125._Valid_Palindrome;

public class Solution
{
    [ResultGenerator]
    public bool IsPalindrome(string s)
    {
        // ASCII representation
        // 48: 0
        // 57: 9

        // 65:  A
        // 90:  Z

        // 97:  a
        // 122: z

        // some optimization
        ReadOnlySpan<char> sp = s.AsSpan();

        // we have declare an unsafe block in order to use actual pointers
        unsafe
        {
            // we declare pointers at the start and the end of the string
            fixed (char* first = sp, last = &sp[^1])
            {
                // since we can't iterate fixed pointers, we pass the reference to yet another pair of pointers
                char* l = first;
                char* r = last;

                while (true)
                {
                    // move left pointer to the next valid character
                    while (!IsAlphanumeric(l) && l < r)
                    {
                        // incrementing the pointer moves it to the next index within the array
                        l++;
                    }

                    // both pointers met -> there were no valid characters
                    if (l >= r)
                        return true;

                    // move right pointer to the next valid character
                    while (!IsAlphanumeric(r) && r > l)
                    {
                        r--;
                    }

                    // decimal representation value of selected characters does not match
                    if (*l != *r)
                    {
                        // either character is a number -> not a palindrome
                        if (*l < 'A' || *r < 'A')
                            return false;

                        // check if letter case is different ('b', 'B')
                        // if not -> not a palindrome
                        if (((*l) + 32) != *r && ((*r) + 32) != *l)
                            return false;
                    }

                    // iterate both pointers to the next character
                    l++;
                    r--;
                }

                // nothing left to compare -> we have a palindrome
                //return true;
            }
        }
    }

    private unsafe static bool IsAlphanumeric(char* ch)
    {
        // "Alphanumeric characters include letters and numbers." - RIP acceptance rate
        return 'a' <= *ch && *ch <= 'z' || 'A' <= *ch && *ch <= 'Z' || '0' <= *ch && *ch <= '9';
    }
}