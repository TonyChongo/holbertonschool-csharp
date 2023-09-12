using System;

/// <summary>
/// public class
/// </summary>
public static class MatrixMath
{
    /// <summary>
    /// public static
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
            for (int j = 0; j < cols; j++)
            {
                // Apply rotation to each element
                rotatedMatrix[i, j] = matrix[i, j] * Math.Cos(angle) - matrix[j, i] * Math.Sin(angle);
            }
        }

        return rotatedMatrix;
    }
}
