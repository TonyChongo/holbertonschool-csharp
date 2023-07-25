using System;

namespace _6_print_comb2
{
    class Program
    {
        static void Main(string[] args)
        {
            int first;
            int second;

            for (first = 0; first < 9; first++)
            {
                for (second = first + 1; second <= 9; second++)
                {
                    Console.Write("{0}{1}", first, second);
                    if (first < 8 || second < 9)
                    {
                        Console.Write(", ");
                    }
                }
            }
            Console.Write("\n");
        }
    }
}
