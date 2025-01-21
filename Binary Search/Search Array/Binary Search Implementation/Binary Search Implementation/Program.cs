namespace Binary_Search_Implementation;

class Program
{
    public static int[] TestCase1()
    {
        return new int[] { -1, 0, 3, 5, 9, 12 };
    }

    public static int Search(int[] nums, int target)
    {
        int left = 0,
            right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else
            {
                return mid;
            }
        }

        return -1;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(Search(TestCase1(), 9));
        Console.WriteLine(Search(TestCase1(), 2));
    }
}
