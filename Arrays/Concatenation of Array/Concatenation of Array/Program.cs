namespace Concatenation_of_Array;

class Program
{

    private static int[] inputArray = [1,2,1];

    private static int numberOfConcatTimes = 2;

    static void Main(string[] args)
    {
        var ConcatArray = GetConcatenation(inputArray);
        PrintConcatArray(ConcatArray);
    }

    public static void PrintConcatArray(int[] concatArray) {

        Console.WriteLine("---------------------------------");
        foreach (int item in concatArray)
        {
            Console.WriteLine($"Element {item}");
        }
        Console.WriteLine("---------------------------------");
    }

    public static int[] ConcatArray(int[] originalArray)
    {
        int originalArrayLength = originalArray.Length;

        int[] newResizedArray = new int[2 * originalArrayLength];

        for (int i = 0; i < newResizedArray.Length; i++)
        {
            

            if (i < originalArrayLength)
            {
                newResizedArray[i] = originalArray[i];
                
            }
            else {
                newResizedArray[i] = originalArray[i - originalArrayLength];
            }
        }

        return newResizedArray;
    }

    public static int[] ContactArrayV2(int[] originalArray, int numberOfContactTimes) {
        List<int> newResizedArray = new List<int>();

        for (int i = 1; i <= numberOfContactTimes; i++) {
            for (int j = 0; j < originalArray.Length; j++) {
                newResizedArray.Add(originalArray[j]);
            }
        }

        return newResizedArray.ToArray();
    }    

    public static int[] GetConcatenation(int[] nums)
    {
        return ContactArrayV2(nums, numberOfConcatTimes);
    }
}
