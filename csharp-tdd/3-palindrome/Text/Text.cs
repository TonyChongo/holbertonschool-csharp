using System;
using System.Linq;
using System.Text.RegularExpressions;

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
        public static bool IsPalindrome(string s)
        {
            // Remove spaces and punctuation and convert to lowercase
            string cleanedString = Regex.Replace(s, @"[\s\p{P}]", "").ToLower();
            
            // Compare the cleaned string with its reverse
            return cleanedString == new string(cleanedString.Reverse().ToArray());
        }
    }
}
