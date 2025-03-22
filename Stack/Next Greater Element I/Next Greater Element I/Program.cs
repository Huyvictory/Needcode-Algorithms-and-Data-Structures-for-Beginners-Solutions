namespace Next_Greater_Element_I;

class Program
{
    private static (int[] nums1, int[] nums2) TestCase1() {
        return (nums1: [4,1,2], nums2: [1,3,4,2]);
    }

    private static (int[] nums1, int[] nums2) TestCase2() {
        return (nums1: [2,4], nums2: [1,2,3,4]);
    }

    // TC: O(n^3), SC: O(n)
    private static int[] NextGreaterElementBruteForce(int[] nums1, int[] nums2)
    {
        int[] ans = new int[nums1.Length];

        // Iterate element of nums1 array
        for (int i = 0; i < nums1.Length; i++)
        {
            // Iterate element of element of nums2 array and find the exact element
            for (int j = 0; j < nums2.Length; j++)
            {
                if (nums1[i] == nums2[j])
                {
                    int indexFinding = j;
                    bool hasFoundNextGreaterElement = false;

                    for (int k = indexFinding + 1; k < nums2.Length; k++)
                    {
                        // If we have found the next greater element in nums2 array
                        // Update the ans output
                        if (nums2[k] > nums2[j])
                        {
                            ans[i] = nums2[k];
                            hasFoundNextGreaterElement = true;
                            break;
                        }
                    }

                    // If we can't find the next greater element of element of iteration i in nums2
                    // then we update the ans array with -1
                    if (!hasFoundNextGreaterElement)
                    {
                        ans[i] = -1;
                    }

                    break;
                }
            }
        }

        return ans;
    }

    // TC: O(n^2), SC: O(n)
    private static int[] NextGreaterElementHashMap(int[] nums1, int[] nums2) {
        // Save every element and its index in a hashmap of array nums2
        var map = new Dictionary<int, int>();

        int[] ans = new int[nums1.Length];

        for (int i = 0; i < nums2.Length; i++)
        {
            map.Add(nums2[i], i);
        }

        // Iterate element of nums1
        // Get same element in nums2 through map and find its next greater element in nums2
        for (int i = 0; i < nums1.Length; i++)
        {
            // Index to find next greater element of current element in array nums2
            var indexFinding = map[nums1[i]];

            bool hasFoundNextGreaterElement = false;

            for (int j = indexFinding + 1; j < nums2.Length; j++)
            {
                if (nums2[j] > nums1[i]) {
                    ans[i] = nums2[j];
                    hasFoundNextGreaterElement = true;
                    break;
                }
            }

            if (!hasFoundNextGreaterElement) {
                ans[i] = -1;
            }

        }

        return ans;
    }

    public static int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        // return NextGreaterElementBruteForce(nums1, nums2);
        return NextGreaterElementHashMap(nums1, nums2);
    }

    static void Main(string[] args)
    {
        var result = NextGreaterElement(TestCase2().nums1, TestCase2().nums2);

        return;
    }
}
