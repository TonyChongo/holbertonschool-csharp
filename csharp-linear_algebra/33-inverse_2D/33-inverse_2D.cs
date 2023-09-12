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
    public static double[,] Inverse2D(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if (rows != 2 || cols != 2)
        {
            // Return [-1] for non-2D matrices
            return new double[,] { { -1 } };
        }

        double determinant = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

        if (Math.Abs(determinant) < 1e-6)
        {
            // Matrix is non-invertible (determinant is close to zero)
            return new double[,] { { -1 } };
        }

        double[,] inverse = new double[2, 2];

        inverse[0, 0] = Math.Round(matrix[1, 1] / determinant, 2);
        inverse[0, 1] = Math.Round(-matrix[0, 1] / determinant, 2);
        inverse[1, 0] = Math.Round(-matrix[1, 0] / determinant, 2);
        inverse[1, 1] = Math.Round(matrix[0, 0] / determinant, 2);

        return inverse;
    }
}
