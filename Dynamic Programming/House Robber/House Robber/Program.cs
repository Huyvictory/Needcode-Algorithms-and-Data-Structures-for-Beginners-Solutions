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

    public int Rob(int[] nums)
    {
        return RobTopDown(nums, 0);
    }

    static void Main(string[] args)
    {
        Program testProgram = new Program();
        Console.WriteLine(testProgram.Rob(testProgram.TestCase1()));
    }
}
