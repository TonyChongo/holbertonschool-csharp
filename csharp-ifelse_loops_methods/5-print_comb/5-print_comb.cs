using System;

namespace _5_print_comb
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
        
            for (i = 0; i < 100; i++)
            {
                Console.Write("{0:D2}", i);
                if (i < 99)
                Console.Write(", ");
            }
        }
    }
}
