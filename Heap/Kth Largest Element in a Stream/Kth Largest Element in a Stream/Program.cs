namespace Kth_Largest_Element_in_a_Stream;

class Program
{
    public static void TestCase1()
    {
        KthLargest testCase1 = new KthLargest(3, [4, 5, 8, 2]);
        Console.WriteLine(testCase1.Add(3));
        Console.WriteLine(testCase1.Add(5));
        Console.WriteLine(testCase1.Add(10));
        Console.WriteLine(testCase1.Add(9));
        Console.WriteLine(testCase1.Add(4));
    }

    public static void TestCase2() {
        KthLargest testCase1 = new KthLargest(4, [7, 7, 7, 7, 8, 3]);
        Console.WriteLine(testCase1.Add(2));
        Console.WriteLine(testCase1.Add(10));
        Console.WriteLine(testCase1.Add(9));
        Console.WriteLine(testCase1.Add(9));
    }

    public static void TestCase3() {
        KthLargest testCase1 = new KthLargest(1, []);
        Console.WriteLine(testCase1.Add(-3));
        Console.WriteLine(testCase1.Add(-2));
        Console.WriteLine(testCase1.Add(-4));
        Console.WriteLine(testCase1.Add(0));
        Console.WriteLine(testCase1.Add(4));
    }

    public static void TestCase4() {
        KthLargest testCase1 = new KthLargest(2, [0]);
        Console.WriteLine(testCase1.Add(-1));
        Console.WriteLine(testCase1.Add(1));
        Console.WriteLine(testCase1.Add(-2));
        Console.WriteLine(testCase1.Add(-4));
        Console.WriteLine(testCase1.Add(3));
    }

    public static void TestCase5() {
        KthLargest testCase5 = new KthLargest(3, [1, 2, 3, 3]);
        Console.WriteLine(testCase5.Add(3));
        Console.WriteLine(testCase5.Add(5));
        Console.WriteLine(testCase5.Add(6));
        Console.WriteLine(testCase5.Add(6));
        Console.WriteLine(testCase5.Add(8));
    }

    static void Main(string[] args)
    {
        TestCase1();
        // TestCase2();
        // TestCase3();
        // TestCase4();
        // TestCase5();
    }
}
