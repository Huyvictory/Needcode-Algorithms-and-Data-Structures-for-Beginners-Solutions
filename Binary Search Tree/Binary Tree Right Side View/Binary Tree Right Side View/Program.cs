namespace Binary_Tree_Right_Side_View;

class Program
{
    public static TreeNode TestCase1() {
        TreeNode Node_5 = new TreeNode(5);
        TreeNode Node_4 = new TreeNode(4);

        TreeNode Node_2 = new TreeNode(2, null, Node_5);
        TreeNode Node_3 = new TreeNode(3, null, Node_4);

        TreeNode rootNode = new TreeNode(1, Node_2, Node_3);

        return rootNode;
    }

    public static TreeNode TestCase2() {
        TreeNode Node_5 = new TreeNode(5);
        TreeNode Node_4 = new TreeNode(4, Node_5);

        TreeNode Node_2 = new TreeNode(2, Node_4);
        TreeNode Node_3 = new TreeNode(3, null, Node_4);

        TreeNode rootNode = new TreeNode(1, Node_2, Node_3);

        return rootNode;
    }

    public static IList<int> RightSideView(TreeNode root)
    {
        if (root == null)
            return [];

        Queue<TreeNode> queue = new Queue<TreeNode>([root]);
        
        IList<int> result = [];

        while(queue.Count > 0) {

            int NodesLevel = queue.Count;
            
            for (int i = 1; i <= NodesLevel; i++) {
                var traversedNode = queue.Dequeue();

                if (traversedNode.left != null) {
                    queue.Enqueue(traversedNode.left);
                }

                if (traversedNode.right != null) {
                    queue.Enqueue(traversedNode.right);
                }

                if (i == NodesLevel) {
                    result.Add(traversedNode.val);
                }
            }
        }

        return result;
    }

    static void Main(string[] args)
    {
        var rightSideViewResultList = RightSideView(TestCase2());

        return;
    }
}
