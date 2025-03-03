namespace Counting_Bits;

class Program
{
    private int BitCounting(int n)
    {
        int count = 0;

        while (n > 0)
        {
            // Get rid of the 1 bit in the n integer
            n &= n - 1;

            count++;
        }

        return count;
    }

    public int[] CountBits(int n)
    {
        int[] ans = new int[n + 1];

        for (int i = 0; i < ans.Length; i++)
        {
            ans[i] = BitCounting(i);
        }

        return ans;
    }

    static void Main(string[] args)
    {
        Program testProgram = new Program();

        testProgram.CountBits(5);

        return;
    }
}
