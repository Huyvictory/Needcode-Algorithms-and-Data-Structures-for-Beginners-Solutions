namespace Design_Hash_Table;

class Program
{
    public static void TestCase1()
    {
        HashTable hashTable = new HashTable(4);
        hashTable.Insert(1, 2);
        Console.WriteLine(hashTable.Get(1));
        hashTable.Insert(1, 3);
        Console.WriteLine(hashTable.Get(1));
        Console.WriteLine(hashTable.Remove(1));
        Console.WriteLine(hashTable.Get(1));
    }

    public static void TestCase2()
    {
        HashTable hashTable = new HashTable(2);
        Console.WriteLine(hashTable.GetCapacity());
        hashTable.Insert(6, 7);
        Console.WriteLine(hashTable.GetCapacity());
        hashTable.Insert(1, 2);
        Console.WriteLine(hashTable.GetCapacity());
        hashTable.Insert(3, 4);
        Console.WriteLine(hashTable.GetCapacity());
        Console.WriteLine(hashTable.GetSize());
    }

    static void Main(string[] args)
    {
        // TestCase1();
        TestCase2();
    }
}
