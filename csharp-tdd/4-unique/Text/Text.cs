using System;
using System.Collections.Generic;

namespace Text
{
    /// <summary>
    /// Class
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
            // Create a dictionary to store the frequency of each character
            Dictionary<char, int> charFrequency = new Dictionary<char, int>();

            // Populate the dictionary with character frequencies
            foreach (char c in s)
            {
                if (charFrequency.ContainsKey(c))
                {
                    charFrequency[c]++;
                }
                else
                {
                    charFrequency[c] = 1;
                }
            }

            // Find the index of the first non-repeating character
            for (int i = 0; i < s.Length; i++)
            {
                if (charFrequency[s[i]] == 1)
                {
                    return i;
                }
            }

            return -1; // No non-repeating character found
        }
    }

    /// <summary>
    /// Class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Prototype
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string input = "leetcode";
            int index = Str.UniqueChar(input);
            
            if (index != -1)
            {
                Console.WriteLine($"The index of the first non-repeating character in '{input}' is {index}");
            }
            else
            {
                Console.WriteLine("No non-repeating character found.");
            }
        }
    }
}





