using System;

/// <summary>
/// Class name
/// </summary>
class Shape
{
    /// <summary>
    /// Public method
    /// </summary>
    /// <returns></returns>
    public virtual int Area()
    {
        throw new NotImplementedException("Area() is not implemented");
    }
}

/// <summary>
/// Subclass rectangle that inherits from class Shape
/// </summary>
class Rectangle : Shape
{
    private int width;
    private int height;

    /// <summary>
    /// Public property of width
    /// </summary>
    /// <value></value>
    public int Width
    {
        get { return width; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Width must be greater than or equal to 0");
            width = value;
        }
    }

    /// <summary>
    /// Public property of height
    /// </summary>
    /// <value></value>
    public int Height
    {
        get { return height; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Height must be greater than or equal to 0");
            height = value;
        }
    }

    /// <summary>
    /// Public property of area
    /// </summary>
    /// <returns></returns>
    public new int Area()
    {
        return Width * Height;
    }

    /// <summary>
    /// Public property that devide rectangle
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"[Rectangle] {Width} / {Height}";
    }
}

/// <summary>
/// New class square that inherits from class rectangle
/// </summary>
class Square : Rectangle
{
    private int size;

    /// <summary>
    /// New public property
    /// </summary>
    /// <value></value>
    public int Size
    {
        get { return size; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Size must be greater than or equal to 0");
            size = value;
            Width = value;
            Height = value;
        }
    }

    /// <summary>
    /// Public property that devide square
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"[Square] {size} / {size}";
    }
}