namespace Kth_Largest_Element_in_a_Stream;

public class KthLargest
{
    private PriorityQueue<int, int> StreamNums = new PriorityQueue<int, int>();

    private int k;

    public KthLargest(int k, int[] nums)
    {
        this.k = k;

        foreach (int num in nums)
        {
            StreamNums.Enqueue(num, num);
        }
    }

    public int Add(int val)
    {
        StreamNums.Enqueue(val, val);

        while (StreamNums.Count > k)
        {
            StreamNums.Dequeue();
        }

        return StreamNums.Peek();
    }
}
