namespace Reverse_Linked_List;

class Program
{
    public static ListNode ListNode5 = new ListNode(5);
    public static ListNode ListNode4 = new ListNode(4, ListNode5);
    public static ListNode ListNode3 = new ListNode(3, ListNode4);
    public static ListNode ListNode2 = new ListNode(2, ListNode3);
    public static ListNode ListNode1 = new ListNode(1, ListNode2);

    public static ListNode ReverseList(ListNode head)
    {
        // If link list doesn't have any node return null
        if (head == null)
            return null;

        // Keep track of the current node for every sub problem function call
        ListNode oldHead = head;

        // New head of every result linked list that belongs to a sub problem function  call
        ListNode newHead = null;

        // Have next node to traverse then call the next sub problem function
        if (head.next != null)
        {
            newHead = ReverseList(head.next);
            oldHead.next.next = head;
        }
        /* if reach to the old tailNode of original linked list,
         make it the new head node also the tail node of resulted linked list of a base case
         then return the result for other sub problem function call in the call stack or recursion tree  */
        else
        {
            newHead = head;
        }

        // This old Head of the linked list sub problem function call will become the new tail node
        oldHead.next = null;

        return newHead;
    }

    static void Main(string[] args)
    {
        ListNode reversedLinkedList = ReverseList(ListNode1);

        return;
    }
}
