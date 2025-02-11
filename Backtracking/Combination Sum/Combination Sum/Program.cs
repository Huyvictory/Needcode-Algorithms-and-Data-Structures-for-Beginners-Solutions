namespace Combination_Sum;

class Program
{
    public static IList<IList<int>> result = [];

    public static (int[] array, int target) TestCase1() {
        return ([2, 3, 6, 7], 7);
    }

    public static (int[] array, int target) TestCase2() {
        return ([2, 3, 5], 8);
    }

     public static (int[] array, int target) TestCase3() {
        return ([3, 5, 8], 11);
    }

    public static IList<IList<int>> CombinationSum(int[] candidates, int target) {
       
        helperDFS(candidates, [], 0, 0, target );
        return result;
     }

     public static void helperDFS(int[] candidates, List<int> traversePath ,int index, int sum, int target) {
        
            if (sum == target) {
                result.Add(traversePath.ToArray());
                return;
            }

            if (sum > target || index >= candidates.Length) {
                return;
            }

            sum += candidates[index]; 
            traversePath.Add(candidates[index]);

            // Add itself
            helperDFS(candidates, traversePath, index, sum, target);

            // Backtrack
            traversePath.RemoveAt(traversePath.Count - 1);  

            // Combination of other elements in the candidates array
            helperDFS(candidates, traversePath, index + 1, sum - candidates[index], target); 
     }

    static void Main(string[] args)
    {
        var result_1 = CombinationSum(TestCase1().array, TestCase1().target);

        // var result_2 = CombinationSum(TestCase2().array, TestCase2().target);

        // var result_3 = CombinationSum(TestCase3().array, TestCase3().target);

        return;
    }
}
