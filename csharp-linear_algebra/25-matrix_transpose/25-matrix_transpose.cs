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
    public static double[,] Transpose(double[,] matrix)
    {
        int numRows = matrix.GetLength(0);
        int numCols = matrix.GetLength(1);

        // Check if the matrix is empty
        if (numRows == 0 || numCols == 0)
        {
            // Return an empty matrix if it's empty
            return new double[0, 0];
        }

        // Create a new matrix to store the transposed values
        double[,] resultMatrix = new double[numCols, numRows];

        // Perform the transpose by swapping rows and columns
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                resultMatrix[j, i] = matrix[i, j];
            }
        }

        return resultMatrix;
    }
}
