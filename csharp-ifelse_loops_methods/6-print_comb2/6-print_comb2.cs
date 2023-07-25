using System;

namespace _6_print_comb2
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = i; j < 10; j++)
                {
                    if (i != j)
                    {
                        Console.Write($"{i}{j}{(count == 44 ? "\n" : ", ")}");
                        count++;
                    }
                }
            }
        }
    }
}
