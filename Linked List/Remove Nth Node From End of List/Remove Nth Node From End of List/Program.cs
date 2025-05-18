namespace Remove_Nth_Node_From_End_of_List;

class Program
{
    private static ListNode TestCase1()
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

    private static ListNode TestCase2()
    {
        ListNode head = new ListNode(1);

        return head;
    }

    private static ListNode TestCase3()
    {
        ListNode head = new ListNode(1);
        ListNode node2 = new ListNode(2);

        head.next = node2;

        return head;
    }

    // TC: O(n), SC: O(1)
    private static ListNode RemoveNthFromEndCounting2Pass(ListNode head, int n)
    {
        if (head.next == null && n == 1)
        {
            return null;
        }

        // Count number of nodes in a given linked list input
        var numberOfNodes = 0;
        ListNode cur = head;

        while (cur != null)
        {
            numberOfNodes++;
            cur = cur.next;
        }

        // Find node to delete
        cur = head;
        var previousNode = cur;

        while (numberOfNodes != n)
        {
            numberOfNodes--;

            previousNode = cur;
            cur = cur.next;
        }

        // Check whether the node to delete is at the end or middle of the list
        if (previousNode != cur)
        {
            previousNode.next = cur.next;
            cur.next = null;
        }
        else
        {
            head = cur.next;
        }

        return head;
    }

    // TC: O(n), SC: O(1)
    private static ListNode RemoveNthFromEndTwoPointersNDistance(ListNode head, int n)
    {
        if (head.next == null && n == 1)
        {
            return null;
        }

        ListNode first = head;
        ListNode second = head;

        // Make first pointer to have n distance with second pointer
        while (n > 0)
        {
            first = first.next;
            n--;
        }

        while (first != null && first.next != null)
        {
            first = first.next;
            second = second.next;
        }

        // Check whether node to delete is at the end or middle linked list
        if (first != null)
        {
            second.next = second.next.next;
        }
        else
        {
            head = second.next;
        }

        return head;
    }

    public static ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        // return RemoveNthFromEndCounting2Pass(head, n);
        return RemoveNthFromEndTwoPointersNDistance(head, n);
    }

    static void Main(string[] args)
    {
        var result = RemoveNthFromEnd(TestCase1(), 2);

        return;
    }
}
