namespace Reverse_Linked_List;

class Program
{
    public static ListNode ListNode5 = new ListNode(5);
    public static ListNode ListNode4 = new ListNode(4, ListNode5);
    public static ListNode ListNode3 = new ListNode(3, ListNode4);
    public static ListNode ListNode2 = new ListNode(2, ListNode3);
    public static ListNode ListNode1 = new ListNode(1, ListNode2);
    public static List<ListNode> testCase1 = new List<ListNode>
    {
        ListNode1,
        ListNode2,
        ListNode3,
        ListNode4,
        ListNode5
    };

    static void Main(string[] args)
    {
        Console.WriteLine(ReverseList(ListNode1).val);
    }

    public static ListNode ReverseList(ListNode head)
    {
        if (head == null)
            return null;

        ListNode previousNode = null;
        ListNode cur = head;
        ListNode nextNode = head.next;

        while (true)
        {
            cur.next = previousNode;
            previousNode = cur;
            cur = nextNode;

            if (cur == null)
                break;
            nextNode = nextNode.next;
        }

        return previousNode;
    }
}
