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
        if (rows != cols)
        {
            return new double[,] { { -1 } };
        }

        double[,] rotatedMatrix = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                double x = matrix[i, j];
                double y = matrix[j, i];

                // Apply rotation
                rotatedMatrix[i, j] = x * Math.Cos(angle) - y * Math.Sin(angle);
            }
        }

        return rotatedMatrix;
    }
}
