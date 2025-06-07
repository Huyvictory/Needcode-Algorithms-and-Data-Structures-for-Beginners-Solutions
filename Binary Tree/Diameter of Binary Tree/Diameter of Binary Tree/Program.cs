namespace Diameter_of_Binary_Tree;

class Program
{
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

    // TC: O(n), SC: O(n)
    private static int DiameterOfBinaryTreeDFS(TreeNode root, int length)
    {
        // If the node is a leaf node or a invalid one then return the traversed length
        if (root == null || (root.left == null && root.right == null))
            return length;

        // Calculate the traversed length on the left of the current root node
        int traversedLengthLeft =
            root.left != null ? DiameterOfBinaryTreeDFS(root.left, length + 1) : length;

        // Calculate the traversed length on the right of the current root node
        int traversedLengthRight =
            root.right != null ? DiameterOfBinaryTreeDFS(root.right, length + 1) : length;

        return Math.Max(traversedLengthLeft, traversedLengthRight);
    }

    public static int DiameterOfBinaryTree(TreeNode root)
    {
        // Get the max length traversed from both left and right sub trees and find the sum of it
        return (root.left != null ? DiameterOfBinaryTreeDFS(root.left, 1) : 0)
            + (root.right != null ? DiameterOfBinaryTreeDFS(root.right, 1) : 0);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(DiameterOfBinaryTree(TestCase1()));
    }
}
