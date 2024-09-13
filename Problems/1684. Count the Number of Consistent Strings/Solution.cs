using LeetCodeDaily.Core;

namespace _1684.Count_the_Number_of_Consistent_Strings
{
    public class Solution
    {
        [ResultGenerator]
        public int CountConsistentStringsBitManipulation(string allowed, string[] words)
        {
            if (string.IsNullOrEmpty(allowed)) return 0;
            if (words.Length == 0) return 0;

            int consistentCount = 0;

            // we can use an int because allowed will never exceed 26 distinct chars
            // and an int has 32 bit
            int allowedMask = GetMask(allowed);

            for (int i = 0; i < words.Length; i++)
            {
                if ((GetMask(words[i]) | allowedMask) == allowedMask)
                    consistentCount++;
            }

            return consistentCount;

            int GetMask(string inputString)
            {
                int mask = 0;
                foreach (var ch in inputString)
                {
                    // setting the n-th bit for each character,
                    // where n is the ASCII value of that letter minus
                    // the ASCII value of the letter 'a', so that
                    // n(a) = 1, n(b) = 2, n(c) = 3 ...
                    mask |= 1 << (ch - 'a');
                }
                return mask;
            }
        }

        [ResultGenerator(ApproachIndex = 1)]
        public int CountConsistentStringsLinq(string allowed, string[] words) 
        {
            if (string.IsNullOrEmpty(allowed)) return 0;
            if (words.Length == 0) return 0;

            int consistentCount = 0;
            var allowedArray = allowed.ToCharArray();

            foreach (var word in words)
            {
                if (word.ToCharArray().Any(x => !allowedArray.Contains(x)))
                    continue;

                consistentCount++;
            }

            return consistentCount;
        }
    }
}