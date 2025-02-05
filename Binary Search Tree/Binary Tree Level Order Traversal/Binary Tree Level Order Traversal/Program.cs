namespace Binary_Tree_Level_Order_Traversal;

class Program
{
    public static TreeNode TestCase1() {
        TreeNode Node_15 = new TreeNode(15);
        TreeNode Node_7 = new TreeNode(7);

        TreeNode Node_9 = new TreeNode(9);
        TreeNode Node_20 = new TreeNode(20, Node_15, Node_7);

        TreeNode rootNode = new TreeNode(3, Node_9, Node_20);

        return rootNode;
    }

    public static TreeNode TestCase2() {
        TreeNode rootNode = new TreeNode(1);

        return rootNode;
    }

    public static TreeNode TestCase3() {
        return null;
    }

    public static IList<IList<int>> LevelOrder(TreeNode root)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        IList<IList<int>> result = [];

        if (root != null)
        {
            queue.Enqueue(root);
        }

        // when there are still nodes in levels to traverse
        while (queue.Count > 0)
        {
            // Get number of Nodes for each level and traverse through
            int numberOfNodesLevel = queue.Count;
            List<int> traversedNodesLevel = [];

            for (int i = 1; i <= numberOfNodesLevel; i++) {
                TreeNode traversedNode = queue.Dequeue();
                traversedNodesLevel.Add(traversedNode.val);

                // For each node if there is subtree at the left or right 
                // add it to the queue for the traversal of the next level
                if (traversedNode.left != null) {
                    queue.Enqueue(traversedNode.left);
                }

                if (traversedNode.right != null) {
                    queue.Enqueue(traversedNode.right);
                }
            }

            result.Add(traversedNodesLevel);
        }

        return result;
    }

    static void Main(string[] args)
    {
        var traversedNodesList = LevelOrder(TestCase1());

        return;
    }
}
