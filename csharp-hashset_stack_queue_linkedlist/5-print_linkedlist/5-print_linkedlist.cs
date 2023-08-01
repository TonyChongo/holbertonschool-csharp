using System;
using System.Collections.Generic;

class LList
{
    public static LinkedList<int> CreatePrint(int size)
    {
        LinkedList<int> list = new LinkedList<int>();

        if (size < 0)
        {
            return list;
        }

        for (int i = 0; i < size; i++)
        {
            list.AddLast(i);
        }

        foreach (int value in list)
        {
            Console.WriteLine(value);
        }
        return list;
    }
}