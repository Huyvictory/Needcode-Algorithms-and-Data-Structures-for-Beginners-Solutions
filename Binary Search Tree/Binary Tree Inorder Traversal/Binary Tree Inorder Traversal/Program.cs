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

    public static TreeNode TestCase2() {
        TreeNode Node_4 = new TreeNode(4);
        TreeNode Node_2 = new TreeNode(2, null, Node_4);
        TreeNode Node_1 = new TreeNode(1, Node_2);
       TreeNode rootNode = new TreeNode(3, Node_1);

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

    

    public static IList<int> InorderTraversalIteratively(TreeNode root) {
        if (root == null)
            return [];
        
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode cur = root;

        while (cur != null || stack.Count > 0) {
            while (cur != null) {
                stack.Push(cur);
                cur = cur.left;
            }

            var poppedTopStack = stack.Pop();
            result.Add(poppedTopStack.val);
            if (poppedTopStack.right != null) {
                cur = poppedTopStack.right;
            }
        }
        
        return result;
    }

    static void Main(string[] args)
    {
        var inorderTraversedList = InorderTraversal(TestCase1());
        var inorderTraversedList2 = InorderTraversalIteratively(TestCase2());

        return;
    }
}
