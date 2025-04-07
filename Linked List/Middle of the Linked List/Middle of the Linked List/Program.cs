namespace Middle_of_the_Linked_List;

class Program
{
    private static ListNode TestCase1()
    {
        var ListNode5 = new ListNode(5);
        var ListNode4 = new ListNode(4, ListNode5);
        var ListNode3 = new ListNode(3, ListNode4);
        var ListNode2 = new ListNode(2, ListNode3);
        var head = new ListNode(1, ListNode2);

        return head;
    }

    private static ListNode TestCase2()
    {
        var ListNode6 = new ListNode(6);
        var ListNode5 = new ListNode(5, ListNode6);
        var ListNode4 = new ListNode(4, ListNode5);
        var ListNode3 = new ListNode(3, ListNode4);
        var ListNode2 = new ListNode(2, ListNode3);
        var head = new ListNode(1, ListNode2);

        return head;
    }

    // TC: O(n), SC: O(1)
    private static ListNode MiddleNodeFastAndSlowPointers(ListNode head)
    {
        var slowPointer = head;
        var fastPointer = head;

        while (fastPointer != null && fastPointer.next != null)
        {
            slowPointer = slowPointer.next;
            fastPointer = fastPointer.next.next;
        }

        return slowPointer;
    }

    public static ListNode MiddleNode(ListNode head)
    {
        return MiddleNodeFastAndSlowPointers(head);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(MiddleNode(TestCase1()).val);
    }
}
