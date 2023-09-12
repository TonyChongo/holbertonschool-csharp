using System;

/// <summary>
/// Public class
/// </summary>
public static class MatrixMath
{
    /// <summary>
    /// Public static
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="angle"></param>
    /// <returns></returns>
    public static double[,] Rotate2D(double[,] matrix, double angle)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        // Ensure it's a square matrix
        if (rows != cols || (rows != 2 && rows != 3))
        {
            return new double[,] { { -1 } };
        }

        double[,] rotatedMatrix = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            double x = matrix[i, 0];
            double y = matrix[i, 1];

            rotatedMatrix[i, 0] = x * Math.Cos(angle) - y * Math.Sin(angle);
            rotatedMatrix[i, 1] = x * Math.Sin(angle) + y * Math.Cos(angle);
        }

        return rotatedMatrix;
    }
}
