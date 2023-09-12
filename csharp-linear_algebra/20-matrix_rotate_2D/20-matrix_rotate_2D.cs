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
    /// <param name="angle"></param>
    /// <returns></returns>
    public static double[,] Rotate2D(double[,] matrix, double angle)
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

        // Create the rotation matrix
        double[,] rotationMatrix = new double[2, 2];
        rotationMatrix[0, 0] = Math.Cos(angle);
        rotationMatrix[0, 1] = -Math.Sin(angle);
        rotationMatrix[1, 0] = Math.Sin(angle);
        rotationMatrix[1, 1] = Math.Cos(angle);

        // Multiply the rotation matrix with the input matrix
        double[,] resultMatrix = new double[numRows, numCols];
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                double sum = 0;
                for (int k = 0; k < numRows; k++)
                {
                    sum += rotationMatrix[i, k] * matrix[k, j];
                }
                resultMatrix[i, j] = sum;
            }
        }

        return resultMatrix;
    }
}
