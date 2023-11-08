using System;
using System.Text;

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
    /// New public method name Peek
    /// </summary>
    /// <returns></returns>
    public T Peek()
    {
        if (head == null)
        {
            Console.WriteLine("Queue is empty");
            return default(T);
        }

        return head.value;
    }

    /// <summary>
    /// New methode name print
    /// </summary>
    public void Print()
    {
        if (head == null)
        {
            Console.WriteLine("Queue is empty");
            return;
        }

        Node current = head;
        while (current != null)
        {
            Console.WriteLine(current.value);
            current = current.next;
        }
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

    /// <summary>
    /// New method to concatenate the string
    /// </summary>
    /// <returns></returns>
    public string Concatenate()
    {
        if (count == 0)
        {
            Console.WriteLine("Queue is empty");
            return null;
        }

        if (typeof(T) != typeof(string) && typeof(T) != typeof(char))
        {
            Console.WriteLine("Concatenate() is for a queue of Strings or Chars only.");
            return null;
        }

        var builder = new StringBuilder();
        Node current = head;

        while (current != null)
        {
            builder.Append(current.value);
            if (typeof(T) == typeof(string))
            {
                builder.Append(" ");
            }
            current = current.next;
        }

        return builder.ToString().TrimEnd();
    }
}
