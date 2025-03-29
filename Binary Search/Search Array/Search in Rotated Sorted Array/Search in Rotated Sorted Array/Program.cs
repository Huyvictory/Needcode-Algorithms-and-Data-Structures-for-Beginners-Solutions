namespace Search_in_Rotated_Sorted_Array;

class Program
{
    private static (int[] nums, int target) TestCase1() {
        return (nums: [4,5,6,7,0,1,2], target: 0);
    }

    private static (int[] nums, int target) TestCase2() {
        return (nums: [4,5,6,7,0,1,2], target: 3);
    }

    private static (int[] nums, int target) TestCase3() {
        return (nums: [1], target: 0);
    }

    private static (int[] nums, int target) TestCase4() {
        return (nums: [5,6,7,0,1,2,4], target: 0);
    }

    private static (int[] nums, int target) TestCase5() {
        return (nums: [4,5,6,7,8,0,1,2], target: 8);
    }

    private static (int[] nums, int target) TestCase6() {
        return (nums: [4,5,6,7,0,1,2,3], target: 1);
    }

    private static (int[] nums, int target) TestCase7() {
        return (nums: [4,5,6,7,0,1,2,3], target: 5);
    }

    private static (int[] nums, int target) TestCase8() {
        return (nums: [3,1], target: 4);
    }

    private static (int[] nums, int target) TestCase9() {
        return (nums: [3,1], target: 3);
    }

    private static (int[] nums, int target) TestCase10() {
        return (nums: [3,1], target: 1);
    }

    private static (int[] nums, int target) TestCase11() {
        return (nums: [5,1,2,3,4], target: 1);
    }

    // TC: O(logn), SC: O(1)
    private static int SearchBinarySearch(int[] nums, int target)
    {
        int res = -1;

        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == target) {
                res = mid;
                break;
            }

            // Left and mid are in larger sub array section
            if (nums[left] <= nums[mid]) {
                
                // If target is smaller than element mid
                // values before and after mid could potentially smaller than than element at mid
                // We need to check which portion the target element is in

                // if target is equal or larger than left. That means it is in the left portion
                if (target < nums[mid] && target >= nums[left]) {
                    right = mid - 1;
                }

                // if target is smaller than left. That means it is in the right portion
                else if (target < nums[mid] && target < nums[left]) {
                    left = mid + 1;
                }

                // left and mid both in larger sub-array section but target is larger than both of these
                // then we move to right to check for that target
                else if (target > nums[mid]) {
                    left = mid + 1;
                }
            }

            // Mid and right both in smaller sub array section
            else {
                
                // If target is larger than element mid
                // We need to check which portion the target element is in

                // If the target is smaller or equal to right element:
                // That means it is still in right portion.
                if (target > nums[mid] && target <= nums[right]) {
                    left = mid + 1;
                }

                // If not then it is in left portion.
                if (target > nums[mid] && target > nums[right]) {
                    right = mid - 1;
                }

                // If target is smaller than mid and right then go to left to search for the target
                else if (target < nums[mid]) {
                    right = mid - 1;
                }
            }
        }

        return res;
    }

    private static int InternalBinarySearch(int[]nums, int target, int left, int right) {
        int res = -1;

        while (left <= right) {
            int mid = left + (right - left) / 2;

            if (nums[mid] > target) {
                right = mid - 1;
            } 
            else if (nums[mid] < target) {
                left = mid + 1;
            }
            else {
                res = mid;
                break;
            }
        }

        return res;
    }

    // TC: O(logn), SC: O(1)
    private static int SearchBinarySearchPivot(int[] nums, int target)
    {
        int pivot = 0;

        int left = 0;
        int right = nums.Length - 1;

        // Binary search to find the pivot
        while (left < right) {
            int mid = left + (right - left) / 2;

            // mid at left most sub array
            if (nums[mid] > nums[right]) {
                pivot = mid + 1;
                left = mid + 1;
            }

            // mid at right most sub array
            else if (nums[mid] <= nums[right]) {
                right = mid;
            }
        }

        int res;
        
        res = InternalBinarySearch(nums, target, 0, pivot - 1);
        
        if (res != -1) {
            return res;
        }
        else
        {
            res = InternalBinarySearch(nums, target, pivot, nums.Length - 1);
        }

        return res;
    }

    public static int Search(int[] nums, int target)
    {
        return SearchBinarySearchPivot(nums, target);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(Search(TestCase1().nums, TestCase1().target));
    }
}
