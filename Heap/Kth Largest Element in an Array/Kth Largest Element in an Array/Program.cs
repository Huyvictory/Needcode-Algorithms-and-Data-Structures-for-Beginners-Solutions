namespace Kth_Largest_Element_in_an_Array;

class Program
{
    private static (int[] nums, int k) TestCase1() {
        return ([3,2,1,5,6,4], 2);
    }

    private static (int[] nums, int k) TestCase2() {
        return ([3,2,3,1,2,4,5,5,6], 4);
    }

    private static PriorityQueue<int, int> HeapifyMax(int[] nums)
    {
        PriorityQueue<int, int> heapMax = new PriorityQueue<int, int>();

        foreach (int num in nums)
        {
            heapMax.Enqueue(num, num > 0 ? -num : Math.Abs(num));
        }

        return heapMax;
    }

    public static int FindKthLargest(int[] nums, int k)
    {
        var heapMax = HeapifyMax(nums);

        while (k > 1)
        {
            heapMax.Dequeue();
            k--;
        }

        return heapMax.Peek();
    }

    static void Main(string[] args)
    {
        // Console.WriteLine(FindKthLargest(TestCase1().nums, TestCase1().k));
        Console.WriteLine(FindKthLargest(TestCase2().nums, TestCase2().k));
    }
}
