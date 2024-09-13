using LeetCodeDaily.Core;
using System.Text;

namespace _1309.Decrypt_String_from_Alphabet_to_Integer_Mapping
{
    public class Solution
    {
        [ResultGenerator]
        public string FreqAlphabets(string s)
        {
            var sb = new StringBuilder();
            var n2 = s.Length - 2;
            int i = -1;

            while (++i < n2)
            {
                if (s[i + 2] != '#')
                {
                    sb.Append((char)(s[i] + 48));
                }
                else
                {
                    sb.Append((char)((s[i] - 48) * 10 + 48 + s[i + 1]));
                    i += 2;
                }
            }

            for (; i < s.Length; i++)
            {
                sb.Append((char)(s[i] + 48));
            }

            return sb.ToString();
        }
    }
}