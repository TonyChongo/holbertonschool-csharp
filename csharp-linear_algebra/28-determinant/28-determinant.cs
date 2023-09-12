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
        int numRows = matrix.GetLength(0);
        int numCols = matrix.GetLength(1);

        // Check if the matrix is not 2D or 3D
        if (numRows != numCols || (numRows != 2 && numRows != 3))
        {
            // Return -1 for invalid dimensions
            return -1;
        }

        double determinant = 0;

        if (numRows == 2)
        {
            // For a 2x2 matrix, calculate the determinant directly
            determinant = (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);
        }
        else if (numRows == 3)
        {
            // For a 3x3 matrix, use the formula to calculate the determinant
            determinant = (matrix[0, 0] * matrix[1, 1] * matrix[2, 2]) +
                          (matrix[0, 1] * matrix[1, 2] * matrix[2, 0]) +
                          (matrix[0, 2] * matrix[1, 0] * matrix[2, 1]) -
                          (matrix[0, 2] * matrix[1, 1] * matrix[2, 0]) -
                          (matrix[0, 1] * matrix[1, 0] * matrix[2, 2]) -
                          (matrix[0, 0] * matrix[1, 2] * matrix[2, 1]);
        }

        return determinant;
    }
}
