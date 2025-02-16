namespace K_Closest_Points_to_Origin;

class Program
{
    private static (int[][] points, int k) TestCase1() {
        return ([[1,3],[-2,2]], 1);
    }

    private static (int[][] points, int k) TestCase2() {
        return ([[3,3],[5,-1],[-2,4]], 2);
    }

    private static PriorityQueue<int[], double> Heapify(int[][] points)
    {
        PriorityQueue<int[], double> minHeap = new PriorityQueue<int[], double>();

        foreach (int[] point in points)
        {
            minHeap.Enqueue(point, EuclieanDistanceCalculate(point));
        }

        return minHeap;
    }

    private static PriorityQueue<int[], double> Heapify2Max(int[][] points, int k)
    {
        PriorityQueue<int[], double> minHeap = new PriorityQueue<int[], double>();

        foreach (int[] point in points)
        {
            minHeap.Enqueue(point, -EuclieanDistanceCalculate(point));

            if (minHeap.Count > k) {
                minHeap.Dequeue();
            }
        }

        return minHeap;
    }
    

    public static double EuclieanDistanceCalculate(int[] point)
    {
        return Math.Sqrt(Math.Pow(point[0], 2) + Math.Pow(point[1], 2));
    }

    public static int[][] KClosest(int[][] points, int k) {
        int[][] result = new int[k][];

        var minHeap = Heapify(points);

        for (int i = 0; i < k; i++)
        {
            result[i] = minHeap.Dequeue();
        }

        return result;
     }

     public static int[][] KClosest2(int[][] points, int k) {
        int[][] result = new int[k][];

        var minHeap = Heapify2Max(points, k);

        for (int i = 0; i < k; i++)
        {
            result[i] = minHeap.Dequeue();
        }

        return result;
     }

    static void Main(string[] args)
    {
        var result1 = KClosest(TestCase1().points, TestCase1().k);
        // var result2 = KClosest(TestCase2().points, TestCase2().k);

        // var result1_2 = KClosest2(TestCase1().points, TestCase1().k);
        // var result2_2 = KClosest2(TestCase2().points, TestCase2().k);

        return;
    }
}
