namespace Trapping_Rain_Water;

class Program
{

    private static int[] TestCase1() {
        return [0,1,0,2,1,0,1,3,2,1,2,1];
    }

    private static int[] TestCase2() {
        return [4,2,0,3,2,5];
    }

    // TC: O(n): SC: O(n)
    private static int TrapPrefixSuffixArray(int[] height)
    {
        // Calculate the prefix and suffix array for max left and right boundary
        // So that we could calculate water trapped for each position
        int[] prefixMaxLeft = new int[height.Length];
        int[] suffixMaxRight = new int[height.Length];

        int maxLeft = 0;
        int maxRight = 0;
        int res = 0;

        // If we want to calculate the max left of current position we have to calculate the max of other prefix sub arrays
        for (int i = 0; i < prefixMaxLeft.Length; i++)
        {
            prefixMaxLeft[i] = Math.Max(maxLeft, 0);
            maxLeft = Math.Max(maxLeft, height[i]); 
        }

        // If we want to calculate the max right of current position we have to calculate the max of other suffix sub arrays
        for (int j = suffixMaxRight.Length - 1; j >= 0; j--)
        {
            suffixMaxRight[j] = Math.Max(maxRight, 0);
            maxRight = Math.Max(maxRight, height[j]);
        }

        // Calculate the amount of water trapped for each position by utilizing the prefix and suffix array 
        // with precomputed left and right boundary
        for (int k = 0; k < height.Length; k++)
        {
            int trappedWater = Math.Min(prefixMaxLeft[k], suffixMaxRight[k]) - height[k];

            if (trappedWater > 0) {
                res += trappedWater;
            }
        }

        return res;
    }


    public static int Trap(int[] height)
    {
        return TrapPrefixSuffixArray(height);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(Trap(TestCase1()));
    }
}
