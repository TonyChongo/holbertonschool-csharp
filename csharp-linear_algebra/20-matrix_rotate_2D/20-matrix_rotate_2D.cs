using System;

/// <summary>
/// Public class
/// </summary>
class MatrixMath
{
    /// <summary>
    /// public static
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="angle"></param>
    /// <returns></returns>
    public static double[,] Rotate2D(double[,] matrix, double angle)
    {
        double[,] error = { { -1 } };
        if (matrix.Length == 0 || matrix.GetLength(0) != 2 || matrix.GetLength(1) != 2)
        {
            return error;
        }

        double[,] result = new double[2, 2];
        double[,] rotateMatrix = new double[2, 2] {
            {Math.Cos(angle), Math.Sin(angle)},
            {-Math.Sin(angle), Math.Cos(angle)}
        };

        for (int i = 0; i < matrix.GetLength(0); i++)
        {

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    result[i, j] += Math.Round(matrix[i, k] * rotateMatrix[k, j], 2);
                }
                result[i, j] = Math.Round(result[i, j], 2);
            }
        }
        return result;
    }
}