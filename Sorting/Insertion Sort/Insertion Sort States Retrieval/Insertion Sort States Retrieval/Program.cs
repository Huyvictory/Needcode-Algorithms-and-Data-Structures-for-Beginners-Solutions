namespace Insertion_Sort_States_Retrieval;

class Program
{
    public static List<Pair> TestCase1()
    {
        return new List<Pair>
        {
            new Pair(5, "apple"),
            new Pair(2, "banana"),
            new Pair(9, "cherry")
        };
    }

    public static List<Pair> TestCase2()
    {
        return new List<Pair> { new Pair(3, "cat"), new Pair(3, "bird"), new Pair(2, "dog") };
    }

    public static List<List<Pair>> InsertionSort(List<Pair> pairs)
    {
        List<List<Pair>> result = new List<List<Pair>>() { };

        for (int i = 0; i < pairs.Count; i++)
        {
            int j = i - 1;

            while (j >= 0 && pairs[j + 1].Key < pairs[j].Key)
            {
                Pair temp = pairs[j + 1];
                pairs[j + 1] = pairs[j];
                pairs[j] = temp;

                j--;
            }

            Pair[] stateAfterInsertionSort = new Pair[pairs.Count];

            pairs.CopyTo(stateAfterInsertionSort);

            result.Add(stateAfterInsertionSort.ToList());
        }

        return result;
    }

    static void Main(string[] args)
    {
        InsertionSort(TestCase2());

        return;
    }
}
