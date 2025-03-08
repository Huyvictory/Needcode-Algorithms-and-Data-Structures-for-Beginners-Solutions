namespace Product_of_Array_Except_Self;

class Program
{
    private static int[] TestCase1() { 
        return [1,2,3,4];
    }

    private static int[] TestCase2() { 
        return [-1,1,0,-3,3];
    }

    // TC: O(N), SC: O(n)
    public static int[] ProductExceptSelfPrefixPostfixProduct(int[] nums)
    {
        int[] prefixProduct = new int[nums.Length];
        int[] postfixProduct = new int[nums.Length];

        prefixProduct[0] = nums[0];
        postfixProduct[postfixProduct.Length - 1] = nums[nums.Length - 1];

        for (int i = 1; i < nums.Length; i++)
        {
            prefixProduct[i] =  prefixProduct[i - 1] * nums[i];
        }

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            postfixProduct[i] = postfixProduct[i + 1] * nums[i];
        }

        for (int i = 0; i < nums.Length; i++)
        {
            int prefix = i - 1 >= 0 ? prefixProduct[i - 1] : 1;
            int postfix = i + 1 < postfixProduct.Length ? postfixProduct[i + 1] : 1;
            nums[i] = prefix * postfix;
        }

        return nums;
    }

    // TC: O(N), SC: O(1) if we don't count the res array, O(n) if we do
    public static int[] ProductExceptSelfPrefixPostfixSpaceOptimized(int[] nums) {
        int[] res = new int[nums.Length];
        Array.Fill(res, 1);

        // Update recent prefix value for every element of result array
        int recentPrefixValue = 1;

        for (int i = 0; i < res.Length; i++)
        {
            // The prefix value of current element equals to the recent prefix value
            res[i] = recentPrefixValue;

            // Update the recent prefix value for next element
            recentPrefixValue = nums[i] * recentPrefixValue;
        }

        int recentPostfixValue = 1;

        for (int i = res.Length - 1; i >=0; i--) {

            // Update the product of current element except itself
            res[i] *= recentPostfixValue;

            // Update the recent postfix value for next element
            recentPostfixValue = nums[i] * recentPostfixValue;
        }

        return res;
    }

    public static int[] ProductExceptSelf(int[] nums)
    {
        return ProductExceptSelfPrefixPostfixSpaceOptimized(nums);
    }

    static void Main(string[] args)
    {
        var result = ProductExceptSelf(TestCase1());

        return;
    }
}
