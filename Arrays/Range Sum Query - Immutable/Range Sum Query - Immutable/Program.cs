namespace Range_Sum_Query___Immutable;

class Program
{
    private static void TestCase1()
    {
        NumArray numArray = new NumArray([-2,0,3,-5,2,-1]);

        Console.WriteLine(numArray.SumRange(0, 2));
        Console.WriteLine(numArray.SumRange(2, 5));
        Console.WriteLine(numArray.SumRange(0, 5));
    }

    private static void TestCase2()
    {
        NumArray numArray = new NumArray([-4,-5]);

        Console.WriteLine(numArray.SumRange(0, 0));
        Console.WriteLine(numArray.SumRange(1, 1));
        Console.WriteLine(numArray.SumRange(0, 1));
        Console.WriteLine(numArray.SumRange(1, 1));
        Console.WriteLine(numArray.SumRange(0, 0));
    }

    static void Main(string[] args)
    {
        TestCase2();
    }
}
