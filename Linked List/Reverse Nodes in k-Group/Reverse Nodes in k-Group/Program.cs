namespace Reverse_Nodes_in_k_Group;

class Program
{
    private static (ListNode head, int k) TestCase1()
    {
        var head = new ListNode(1);
        var node2 = new ListNode(2);
        var node3 = new ListNode(3);
        var node4 = new ListNode(4);
        var node5 = new ListNode(5);

        head.next = node2;
        node2.next = node3;
        node3.next = node4;
        node4.next = node5;

        return (head, 2);
    }

    private static (ListNode head, int k) TestCase2()
    {
        var head = new ListNode(1);
        var node2 = new ListNode(2);
        var node3 = new ListNode(3);
        var node4 = new ListNode(4);
        var node5 = new ListNode(5);

        head.next = node2;
        node2.next = node3;
        node3.next = node4;
        node4.next = node5;

        return (head, 3);
    }

    private static (ListNode head, int k) TestCase3()
    {
        var head = new ListNode(1);
        var node2 = new ListNode(2);
        var node3 = new ListNode(3);
        var node4 = new ListNode(4);
        var node5 = new ListNode(5);

        head.next = node2;
        node2.next = node3;
        node3.next = node4;
        node4.next = node5;

        return (head, 1);
    }

    private static (ListNode head, int k) TestCase4()
    {
        var head = new ListNode(1);
        var node2 = new ListNode(2);
        var node3 = new ListNode(3);
        var node4 = new ListNode(4);
        var node5 = new ListNode(5);

        head.next = node2;
        node2.next = node3;
        node3.next = node4;
        node4.next = node5;

        return (head, 5);
    }

    // Method to reverse linked list in specified range from start to end
    private static (ListNode reversedLinkedLIst, ListNode oldHead) ReverseLinkedList(
        ListNode start,
        ListNode end
    )
    {
        var cur = start;
        ListNode previous = null;
        ListNode temp = null;

        while (cur != null)
        {
            // Keep track nodes from original linked list
            temp = cur.next;

            cur.next = previous!;
            previous = cur;

            // If we reach to the end of the reverse linked list size k, stop the reverse
            if (cur == end)
                break;

            cur = temp;
        }

        return (previous!, temp!);
    }

    // TC: O(n * k), SC: O(1)
    private static ListNode ReverseKGroupBruteForceTwoPointers(ListNode head, int k)
    {
        if (head.next == null)
            return head;

        ListNode res = new ListNode(0);

        var fast = head;
        var slow = fast;
        var curRes = res;

        var currentNumberNodes = 0;

        while (fast != null)
        {
            // Count number of traversed nodes
            currentNumberNodes++;

            // Number of traversed nodes reaches size k then we reverse that portion of linked list
            if (currentNumberNodes == k)
            {
                var reverseResult = ReverseLinkedList(slow, fast);
                curRes.next = reverseResult.reversedLinkedLIst;

                currentNumberNodes = 0;

                // Update pointers for reverse in next iterations
                curRes = slow;
                fast = reverseResult.oldHead;
                slow = fast;

                continue;
            }

            fast = fast.next;
        }

        // Update the pointer reference to point to rest of the input linked list
        curRes.next = slow;

        return res.next;
    }

    public static ListNode ReverseKGroup(ListNode head, int k)
    {
        return ReverseKGroupBruteForceTwoPointers(head, k);
    }

    static void Main(string[] args)
    {
        var res = ReverseKGroup(TestCase4().head, TestCase4().k);

        return;
    }
}
