namespace Guess_Number_Higher_or_Lower;

class Program
{
    private static int pickedNumber = 6;

    public static int guess(int num)
    {
        if (num > pickedNumber)
        {
            return -1;
        }
        else if (num < pickedNumber)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public static int GuessNumber(int n)
    {
        int left = 1;

        while (left <= n)
        {
            int midPointer = left + ((n - left) / 2);

            if (guess(midPointer) == -1)
            {
                n = midPointer - 1;
            }
            else if (guess(midPointer) == 1)
            {
                left = midPointer + 1;
            }
            else
            {
                return midPointer;
            }
        }

        return -1;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(GuessNumber(10));
    }
}
