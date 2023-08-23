using System;

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
        public static int CamelCase(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            int wordCount = 1; // Initialize with 1 because the first word doesn't have a capital letter

            foreach (char c in s)
            {
                if (char.IsUpper(c))
                {
                    wordCount++;
                }
            }

            return wordCount;
        }
    }

    /// <summary>
    /// New public class
    /// </summary>
    class Program
    {
        /// <summary>
        /// prototype
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string input = "thisIsCamelCaseString";
            int wordCount = Text.Str.CamelCase(input);
            Console.WriteLine($"Number of words: {wordCount}");
        }
    }
}
