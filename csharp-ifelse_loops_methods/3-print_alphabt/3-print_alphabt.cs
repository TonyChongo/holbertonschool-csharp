using System;

namespace _3_print_alphabt
{
    class Program
    {
        static void Main(string[] args)
        {
            char alphabt;
        
            for (alphabt = 'a'; alphabt <= 'z'; alphabt++)
            {
                if (alphabt != 'q' && alphabt != 'e')
                {
                    Console.Write(alphabt);
                }
            }
        }
    }
}
