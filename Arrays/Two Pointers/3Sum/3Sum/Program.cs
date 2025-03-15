using System.Text;

namespace _3Sum;

class Program
{
    private static int[] TestCase1() {
        return [-1,0,1,2,-1,-4];
    }

    private static int[] TestCase2() {
        return [0,1,1];
    }

    private static int[] TestCase3() {
        return [0,0,0];
    }

    private static int[] TestCase4() {
        return [-2, -2, 0, 0, 2, 2];
    }

    private static IList<IList<int>> ThreeSumTwoPointersSorted(int[] nums)
    {
        // Sort the input array first
        Array.Sort(nums);

        // A result contains every distinct triplets
        var set = new HashSet<string>();
        var result = new List<IList<int>>();

        // Iterate every element in outer loop
        // Run inside loop that check for every pairs of element
        // that possibly sum up to current element with result of 0

        // TC: O(n^2), SC: O(c)
        for (int i = 0; i < nums.Length; i++)
        {
            int left = i + 1;
            int right = nums.Length - 1;

            // Continue checking sum if these two pointers haven't met each other
            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];

                // Upper bound too high
                if (sum > 0)
                {
                    right--;
                }
                // Lower bound too low
                else if (sum < 0)
                {
                    left++;
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(nums[i]);
                    sb.Append(nums[left]);
                    sb.Append(nums[right]);

                    // If set has not contain the current triplet, add to the result list
                    if (!set.Contains(sb.ToString()))
                    {
                        set.Add(sb.ToString());
                        result.Add(new int[] {nums[i], nums[left], nums[right]});
                    }

                    // Continue lookup for every possible pair
                    left++;
                    right--;
                }
            }
        }

        return result;
    }

    

    public static IList<IList<int>> ThreeSum(int[] nums)
    {
        return ThreeSumTwoPointersSorted(nums);
    }

    static void Main(string[] args)
    {
        var result = ThreeSum(TestCase1());

        return;
    }
}
