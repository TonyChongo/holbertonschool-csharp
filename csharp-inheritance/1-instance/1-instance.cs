using System;

/// <summary>
/// Method class
/// </summary>
class Obj
{
    /// <summary>
    /// Prototype of method
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool IsInstanceOfArray(object obj)
    {
        return obj is Array;
    }
}