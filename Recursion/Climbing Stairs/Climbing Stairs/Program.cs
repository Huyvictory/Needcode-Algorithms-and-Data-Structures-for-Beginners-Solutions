namespace Climbing_Stairs;

class Program
{
    public static int[] cacheData;

    public static int ClimbStairs(int n)
    {
        if (n <= 2)
            return n;

        return ClimbStairs(n - 1) + ClimbStairs(n - 2);
    }

    public static int ClimbStairs2(int n)
    {
        cacheData = new int[n];
        for (int i = 0; i < n; i++)
        {
            cacheData[i] = -1;
        }

        return ClimbStairs_DP(n, 0);
    }

    public static int ClimbStairs_DP(int n, int i = 0)
    {
        if (i >= n)
        {
            return i == n ? 1 : 0;
        }

        if (cacheData[i] != -1)
            return cacheData[i];

        cacheData[i] = ClimbStairs_DP(n, i + 1) + ClimbStairs_DP(n, i + 2);

        return cacheData[i];
    }

    static void Main(string[] args)
    {
        Console.WriteLine(ClimbStairs(6));
        Console.WriteLine(ClimbStairs2(6));

        Console.WriteLine(ClimbStairs(7));
        Console.WriteLine(ClimbStairs2(7));

        Console.WriteLine(ClimbStairs(8));
        Console.WriteLine(ClimbStairs2(8));

        Console.WriteLine(ClimbStairs(9));
        Console.WriteLine(ClimbStairs2(9));

        Console.WriteLine(ClimbStairs(10));
        Console.WriteLine(ClimbStairs2(10));

        Console.WriteLine(ClimbStairs(45));
        Console.WriteLine(ClimbStairs2(45));
    }
}
