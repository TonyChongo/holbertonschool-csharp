using System;

/// <summary>
/// Public generic class
/// </summary>
/// <typeparam name="T"></typeparam>
public class Queue<T>
{
    /// <summary>
    /// Public node head
    /// </summary>
    public Node head;
    /// <summary>
    /// Public node tail
    /// </summary>
    public Node tail;
    private int count = 0;
    
    /// <summary>
    /// Public class name Node
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Public T value
        /// </summary>
        public T value;
        /// <summary>
        /// Public node next
        /// </summary>
        public Node next;

        /// <summary>
        /// Public node T value
        /// </summary>
        /// <param name="value"></param>
        public Node(T value)
        {
            this.value = value;
            this.next = null;
        }
    }

    /// <summary>
    /// Public method 
    /// </summary>
    /// <param name="value"></param>
    public void Enqueue(T value)
    {
        Node newNode = new Node(value);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.next = newNode;
            tail = newNode;
        }
        count++;
    }

    /// <summary>
    /// Public method Dequeue()
    /// </summary>
    /// <returns></returns>
    public T Dequeue()
    {
        if (head == null)
        {
            Console.WriteLine("Queue is empty");
            return default(T);
        }

        T value = head.value;
        head = head.next;
        count--;

        if (head == null)
        {
            tail = null;
        }

        return value;
    }

    /// <summary>
    /// Public int for counter
    /// </summary>
    /// <returns></returns>
    public int Count()
    {
        return count;
    }

    /// <summary>
    /// Public generic method that returns the Queue’s type
    /// </summary>
    /// <returns></returns>
    public string CheckType()
    {
        return typeof(T).ToString();
    }
}
