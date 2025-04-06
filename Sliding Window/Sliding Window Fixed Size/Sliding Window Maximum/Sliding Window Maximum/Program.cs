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

    

    public static int[] MaxSlidingWindow(int[] nums, int k)
    {
        return MaxSlidingWindowBruteForce(nums, k);
    }

    static void Main(string[] args)
    {
        var res = MaxSlidingWindow(TestCase1().nums, TestCase1().k);

        return;
    }
}
