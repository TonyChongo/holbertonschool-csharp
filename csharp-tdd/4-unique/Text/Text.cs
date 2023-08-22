using System;
using System.Collections.Generic;

namespace Text
{
    /// <summary>
    /// Public class
    /// </summary>
    public class Str
    {
        /// <summary>
        /// Prototype
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int UniqueChar(string s)
        {
            // Create a dictionary to store character frequencies
            Dictionary<char, int> charFrequencies = new Dictionary<char, int>();

            // Iterate through the string and populate the character frequencies
            foreach (char c in s)
            {
                if (charFrequencies.ContainsKey(c))
                {
                    charFrequencies[c]++;
                }
                else
                {
                    charFrequencies[c] = 1;
                }
            }

            // Find the index of the first non-repeating character
            for (int i = 0; i < s.Length; i++)
            {
                if (charFrequencies[s[i]] == 1)
                {
                    return i;
                }
            }

            return -1; // No non-repeating character found
        }
    }
}
