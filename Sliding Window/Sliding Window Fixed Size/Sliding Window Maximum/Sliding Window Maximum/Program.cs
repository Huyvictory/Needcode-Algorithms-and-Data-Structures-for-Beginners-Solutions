namespace Sliding_Window_Maximum;

class Program
{
    private static (int[] nums, int k) TestCase1() {
        return ([1,3,-1,-3,5,3,6,7], 3);
    }

    private static (int[] nums, int k) TestCase2() {
        return ([1], 1);
    }

    // TC: O(n * k), SC: O(1)
    private static int[] MaxSlidingWindowBruteForce(int[] nums, int k)
    {
        List<int> result = new List<int>();

        // Iterate for every possible sliding window of size k
        for (int left = 0; left < nums.Length; left++)
        {
            int right = left + k - 1;

            if (right >= nums.Length) {
                break;
            }

            int i = left;
            int max = int.MinValue;

            while (i <= right)
            {
                if (nums[i] > max)
                {
                    max = nums[i];
                }
                i++;
            }

            result.Add(max);
        }

        return result.ToArray();
    }

    // TC: O(n), SC: O(n)
    private static int[] MaxSlidingWindowDequeue(int[] nums, int k)
    {
        List<(int num, int index)> dequeue = new List<(int num, int index)>();
        List<int> ans = new List<int>();

        // Pointer to trace the max of many sliding windows
        int left = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            // If we meet next max value in next sliding window position
            // Update the queue to only contains max element of every sliding window
            while (dequeue.Count > 0 && nums[right] > dequeue.Last().num) {
                dequeue.RemoveAt(dequeue.Count - 1);
            }

            dequeue.Add((nums[right], right));

            // Check if current max is at the current sliding window
            // If not then remove that element to update the correct max value of current sliding window
            if (left > dequeue.First().index) {
                dequeue.RemoveAt(0);
            }

            // Check if current element has form a sliding window or not
            if (right + 1 >= k) {
                ans.Add(dequeue.First().num);

                left++;
            }
        }

        return ans.ToArray();
    }

    public static int[] MaxSlidingWindow(int[] nums, int k)
    {
        // return MaxSlidingWindowBruteForce(nums, k);
        return MaxSlidingWindowDequeue(nums, k);
    }

    static void Main(string[] args)
    {
        var res = MaxSlidingWindow(TestCase1().nums, TestCase1().k);

        return;
    }
}
