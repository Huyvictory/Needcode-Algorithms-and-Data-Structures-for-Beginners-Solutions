namespace LRU_Cache;

class Program
{
    private static void TestCase1()
    {
        LRUCache lRUCache = new LRUCache(2);
        lRUCache.Put(1, 1); // cache is {1=1}
        lRUCache.Put(2, 2); // cache is {1=1, 2=2}
        Console.WriteLine(lRUCache.Get(1)); // return 1
        lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
        Console.WriteLine(lRUCache.Get(2)); // returns -1 (not found)
        lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
        Console.WriteLine(lRUCache.Get(1)); // return -1 (not found)
        Console.WriteLine(lRUCache.Get(3)); // return 3
        Console.WriteLine(lRUCache.Get(4)); // return 4
    }

    private static void TestCase2()
    {
        LRUCache lRUCache = new LRUCache(2);
        lRUCache.Put(2, 1);
        lRUCache.Put(1, 1);
        lRUCache.Put(2, 3);
        lRUCache.Put(4, 1);
        Console.WriteLine(lRUCache.Get(1));
        Console.WriteLine(lRUCache.Get(2));
    }

    private static void TestCase3()
    {
        LRUCache lRUCache = new LRUCache(1);
        Console.WriteLine(lRUCache.Get(6));
        Console.WriteLine(lRUCache.Get(8));
        lRUCache.Put(12, 1);
        Console.WriteLine(lRUCache.Get(2));
        lRUCache.Put(15, 1);
        lRUCache.Put(5, 2);
        lRUCache.Put(1, 15);
        lRUCache.Put(4, 2);
        Console.WriteLine(lRUCache.Get(4));
        lRUCache.Put(15, 15);
    }

    private static void TestCase4()
    {
        LRUCache lRUCache = new LRUCache(3);
        lRUCache.Put(1, 1);
        lRUCache.Put(2, 2);
        lRUCache.Put(3, 3);
        lRUCache.Put(4, 4);
        Console.WriteLine(lRUCache.Get(4));
        Console.WriteLine(lRUCache.Get(3));
        Console.WriteLine(lRUCache.Get(2));
        Console.WriteLine(lRUCache.Get(1));
        lRUCache.Put(5, 5);
        Console.WriteLine(lRUCache.Get(1));
        Console.WriteLine(lRUCache.Get(2));
        Console.WriteLine(lRUCache.Get(3));
        Console.WriteLine(lRUCache.Get(4));
        Console.WriteLine(lRUCache.Get(5));
    }

    private static void TestCase5()
    {
        LRUCache lRUCache = new LRUCache(2);
        Console.WriteLine(lRUCache.Get(2));
        lRUCache.Put(2, 6);
        Console.WriteLine(lRUCache.Get(1));
        lRUCache.Put(1, 5);
        lRUCache.Put(1, 2);
        Console.WriteLine(lRUCache.Get(1));
        Console.WriteLine(lRUCache.Get(2));
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
