namespace Design_Binary_Search_Tree;

class Program
{
    public static TreeNode TestCase1()
    {
        TreeMap treeMap1 = new TreeMap();

        treeMap1.Insert(1, 2);
        Console.WriteLine(treeMap1.Get(1));
        treeMap1.Insert(4, 0);
        Console.WriteLine(treeMap1.GetMin());
        Console.WriteLine(treeMap1.GetMax());

        return treeMap1.treeMap;
    }

    public static TreeNode TestCase2()
    {
        TreeMap treeMap2 = new TreeMap();

        treeMap2.Insert(1, 2);
        treeMap2.Insert(4, 2);
        treeMap2.Insert(3, 7);
        treeMap2.Insert(2, 1);
        Console.WriteLine(string.Join(',', treeMap2.GetInorderKeys()));
        treeMap2.Remove(1);
        Console.WriteLine(string.Join(',', treeMap2.GetInorderKeys()));

        return treeMap2.treeMap;
    }

    public static TreeNode TestCase3()
    {
        TreeMap treeMap3 = new TreeMap();

        treeMap3.Insert(4, 2);
        treeMap3.Insert(5, 2);
        treeMap3.Insert(3, 7);
        treeMap3.Insert(2, 1);
        Console.WriteLine(string.Join(',', treeMap3.GetInorderKeys()));
        treeMap3.Remove(4);
        Console.WriteLine(string.Join(',', treeMap3.GetInorderKeys()));

        return treeMap3.treeMap;
    }

    public static TreeNode TestCase4()
    {
        TreeMap treeMap4 = new TreeMap();

        treeMap4.Insert(100, 200);
        treeMap4.Insert(50, 100);
        Console.WriteLine(treeMap4.GetMax());
        treeMap4.Remove(100);
        Console.WriteLine(treeMap4.GetMax());

        return treeMap4.treeMap;
    }

    public static TreeNode TestCase5()
    {
        TreeMap treeMap5 = new TreeMap();

        treeMap5.Insert(1, 10);
        treeMap5.Insert(1, 20);

        Console.WriteLine(treeMap5.Get(1));

        return treeMap5.treeMap;
    }

    public static TreeNode TestCase6()
    {
        TreeMap treeMap6 = new TreeMap();

        treeMap6.Insert(1, 2);
        treeMap6.Insert(4, 0);

        treeMap6.Remove(1);

        Console.WriteLine(string.Join(',', treeMap6.GetInorderKeys()));

        treeMap6.Remove(4);

        Console.WriteLine(string.Join(',', treeMap6.GetInorderKeys()));

        return treeMap6.treeMap;
    }

    static void Main(string[] args)
    {
        var testCase1_Result = TestCase1();

        var testCase2_Result = TestCase2();

        var testCase3_Result = TestCase3();

        var testCase4_Result = TestCase4();

        var testCase5_Result = TestCase5();

        var testCase6_Result = TestCase6();

        return;
    }
}
