using System;
using System.Collections.Generic;

class LList
{
    public static void Delete(LinkedList<int> myLList, int index)
    {
        LinkedListNode<int> currentNode = myLList.First;
        for (int i = 0; currentNode != null; i++)
        {
            if (i == index)
            {
                myLList.Remove(currentNode);
            }
            currentNode = currentNode.Next;
        }
    }
}