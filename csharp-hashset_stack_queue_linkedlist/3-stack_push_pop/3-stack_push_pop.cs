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
        Console.WriteLine("Stack contains " + search + ": " + containsSearch);

        if (containsSearch)
        {
            Stack<string> tempStack = new Stack<string>();
            while (aStack.Peek() != search)
            {
                tempStack.Push(aStack.Pop());
            }
            aStack.Pop(); // Remove the search item
            while (tempStack.Count > 0)
            {
                aStack.Push(tempStack.Pop());
            }
        }
        aStack.Push(newItem);

        return aStack;
    }
}