using System;

/// <summary>
/// Public static
/// </summary>
public static class MatrixMath
{
    /// <summary>
    /// Public static
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="scalar"></param>
    /// <returns></returns>
    public static double[,] MultiplyScalar(double[,] matrix, double scalar)
    {
        if (matrix == null || 
            (matrix.GetLength(0) != 2 && matrix.GetLength(0) != 3) ||
            (matrix.GetLength(1) != 2 && matrix.GetLength(1) != 3))
        {
            return new double[,] { { -1 } };
        }

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix[i, j] * scalar;
            }
        }

        return result;
    }
}