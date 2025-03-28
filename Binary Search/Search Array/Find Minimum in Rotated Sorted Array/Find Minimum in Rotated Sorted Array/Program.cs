namespace Find_Minimum_in_Rotated_Sorted_Array;

class Program
{
    private static int[] TestCase1() {
        return [3,4,5,1,2];
    }

    private static int[] TestCase2() {
        return [4,5,6,7,0,1,2];
    }

    private static int[] TestCase3() {
        return [11,13,15,17];
    }

    private static int[] TestCase4() {
        return [2,1];
    }

    private static int[] TestCase5() {
        return [266,267,268,269,271,278,282,292,293,298,6,9,15,19,21,26,33,35,37,38,39,46,49,54,65,71,74,77,79,82,83,88,92,93,94,97,104,108,114,115,117,122,123,127,128,129,134,137,141,142,144,147,150,154,160,163,166,169,172,173,177,180,183,184,188,198,203,208,210,214,218,220,223,224,233,236,241,243,253,256,257,262,263];
    }

    // TC: O(logn), SC: O(1)
    private static int FindMinBinarySearch(int[] nums)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            // If left and mid elements are both larger than the element at right pointer
            // that means both of those two are in the rotated increasing sub-array
            // Move left pointer closer to non-rotated increasing sub-array

            if (nums[left] > nums[right] && nums[mid] > nums[right] && nums[left] <= nums[mid])
            {
                left = mid + 1;
            }
            // If pointer at left is both larger than mid and right elements,
            // also move pointer right closer to non-rotated increasing sub-array
            else if (nums[left] > nums[mid] && nums[left] > nums[right])
            {
                right = mid;
            }
            // If element at left pointer is smaller or equal mid and smaller than right pointer elements
            // That means it already in the non-rotated increasing sub-array
            else if (nums[left] <= nums[mid] && nums[left] < nums[right])
            {
                int shiftedLeftPointer = left - 1;
                if (shiftedLeftPointer < 0 || nums[shiftedLeftPointer] > nums[left])
                {
                    break;
                }
                else
                {
                    left = shiftedLeftPointer;
                    right = mid - 1;
                }
            }
        }

        return nums[left];
    }

    public static int FindMin(int[] nums)
    {
        return FindMinBinarySearch(nums);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(FindMin(TestCase5()));
    }
}
