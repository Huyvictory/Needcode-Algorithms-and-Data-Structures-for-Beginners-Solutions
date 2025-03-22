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

    public static int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        return NextGreaterElementBruteForce(nums1, nums2);
    }

    static void Main(string[] args)
    {
        var result = NextGreaterElement(TestCase2().nums1, TestCase2().nums2);

        return;
    }
}
