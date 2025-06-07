namespace Diameter_of_Binary_Tree;

class Program
{
    private static int maxDiameter = 0;

    private static TreeNode TestCase1()
    {
        var root = new TreeNode(1);
        var node2 = new TreeNode(2);
        var node3 = new TreeNode(3);
        var node4 = new TreeNode(4);
        var node5 = new TreeNode(5);

        root.left = node2;
        root.right = node3;
        node2.left = node4;
        node2.right = node5;

        return root;
    }

    private static TreeNode TestCase2()
    {
        var root = new TreeNode(1);
        var node2 = new TreeNode(2);

        root.left = node2;

        return root;
    }

    private static TreeNode TestCase3()
    {
        var root = new TreeNode(1);
        var node2 = new TreeNode(2);
        var node3 = new TreeNode(3);

        root.left = node2;
        root.right = node3;

        return root;
    }

    private static TreeNode TestCase4()
    {
        var root = new TreeNode(4);
        var node_minus_9_1 = new TreeNode(-9);
        var node_minus_7_1 = new TreeNode(-7);
        var node_minus_7_2 = new TreeNode(-7);
        var node_minus_6_1 = new TreeNode(-6);
        var node_minus_6_2 = new TreeNode(-6);
        var node_minus_4_1 = new TreeNode(-4);
        var node_minus_4_2 = new TreeNode(-4);
        var node_minus_3_1 = new TreeNode(-3);
        var node_minus_3_2 = new TreeNode(-3);
        var node_minus_2_1 = new TreeNode(-2);
        var node_minus_1_1 = new TreeNode(-1);
        var node_0 = new TreeNode(0);
        var node_5 = new TreeNode(5);
        var node_6_1 = new TreeNode(6);
        var node_6_2 = new TreeNode(6);
        var node_9_1 = new TreeNode(9);
        var node_9_2 = new TreeNode(9);

        root.left = node_minus_7_1;
        root.right = node_minus_3_1;
        node_minus_3_1.left = node_minus_9_1;
        node_minus_3_1.right = node_minus_3_2;
        node_minus_3_2.left = node_minus_4_2;
        node_minus_9_1.left = node_9_1;
        node_minus_9_1.right = node_minus_7_2;
        node_9_1.left = node_6_1;
        node_6_1.left = node_0;
        node_6_1.right = node_6_2;
        node_0.right = node_minus_1_1;
        node_6_2.left = node_minus_4_1;
        node_minus_7_2.left = node_minus_6_1;
        node_minus_7_2.right = node_minus_6_2;
        node_minus_6_1.left = node_5;
        node_minus_6_2.left = node_9_2;
        node_9_2.left = node_minus_2_1;

        return root;
    }

    // TC: O(n), SC: O(n)
    private static int DiameterOfBinaryTreeDFS(TreeNode root)
    {
        // If we have reached leaf node, return 1 as the traversed diameter
        if (root.left == null && root.right == null)
        {
            return 1;
        }

        // Calculate the max traversed diameter length on the left subtree of the current root node
        int traversedLengthLeft = root.left != null ? DiameterOfBinaryTreeDFS(root.left) : 0;

        // Calculate the max traversed diameter length on the right subtree of the current root node
        int traversedLengthRight = root.right != null ? DiameterOfBinaryTreeDFS(root.right) : 0;

        // Check if the total of two max diameters of both left and right subtrees of the current node is larger than the global max diameter variable or not
        if (traversedLengthLeft + traversedLengthRight > maxDiameter)
        {
            maxDiameter = traversedLengthLeft + traversedLengthRight;
        }

        // Find the max between max diameters of left and right subtrees of the current node and add 1
        // We add 1 denoted as the current node and the returned value will be used to find the next max diameter of bigger sub problems
        return Math.Max(traversedLengthLeft, traversedLengthRight) + 1;
    }

    public static int DiameterOfBinaryTree(TreeNode root)
    {
        DiameterOfBinaryTreeDFS(root);
        return maxDiameter;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(DiameterOfBinaryTree(TestCase1()));
    }
}
