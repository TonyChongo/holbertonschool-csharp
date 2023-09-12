using System;

/// <summary>
/// Public class
/// </summary>
public class MatrixMath
{
    /// <summary>
    /// Public static
    /// </summary>
    /// <param name="matrix"></param>
    /// <returns></returns>
    public static double Determinant(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if (rows != cols || (rows != 2 && rows != 3))
        {
            // Return -1 for matrices that are not 2x2 or 3x3
            return -1;
        }

        if (rows == 2)
        {
            // For a 2x2 matrix
            double det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            return Math.Round(det, 2);
        }
        else
        {
            // For a 3x3 matrix
            double det = matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1])
                         - matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0])
                         + matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);
            return Math.Round(det, 2);
        }
    }
}
