namespace Two_Sum;

class Program
{
    private static (int[] nums, int target) TestCase1() {
        return ([2, 7, 11, 15], 9);
    }

    private static (int[] nums, int target) TestCase2() {
        return ([3, 2, 4], 6);
    }

    private static (int[] nums, int target) TestCase3() {
        return ([3, 3], 6);
    }

    private static (int[] nums, int target) TestCase4() {
        return ([1,1,1,1,1,4,1,1,1,1,1,7,1,1,1,1,1], 11);
    }

    private static (int[] nums, int target) TestCase5() {
        return ([2,5,5,11], 10);
    }

    private static int[] HashMapImplementation(int[] nums, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();
        int [] result  = [];

        for (int i = 0; i < nums.Length; i++)
        {
            var minus = target - nums[i];

            if (minus + nums[i] == target && map.ContainsKey(minus))
            {
                result =  [map[minus], i];
                break;
            }

            else if (!map.ContainsKey(nums[i]))
            {
                map.Add(nums[i], i);
            }
        }

        return result;
    }

    private static int[] BinarySearchImplementation(int[] nums, int target) {
        var nums_sorted = nums.ToArray();
        Array.Sort(nums_sorted);

        int left = 0;
        int right = nums.Length - 1;

        while (true) {
            int sum = nums_sorted[left] + nums_sorted[right];

            if (sum < target) {
                left++;
            }
            else if (sum > target) {
                right--;
            }
            else {
                var index1 = Array.IndexOf(nums, nums_sorted[left]);
                var index2 = Array.IndexOf(nums, nums_sorted[right]);
                
                if (index1 != index2) {
                    return [index1, index2];
                }
                else {
                    for (int i = index1 + 1; i < nums.Length; i++)
                    {
                        if (nums[i] == nums_sorted[left]) {
                            return [index1, i];
                        }
                    }
                }
            }
        }
    }

    public static int[] TwoSum(int[] nums, int target) {
        // return HashMapImplementation(nums, target);

        return BinarySearchImplementation(nums, target);
     }

    static void Main(string[] args)
    {
        Console.WriteLine(string.Join(',', TwoSum(TestCase1().nums, TestCase1().target)));
        Console.WriteLine(string.Join(',', TwoSum(TestCase2().nums, TestCase2().target)));
        Console.WriteLine(string.Join(',', TwoSum(TestCase3().nums, TestCase3().target)));
        Console.WriteLine(string.Join(',', TwoSum(TestCase4().nums, TestCase4().target)));
        Console.WriteLine(string.Join(',', TwoSum(TestCase5().nums, TestCase5().target)));
    }
}
