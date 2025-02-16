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

    private static PriorityQueue<int, int> HeapifyMin(int[] nums, int k)
    {
        PriorityQueue<int, int> heapMin = new PriorityQueue<int, int>();

        foreach (int num in nums)
        {
            heapMin.Enqueue(num, num);

            if (heapMin.Count > k) {
                heapMin.Dequeue();
            }
        }

        return heapMin;
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

    public static int FindKthLargest2(int[] nums, int k)
    {
        var heapMin = HeapifyMin(nums, k);

        return heapMin.Peek();
    }

    private static void Swap(int[] nums, int index1, int index2) {
        int temp = nums[index1];
        nums[index1] = nums[index2];
        nums[index2] = temp;
    }

    private static int QuickSelect(int[] nums, int left, int right, int partitionK) {
        int swapPointer = left;
        int pivot = right;

        for (int i = left; i < pivot; i++)
        {
            if (nums[i] <= nums[pivot]) {
                Swap(nums, swapPointer, i);
                swapPointer++;
            }
        }

        Swap(nums, swapPointer, pivot);

        if (swapPointer > partitionK) {
            return QuickSelect(nums, left, swapPointer - 1, partitionK);
        }
        else if (swapPointer < partitionK) {
            return QuickSelect(nums, swapPointer + 1, right, partitionK);
        }

        else {
            return nums[swapPointer];
        }
        
    }

    public static int FindKthLargest3(int[] nums, int k) {
        int partitionK = nums.Length - k;

        return QuickSelect(nums, 0, nums.Length - 1, partitionK);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(FindKthLargest(TestCase1().nums, TestCase1().k));
        // Console.WriteLine(FindKthLargest(TestCase2().nums, TestCase2().k));

        // Console.WriteLine(FindKthLargest2(TestCase1().nums, TestCase1().k));
        // Console.WriteLine(FindKthLargest2(TestCase2().nums, TestCase2().k));

        // Console.WriteLine(FindKthLargest3(TestCase1().nums, TestCase1().k));
        // Console.WriteLine(FindKthLargest3(TestCase2().nums, TestCase2().k));
    }
}
