namespace Subsets;

class Program
{
    public IList<IList<int>> result = [];

    public static int[] TestCase1() {
        return [1, 2, 3, 4, 5];
    }

    public static int[] TestCase2() {
        return [0];
    }

    public static int[] TestCase3() {
        return [1, 2];
    }    

    public IList<IList<int>> Subsets(int[] nums) {
        if (nums.Length == 0) return [];

        helperDFS(nums, 0, []);

        return result;
     }

     public void helperDFS(int[] nums, int i, List<int> subset) {
        // DFS and brute force all possible answer of the sub condition branch
        if (i == nums.Length) {
            result.Add(subset.ToArray());
            return;
        }

        subset.Add(nums[i]);

        // Case that contains the subset
        helperDFS(nums, i + 1, subset);

        // backtrack to previous state of the sub decision
        subset.RemoveAt(subset.Count - 1);

        // Case that doesn't contain the subset
        helperDFS(nums, i + 1, subset);

     }

    static void Main(string[] args)
    {
        var result_1 = new Program().Subsets(TestCase1());

        // var result_2 = Subsets(TestCase2());

        // var result_3 = Subsets(TestCase3());

        return;
    }
}
