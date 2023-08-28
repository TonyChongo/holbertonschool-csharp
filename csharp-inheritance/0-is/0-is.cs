using System;

/// <summary>
/// Class of method
/// </summary>
class Obj
{
    /// <summary>
    /// Prototype of method
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool IsOfTypeInt(object obj)
    {
        return obj is int;
    }
}
