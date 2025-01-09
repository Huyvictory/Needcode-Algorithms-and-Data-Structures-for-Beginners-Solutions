namespace Implement_Stack_using_Queues;

public class MyStack
{
    public ListNode headNode = null;
    public ListNode tailNode = null;

    public MyStack() { }

    public void Push(int x)
    {
        ListNode newNode = new ListNode(x);
        if (headNode == null)
        {
            headNode = newNode;
            tailNode = headNode;
        }
        else
        {
            tailNode.next = newNode;
            tailNode = newNode;
        }
    }

    public int Pop()
    {
        if (Empty() == true)
            return -1;

        int ElementTopStack = tailNode.val;

        ListNode curTraversalNode = headNode;
        ListNode previousTailNode = null;

        while (curTraversalNode.next != null)
        {
            previousTailNode = curTraversalNode;
            curTraversalNode = curTraversalNode.next;
        }

        if (previousTailNode != null)
        {
            previousTailNode.next = null;
            tailNode = previousTailNode;
        }
        else
        {
            headNode = null;
            tailNode = null;
        }

        return ElementTopStack;
    }

    public int Top()
    {
        if (Empty() == true)
            return -1;

        return tailNode.val;
    }

    public bool Empty()
    {
        return headNode == null;
    }
}
