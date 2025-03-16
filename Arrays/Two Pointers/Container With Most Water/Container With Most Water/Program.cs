namespace Container_With_Most_Water;

class Program
{
    private static int[] TestCase1() {
        return [1,8,6,2,5,4,8,3,7];
    }

    private static int[] TestCase2() {
        return [1,1];
    }

    private static int[] TestCase3() {
        return [1,2,3,1000,9];
    }

    private static int[] TestCase4() {
        return [1,7,2,5,4,7,3,6];
    }

    private static int[] TestCase5() {
        return [2,2,2];
    }

    // Calculate every possible container area and overrides with max value container area
    // TC: O(n^2), SC: O(1)
    private static int MaxAreaBruteForce(int[] height) {

        // Initialize the max area variable as output result
        int maxArea = 0;

        for (int i = 0; i < height.Length; i++)
        {
            for (int j = i + 1; j < height.Length; j++)
            {
                // Calculate distance on x plane
            int xDistance = j + 1 - (i + 1);

            // Calculate the current area
            int area = Math.Min(height[i], height[j]) * xDistance;

            // Override the area if the calculated area is larger than the maxArea itself
            maxArea = Math.Max(maxArea, area);
            }
        }

        return maxArea;
    }

    public static int MaxArea(int[] height)
    {
        return MaxAreaBruteForce(height);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(MaxArea(TestCase1()));
    }
}
