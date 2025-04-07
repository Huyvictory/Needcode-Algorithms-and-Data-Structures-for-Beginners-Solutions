namespace Reverse_Linked_List;

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

    private static ListNode ReverseListThreePointers(ListNode head)
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

    // TC: O(n), SC: O(1)
    private static ListNode ReverseListTwoPointers(ListNode head)
    {
        if (head == null)
            return null;

        // Pointer cur that traverse on original linked list
        var cur = head.next;

        // Pointer newHead to keep track all of the swaps reverse
        // By default this is the head of original linked list but has been changed to the tail node of reversed linked list
        var newHead = head;
        newHead.next = null;

        while (cur != null)
        {
            // Keep track of the next node of original linked list
            var nextNode = cur.next;

            // Reverse the pointer reference of every node in original linked list
            cur.next = newHead;

            // Move pointer newHead to next new head position
            newHead = cur;

            // Move to next node of original linked list for next swap reverse
            cur = nextNode;
        }

        return newHead;
    }

    public static ListNode ReverseList(ListNode head)
    {
        // return ReverseListThreePointers(head);
        return ReverseListTwoPointers(head);
    }

    static void Main(string[] args)
    {
        var result = ReverseList(TestCase1());

        return;
    }
}
