namespace Delete_Node_in_a_BST;

class Program
{
    public static TreeNode TestCase1()
    {
        TreeNode Node_2 = new TreeNode(2);
        TreeNode Node_4 = new TreeNode(4);
        TreeNode Node_7 = new TreeNode(7);
        TreeNode Node_3 = new TreeNode(3, Node_2, Node_4);
        TreeNode Node_6 = new TreeNode(6, null, Node_7);

        TreeNode rootNode = new TreeNode(5, Node_3, Node_6);

        return rootNode;
    }

    public static TreeNode FindMinimumRightSubTreeTarget(TreeNode target)
    {
        while (target != null && target.left != null)
        {
            target = target.left;
        }

        return target;
    }

    public static TreeNode DeleteNode(TreeNode root, int key)
    {
        // If could not find the node with the target key or BST with no node
        if (root == null)
            return root;

        if (key > root.val)
        {
            root.right = DeleteNode(root.right, key);
        }
        else if (key < root.val)
        {
            root.left = DeleteNode(root.left, key);
        }
        // Found the node that has the exact key for deletion
        else
        {
            // Node that is leaf node or has at most one child
            if (root.left == null || root.right == null)
            {
                return root.left != null ? root.left : root.right;
            }
            // Node that has two children
            else
            {
                // Find the minimum node in the right subtree of target node
                TreeNode MinimumNodeRightSubTree = FindMinimumRightSubTreeTarget(root.right);
                root.val = MinimumNodeRightSubTree.val;
                root.right = DeleteNode(root.right, MinimumNodeRightSubTree.val);
            }
        }

        return root;
    }

    static void Main(string[] args)
    {
        var rootNodeAfterDelete3 = DeleteNode(TestCase1(), 3);
        var rootNodeAfterDelete0 = DeleteNode(TestCase1(), 0);
        var rootNodeNullBST = DeleteNode(null, 0);

        return;
    }
}
