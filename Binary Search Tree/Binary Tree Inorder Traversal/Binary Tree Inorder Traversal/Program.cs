namespace Binary_Tree_Inorder_Traversal;

class Program
{
    public static List<int> result  = [];
    public static TreeNode TestCase1()
    {
        TreeNode Node_3 = new TreeNode(3);
        TreeNode Node_2 = new TreeNode(2, Node_3);

        TreeNode rootNode = new TreeNode(1, null, Node_2);

        return rootNode;
    }

    public static IList<int> InorderTraversal(TreeNode root)
    {
        if (root == null)
            return [];
        
        InorderTraversal(root.left);
        result.Add(root.val);
        InorderTraversal(root.right);

        return result;
    }

    static void Main(string[] args)
    {
        var inorderTraversedList = InorderTraversal(TestCase1());

        return;
    }
}
