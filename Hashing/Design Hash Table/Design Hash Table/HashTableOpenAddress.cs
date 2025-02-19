namespace Design_Hash_Table;

// Open Address Hash Collision implementation
public class HashTableOpenAddress
{
    private List<Pair> map;
    private int capacity;
    private int size;

    public HashTableOpenAddress(int capacity)
    {
        this.capacity = capacity;
        size = 0;
        map = new List<Pair>(capacity);
        map.AddRange(Enumerable.Repeat<Pair>(null, capacity));
    }

    private int Hash(int key)
    {
        return key % capacity;
    }

    public int Get(int key)
    {
        var hashIndex = Hash(key);

        while (map[hashIndex] != null)
        {
            if (map[hashIndex].key == key)
            {
                return map[hashIndex].value;
            }

            hashIndex++;

            // Make sure the hash index is always inbound of array map
            hashIndex = Hash(hashIndex);
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
        var hashIndex = Hash(key);

        while (true)
        {
            if (map[hashIndex] != null && map[hashIndex].key == key)
            {
                map[hashIndex].value = value;
            }

            if (map[hashIndex] == null)
            {
                map[hashIndex] = new Pair(key, value);

                size++;

                // If the size is equal or more than half of the maximum capacity of the array map then resize
                if (size >= (capacity / 2))
                {
                    Resize();
                }
                break;
            }

            hashIndex++;

            hashIndex = Hash(hashIndex);
        }
    }

    public bool Remove(int key)
    {
        var hashIndex = Hash(key);

        while (map[hashIndex] != null)
        {
            if (map[hashIndex].key == key)
            {
                map[hashIndex] = null;
                size--;
                return true;
            }

            hashIndex++;

            hashIndex = Hash(hashIndex);
        }

        return false;
    }

    private void Rehashing()
    {
        var oldMap = map;
        map = new List<Pair>();
        map.AddRange(Enumerable.Repeat<Pair>(null, capacity));
        size = 0;

        // Rehashing the existing keys in the old map
        foreach (var pair in oldMap)
        {
            if (pair != null)
            {
                Insert(pair.key, pair.value);
            }
        }
    }

    public void Resize()
    {
        capacity *= 2;
        Rehashing();
    }
}
