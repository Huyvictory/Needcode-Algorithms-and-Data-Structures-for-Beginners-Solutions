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

    // TC: O(log(min(m, n))), SC: O(1)
    private static double FindMedianSortedArraysBinarySearchPartitionArray(int[] nums1, int[] nums2) {
        int[] arrays1 = nums1;
        int[] arrays2 = nums2;

        // We init the arrays1 always have length that is smaller or equal arrays2
        if (nums1.Length > nums2.Length) {
            arrays1 = nums2;
            arrays2 = nums1;
        }

        int left = 0;
        int right = arrays1.Length;
        int total = arrays1.Length + arrays2.Length;

        double result = 0;

        int halfPartition = (total + 1) / 2;

        while (true) {
            // Get the left partition of both input arrays
            // These two left partitions form left partition of merged array
            int midArrays1 = (left + right) / 2;
            int midArrays2 = halfPartition - midArrays1;

            // Using lower and higher bound of int to avoid empty list test cases and out of bound situation
            int arrays1Left = midArrays1 > 0 ? arrays1[midArrays1 - 1] : int.MinValue;
            int arrays1Right = midArrays1 < arrays1.Length ? arrays1[midArrays1] : int.MaxValue; 
            int arrays2Left = midArrays2 > 0 ? arrays2[midArrays2 - 1] : int.MinValue;
            int arrays2Right = midArrays2 < arrays2.Length ? arrays2[midArrays2] : int.MaxValue;

            // If we handle the partition correctly
            // Compare elements that match the increasing sorted property of merged array
            if (arrays1Left <= arrays2Right && arrays2Left <= arrays1Right) {

                // If merge array has old number of elements
                if (total % 2 != 0)
                {
                    result = Math.Max(arrays1Left, arrays2Left);
                }
                // If merge array has even number of elements
                else {
                    result = (double)(Math.Max(arrays1Left, arrays2Left) + Math.Min(arrays1Right, arrays2Right)) / 2;
                }

                break;
            }

            // If the partition is not correct 
            // and element pointer partition left of one of the input array is larger than right pointer partition right
            else if (arrays2Right < arrays1Left) {
                right = midArrays1 - 1;
            }
            else {
                left = midArrays1 + 1;
            }
        }

        return result;
    }

    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        // return FindMedianSortedArraysMergeSortedArray(nums1, nums2);
        return FindMedianSortedArraysBinarySearchPartitionArray(nums1, nums2);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(FindMedianSortedArrays(TestCase1().nums1, TestCase1().nums2));
    }
}
