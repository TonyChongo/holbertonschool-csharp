using System;

class Matrix
{
    public static int[,] Square(int[,] myMatrix)
    {
        int rows = myMatrix.GetLength(0);
        int cols = myMatrix.GetLength(1);
        int[,] squareMatrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                squareMatrix[i, j] = myMatrix[i, j] * myMatrix[i, j];
            }
        }

        return squareMatrix;
    }
}