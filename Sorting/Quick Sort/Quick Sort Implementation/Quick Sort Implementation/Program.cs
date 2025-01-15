namespace Quick_Sort_Implementation;

class Program
{
    public static List<Pair> TestCase1()
    {
        return new List<Pair> { new Pair(3, "cat"), new Pair(2, "dog"), new Pair(3, "bird") };
    }

    public static List<Pair> TestCase2()
    {
        return new List<Pair>
        {
            new Pair(5, "apple"),
            new Pair(9, "banana"),
            new Pair(9, "cherry"),
            new Pair(1, "date"),
            new Pair(9, "elderberry")
        };
    }

    public static List<Pair> QuickSort(List<Pair> pairs)
    {
        return QuickSortImplementation(pairs, 0, pairs.Count - 1);
    }

    public static List<Pair> QuickSortImplementation(List<Pair> pairs, int start, int end)
    {
        // base case
        if ((end - start + 1) <= 1)
            return pairs;

        int pivotPosition = end;
        int swapPointer = start;

        for (int i = start; i < end; i++)
        {
            if (pairs[i].Key < pairs[pivotPosition].Key)
            {
                Pair temp = pairs[swapPointer];
                pairs[swapPointer] = pairs[i];
                pairs[i] = temp;
                swapPointer++;
            }
        }

        Pair tempSwapPivot = pairs[swapPointer];
        pairs[swapPointer] = pairs[pivotPosition];
        pairs[pivotPosition] = tempSwapPivot;

        QuickSortImplementation(pairs, start, swapPointer - 1);
        QuickSortImplementation(pairs, swapPointer + 1, end);

        return pairs;
    }

    static void Main(string[] args)
    {
        var sortedList = QuickSort(TestCase2());

        return;
    }
}
