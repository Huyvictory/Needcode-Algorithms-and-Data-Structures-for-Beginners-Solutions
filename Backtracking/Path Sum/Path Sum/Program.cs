namespace Path_Sum;

class Program
{
    public static int sum = 0;
    public static bool hasFoundPath = false;

    public static TreeNode TestCase1()
    {
        TreeNode Node7 = new TreeNode(7);
        TreeNode Node2 = new TreeNode(2);
        TreeNode Node1 = new TreeNode(1);
        TreeNode Node13 = new TreeNode(13);

        TreeNode Node11 = new TreeNode(11, Node7, Node2);
        TreeNode Node4_1 = new TreeNode(4, null, Node1);
        TreeNode Node4_2 = new TreeNode(4, Node11);
        TreeNode Node8 = new TreeNode(8, Node13, Node4_1);

        TreeNode rootNode = new TreeNode(5, Node4_2, Node8);

        return rootNode;
    }

    public static TreeNode TestCase2()
    {
        TreeNode Node2 = new TreeNode(2);
        TreeNode Node3 = new TreeNode(3);

        TreeNode rootNode = new TreeNode(1, Node2, Node3);

        return rootNode;
    }

    public static TreeNode TestCase3()
    {
        return null;
    }

    public static TreeNode TestCase4()
    {
        TreeNode Node2 = new TreeNode(2);

        TreeNode rootNode = new TreeNode(1, Node2);

        return rootNode;
    }

    public static bool HasPathSum(TreeNode root, int targetSum)
    {
        if (hasFoundPath)
        {
            return true;
        }

        if (root == null)
        {
            return false;
        }

        sum += root.val;

        // Leaf node reached
        if (root.left == null && root.right == null)
        {
            if (sum != targetSum)
            {
                sum -= root.val;
                return false;
            }
            return true;
        }

        if (!HasPathSum(root.left, targetSum) && !HasPathSum(root.right, targetSum))
        {
            sum -= root.val;
            return false;
        }

        hasFoundPath = true;

        return true;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(HasPathSum(TestCase1(), 22));
        // Console.WriteLine(HasPathSum(TestCase2(), 5));
        // Console.WriteLine(HasPathSum(TestCase3(), 0));
        // Console.WriteLine(HasPathSum(TestCase4(), 1));
    }
}
