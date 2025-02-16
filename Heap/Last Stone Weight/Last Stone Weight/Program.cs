namespace Last_Stone_Weight;

class Program
{
    private static PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

    private static int[] TestCase1() {
        return [2,7,4,1,8,1];
    }

    private static int[] TestCase2() {
        return [1];
    }

    private static int[] TestCase3() {
        return [2, 2];
    }

    private static void Heapify(List<int> stones)
    {
        foreach (int stone in stones)
        {
            minHeap.Enqueue(stone, stone);

            if (minHeap.Count > 2)
            {
                minHeap.Dequeue();
            }
        }
    }

    public static int LastStoneWeight(int[] stones)
    {
        if (stones.Length == 1)
            return stones[0];

        var listStones = stones.ToList();

        var numberOfStones = listStones.Count;
        while (numberOfStones > 1)
        {
            Heapify(listStones);

            var stone1 = minHeap.Dequeue();
            var stone2 = minHeap.Dequeue();

            if (stone1 == stone2)
            {
                listStones.Remove(stone1);
                listStones.Remove(stone2);

                numberOfStones -= 2;
            }
            else if (stone1 != stone2)
            {
                listStones.Remove(stone1);
                listStones[listStones.IndexOf(stone2)] = stone2 - stone1;

                numberOfStones -= 1;
            }
        }

        return listStones.Count == 0 ? 0 : listStones[0];
    }

    static void Main(string[] args)
    {
        Console.WriteLine(LastStoneWeight(TestCase1()));
        // Console.WriteLine(LastStoneWeight(TestCase2()));
        // Console.WriteLine(LastStoneWeight(TestCase3()));
    }
}
