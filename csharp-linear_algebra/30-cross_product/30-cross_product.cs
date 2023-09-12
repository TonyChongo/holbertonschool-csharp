using System;

/// <summary>
/// Public class
/// </summary>
public class VectorMath
{
    /// <summary>
    /// Public static
    /// </summary>
    /// <param name="vector1"></param>
    /// <param name="vector2"></param>
    /// <returns></returns>
    public static double[] CrossProduct(double[] vector1, double[] vector2)
    {
        if (vector1.Length != 3 || vector2.Length != 3)
        {
            // Return a vector containing -1 for non-3D vectors
            return new double[] { -1, -1, -1 };
        }

        double resultX = vector1[1] * vector2[2] - vector1[2] * vector2[1];
        double resultY = vector1[2] * vector2[0] - vector1[0] * vector2[2];
        double resultZ = vector1[0] * vector2[1] - vector1[1] * vector2[0];

        return new double[] { resultX, resultY, resultZ };
    }
}
