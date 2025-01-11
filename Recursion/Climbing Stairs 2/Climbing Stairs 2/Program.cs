namespace Climbing_Stairs_2;

class Program
{
    public static Dictionary<int, int> memoizedDecisitionsSubProblem = new Dictionary<int, int> { };

    public static int ClimbStairs(int n)
    {
        return StartClimbingStairs(n, 0);
    }

    public static int StartClimbingStairs(int steps, int StartingPoint = 0)
    {
        if (StartingPoint >= steps)
            return StartingPoint == steps ? 1 : 0;

        if (!memoizedDecisitionsSubProblem.ContainsKey(StartingPoint))
        {
            memoizedDecisitionsSubProblem[StartingPoint] = -1;
        }
        else
        {
            return memoizedDecisitionsSubProblem[StartingPoint];
        }

        return memoizedDecisitionsSubProblem[StartingPoint] =
            StartClimbingStairs(steps, StartingPoint + 1)
            + StartClimbingStairs(steps, StartingPoint + 2);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(ClimbStairs(45));
    }
}
