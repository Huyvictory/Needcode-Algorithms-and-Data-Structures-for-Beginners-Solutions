namespace Contains_Duplicate_II;

class Program
{
    private static (int[] nums, int k) TestCase1() {
        return ([1,2,3,1], 3);
    }

    private static (int[] nums, int k) TestCase2() {
        return ([1,0,1,1], 1);
    }

    private static (int[] nums, int k) TestCase3() {
        return ([1,2,3,1,2,3], 2);
    }

    // TC: O(n), SC: O(k)
    private static bool ContainsNearbyDuplicateSlidingWindow(int[] nums, int k)
    {
        var setWindow = new HashSet<int>();

        int left = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            // If the current set window has the size that is larger than k
            // Then remove the element at pointer left and move it to right to the next sliding window
            if (right - left > k)
            {
                setWindow.Remove(nums[left]);
                left++;
            }
            // If current set window already contains the element at right pointer
            // That means the current window already contains that element before
            if (setWindow.Contains(nums[right]))
            {
                return true;
            }

            setWindow.Add(nums[right]);
        }

        // If we could not find the nearest set sliding window that contains duplicate then return false
        return false;
    }

    public static bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        return ContainsNearbyDuplicateSlidingWindow(nums, k);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(ContainsNearbyDuplicate(TestCase3().nums, TestCase3().k));
    }
}
