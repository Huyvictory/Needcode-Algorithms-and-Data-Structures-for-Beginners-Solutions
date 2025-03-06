namespace Top_K_Frequent_Elements;

class Program
{
    private static int[] TestCase1() {
        return [1,1,1,2,2,3];
    }

    private static int[] TestCase2() {
        return [1];
    }

    private static int[] TestCase3() {
        return [3,0,1,0];
    }

    private static int[] TestCase4() {
        return [4,1,-1,2,-1,2,3];
    }

    private static int[] TestCase5() {
        return [1,2];
    }

    private static int[] TestCase6() {
        return [5,3,1,1,1,3,5,73,1];
    }

    private static int[] TestCase7() {
        return [5,1,-1,-8,-7,8,-5,0,1,10,8,0,-4,3,-1,-1,4,-5,4,-3,0,2,2,2,4,-2,-4,8,-7,-7,2,-8,0,-8,10,8,-8,-2,-9,4,-7,6,6,-1,4,2,8,-3,5,-9,-3,6,-8,-5,5,10,2,-5,-1,-5,1,-3,7,0,8,-2,-3,-1,-5,4,7,-9,0,2,10,4,4,-4,-1,-1,6,-8,-9,-1,9,-9,3,5,1,6,-1,-2,4,2,4,-6,4,4,5,-5];
    }

    // TC: O(klogn), SC: O(n)
    private static int[] TopKFrequentHashMapMaxHeap(int[] nums, int k) {
        var map = new Dictionary<int, int>();
        var result = new List<int>();
        var minHeap = new PriorityQueue<int, int>();

        // Count frequency for each number
        foreach (var num in nums)
        {
            if (!map.ContainsKey(num))
            {
                map.Add(num, 1);
            }
            else {
                map[num] += 1;
            }       
        }

        // Loop every single pair in map and add to maxHeap
        foreach (var pair in map) {
            minHeap.Enqueue(pair.Key, pair.Value * -1);
        }

        // Get k most frequent elements of maxHeap
        while (k > 0) {
            result.Add(minHeap.Dequeue());        
            k--;
        }

        return result.ToArray();
    }

    public static int[] TopKFrequent(int[] nums, int k)
    {
        return TopKFrequentHashMapMaxHeap(nums, k);
    }

    static void Main(string[] args)
    {
        var result = TopKFrequent(TestCase7(), 7);
        
        return;
    }
}
