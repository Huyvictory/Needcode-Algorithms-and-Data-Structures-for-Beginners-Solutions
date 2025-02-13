namespace Insert_into_a_Binary_Search_Tree;

class Program
{
    public static TreeNode TestCase1()
    {
        TreeNode leafNode1 = new TreeNode(1);
        TreeNode leafNode3 = new TreeNode(3);

        TreeNode Node_2 = new TreeNode(2, leafNode1, leafNode3);
        TreeNode Node_7 = new TreeNode(7);
        TreeNode rootNode = new TreeNode(4, Node_2, Node_7);

        return rootNode;
    }

    public static TreeNode InsertIntoBST(TreeNode root, int val)
    {
        // Found the spot that is needed to insert the new node into BST
        if (root == null)
        {
            return new TreeNode(val);
        }

        if (root.val > val)
        {
            root.left = InsertIntoBST(root.left, val);
        }
        else if (root.val < val)
        {
            root.right = InsertIntoBST(root.right, val);
        }

        return root;
    }

    static void Main(string[] args)
    {
        var insertedTree = InsertIntoBST(TestCase1(), 5);

        return;
    }
}
