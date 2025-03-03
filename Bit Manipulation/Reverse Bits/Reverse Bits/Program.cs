namespace Reverse_Bits;

class Program
{
    public uint reverseBits(uint n)
    {
        // Build output binary by using n and with 1 shifting to the left i time for each iteration
        string outputBinary = "";
        for (int i = 0; i < 32; i++)
        {
            if (((n >> i) & 1) == 1)
            {
                outputBinary += "1";
            }
            else
            {
                outputBinary += "0";
            }
        }

        uint result = 0;

        // For each result we or with 1 shifting to left i times (for each iteration)
        for (int i = 0; i < 32; i++)
        {
            if (outputBinary[31 - i] == '1')
            {
                result = (uint)(result | (1 << i));
            }
        }

        return result;
    }

    static void Main(string[] args)
    {
        Program program = new Program();

        uint x = 0b_0000_0010_1001_0100_0001_1110_1001_1100;

        Console.WriteLine(program.reverseBits(x));
    }
}
