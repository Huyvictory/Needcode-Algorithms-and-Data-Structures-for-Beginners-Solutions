namespace Min_Stack;

class Program
{
    static void Main(string[] args)
    {
        // TestCase1();
        TestCase2();
        // TestCase3();
        // TestCase4();
        // TestCase5();
    }

    public static void TestCase1()
    {
        MinStack minStack = new MinStack();
        minStack.Push(-2);
        minStack.Push(0);
        minStack.Push(-3);
        Console.WriteLine(minStack.GetMin()); // return -3
        minStack.Pop();
        Console.WriteLine(minStack.Top()); // return 0
        Console.WriteLine(minStack.GetMin()); // return -2
    }

    public static void TestCase2()
    {
        MinStack minStack = new MinStack();
        minStack.Push(2);
        minStack.Push(0);
        minStack.Push(3);
        minStack.Push(0);
        minStack.Pop();
        Console.WriteLine(minStack.GetMin());
        minStack.Pop();
        Console.WriteLine(minStack.GetMin());
        minStack.Pop();
        Console.WriteLine(minStack.GetMin());
    }

    public static void TestCase3()
    {
        MinStack minStack = new MinStack();
        minStack.Push(1);
        minStack.Push(2);
        Console.WriteLine(minStack.GetMin());
    }

    public static void TestCase4()
    {
        MinStack minStack = new MinStack();
        minStack.Push(2147483646);
        minStack.Push(2147483646);
        minStack.Push(2147483647);
        Console.WriteLine(minStack.Top());
        minStack.Pop();
        Console.WriteLine(minStack.GetMin());
        minStack.Pop();
        Console.WriteLine(minStack.GetMin());
        minStack.Pop();
        minStack.Push(2147483647);
        Console.WriteLine(minStack.Top());
        Console.WriteLine(minStack.GetMin());
        minStack.Push(-2147483648);
        Console.WriteLine(minStack.Top());
        Console.WriteLine(minStack.GetMin());
        minStack.Pop();
        Console.WriteLine(minStack.GetMin());
    }

    public static void TestCase5()
    {
        MinStack minStack = new MinStack();
        minStack.Push(0);
        minStack.Push(1);
        minStack.Push(0);
        Console.WriteLine(minStack.GetMin());
        minStack.Pop();
        Console.WriteLine(minStack.GetMin());
    }
}
