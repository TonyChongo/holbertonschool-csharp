using System;
using System.Collections.Generic;

class MyStack
{
    public static Stack<string> Info(Stack<string> aStack, string newItem, string search)
    {
        Console.WriteLine("Number of items: " + aStack.Count);
        if (aStack.Count > 0)
            Console.WriteLine("Top item: " + aStack.Peek());
        else
            Console.WriteLine("Stack is empty");

        bool containsSearch = aStack.Contains(search);
        Console.WriteLine("Stack contains \"" + search + "\": " + containsSearch);

        if (aStack.Contains(search))
        {
            while (aStack.Count > 0)
            {
                string currentItem = aStack.Peek();
                aStack.Pop();
                if (currentItem == search)
                    break;
            }
        }
        aStack.Push(newItem);
        return aStack;
    }
}