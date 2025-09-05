namespace Count_Good_Nodes_in_Binary_Tree;

class Program
{
    public static int GoodNodesCount = 0;

    private static TreeNode TestCase1()
    {
        TreeNode root = new TreeNode(3);
        TreeNode node1 = new TreeNode(1);
        TreeNode node3 = new TreeNode(3);
        TreeNode node4 = new TreeNode(4);
        TreeNode node1_1 = new TreeNode(1);
        TreeNode node5 = new TreeNode(5);

        root.left = node1;
        root.right = node4;
        node1.left = node3;
        node4.left = node1_1;
        node4.right = node5;

        // node1_1.right = new TreeNode(8);

        return root;
    }

    private static TreeNode TestCase2()
    {
        TreeNode root = new TreeNode(3);

        TreeNode node3 = new TreeNode(3);
        TreeNode node4 = new TreeNode(4);
        TreeNode node2 = new TreeNode(2);

        root.left = node3;
        node3.left = node4;
        node3.right = node2;

        return root;
    }

    private static TreeNode TestCase3()
    {
        TreeNode root = new TreeNode(1);

        return root;
    }

    // TC: O(n), SC: O(n)
    private static void GoodNodesDFS(TreeNode root, int maxValuePath)
    {
        if (root == null)
            return;

        // Update the max value of a certain path
        if (root.val >= maxValuePath)
        {
            maxValuePath = root.val;
            GoodNodesCount++;
        }

        GoodNodesDFS(root.left, maxValuePath);

        GoodNodesDFS(root.right, maxValuePath);
    }

    public static int GoodNodes(TreeNode root)
    {
        GoodNodesDFS(root, root.val);

        return GoodNodesCount;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(GoodNodes(TestCase1()));
    }
}
