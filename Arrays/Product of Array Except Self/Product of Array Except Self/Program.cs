namespace Product_of_Array_Except_Self;

class Program
{
    private static int[] TestCase1() { 
        return [1,2,3,4];
    }

    private static int[] TestCase2() { 
        return [-1,1,0,-3,3];
    }

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

    public static int[] ProductExceptSelf(int[] nums)
    {
        return ProductExceptSelfPrefixPostfixProduct(nums);
    }

    static void Main(string[] args)
    {
        var result = ProductExceptSelf(TestCase2());

        return;
    }
}
