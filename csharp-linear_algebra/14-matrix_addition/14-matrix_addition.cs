using System;

/// <summary>
/// Public class matrix
/// </summary>
public static class MatrixMath
{
    /// <summary>
    /// Public static 
    /// </summary>
    /// <param name="matrix1"></param>
    /// <param name="matrix2"></param>
    /// <returns></returns>
    public static double[,] Add(double[,] matrix1, double[,] matrix2)
    {
        // Check for null matrices and size constraints
        if (matrix1 == null || matrix2 == null ||
            (matrix1.GetLength(0) != 2 && matrix1.GetLength(0) != 3) ||
            matrix1.GetLength(0) != matrix2.GetLength(0) ||
            matrix1.GetLength(1) != matrix2.GetLength(1))
        {
            return new double[,] { { -1 } };
        }

        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);
        
        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        return result;
    }
}
