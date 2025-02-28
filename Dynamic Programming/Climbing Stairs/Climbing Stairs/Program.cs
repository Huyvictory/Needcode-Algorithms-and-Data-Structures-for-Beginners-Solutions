namespace Climbing_Stairs;

class Program
{
    private Dictionary<int, int> MemorizeSteps = new Dictionary<int, int>();

    private int ClimbStairsTopDown(int takenStep, int target)
    {
        // the decision of climbing stairs has reached over the top
        if (takenStep > target)
            return 0;

        // the decision of climbing stairs has reached to the top
        if (takenStep == target)
            return 1;

        // If we have taken that sub decision step then return the amount of unique ways
        // such that from that step we have make the decision of going 1 or 2 steps and found that unique ways to reach to top
        if (MemorizeSteps.ContainsKey(takenStep))
        {
            return MemorizeSteps[takenStep];
        }

        int decisionOneStep = ClimbStairsTopDown(takenStep + 1, target);
        int decisionTwoSteps = ClimbStairsTopDown(takenStep + 2, target);

        // Memorize the step we have taken and amount of unique ways that helped us reach to the top
        if (!MemorizeSteps.ContainsKey(takenStep))
        {
            MemorizeSteps.Add(takenStep, decisionOneStep + decisionTwoSteps);
        }

        return MemorizeSteps[takenStep];
    }

    private int ClimbStairsBottomUp(int target)
    {
        List<int> dpSteps = new List<int>() { 1, 1 };

        // For step number n and n - 1 we all have 1 way of reaching to step n
        // So we have to minus two for those two steps and get number of previous step numbers that need
        // to update the amount of unique ways reaching to top by depending dynamically number of ways of two recent step
        int i = target - 2;

        while (i >= 0)
        {
            // Memorize the recent step number ways of reach to top
            int temp = dpSteps[0];

            // Dynamically update the recent step numbers

            // Calculate the number of ways to reach to top of current previous step number (each iteration)
            dpSteps[0] = dpSteps[0] + dpSteps[1];

            dpSteps[1] = temp;

            // Move to the next previous step to compute number of ways reaching to top
            // (depend on two recent dynamically updated step after)
            i--;
        }

        return dpSteps[0];
    }

    public int ClimbStairs(int n)
    {
        return ClimbStairsTopDown(0, n);
    }

    static void Main(string[] args)
    {
        Program testProgram = new Program();

        Console.WriteLine(testProgram.ClimbStairs(5));
    }
}
