public class LRUCache
{
    private int _capacity;

    private Dictionary<int, LinkedListNode<(int key, int value)>> map;

    private LinkedList<(int key, int value)> cache;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        map = new Dictionary<int, LinkedListNode<(int key, int value)>>(capacity);
        cache = new LinkedList<(int key, int value)>();
    }

    public int Get(int key)
    {
        // If key exists in the map then update
        // the key that has just been used lately as the tail of the doubly linked list.
        if (map.TryGetValue(key, out LinkedListNode<(int key, int value)> value))
        {
            cache.Remove(value);
            cache.AddFirst(value);

            return value.Value.value;
        }

        return -1;
    }

    public void Put(int key, int value)
    {
        // If the cache has reached the capacity and it doesn't contain the new key
        if (cache.Count == _capacity && !map.ContainsKey(key))
        {
            map.Remove(cache.Last.Value.key);

            cache.RemoveLast();
        }

        var nodeToPut = new LinkedListNode<(int key, int value)>((key, value));

        if (!map.ContainsKey(key))
        {
            map.Add(key, null);
        }
        else
        {
            cache.Remove(map[key]);
        }

        cache.AddFirst(nodeToPut);
        map[key] = nodeToPut;
    }
}
