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

    // TC: O(n), SC: O(n)
    private static int GoodNodesDFS2(TreeNode root, int maxValuePath)
    {
        if (root == null)
            return 0;

        // The amount of good nodes for a certain sub root node
        int goodNodesRootNode = 0;

        if (root.val >= maxValuePath)
        {
            maxValuePath = root.val;

            goodNodesRootNode = 1;
        }

        // Count number of good nodes on left sub tree
        goodNodesRootNode += GoodNodesDFS2(root.left, maxValuePath);

        // Count number of good nodes on right sub tree
        goodNodesRootNode += GoodNodesDFS2(root.right, maxValuePath);

        return goodNodesRootNode;
    }

    private static int GoodNodesBFS(TreeNode root)
    {
        int goodNodesCount = 0;
        Queue<(TreeNode root, int maxValuePath)> q = new Queue<(TreeNode root, int maxValuePath)>();

        q.Enqueue((root, int.MinValue));

        while (q.Count > 0)
        {
            var (currentNode, maxValue) = q.Dequeue();

            if (currentNode.val >= maxValue)
            {
                goodNodesCount++;
                maxValue = currentNode.val;
            }

            // Keep track the max value of every single node of each level (route) when compare to its parent node
            if (currentNode.left != null)
            {
                q.Enqueue((currentNode.left, Math.Max(maxValue, currentNode.left.val)));
            }

            if (currentNode.right != null)
            {
                q.Enqueue((currentNode.right, Math.Max(maxValue, currentNode.right.val)));
            }
        }

        return goodNodesCount;
    }

    public static int GoodNodes(TreeNode root)
    {
        // GoodNodesDFS(root, root.val);

        // return GoodNodesDFS2(root, root.val);

        return GoodNodesBFS(root);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(GoodNodes(TestCase1()));
    }
}
