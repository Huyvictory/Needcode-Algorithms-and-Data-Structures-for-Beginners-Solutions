namespace Range_Sum_Query_2D___Immutable;

class Program
{
    private static void TestCase1()
    {
        NumMatrix numMatrix = new NumMatrix(
        [[3, 0, 1, 4, 2], 
        [5, 6, 3, 2, 1], 
        [1, 2, 0, 1, 5], 
        [4, 1, 0, 1, 7], 
        [1, 0, 3, 0, 5]]);

        Console.WriteLine(numMatrix.SumRegion(2, 1, 4, 3));
        Console.WriteLine(numMatrix.SumRegion(1, 1, 2, 2));
        Console.WriteLine(numMatrix.SumRegion(1, 2, 2, 4));
    }

    static void Main(string[] args)
    {
        TestCase1();
    }
}
