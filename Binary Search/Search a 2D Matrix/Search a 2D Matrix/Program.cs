namespace Search_a_2D_Matrix;

class Program
{
    public static int[][] TestCase1()
    {
        return new int[][]
        {
            new int[] { 1, 3, 5, 7 },
            new int[] { 10, 11, 16, 20 },
            new int[] { 23, 30, 34, 60 }
        };
    }

    public static int[][] TestCase2()
    {
        return new int[][] { new int[] { 1, 3 } };
    }

    public static bool BinarySearch(int[] subArrayMatrix, int target)
    {
        int left = 0,
            right = subArrayMatrix.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (subArrayMatrix[mid] > target)
            {
                right = mid - 1;
            }
            else if (subArrayMatrix[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    public static bool SearchMatrix(int[][] matrix, int target)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            int left = matrix[i][0],
                right = matrix[i][matrix[i].Length - 1];

            if ((target > left && target > right) || (target < left && target < right))
            {
                continue;
            }
            else if (target >= left || target <= right)
            {
                if (BinarySearch(matrix[i], target))
                {
                    return true;
                }
            }
        }

        return false;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(SearchMatrix(TestCase1(), 3));
        Console.WriteLine(SearchMatrix(TestCase1(), 13));
        Console.WriteLine(SearchMatrix(TestCase2(), 3));
    }
}
