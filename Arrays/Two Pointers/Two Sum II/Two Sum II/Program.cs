namespace Two_Sum_II;

class Program
{
    private static (int[] numbers, int target) TestCase1() {
        return ([2, 7, 11, 15], 9);
    }

    private static (int[] numbers, int target) TestCase2() {
        return ([2,3,4], 6);
    }

    private static (int[] numbers, int target) TestCase3() {
        return ([-1,0], -1);
    }

    // Using two pointers that go opposite ways
    // For every iteration of two pointers
    // If sum of two pointers element is greater than target, that means the upper bound is too large
    // we need to reduce the right pointer
    // Otherwise, the sum is smaller indicating the lower bound is too small then we need to increase the left pointer

    // TC: O(n), SC: O(1)
    private static int[] TwoSumTwoPointers(int[] numbers, int target)
    {
        int left = 0;
        int right = numbers.Length - 1;

        while (left < right)
        {
            if (numbers[left] + numbers[right] > target)
            {
                right--;
            }
            else if (numbers[left] + numbers[right] < target)
            {
                left++;
            }
            else
            {
                break;
            }
        }

        return new int[] { left + 1, right + 1 };
    }

    // For every single element in outer loop iteration
    // We would have another loop running inside to check for every possible pairs that could sum up to target

    // TC: O(n^2), SC: O(1)
    private static int[] TwoSumBruteForce(int[] numbers, int target) {
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[i] + numbers[j] == target) {
                    return new int[] {i + 1, j + 1};
                }

                else if (numbers[i] + numbers[j] > target) {
                    break;
                }
            }
        }

        return new int[] {};
    }

    public static int[] TwoSum(int[] numbers, int target)
    {
        return TwoSumTwoPointers(numbers, target);
    }

    static void Main(string[] args)
    {
        var result = TwoSum(TestCase1().numbers, TestCase1().target);

        return;
    }
}
