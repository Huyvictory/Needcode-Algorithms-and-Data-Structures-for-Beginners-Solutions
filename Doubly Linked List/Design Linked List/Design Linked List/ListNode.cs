namespace Design_Linked_List;

public class ListNode
{
    public ListNode prev;
    public int val;
    public ListNode next;

    public ListNode(int val, ListNode prev = null, ListNode next = null)
    {
        this.prev = prev;
        this.val = val;
        this.next = next;
    }
}
