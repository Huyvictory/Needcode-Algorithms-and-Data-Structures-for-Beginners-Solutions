namespace LRU_Cache;

public class LRUCache
{
    private Dictionary<int, LinkedListNode<(int key, int value)>> cache;

    private int capacity;

    private LinkedList<(int key, int value)> linkedList;

    public LRUCache(int capacity)
    {
        cache = new Dictionary<int, LinkedListNode<(int key, int value)>>(capacity);
        this.capacity = capacity;
        linkedList = new LinkedList<(int key, int value)>();
    }

    public int Get(int key)
    {
        if (!cache.ContainsKey(key))
        {
            return -1;
        }

        var node = cache[key];

        linkedList.Remove(node);
        linkedList.AddLast(node);

        return node.Value.value;
    }

    public void Put(int key, int value)
    {
        var nodeToInteract = new LinkedListNode<(int key, int value)>((key, value));

        if (cache.Count < capacity || cache.ContainsKey(key))
        {
            if (!cache.ContainsKey(key))
            {
                cache.Add(key, nodeToInteract);
            }
            else
            {
                var oldNode = cache[key];
                cache[key] = nodeToInteract;
                linkedList.Remove(oldNode);
            }

            linkedList.AddLast(nodeToInteract);
        }
        else if (cache.Count == capacity)
        {
            // Delete old LRU Node both at head of linked list and cache
            var Old_LRU_Node = linkedList.First();
            cache.Remove(Old_LRU_Node.key);
            linkedList.RemoveFirst();

            // Add new MRU Node to the cache and linked list
            cache.Add(key, nodeToInteract);
            linkedList.AddLast(nodeToInteract);
        }
    }
}
