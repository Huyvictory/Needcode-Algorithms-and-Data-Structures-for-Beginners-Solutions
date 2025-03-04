public class NumMatrix
{
    private int[,] prefixSumMatrix;

    public NumMatrix(int[][] matrix)
    {
        prefixSumMatrix = new int[matrix.Length, matrix[0].Length];

        for (int row = 0; row < matrix.Length; row++)
        {
            int prefixSumRow = 0;

            for (int col = 0; col < matrix[0].Length; col++)
            {
                prefixSumRow = prefixSumRow + matrix[row][col];
                prefixSumMatrix[row, col] = prefixSumRow;
            }
        }
    }

    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        int sumRegion = 0;

        for (int row = row1; row <= row2; row++)
        {
            if (col1 == 0)
            {
                sumRegion += prefixSumMatrix[row, col2];
            }
            else
            {
                sumRegion += prefixSumMatrix[row, col2] - prefixSumMatrix[row, col1 - 1];
            }
        }

        return sumRegion;
    }
}
