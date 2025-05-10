namespace Linked_List_Cycle;

class Program
{
    private static ListNode TestCase1()
    {
        ListNode head = new ListNode(3);
        ListNode Node2 = new ListNode(2);
        ListNode Node0 = new ListNode(0);
        ListNode NodeMinus4 = new ListNode(-4);

        head.next = Node2;
        Node2.next = Node0;
        Node0.next = NodeMinus4;
        NodeMinus4.next = Node2;

        return head;
    }

    private static ListNode TestCase2()
    {
        ListNode head = new ListNode(1);
        ListNode Node2 = new ListNode(2);

        head.next = Node2;
        Node2.next = head;

        return head;
    }

    private static ListNode TestCase3()
    {
        ListNode head = new ListNode(1);

        return head;
    }

    private static ListNode TestCase4()
    {
        ListNode head = new ListNode(3);
        ListNode Node2 = new ListNode(2);
        ListNode Node0 = new ListNode(0);
        ListNode NodeMinus4 = new ListNode(-4);

        head.next = Node2;
        Node2.next = Node0;
        Node0.next = NodeMinus4;

        return head;
    }

    // TC: O(n), SC: O(1)
    private static bool HasCycleFastSlowPointers(ListNode head)
    {
        if (head == null || head.next == null)
            return false;

        // Initialize fast and slow pointers to detect whether linked list has cycle or not
        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;

            // cycle in linked list detected
            if (slow == fast)
            {
                return true;
            }
        }

        // Linked list has no cycle
        return false;
    }

    // TC: O(n), SC: O(n)
    private static bool HasCycleHasSet(ListNode head)
    {
        if (head == null || head.next == null)
            return false;

        HashSet<ListNode> set = new HashSet<ListNode>();

        ListNode curNode = head;

        while (curNode != null && curNode.next != null)
        {
            if (!set.Contains(curNode))
            {
                set.Add(curNode);
                curNode = curNode.next;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    private static bool HasCycle(ListNode head)
    {
        // return HasCycleFastSlowPointers(head);
        return HasCycleHasSet(head);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(HasCycle(TestCase1()));
    }
}
