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

    public int[] CountBits2(int n)
    {
        int[] dp = new int[n + 1];
        dp[0] = 0;

        int offset = 1;

        for (int i = 1; i < dp.Length; i++)
        {
            // Current number is a number that has the significant 1 bit shifted to left
            if (offset * 2 == i)
            {
                offset = i;
            }

            // Number of 1 bits depend on the current significant bit that the current number is holding
            // combine with bits 1 calculated from previous other number
            dp[i] = 1 + dp[i - offset];
        }

        return dp;
    }

    static void Main(string[] args)
    {
        Program testProgram = new Program();

        testProgram.CountBits2(5);

        return;
    }
}
