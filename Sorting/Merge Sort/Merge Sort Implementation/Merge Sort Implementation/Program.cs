namespace Merge_Sort_Implementation;

class Program
{
    public static List<Pair> MergeSort(List<Pair> pairs)
    {
        if (pairs.Count <= 1)
            return pairs;

        return MergeSortImplementation(pairs, 0, pairs.Count - 1);
    }

    public static List<Pair> TestCase1()
    {
        return new List<Pair>()
        {
            new Pair(5, "apple"),
            new Pair(2, "banana"),
            new Pair(9, "cherry"),
            new Pair(1, "date"),
            new Pair(9, "elderberry"),
        };
    }

    public static List<Pair> TestCase2()
    {
        return new List<Pair>() { new Pair(5, "apple"), };
    }

    public static List<Pair> MergeSubArraysLeftRight(
        List<Pair> leftSubArray,
        List<Pair> rightSubArray
    )
    {
        List<Pair> mergedSortedArray = new List<Pair>();

        int j = 0;
        int k = 0;

        while (j < leftSubArray.Count && k < rightSubArray.Count)
        {
            if (leftSubArray[j].Key <= rightSubArray[k].Key)
            {
                mergedSortedArray.Add(leftSubArray[j]);
                j++;
            }
            else
            {
                mergedSortedArray.Add(rightSubArray[k]);
                k++;
            }
        }

        /* Pointer j or k is still not out of bound, there is still some sorted elements in the array that needs to be
            added to the result sub array for other bigger sub problems to rely on
        */
        while (j < leftSubArray.Count)
        {
            mergedSortedArray.Add(leftSubArray[j]);
            j++;
        }

        while (k < rightSubArray.Count)
        {
            mergedSortedArray.Add(rightSubArray[k]);
            k++;
        }

        return mergedSortedArray;
    }

    public static List<Pair> MergeSortImplementation(List<Pair> pairs, int start, int end)
    {
        // Base case when splitted sub array only have one element and we don't have to sort or continue the split
        if (start == end)
            return new List<Pair>() { pairs[start] };

        int mediumPoint = (start + end) / 2;

        // Half Left Sub Array
        var subArrayLeft = MergeSortImplementation(pairs, start, mediumPoint);

        // Half Right Sub Array
        var subArrayRight = MergeSortImplementation(pairs, mediumPoint + 1, end);

        List<Pair> sortedSubArray = MergeSubArraysLeftRight(subArrayLeft, subArrayRight);

        return sortedSubArray;
    }

    public static void Main(string[] args)
    {
        var sortedArray = MergeSort(TestCase1());

        var sortedArray2 = MergeSort(TestCase2());

        return;
    }
}
