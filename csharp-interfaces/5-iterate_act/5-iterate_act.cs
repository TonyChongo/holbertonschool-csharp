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

class Decoration : Base, IInteractive, IBreakable
{
    public bool isQuestItem { get; set; }
    public int durability { get; set; }

    public Decoration(string name = "Decoration", int durability = 1, bool isQuestItem = false)
    {
        if (durability <= 0)
        {
            throw new ArgumentException("Durability must be greater than 0");
        }

        this.name = name;
        this.durability = durability;
        this.isQuestItem = isQuestItem;
    }

    public void Interact()
    {
        if (durability <= 0)
        {
            Console.WriteLine($"The {name} has been broken.");
        }
        else if (isQuestItem)
        {
            Console.WriteLine($"You look at the {name}. There's a key inside.");
        }
        else
        {
            Console.WriteLine($"You look at the {name}. Not much to see here.");
        }
    }

    public void Break()
    {
        if (durability > 1)
        {
            Console.WriteLine($"You hit the {name}. It cracks.");
        }
        else if (durability == 1)
        {
            Console.WriteLine($"You smash the {name}. What a mess.");
        }
        else
        {
            Console.WriteLine($"The {name} is already broken.");
        }
        durability -= 1;
    }
}

class Key : Base, ICollectable
{
    public bool isCollected { get; set; }

    public Key(string name = "Key", bool isCollected = false)
    {
        this.name = name;
        this.isCollected = isCollected;
    }

    public void Collect()
    {        
        if (!isCollected)
        {
            isCollected = true;
            Console.WriteLine($"You pick up the {name}.");
        }
        else
        {
            Console.WriteLine($"You have already picked up the {name}.");
        }
    }
}

class RoomObjects
{
    public static void IterateAction(List<Base> roomObjects, Type type)
    {
        foreach (Base obj in roomObjects)
        {
            if (type == typeof(IInteractive) && obj is IInteractive interactive)
            {
                interactive.Interact();
            }
            else if (type == typeof(IBreakable) && obj is IBreakable breakable)
            {
                breakable.Break();
            }
            else if (type == typeof(ICollectable) && obj is ICollectable collectable)
            {
                collectable.Collect();
            }
        }
    }
}
