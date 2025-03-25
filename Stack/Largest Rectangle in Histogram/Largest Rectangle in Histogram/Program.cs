namespace Largest_Rectangle_in_Histogram;

class Program
{
    private static int[] TestCase1() {
        return [2,1,5,6,2,3];
    }

    private static int[] TestCase2() {
        return [2,4];
    }

    private static int[] TestCase3() {
        return [2,1,2];
    }

    // TC: O(n^2), SC: O(1)
    private static int LargestRectangleAreaBruteForce(int[] heights)
    {
        int maxArea = 0;

        for (int i = 0; i < heights.Length; i++)
        {
            int height = heights[i];

            // Start the width index both left and right at current bar
            int widthLeft = i;
            int widthRight = i;

            // Finding the maximum left boundary
            for (int j = i - 1; j >= 0; j--)
            {
                if (heights[j] >= height)
                    widthLeft--;

                if (heights[j] < height)
                {
                    break;
                }
            }

            // Finding the maximum right boundary
            for (int k = i + 1; k < heights.Length; k++)
            {
                if (heights[k] >= height)
                    widthRight++;

                if (heights[k] < height)
                {
                    break;
                }
            }

            // The width of current rectangular is between the right and left boundary + 1 (consecutive histogram interval)

            // Checking if the current rectangular area is larger than max area rectangular
            maxArea = Math.Max(maxArea, height * (widthRight - widthLeft + 1));
        }

        return maxArea;
    }

    // TC: O(n), SC: O(n)
    private static int LargestRectangleAreaStack(int[] heights)
    {
        int maxArea = 0;

        // Stack that contains only bar elements that are in increasing order
        Stack<(int startIndex, int height)> stackMax = new Stack<(int startIndex, int height)>();

        for (int i = 0; i < heights.Length; i++)
        {
            // Init index to push into stack of current element
            int index = i;

            // If elements in stack is greater than the current element
            // that means the rectangular histogram's width is restricted by lower bound of current element
            while (stackMax.Count > 0 && stackMax.Peek().height > heights[i]) {
                var barTopStack = stackMax.Pop();

                maxArea = Math.Max(maxArea, barTopStack.height * (i - barTopStack.startIndex));

                // If current element is smaller than elements at old top stack
                // That means the width of rectangular histogram can be extended from the popped elements at top stack
                // to current element and might be to the end of the list
                index = barTopStack.startIndex;
            }

            stackMax.Push((index, heights[i]));
        }

        // Stack still have some increasing bar height value, compute the area of those and compare to max value
        while (stackMax.Count > 0) {
            var barTopStack = stackMax.Pop();

            int area = barTopStack.height * (heights.Length - barTopStack.startIndex);
            maxArea = Math.Max(maxArea, area);
        }

        return maxArea;
    }

    public static int LargestRectangleArea(int[] heights)
    {
        // return LargestRectangleAreaBruteForce(heights);
        return LargestRectangleAreaStack(heights);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(LargestRectangleArea(TestCase1()));
    }
}
