namespace Balanced_Binary_Tree;

class Program
{
    private static TreeNode TestCase1()
    {
        var root = new TreeNode(3);
        var node9 = new TreeNode(9);
        var node20 = new TreeNode(20);
        var node15 = new TreeNode(15);
        var node7 = new TreeNode(7);

        root.left = node9;
        root.right = node20;
        node20.left = node15;
        node20.right = node7;

        return root;
    }

    private static TreeNode TestCase2()
    {
        var root = new TreeNode(1);
        var node2_1 = new TreeNode(2);
        var node2_2 = new TreeNode(2);
        var node3_1 = new TreeNode(3);
        var node3_2 = new TreeNode(3);
        var node4_1 = new TreeNode(4);
        var node4_2 = new TreeNode(4);

        root.left = node2_1;
        root.right = node2_2;
        node2_1.left = node3_1;
        node2_1.right = node3_2;
        node3_1.left = node4_1;
        node3_1.right = node4_2;

        return root;
    }

    private static TreeNode TestCase3()
    {
        return null;
    }

    private static TreeNode TestCase4()
    {
        var root = new TreeNode(1);
        var node2 = new TreeNode(2);
        var node3 = new TreeNode(3);

        root.right = node2;
        node2.right = node3;

        return root;
    }

    private static TreeNode TestCase5()
    {
        var root = new TreeNode(1);
        var node2 = new TreeNode(2);
        var node3 = new TreeNode(3);
        var node4 = new TreeNode(4);
        var node5 = new TreeNode(5);
        var node6 = new TreeNode(6);
        var node8 = new TreeNode(8);

        root.left = node2;
        root.right = node3;
        node2.left = node4;
        node2.right = node5;
        node4.left = node8;
        node3.left = node6;

        return root;
    }

    private static TreeNode TestCase6()
    {
        var root = new TreeNode(1);
        var node2_1 = new TreeNode(2);
        var node2_2 = new TreeNode(2);
        var node3_1 = new TreeNode(3);
        var node3_2 = new TreeNode(3);
        var node4_1 = new TreeNode(4);
        var node4_2 = new TreeNode(4);

        root.left = node2_1;
        root.right = node2_2;
        node2_1.left = node3_1;
        node2_2.right = node3_2;
        node3_1.left = node4_1;
        node3_2.right = node4_2;

        return root;
    }

    // TC: O(n), SC: O(h)
    private static int CheckBalancedTreeDFS(TreeNode node)
    {
        // If we meet leaf node, return 1 and start calculating height of larger subtree starting from this node
        if (node.left == null && node.right == null)
        {
            return 1;
        }

        int leftHeight = node.left != null ? CheckBalancedTreeDFS(node.left) : 0;
        int rightHeight = node.right != null ? CheckBalancedTreeDFS(node.right) : 0;

        // If height of left and right subtrees differ by more than 1, return -1
        // to indicate that the tree is not balanced
        if (Math.Abs(rightHeight - leftHeight) > 1)
        {
            return -1;
        }

        // If the tree is balanced, return the height of the larger subtree + 1
        // the return value will be used to calculate the height of the parent node
        // and so on until we reach the root node
        return leftHeight != -1 && rightHeight != -1 ? Math.Max(leftHeight, rightHeight) + 1 : -1;
    }

    private static bool IsBalancedDFS(TreeNode node)
    {
        // If the tree is empty, it is balanced
        if (node == null)
        {
            return true;
        }

        // The binary tree is not balanced return false
        if (CheckBalancedTreeDFS(node) == -1)
        {
            return false;
        }

        // The binary tree is balanced, return true
        return true;
    }

    public static bool IsBalanced(TreeNode root)
    {
        return IsBalancedDFS(root);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(IsBalanced(TestCase1()));
    }
}
