namespace Time_Based_Key_Value_Store;

class Program
{
    private static void TestCase1()
    {
        TimeMap timeMap = new TimeMap();

        timeMap.Set("foo", "bar", 1);
        Console.WriteLine(timeMap.GetBinarySearch("foo", 1));
        Console.WriteLine(timeMap.GetBinarySearch("foo", 3));
        timeMap.Set("foo", "bar2", 4);
        Console.WriteLine(timeMap.GetBinarySearch("foo", 4));
        Console.WriteLine(timeMap.GetBinarySearch("foo", 5));
    }

    private static void TestCase2()
    {
        TimeMap timeMap = new TimeMap();

        timeMap.Set("love", "high", 10);
        timeMap.Set("love", "low", 20);
        Console.WriteLine(timeMap.GetBinarySearch("love", 5));
        Console.WriteLine(timeMap.GetBinarySearch("love", 10));
        Console.WriteLine(timeMap.GetBinarySearch("love", 15));
        Console.WriteLine(timeMap.GetBinarySearch("love", 20));
        Console.WriteLine(timeMap.GetBinarySearch("love", 25));
    }

    private static void TestCase3()
    {
        TimeMap timeMap = new TimeMap();

        timeMap.Set("test", "one", 10);
        timeMap.Set("test", "two", 20);
        timeMap.Set("test", "three", 30);

        Console.WriteLine(timeMap.GetBinarySearch("test", 15));
        Console.WriteLine(timeMap.GetBinarySearch("test", 25));
        Console.WriteLine(timeMap.GetBinarySearch("test", 35));
    }

    static void Main(string[] args)
    {
        TestCase3();
    }
}
