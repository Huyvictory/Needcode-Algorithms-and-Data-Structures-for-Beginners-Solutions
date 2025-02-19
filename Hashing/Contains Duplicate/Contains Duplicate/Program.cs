namespace Contains_Duplicate;

class Program
{
    private static int[] TestCase1() {
        return [1, 2, 3, 1];
    }

    private static int[] TestCase2() {
        return [1, 2, 3, 4];
    }

    private static int[] TestCase3() {
        return [1,1,1,3,3,4,3,2,4,2];
    }

    private static bool HashMapApproach(int[] nums)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!map.ContainsKey(nums[i]))
            {
                map.Add(nums[i], 1);
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    private static bool BruteForceApproach(int[] nums) {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] == nums[j]) {
                    return true;
                }
            }
        }

        return false;
    }

    private static bool TwoPointersApproach(int[] nums) {
        Array.Sort(nums);

        for (int i = 0; i < nums.Length; i++)
        {
            if (i + 1 < nums.Length && nums[i] == nums[i + 1]) {
                return true;
            }   
        }

        return false;
    }

    public static bool ContainsDuplicate(int[] nums)
    {
        // return HashMapApproach(nums);
        // return BruteForceApproach(nums);
        return TwoPointersApproach(nums);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(ContainsDuplicate(TestCase1()));
        Console.WriteLine(ContainsDuplicate(TestCase2()));
        Console.WriteLine(ContainsDuplicate(TestCase3()));
    }
}
