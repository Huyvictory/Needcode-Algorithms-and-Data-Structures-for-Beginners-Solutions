namespace Best_Time_to_Buy_and_Sell_Stock;

class Program
{
    private static int[] TestCase1() {
        return [7,1,5,3,6,4];
    }

    private static int[] TestCase2() {
        return [7,6,4,3,1];
    }

    private static int[] TestCase3() {
        return [1,2,4,2,5,7,2,4,9,0,9];
    }

    // TC: O(n), SC: O(1)
    private static int MaxProfitSlidingWindow(int[] prices)
    {
        int maxProfit = 0;

        // Initialize a sliding window that have left pointer starting at 0 and right pointer behind it
        int left = 0;

        // Buy at pointer left and sell at pointer right
        for (int right = 1; right < prices.Length; right++)
        {
            // If the buying day (pointer left) is too large leaving expanding the window might not help us
            // receive profit so we need to reduce the sliding window and move pointer left to right to check for next sliding window
            if (prices[right] - prices[left] <= 0)
            {
                left = right;
            }

            // If there is profit in the current sliding window, calculate and override maxProfit
            // Continue expanding window by moving pointer right to next window
            // Just to check the profit of the next day stock
            maxProfit = Math.Max(maxProfit, prices[right] - prices[left]);
        }

        return maxProfit;
    }

    public static int MaxProfit(int[] prices)
    {
        return MaxProfitSlidingWindow(prices);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(MaxProfit(TestCase1()));
    }
}
