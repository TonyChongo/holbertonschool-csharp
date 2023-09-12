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
    /// <param name="direction"></param>
    /// <param name="factor"></param>
    /// <returns></returns>
    public static double[,] Shear2D(double[,] matrix, char direction, double factor)
    {
        int numRows = matrix.GetLength(0);
        int numCols = matrix.GetLength(1);

        // Check if the matrix is square and has a valid size
        if (numRows != numCols || numRows <= 0)
        {
            // Return a matrix containing -1 if it's not valid
            double[,] invalidMatrix = new double[numRows, numCols];
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    invalidMatrix[i, j] = -1;
                }
            }
            return invalidMatrix;
        }

        double[,] resultMatrix = new double[numRows, numCols];

        if (direction == 'x' || direction == 'X')
        {
            // Shear in the X direction
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    resultMatrix[i, j] = matrix[i, j] + (i * factor);
                }
            }
        }
        else if (direction == 'y' || direction == 'Y')
        {
            // Shear in the Y direction
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    resultMatrix[i, j] = matrix[i, j] + (j * factor);
                }
            }
        }
        else
        {
            // Invalid direction, return a matrix containing -1
            double[,] invalidDirectionMatrix = new double[numRows, numCols];
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    invalidDirectionMatrix[i, j] = -1;
                }
            }
            return invalidDirectionMatrix;
        }

        return resultMatrix;
    }
}
