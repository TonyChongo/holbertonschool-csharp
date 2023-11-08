using System;
using System.Collections.Generic;
using System.Reflection;

/// <summary>
/// An interface called IInteractive
/// </summary>
public interface IInteractive
{
    /// <summary>
    /// method void Interact()
    /// </summary>
    void Interact();
}

/// <summary>
/// An interface called IBreakable
/// </summary>
public interface IBreakable
{
    /// <summary>
    /// property integer durability
    /// </summary>
    /// <value></value>
    int durability { get; set; }
    /// <summary>
    /// method void Break()
    /// </summary>
    void Break();
}

/// <summary>
/// An interface called ICollectable
/// </summary>
public interface ICollectable
{
    /// <summary>
    /// property bool isCollected
    /// </summary>
    /// <value></value>
    bool isCollected { get; set; }
    /// <summary>
    /// method void Collect
    /// </summary>
    void Collect();
}

/// <summary>
/// An abstract class called Base
/// </summary>
public abstract class  Base
{
    /// <summary>
    /// public property name
    /// </summary>
    /// <value></value>
    public string name { get; set; }

    /// <summary>
    /// override ToString() method
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{name} is a {this.GetType().Name}";
    }
}

class Door : Base, IInteractive
{
    public Door(string name = "Door")
    {
        this.name = name;
    }

    public void Interact()
    {
        Console.WriteLine($"You try to open the {name}. It's locked.");
    }
}
