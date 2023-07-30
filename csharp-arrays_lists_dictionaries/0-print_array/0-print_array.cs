using System;

class Array
{
    public static int[] CreatePrint(int size)
    {
        if (size == 0)
        {
            Console.WriteLine();
            return new int[0];
        }
        else if (size < 0)
        {
            Console.WriteLine("Size cannot be negative");
            return null;
        }

        int[] newArray = new int[size];
        for (int i = 0; i < size; i++)
        {
            newArray[i] = i;
        }

        for (int i = 0; i < size; i++)
        {
            Console.Write(newArray[i] + " ");
        }
        Console.WriteLine();

        return newArray;
    }
}