namespace Design_Heap;

class Program
{
    public static void TestCase1()
    {
        MinHeap minHeap1 = new MinHeap();

        Console.WriteLine(minHeap1.Top());
        minHeap1.Push(1);
        Console.WriteLine(minHeap1.Top());
        Console.WriteLine(minHeap1.Pop());
        Console.WriteLine(minHeap1.Pop());
    }

    public static void TestCase2()
    {
        MinHeap minHeap2 = new MinHeap();
        minHeap2.Heapify([1, 2, 3, 4, 5]);
        Console.WriteLine(minHeap2.Pop());
        Console.WriteLine(minHeap2.Pop());
        Console.WriteLine(minHeap2.Pop());
        Console.WriteLine(minHeap2.Pop());
        Console.WriteLine(minHeap2.Pop());
    }

    public static void TestCase3()
    {
        MinHeap minHeap3 = new MinHeap();
        minHeap3.Push(5);
        minHeap3.Push(2);
        minHeap3.Push(1);
        minHeap3.Push(10);
        Console.WriteLine(minHeap3.Top());
        Console.WriteLine(minHeap3.Pop());
        Console.WriteLine(minHeap3.Top());
        Console.WriteLine(minHeap3.Pop());
        Console.WriteLine(minHeap3.Top());
        Console.WriteLine(minHeap3.Pop());
        Console.WriteLine(minHeap3.Top());
        Console.WriteLine(minHeap3.Pop());
    }

    public static void TestCase4()
    {
        MinHeap minHeap4 = new MinHeap();
        minHeap4.Push(-1);
        minHeap4.Push(-2);
        minHeap4.Push(-3);
        Console.WriteLine(minHeap4.Pop());
        Console.WriteLine(minHeap4.Top());
    }

    static void Main(string[] args)
    {
        TestCase1();
        // TestCase2();
        // TestCase3();
        // TestCase4();
    }
}
