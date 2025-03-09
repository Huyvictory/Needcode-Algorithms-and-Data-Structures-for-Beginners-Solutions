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
    

    public static int LongestConsecutive(int[] nums)
    {
        return LongestConsecutiveHashSet(nums);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(LongestConsecutive(TestCase1()));
    }
}
