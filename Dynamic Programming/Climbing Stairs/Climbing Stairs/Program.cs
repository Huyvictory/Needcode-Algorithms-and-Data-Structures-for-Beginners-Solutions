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
