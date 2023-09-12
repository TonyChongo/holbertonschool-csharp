using System;

/// <summary>
/// Public class
/// </summary>
public static class MatrixMath
{
    /// <summary>
    /// Public static
    /// </summary>
    /// <param name="matrix1"></param>
    /// <param name="matrix2"></param>
    /// <returns></returns>
    public static double[,] Multiply(double[,] matrix1, double[,] matrix2)
    {
        int matrix1Rows = matrix1.GetLength(0);
        int matrix1Cols = matrix1.GetLength(1);

        int matrix2Rows = matrix2.GetLength(0);
        int matrix2Cols = matrix2.GetLength(1);

        if (matrix1Cols != matrix2Rows)
        {
            return new double[,] { { -1 } };
        }

        double[,] result = new double[matrix1Rows, matrix2Cols];

        for (int i = 0; i < matrix1Rows; i++)
        {
            for (int j = 0; j < matrix2Cols; j++)
            {
                result[i, j] = 0;

                for (int k = 0; k < matrix1Cols; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }

        return result;
    }
}
