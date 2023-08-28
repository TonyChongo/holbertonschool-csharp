using System;
using System.Collections.Generic;
using System.Reflection;

/// <summary>
/// Method class
/// </summary>
class Obj
{
    /// <summary>
    /// Method prototype
    /// </summary>
    /// <param name="myObj"></param>
    public static void Print(object myObj)
    {
        Type objType = myObj.GetType();

        Console.WriteLine("{0} Properties:", objType.Name);
        foreach (PropertyInfo property in objType.GetProperties())
        {
            Console.WriteLine("{0}", property.Name);
        }

        Console.WriteLine("{0} Methods:", objType.Name);
        foreach (MethodInfo method in objType.GetMethods())
        {
            Console.WriteLine("{0}", method.Name);
        } 
    }
}