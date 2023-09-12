using System;

/// <summary>
/// Public class name VectorMath
/// </summary>
public static class VectorMath 
{
    /// <summary>
    /// Public static
    /// </summary>
    /// <param name="vector"></param>
    /// <param name="scalar"></param>
    /// <returns></returns>
    public static double[] Multiply(double[] vector, double scalar) 
    {
        if (vector == null || (vector.Length != 2 && vector.Length != 3)) 
        {
            return new double[] { -1 };
        }

        double[] result = new double[vector.Length];

        for (int i = 0; i < vector.Length; i++) 
        {
            result[i] = vector[i] * scalar;
        }

        return result;
    }
}
