namespace House_Robber;

class Program
{
    private Dictionary<int, int> robbedHouses = new Dictionary<int, int>();

    private int[] TestCase1() {
        return [1,2,3,1];
    }

    private int[] TestCase2() {
        return [2,7,9,3,1];
    }

    private int[] TestCase3() {
        return [1,2];
    }

    private int[] TestCase4() {
        return [2,1];
    }

    private int[] TestCase5() {
        return [1,3,1];
    }

    private int[] TestCase6() {
        return [1,1,1];
    }

    private int[] TestCase7() {
        return [1];
    }

    private int RobTopDown(int[] nums, int attempt)
    {
        if (attempt >= nums.Length)
        {
            return 0;
        }

        if (robbedHouses.ContainsKey(attempt)) {
            return robbedHouses[attempt];
        }

        int firstDecision = nums[attempt] + RobTopDown(nums, attempt + 2);
        int secondDecision = RobTopDown(nums, attempt + 1);

        int totalMoneyRobbed = Math.Max(firstDecision,  secondDecision);

        if (!robbedHouses.ContainsKey(attempt))
        {
            robbedHouses.Add(attempt, totalMoneyRobbed);
        }

        return totalMoneyRobbed;
    }

    private int RobBottomUpArrayOptimized(int[] nums) {
        // First rob attempt get the highest money state of the first house
        List<int> dpList = new List<int>(2){nums[0], Math.Max(0 + nums[1], nums[0])};

        // Update the maximum money robbed from the next attempt that also depends on two latest robbing attempt
        // The maximum money is accounted by adding with non adjacent attempt compared with the adjacent one
        for (int i = 2; i < nums.Length; i++)
        {
            int temp = dpList[1];
            int maxMoneyNextRobAttempt = Math.Max(nums[i] + dpList[0], dpList[1]);

            // Dynamically update the state of two latest rob with largest money each
            dpList[1] = maxMoneyNextRobAttempt;
            dpList[0] = temp;
        }

        return dpList[1];
    }

    private int RobBottomUpArray(int[] nums) {
        // First rob attempt get the highest money state of the first house
        List<int> dpList = new List<int>(){nums[0], Math.Max(0 + nums[1], nums[0])};

        // Update the maximum money robbed from the next attempt that also depends on two latest robbing attempt
        // The maximum money is accounted by adding with non adjacent attempt compared with the adjacent one
        for (int i = 2; i < nums.Length; i++)
        {
            int maxMoneyNextRobAttempt = Math.Max(nums[i] + dpList[dpList.Count - 2], dpList[dpList.Count - 1]);

            dpList.Add(maxMoneyNextRobAttempt);
        }

        return dpList[dpList.Count - 1];
    }

    public int Rob(int[] nums)
    {
        if (nums.Length == 1) return nums[0];

        return RobBottomUpArray(nums);
    }

    static void Main(string[] args)
    {
        Program testProgram = new Program();
        Console.WriteLine(testProgram.Rob(testProgram.TestCase1()));
    }
}
