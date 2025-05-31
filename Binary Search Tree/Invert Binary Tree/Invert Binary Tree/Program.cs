namespace Invert_Binary_Tree;

class Program
{
    private static TreeNode TestCase1()
    {
        var root = new TreeNode(4);
        var node2 = new TreeNode(2);
        var node7 = new TreeNode(7);
        var node1 = new TreeNode(1);
        var node3 = new TreeNode(3);
        var node6 = new TreeNode(6);
        var node9 = new TreeNode(9);

        root.left = node2;
        root.right = node7;
        node2.left = node1;
        node2.right = node3;
        node7.left = node6;
        node7.right = node9;

        return root;
    }

    private static TreeNode TestCase2()
    {
        var root = new TreeNode(2);
        var node1 = new TreeNode(1);

        root.left = node1;

        return root;
    }

    // TC: O(logn), SC: O(n)
    private static TreeNode InvertTreeDFSPostOrder(TreeNode root)
    {
        if (root == null)
            return null;

        var leftChild = InvertTreeDFSPostOrder(root.left);
        var rightChild = InvertTreeDFSPostOrder(root.right);

        root.left = rightChild;
        root.right = leftChild;

        return root;
    }

    public static TreeNode InvertTree(TreeNode root)
    {
        return InvertTreeDFSPostOrder(root);
    }

    static void Main(string[] args)
    {
        var res = InvertTree(TestCase1());

        return;
    }
}
