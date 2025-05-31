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

    // TC: O(n), SC: O(n)
    private static TreeNode InvertTreeBFS(TreeNode root)
    {
        if (root == null)
            return null;

        Queue<TreeNode> queue = new Queue<TreeNode>();

        queue.Enqueue(root);

        while (queue.Any())
        {
            // get the current root not and its left and right subtree
            var dequeuedRoot = queue.Dequeue();
            var leftChild = dequeuedRoot.left ?? null;
            var rightChild = dequeuedRoot.right ?? null;

            // Add to queue if the subtree from left or right exists
            if (leftChild != null)
                queue.Enqueue(leftChild);

            if (rightChild != null)
                queue.Enqueue(rightChild);

            // Swap pointer of left and right subtrees of current root nodes
            dequeuedRoot.right = leftChild!;
            dequeuedRoot.left = rightChild!;
        }

        return root;
    }

    public static TreeNode InvertTree(TreeNode root)
    {
        // return InvertTreeDFSPostOrder(root);
        return InvertTreeBFS(root);
    }

    static void Main(string[] args)
    {
        var res = InvertTree(TestCase1());

        return;
    }
}
