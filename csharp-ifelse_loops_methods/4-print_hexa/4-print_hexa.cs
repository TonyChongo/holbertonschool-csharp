using System;

namespace _4_print_hexa
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
        
            while (i <= 98)
            {
                Console.Write("{0} = 0x{0:X}\n", i, i);
                i++;
            }
        }
    }
}
