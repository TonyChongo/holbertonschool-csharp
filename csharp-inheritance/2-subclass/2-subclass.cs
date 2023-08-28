using System;

/// <summary>
/// Class method
/// </summary>
class Obj
{
    /// <summary>
    /// Prototype of method
    /// </summary>
    /// <param name="derivedType"></param>
    /// <param name="baseType"></param>
    /// <returns></returns>
    public static bool IsOnlyASubclass(Type derivedType, Type baseType)
    {
        return baseType.IsAssignableFrom(derivedType) && derivedType != baseType;
    }
}