namespace Design_Linked_List;

public class MyLinkedList2
{
    public ListNode DummyNode1 = new ListNode(0);

    public ListNode DummyNode2 = new ListNode(0);

    public MyLinkedList2()
    {
        DummyNode1.next = DummyNode2;
        DummyNode2.prev = DummyNode1;
    }

    public int Get(int index)
    {
        ListNode currentTraversalNode = DummyNode1.next;
        while (currentTraversalNode != null)
        {
            if (index == 0 && currentTraversalNode.next != null)
            {
                return currentTraversalNode.val;
            }

            currentTraversalNode = currentTraversalNode.next;
            index--;
        }

        return -1;
    }

    public void AddAtHead(int val)
    {
        ListNode newHeadNode = new ListNode(val);
        ListNode oldHeadNode = DummyNode1.next;

        newHeadNode.next = oldHeadNode;
        newHeadNode.prev = DummyNode1;
        DummyNode1.next = newHeadNode;
        oldHeadNode.prev = newHeadNode;
    }

    public void AddAtTail(int val)
    {
        ListNode newTailNode = new ListNode(val);
        ListNode oldTailNode = DummyNode2.prev;

        newTailNode.prev = oldTailNode;
        newTailNode.next = DummyNode2;
        oldTailNode.next = newTailNode;
        DummyNode2.prev = newTailNode;
    }

    public void AddAtIndex(int index, int val)
    {
        ListNode newNodeAtIndex = new ListNode(val);

        ListNode curTraversalNode = DummyNode1.next;

        if (index == 0)
        {
            AddAtHead(val);
            return;
        }

        while (curTraversalNode != null)
        {
            if (index == 0 && curTraversalNode.next != null)
            {
                ListNode previousNode = curTraversalNode.prev;
                newNodeAtIndex.prev = previousNode;
                newNodeAtIndex.next = curTraversalNode;

                previousNode.next = newNodeAtIndex;
                curTraversalNode.prev = newNodeAtIndex;
                break;
            }

            if (index == 0 && curTraversalNode.next == null)
            {
                AddAtTail(val);
                break;
            }

            curTraversalNode = curTraversalNode.next;
            index--;
        }
    }

    public void DeleteAtIndex(int index)
    {
        ListNode curTraversalNode = DummyNode1.next;

        if (curTraversalNode == null)
        {
            return;
        }

        while (curTraversalNode.next != null && index > 0)
        {
            curTraversalNode = curTraversalNode.next;
            index--;
        }

        if (index == 0 && curTraversalNode.next != null)
        {
            ListNode previousNode = curTraversalNode.prev;
            ListNode nextNode = curTraversalNode.next;

            previousNode.next = nextNode;
            nextNode.prev = previousNode;
        }
    }
}
