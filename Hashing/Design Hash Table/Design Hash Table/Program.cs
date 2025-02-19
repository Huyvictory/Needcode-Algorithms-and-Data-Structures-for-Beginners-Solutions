namespace Design_Hash_Table;

class Program
{
    public static void TestCase1()
    {
        HashTableOpenAddress hashTable = new HashTableOpenAddress(4);
        hashTable.Insert(1, 2);
        Console.WriteLine(hashTable.Get(1));
        hashTable.Insert(1, 3);
        Console.WriteLine(hashTable.Get(1));
        Console.WriteLine(hashTable.Remove(1));
        Console.WriteLine(hashTable.Get(1));
    }

    public static void TestCase2()
    {
        HashTableOpenAddress hashTable = new HashTableOpenAddress(2);
        Console.WriteLine(hashTable.GetCapacity());
        hashTable.Insert(6, 7);
        Console.WriteLine(hashTable.GetCapacity());
        hashTable.Insert(1, 2);
        Console.WriteLine(hashTable.GetCapacity());
        hashTable.Insert(3, 4);
        Console.WriteLine(hashTable.GetCapacity());
        Console.WriteLine(hashTable.GetSize());
    }

    public static void TestCase3()
    {
        HashTableLinkedList hashTable = new HashTableLinkedList(4);
        hashTable.Insert(1, 2);
        Console.WriteLine(hashTable.Get(1));
        hashTable.Insert(1, 3);
        Console.WriteLine(hashTable.Get(1));
        Console.WriteLine(hashTable.Remove(1));
        Console.WriteLine(hashTable.Get(1));
    }

    public static void TestCase4()
    {
        HashTableLinkedList hashTable = new HashTableLinkedList(2);
        Console.WriteLine(hashTable.GetCapacity());
        hashTable.Insert(6, 7);
        Console.WriteLine(hashTable.GetCapacity());
        hashTable.Insert(1, 2);
        Console.WriteLine(hashTable.GetCapacity());
        hashTable.Insert(3, 4);
        Console.WriteLine(hashTable.GetCapacity());
        Console.WriteLine(hashTable.GetSize());
    }

    public static void TestCase5()
    {
        HashTableLinkedList hashTable = new HashTableLinkedList(4);
        Console.WriteLine(hashTable.Remove(5));
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
