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
        return TwoSumBruteForce(numbers, target);
    }

    static void Main(string[] args)
    {
        var result = TwoSum(TestCase3().numbers, TestCase3().target);

        return;
    }
}
