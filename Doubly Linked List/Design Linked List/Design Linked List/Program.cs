namespace Design_Linked_List;

class Program
{
    public static void TestCase1()
    {
        MyLinkedList2 myLinkedList = new MyLinkedList2();
        myLinkedList.AddAtHead(1);
        myLinkedList.AddAtTail(3);
        myLinkedList.AddAtIndex(1, 2); // linked list becomes 1->2->3
        Console.WriteLine(myLinkedList.Get(1)); // return 2
        myLinkedList.DeleteAtIndex(1); // now the linked list is 1->3
        Console.WriteLine(myLinkedList.Get(1)); // return 3

        return;
    }

    public static void TestCase2()
    {
        MyLinkedList2 myLinkedList = new MyLinkedList2();
        myLinkedList.AddAtHead(1);
        myLinkedList.DeleteAtIndex(0);
    }

    public static void TestCase3()
    {
        MyLinkedList2 myLinkedList = new MyLinkedList2();
        myLinkedList.AddAtHead(7);
        myLinkedList.AddAtHead(2);
        myLinkedList.AddAtHead(1);
        myLinkedList.AddAtIndex(3, 0);
        myLinkedList.DeleteAtIndex(2);
        myLinkedList.AddAtHead(6);
        myLinkedList.AddAtTail(4);
        Console.WriteLine(myLinkedList.Get(4));
        myLinkedList.AddAtHead(4);
        myLinkedList.AddAtIndex(5, 0);
        myLinkedList.AddAtHead(6);

        return;
    }

    public static void TestCase4()
    {
        MyLinkedList2 myLinkedList = new MyLinkedList2();
        myLinkedList.AddAtTail(1);
        Console.WriteLine(myLinkedList.Get(0));
    }

    static void Main(string[] args)
    {
        TestCase1();
        // TestCase2();
        // TestCase3();
        // TestCase4();
    }
}
