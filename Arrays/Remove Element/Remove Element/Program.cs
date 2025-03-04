namespace Remove_Element;

class Program
{

    public static int[] inputArray = [0,1,2,2,3,0,4,2];
    public static int target = 2;

    static void Main(string[] args)
    {
        Console.WriteLine($"Number of unique elements: {RemoveElement(inputArray, target)}");
        PrintArray(inputArray);
    }

    public static void SwapElement(int indexPointerLeft, int indexPointerRight, int[] swappingArray) {
        int x = swappingArray[indexPointerLeft];
        swappingArray[indexPointerLeft] = swappingArray[indexPointerRight];
        swappingArray[indexPointerRight] = x;
    }

    public static void PrintArray(int[] arrayToPrint) {
        Console.WriteLine("-----------------------------------------");

        for (int i = 0; i < arrayToPrint.Length; i++)
        {
            Console.WriteLine($"Elements at {i} - {arrayToPrint[i]}");
        }

        Console.WriteLine("-----------------------------------------");

    }

    public static int RemoveElement(int[] nums, int val) {
        int pointerLeft  = 0;
        int pointerRight = 0;

        while(pointerRight < nums.Length) {

            if (nums[pointerLeft] == val && nums[pointerRight] != val) {
                
                SwapElement(pointerLeft, pointerRight, nums);

                pointerLeft++;
                pointerRight++;
                continue;
            }

            if (nums[pointerLeft] != val && nums[pointerRight] != val) {
                pointerLeft++;
                pointerRight++;
                continue;
            }

            if (nums[pointerLeft] == val && nums[pointerRight] == val) {
                pointerRight++;
                continue;
            }

            
        }

        return pointerLeft; 
    }
}
