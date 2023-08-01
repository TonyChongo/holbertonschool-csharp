using System;
using System.Collections.Generic;

class LList
{
    public static int Length(LinkedList<int> myLList)
    {
        int count = 0;

        if (myLList != null)
        {
            LinkedListNode<int> currentNode = myLList.First;
            while (currentNode != null)
            {
                count++;
                currentNode = currentNode.Next;
            }
        }
        return count;
    }
}