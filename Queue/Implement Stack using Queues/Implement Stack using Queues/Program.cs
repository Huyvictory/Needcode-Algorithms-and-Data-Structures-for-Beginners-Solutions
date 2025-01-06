namespace Implement_Stack_using_Queues;

class Program
{
    public static void TestCase1()
    {
        MyStack myStack = new MyStack();
        myStack.Push(1);
        myStack.Push(2);
        Console.WriteLine(myStack.Top()); // return 2
        Console.WriteLine(myStack.Pop()); // return 2
        Console.WriteLine(myStack.Empty()); // return False
    }

    public static void TestCase2()
    {
        MyStack myStack = new MyStack();
        myStack.Push(1);
        Console.WriteLine(myStack.Pop()); // return 1
        Console.WriteLine(myStack.Empty()); // return True
    }

    public static void TestCase3()
    {
        MyStack myStack = new MyStack();
        myStack.Push(1);
        myStack.Push(2);
        Console.WriteLine(myStack.Top()); // return 2
        Console.WriteLine(myStack.Pop()); // return 2
        Console.WriteLine(myStack.Empty()); // return False
    }

    public static void TestCase4()
    {
        MyStack myStack = new MyStack();
        myStack.Push(1);
        myStack.Push(2);
        myStack.Push(3);
        Console.WriteLine(myStack.Pop()); // return 3
        Console.WriteLine(myStack.Pop()); // return 2
        Console.WriteLine(myStack.Pop()); // return 1
        Console.WriteLine(myStack.Empty()); // return True
    }

    static void Main(string[] args)
    {
        // TestCase1();
        // TestCase2();
        // TestCase3();
        TestCase4();
    }
}
