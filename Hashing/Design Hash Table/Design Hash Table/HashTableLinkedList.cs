namespace Design_Hash_Table;

public class HashTableLinkedList
{
    private List<LinkedList<(int key, int value)>> map;

    private int capacity;

    private int size;

    public HashTableLinkedList(int capacity)
    {
        this.capacity = capacity;
        size = 0;
        map = new List<LinkedList<(int key, int value)>>(capacity);
        map.AddRange(Enumerable.Repeat<LinkedList<(int key, int value)>>(null, capacity));
    }

    private int Hash(int key)
    {
        return key % capacity;
    }

    public int Get(int key)
    {
        var hashKeyIndex = Hash(key);
        var linkedListHashIndex = map[hashKeyIndex];
        var linkedListNodeHashIndex = linkedListHashIndex?.First ?? null;

        if (linkedListNodeHashIndex == null)
        {
            return -1;
        }

        while (linkedListNodeHashIndex != null)
        {
            if (linkedListNodeHashIndex.Value.key == key)
            {
                return linkedListNodeHashIndex.Value.value;
            }

            linkedListNodeHashIndex = linkedListNodeHashIndex.Next;
        }

        return -1;
    }

    public int GetSize()
    {
        return size;
    }

    public int GetCapacity()
    {
        return capacity;
    }

    public void Insert(int key, int value)
    {
        var hashKeyIndex = Hash(key);

        if (map[hashKeyIndex] == null)
        {
            // Linked List has not been initialized yet
            var newLinkedList = new LinkedList<(int key, int value)>();
            newLinkedList.AddFirst(new LinkedListNode<(int key, int value)>((key, value)));
            map[hashKeyIndex] = newLinkedList;
        }
        // Collision detected
        else if (map[hashKeyIndex] != null)
        {
            var linkedList = map[hashKeyIndex];
            var cur = linkedList.First;

            while (cur != null)
            {
                // Override existing linked list node with new value
                if (cur.Value.key == key)
                {
                    cur.Value = (key, value);
                    return;
                }

                cur = cur.Next;
            }

            // If the node does not contain in the linked list add it as new tail node
            linkedList?.AddLast(new LinkedListNode<(int key, int value)>((key, value)));
        }

        size++;

        // If the size is equal or more than half of the maximum capacity of the array map then resize
        if (size >= (capacity / 2))
        {
            Resize();
        }
    }

    public void InsertNodeLinkedList(LinkedListNode<(int key, int value)> node)
    {
        while (node != null) { }
    }

    public bool Remove(int key)
    {
        var hashKeyIndex = Hash(key);
        var linkedList = map[hashKeyIndex];
        LinkedListNode<(int key, int value)>? linkedListNode = linkedList?.First ?? null;

        while (linkedListNode != null)
        {
            if (linkedListNode.Value.key == key)
            {
                linkedList.Remove(linkedListNode);

                if (linkedList.Count == 0)
                {
                    map[hashKeyIndex] = null;
                }

                size--;
                return true;
            }

            linkedListNode = linkedListNode.Next;
        }

        return false;
    }

    private void Rehashing()
    {
        var oldMap = map;
        map = new List<LinkedList<(int key, int value)>>(capacity);
        map.AddRange(Enumerable.Repeat<LinkedList<(int key, int value)>>(null, capacity));

        foreach (var linkedList in oldMap)
        {
            if (linkedList != null)
            {
                var collisionHashIndex = Hash(linkedList.First.Value.key);
                map[collisionHashIndex] = linkedList;
            }
        }
    }

    public void Resize()
    {
        capacity *= 2;
        Rehashing();
    }
}
