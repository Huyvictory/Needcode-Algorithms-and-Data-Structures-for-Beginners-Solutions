namespace Remove_Duplicates_from_Sorted_Array;

class Program
{
     public static int[] input = [1,1,2];

    static void Main(string[] args)
    {
        // Console.WriteLine(RemoveDuplicates(input));
        Console.WriteLine(RemoveDuplicates2(input));
    }

    public static void printAfterShift(int[] shiftedInputArray) {
        Console.WriteLine("----------------------------------------");

        for (int i = 0; i < shiftedInputArray.Length; i++)
        {
            Console.WriteLine($"Elements at {i} - {shiftedInputArray[i]}");
        }

        Console.WriteLine("----------------------------------------");

    }

    public static int RemoveDuplicates(int[] nums)
    {

    if (nums.Length == 1) return nums.Length;

        for (int i = 0; i < nums.Length; i++)
        {

            int j = i + 1;

            Console.WriteLine(j);

            if (j >= nums.Length)
            {
                break;
            }

            if (nums[j] == -101) {
                break;
            }

            while (nums[i] == nums[j])
            {
                //Shift elements to the left
                for (int k = j; k < nums.Length; k++)
                {
                    nums[k - 1] = nums[k];
                }

                if (nums[nums.Length - 1] != -101)
                {
                    nums[nums.Length - 1] = -101;
                }
            }

            printAfterShift(nums);            
        }


        return nums.Where((num) => num != -101).ToArray().Length;
    }

    public static int RemoveDuplicates2(int[] nums) {
        int leftPointer = 1;
        int rightPointer = 1;

        while (rightPointer < nums.Length) {

            if (nums[rightPointer] != nums[rightPointer - 1]) {
                nums[leftPointer] = nums[rightPointer];
                leftPointer += 1;
            }

            rightPointer += 1;
        }

        return leftPointer;
    }
}
