using System;
/// <summary>
/// Public class
/// </summary>
class MatrixMath
{
    /// <summary>
    /// Public static
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="direction"></param>
    /// <param name="factor"></param>
    /// <returns></returns>
    public static double[,] Shear2D(double[,] matrix, char direction, double factor)
    {
        double[,] error = { { -1 } };
        
        if (direction != 'x' && direction != 'y')
            return error;
        
        int numRows = matrix.GetLength(0);
        int numCols = matrix.GetLength(1);

        if (numRows != 2 || numCols != 2)
            return error;

        double[,] result = new double[2, 2];

        if (direction == 'x')
        {
            for (int i = 0; i < 2; i++)
            {
                double x = matrix[i, 0];
                double y = matrix[i, 1];
                double xResult = x + y * factor;
                result[i, 0] = xResult;
                result[i, 1] = y;
            }
        }

        if (direction == 'y')
        {
            for (int i = 0; i < 2; i++)
            {
                double x = matrix[i, 0];
                double y = matrix[i, 1];
                double yResult = y + x * factor;
                result[i, 0] = x;
                result[i, 1] = yResult;
            }
        }

        return result;
    }
}
