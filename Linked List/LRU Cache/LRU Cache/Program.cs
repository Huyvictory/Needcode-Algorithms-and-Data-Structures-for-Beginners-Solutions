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
        lRUCache.Put(1, 0);
        lRUCache.Put(2, 2);
        Console.WriteLine(lRUCache.Get(1)); // return 0
        lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=0, 3=3}
        Console.WriteLine(lRUCache.Get(2)); // return -1
        lRUCache.Put(4, 4); // LRU key was 1, evicts key 2, cache is {3=3, 4=4}
        Console.WriteLine(lRUCache.Get(1)); // return -1 (not found)
        Console.WriteLine(lRUCache.Get(3)); // return 3
        Console.WriteLine(lRUCache.Get(4)); // return 4
    }

    private static void TestCase3()
    {
        LRUCache lRUCache = new LRUCache(2);
        Console.WriteLine(lRUCache.Get(2)); // return -1
        lRUCache.Put(2, 6); // LRU key was {}, cache is {2=6}
        Console.WriteLine(lRUCache.Get(1)); // return -1
        lRUCache.Put(1, 5); // LRU key was {2=6}, cache is {1=5, 2=6}
        lRUCache.Put(1, 2); // LRU key was {1=5, 2=6}, cache is {1=2, 2=6}
        Console.WriteLine(lRUCache.Get(1)); // return 2
        Console.WriteLine(lRUCache.Get(2)); // return 6
    }

    static void Main(string[] args)
    {
        TestCase3();
    }
}
