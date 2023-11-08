using System;

/// <summary>
/// Public generic class
/// </summary>
/// <typeparam name="T"></typeparam>
public class Queue<T>
{
    /// <summary>
    /// Public generic method that returns the Queue’s type
    /// </summary>
    /// <returns></returns>
    public string CheckType()
    {
        return typeof(T).ToString();
    }
}
