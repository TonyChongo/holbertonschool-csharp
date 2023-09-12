using System;

/// <summary>
/// Public class
/// </summary>
public static class VectorMath 
{
    /// <summary>
    /// Public static
    /// </summary>
    /// <param name="vector1"></param>
    /// <param name="vector2"></param>
    /// <returns></returns>
    public static double DotProduct(double[] vector1, double[] vector2) 
    {
        // Check for null vectors, size constraints, and matching sizes
        if (vector1 == null || vector2 == null 
            || (vector1.Length != 2 && vector1.Length != 3)
            || vector1.Length != vector2.Length) 
        {
            return -1;
        }

        double dotProduct = 0;

        for (int i = 0; i < vector1.Length; i++) 
        {
            dotProduct += vector1[i] * vector2[i];
        }

        return dotProduct;
    }
}