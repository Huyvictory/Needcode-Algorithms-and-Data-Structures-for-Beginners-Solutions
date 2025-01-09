namespace Design_Linked_List;

public class MyLinkedList
{
    public ListNode headNode = null;

    public ListNode tailNode = null;

    public List<int> myLinkedList = [];

    public MyLinkedList() { }

    public int Get(int index)
    {
        if (index > myLinkedList.Count)
            return -1;

        int traverseIndex = 0;
        int returnValNode = -1;

        ListNode curTraverseNode = headNode;

        while (curTraverseNode != null)
        {
            if (traverseIndex == index)
            {
                returnValNode = curTraverseNode.val;
                break;
            }

            curTraverseNode = curTraverseNode.next;
            traverseIndex++;
        }

        if (returnValNode == -1)
        {
            return -1;
        }

        return returnValNode;
    }

    public void AddAtHead(int val)
    {
        if (headNode == null)
        {
            headNode = new ListNode(val, null, null);
            tailNode = headNode;
        }
        else
        {
            ListNode newHeadNode = new ListNode(val, null, headNode);

            // Update tail node if it is still point at the old head node
            if (tailNode.prev == null)
            {
                tailNode.prev = newHeadNode;
            }

            headNode.prev = newHeadNode;
            headNode = newHeadNode;
        }

        myLinkedList.Add(headNode.val);
    }

    public void AddAtTail(int val)
    {
        ListNode newTailNode = new ListNode(val, tailNode, null);

        if (headNode == null && tailNode == null) {
            headNode = newTailNode;
            tailNode = newTailNode;

            myLinkedList.Add(tailNode.val);
            return;
        }

        tailNode.next = newTailNode;
        tailNode = newTailNode;

        myLinkedList.Add(tailNode.val);
    }

    public void AddAtIndex(int index, int val)
    {
        // Add at head
        if (index == 0)
        {
            AddAtHead(val);
            return;
        }

        // Add at tail
        if (index == myLinkedList.Count) {
            AddAtTail(val);
            return;
        }

        // Check for out of bound case
         if (Get(index) == -1)
            return;

        int traverseIndex = 1;
        ListNode curTraverseNode = headNode.next;

        ListNode newNodeAtIndex = new ListNode(val, null, null);

        while (curTraverseNode != null)
        {
    
            if (traverseIndex == index)
            {
                curTraverseNode.prev.next = newNodeAtIndex;
                newNodeAtIndex.prev = curTraverseNode.prev;
                newNodeAtIndex.next = curTraverseNode;
                curTraverseNode.prev = newNodeAtIndex;
                break;
            }

            curTraverseNode = curTraverseNode.next;
            traverseIndex++;
        }

        myLinkedList.Add(newNodeAtIndex.val);
    }

    public void DeleteAtIndex(int index)
    {
        if (Get(index) == -1)
            return;

        int traverseIndex = 0;
        ListNode curTraverseNode = headNode;

        while (curTraverseNode != null)
        {
            if (traverseIndex == index)
            {
                ListNode nextNode = curTraverseNode.next;
                ListNode prevNode = curTraverseNode.prev;

                // The only node in the link list
                if (prevNode == null && nextNode == null)
                {
                    headNode = null;
                    tailNode = null;

                    myLinkedList.Clear();
                    break;
                }

                // Delete at headNode
                if (prevNode == null)
                {
                    nextNode.prev = null;

                    myLinkedList.Remove(headNode.val);
                    headNode = nextNode;
                    break;
                }

                // Delete at tailNode
                if (nextNode == null)
                {
                    prevNode.next = null;

                    myLinkedList.Remove(tailNode.val);
                    tailNode = prevNode;
                    break;
                }

                prevNode.next = nextNode;
                nextNode.prev = prevNode;

                myLinkedList.Remove(curTraverseNode.val);

                curTraverseNode.next = null;
                curTraverseNode.prev = null;

                break;
            }

            curTraverseNode = curTraverseNode.next;
            traverseIndex++;
        }
    }
}
