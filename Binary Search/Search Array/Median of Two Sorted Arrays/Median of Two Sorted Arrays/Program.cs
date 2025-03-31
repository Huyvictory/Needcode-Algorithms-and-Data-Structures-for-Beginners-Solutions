namespace Median_of_Two_Sorted_Arrays;

class Program
{

    private static (int[] nums1, int[] nums2) TestCase1() {
        return ([1,3], [2]);
    }

    private static (int[] nums1, int[] nums2) TestCase2() {
        return ([1,2], [3,4]);
    }

    private static (int[] nums1, int[] nums2) TestCase3() {
        return ([1,2,3], [3,4]);
    }

    private static (int[] nums1, int[] nums2) TestCase4() {
        return ([1,2,3], [3,4,5]);
    }

    private static (int[] nums1, int[] nums2) TestCase5() {
        return ([1,2,3], [1,1,2]);
    }

    private static (int[] nums1, int[] nums2) TestCase6() {
        return ([1,2,3], [1,1]);
    }

    private static (int[] nums1, int[] nums2) TestCase7() {
        return ([1,1], [1,2]);
    }

    // TC: O(nlogn), SC: O(n)
    private static double FindMedianSortedArraysMergeSortedArray(int[] nums1, int[] nums2)
    {
        double result = 0;

        var mergedSortedArray = nums1.Concat(nums2).ToArray();

        Array.Sort(mergedSortedArray);

        int left = 0;
        int right = mergedSortedArray.Length - 1;

        // If the merged sorted array's length is odd
        // Then median is the middle element
        if (mergedSortedArray.Length % 2 != 0)
        {
            int mid = left + (right - left) / 2;

            result = mergedSortedArray[mid];
        }
        // If the length is equal
        // the median is the average two sum of two middle elements
        else
        {
            int mid = left + (right - left) / 2;

            result = (double)(mergedSortedArray[mid] + mergedSortedArray[mid + 1]) / 2;
        }

        return result;
    }

    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        return FindMedianSortedArraysMergeSortedArray(nums1, nums2);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(FindMedianSortedArrays(TestCase1().nums1, TestCase1().nums2));
    }
}
