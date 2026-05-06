using LeetCodeDaily.Core;

namespace _796.Rotate_String;

public class Solution
{
    [ResultGenerator]
    public bool RotateString(string s, string goal) 
    {
        return s.Length == goal.Length && (s+s).Contains(goal);
    }
    

    [ResultGenerator(ApproachIndex = 1)]
    public bool RotateStringKMP(string s, string goal)
    {
        if (s.Length != goal.Length)
            return false;

        var doubledString = s + s;

        return KMPSearch(doubledString, goal);
    }

    private static bool KMPSearch(string text, string pattern)
    {
        // Precompute the LPS (Longest Prefix Suffix) array for the pattern
        int[] lps = ComputeLPS(pattern);

        int textIndex = 0;
        int patternIndex = 0;
        int textLength = text.Length;
        int patternLength = pattern.Length;

        // Loop through the text to find the pattern
        while (textIndex < textLength)
        {
            // If characters match, move both indices forward
            if (text[textIndex] == pattern[patternIndex])
            {
                textIndex++;
                patternIndex++;
                // If we've matched the entire pattern, return true
                if (patternIndex == patternLength) return true;
            }
            // If there's a mismatch after some matches, use the LPS array to skip unnecessary comparisons
            else if (patternIndex > 0)
            {
                patternIndex = lps[patternIndex - 1];
            }
            // If no matches, move to the next character in text
            else
            {
                textIndex++;
            }
        }
        // Pattern not found in text
        return false;
    }

    private static int[] ComputeLPS(string pattern)
    {
        int patternLength = pattern.Length;
        int[] lps = new int[patternLength];
        int length = 0;
        int index = 1;

        // Build the LPS array
        while (index < patternLength)
        {
            // If characters match, increment length and set lps value
            if (pattern[index] == pattern[length])
            {
                length++;
                lps[index++] = length;
            }
            // If there's a mismatch, update length using the previous LPS value
            else if (length > 0)
            {
                length = lps[length - 1];
            }
            // No match and length is zero
            else
            {
                lps[index++] = 0;
            }
        }
        return lps;
    }
}