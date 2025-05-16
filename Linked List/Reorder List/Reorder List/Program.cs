namespace Reorder_List;

class Program
{
    private static ListNode TestCase1()
    {
        ListNode head = new ListNode(1);
        ListNode node2 = new ListNode(2);
        ListNode node3 = new ListNode(3);
        ListNode node4 = new ListNode(4);

        head.next = node2;
        node2.next = node3;
        node3.next = node4;

        return head;
    }

    private static ListNode TestCase2()
    {
        ListNode head = new ListNode(1);
        ListNode node2 = new ListNode(2);
        ListNode node3 = new ListNode(3);
        ListNode node4 = new ListNode(4);
        ListNode node5 = new ListNode(5);

        head.next = node2;
        node2.next = node3;
        node3.next = node4;
        node4.next = node5;

        return head;
    }

    private static ListNode TestCase3()
    {
        ListNode head = new ListNode(1);
        ListNode node2 = new ListNode(2);

        head.next = node2;

        return head;
    }

    private static ListNode TestCase4()
    {
        ListNode head = new ListNode(1);

        return head;
    }

    private static ListNode TestCase5()
    {
        ListNode head = new ListNode(1);
        ListNode node2 = new ListNode(2);
        ListNode node3 = new ListNode(3);

        head.next = node2;
        node2.next = node3;

        return head;
    }

    // TC: O(n), SC: O(1)
    private static void ReorderListTwoPointers(ListNode head)
    {
        if (head.next == null || head.next.next == null)
            return;

        var firstPointer = head;
        var secondPointer = head.next;

        ListNode tailNode = secondPointer;
        ListNode nearTailNode = tailNode;

        while (secondPointer != null && secondPointer.next != null)
        {
            // Find the recent tail node
            while (tailNode != null && tailNode.next != null)
            {
                nearTailNode = tailNode;
                tailNode = tailNode.next;
            }

            // After finding the tail node update the list
            firstPointer.next = tailNode;
            tailNode.next = secondPointer;
            nearTailNode.next = null;

            firstPointer = secondPointer;
            secondPointer = secondPointer.next;
        }

        return;
    }

    public static void ReorderList(ListNode head)
    {
        ReorderListTwoPointers(head);
    }

    static void Main(string[] args)
    {
        ReorderList(TestCase5());
    }
}
