namespace Number_of_1_Bits;

class Program
{
    public int HammingWeight(int n)
    {
        int count = 0;

        while (n > 0)
        {
            // If the current bit bitwise and with 1 as (0000 0000 0000 0001)
            // give out a valid 1 bit then count up
            if ((n & 1) == 1)
            {
                count++;
            }

            // Shift bits of the integer n to the right and check for 1 bit at the end
            n = n >> 1;
        }

        return count;
    }

    static void Main(string[] args)
    {
        Program testProgram = new Program();

        Console.WriteLine(testProgram.HammingWeight(2147483645));
    }
}
