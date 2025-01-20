namespace Koko_Eating_Bananas;

class Program
{
    public static int[] TestCase1()
    {
        return new int[] { 3, 6, 7, 11 };
    }

    public static int[] TestCase2()
    {
        return new int[] { 30, 11, 23, 4, 20 };
    }

    public static int[] TestCase3()
    {
        return new int[] { 312884470, };
    }

    public static int[] TestCase4()
    {
        return new int[]
        {
            332484035,
            524908576,
            855865114,
            632922376,
            222257295,
            690155293,
            112677673,
            679580077,
            337406589,
            290818316,
            877337160,
            901728858,
            679284947,
            688210097,
            692137887,
            718203285,
            629455728,
            941802184
        };
    }

    public static int[] TestCase5()
    {
        return new int[] { 34392671, 891616382, 813261297, };
    }

    public static bool HasKokoEatenAllBananas(int speed, int[] piles, int limit)
    {
        int timeSpent = 0;

        for (int i = 0; i < piles.Length; i++)
        {
            timeSpent += (int)Math.Ceiling((decimal)piles[i] / speed);

            if (timeSpent > limit)
            {
                return false;
            }
        }

        return true;
    }

    public static int MinEatingSpeed(int[] piles, int h)
    {
        int left = 1;
        int right = piles.Max();
        int k = 0;

        while (left <= right)
        {
            int middle = left + ((right - left) / 2);

            if (HasKokoEatenAllBananas(middle, piles, h))
            {
                k = middle;
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }

        return k;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(MinEatingSpeed(TestCase1(), 8));
        Console.WriteLine(MinEatingSpeed(TestCase2(), 5));
        Console.WriteLine(MinEatingSpeed(TestCase2(), 6));
        Console.WriteLine(MinEatingSpeed(TestCase3(), 312884469));
        Console.WriteLine(MinEatingSpeed(TestCase4(), 823855818));
        Console.WriteLine(MinEatingSpeed(TestCase5(), 712127987));
    }
}
