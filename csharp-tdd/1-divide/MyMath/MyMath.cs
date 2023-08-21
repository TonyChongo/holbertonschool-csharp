using System;

namespace MyMath
{
    /// <summary>
    /// Defined a new public class
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// method that divides all elements of a matrix
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int[,] Divide(int[,] matrix, int num)
        {
            if (matrix == null)
            {
                return null;
            }

            if (num == 0)
            {
                Console.WriteLine("Num cannot be 0");
                return null;
            }

            int numRows = matrix.GetLength(0);
            int numCols = matrix.GetLength(1);
            int[,] result = new int[numRows, numCols];

            try
            {
                for (int i = 0; i < numRows; i++)
                {
                    for (int j = 0; j < numCols; j++)
                    {
                        result[i, j] = matrix[i, j] / num;
                    }
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }

            return result;
        }
    }
}
