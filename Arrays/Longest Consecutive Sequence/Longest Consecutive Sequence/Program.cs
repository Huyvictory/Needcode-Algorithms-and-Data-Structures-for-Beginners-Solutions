namespace Longest_Consecutive_Sequence;

class Program
{
    private static int[] TestCase1() {
        return [100,4,200,1,3,2];
    }

    private static int[] TestCase2() {
        return [0,3,7,2,5,8,4,6,0,1];
    }

    private static int[] TestCase3() {
        return [1,0,1,2];
    }

    private static int[] TestCase4() {
        return [];
    }

     private static int[] TestCase5() {
        return [9,1,4,7,3,-1,0,5,8,-1,6];
    }

    // TC: O(n), SC: O(N)
    private static int LongestConsecutiveHashSet(int[] nums)
    {
        if (nums.Length == 0) return 0;

        var set = new HashSet<int>(nums);

        int min = set.Min();

        int lengthConsecutiveSequence = 0;
        int currentLCSLength = 0;

        while (true)
        {
            // If set contains the min and it is the consecutive increasing value
            if (set.Contains(min))
            {
                currentLCSLength++;
                set.Remove(min);
                min++;
            }

            // If set doesn't contain the min
            // It means that the value doesn't exist in array 
            // Start comparing the computed length with the max consecutive length, if it is larger then we override it
            else
            {
                if (currentLCSLength > lengthConsecutiveSequence) {
                    lengthConsecutiveSequence = currentLCSLength;
                }

                if (set.Count == 0) break;

                currentLCSLength = 0;

                // Move to the next smallest number in set and continue calculating the length of next consecutive sequence
                min = set.Min();
            }
        }

        return lengthConsecutiveSequence;
    }

    // TC: O(n), SC: O(N)
    private static int LongestConsecutiveHashSetTimeOptimized(int[] nums)
    {
        if (nums.Length == 0) return 0;

        // Create hash set that contains unique elements from original array
        var set = new HashSet<int>(nums);

        int maxConsecutiveSequence = 0;

        foreach (var num in set)
        {
            int currentConsecutiveSequence = 0;
            int currentNum = num;

            // If the current number doesn't have any previous adjacent number
            // That means the number is the starting point of increasing consecutive sequence
            if (!set.Contains(currentNum - 1)) {

                // Calculate the length of the current consecutive sequence
                // If the length is greater than max then overrides it
                while (set.Contains(currentNum)) {
                    currentConsecutiveSequence++;
                    currentNum++;
                }

                if (currentConsecutiveSequence > maxConsecutiveSequence) {
                    maxConsecutiveSequence = currentConsecutiveSequence;
                }
            }   
        }

        return maxConsecutiveSequence;
    }

    public static int LongestConsecutive(int[] nums)
    {
        return LongestConsecutiveHashSetTimeOptimized(nums);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(LongestConsecutive(TestCase1()));
    }
}
