namespace Sort_Colors;

class Program
{
    public static int[] TestCase1()
    {
        return new int[] { 2, 0, 2, 1, 1, 0 };
    }

    public static int[] TestCase2()
    {
        return new int[] { 2, 0, 1 };
    }

    public static int[] TestCase3()
    {
        return new int[] { 0, 1, 2 };
    }

    public static int[] TestCase4()
    {
        return new int[] { 1 };
    }

    public static int[] TestCase5()
    {
        return new int[] { 1, 1 };
    }

    public static int[] TestCase6()
    {
        return new int[] { 2, 2 };
    }

    public static int[] BucketFrequency(int[] nums)
    {
        int maxNumber = nums.Max();

        int[] bucketList = new int[Math.Max(maxNumber, nums.Length) + 1];

        foreach (int num in nums)
        {
            bucketList[num]++;
        }

        var finalBucketList = bucketList;

        return finalBucketList;
    }

    public static void SortColors(int[] nums)
    {
        if (nums.Length <= 1)
            return;

        int[] bucketList = BucketFrequency(nums);

        int indexSwap = 0;

        for (int i = 0; i < bucketList.Length; i++)
        {
            for (int j = 0; j < bucketList[i]; j++)
            {
                nums[indexSwap] = i;
                indexSwap++;
            }
        }

        return;
    }

    static void Main(string[] args)
    {
        SortColors(TestCase6());

        return;
    }
}
