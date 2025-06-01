namespace Maximum_Depth_of_Binary_Tree;

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
        var node2 = new TreeNode(2);

        root.right = node2;

        return root;
    }

    // TC: O(n), SC: O(n)
    private static int MaxDepthDFSPreOrder(TreeNode root, int maxDepth)
    {
        if (root == null)
            return 0;

        // If we have reached to the leaf node return the depth traversed
        if (root.left == null && root.right == null)
            return maxDepth;

        int maxDepthLeft =
            root.left != null ? MaxDepthDFSPreOrder(root.left, maxDepth + 1) : maxDepth;
        int maxDepthRight =
            root.right != null ? MaxDepthDFSPreOrder(root.right, maxDepth + 1) : maxDepth;

        return Math.Max(maxDepthLeft, maxDepthRight);
    }

    // TC: O(n), SC: O(n)
    private static int MaxDepthBFS(TreeNode root)
    {
        if (root == null)
            return 0;

        Queue<TreeNode> queue = new Queue<TreeNode>();

        queue.Enqueue(root);

        int depth = 0;

        while (queue.Count > 0)
        {
            // Get snapshot of current queue's count
            for (int i = queue.Count; i > 0; i--)
            {
                var dequeuedRoot = queue.Dequeue();

                if (dequeuedRoot.left != null)
                {
                    queue.Enqueue(dequeuedRoot.left);
                }

                if (dequeuedRoot.right != null)
                {
                    queue.Enqueue(dequeuedRoot.right);
                }
            }

            // Increase the depth before traversing to the next level of the binary tree
            depth++;
        }

        return depth;
    }

    public static int MaxDepth(TreeNode root)
    {
        // return MaxDepthDFSPreOrder(root, 1);
        return MaxDepthBFS(root);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(MaxDepth(TestCase1()));
    }
}
