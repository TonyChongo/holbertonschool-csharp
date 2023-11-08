using System;

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
