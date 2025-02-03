namespace Kth_Smallest_Element_in_a_BST;

class Program
{
    public static int traversalOrder = 0;
    public static int result = 0;

    public static TreeNode TestCase1()
    {
        TreeNode Node_1 = new TreeNode(1);
        TreeNode Node_2 = new TreeNode(2, Node_1);
        TreeNode Node_4 = new TreeNode(4);
        TreeNode Node_3 = new TreeNode(3, Node_2, Node_4);
        TreeNode Node_6 = new TreeNode(6);

        TreeNode rootNode = new TreeNode(5, Node_3, Node_6);

        return rootNode;
    }

    public static TreeNode TestCase2()
    {
        TreeNode Node_2 = new TreeNode(2);
        TreeNode Node_4 = new TreeNode(4);
        TreeNode Node_1 = new TreeNode(1, null, Node_2);

        TreeNode rootNode = new TreeNode(3, Node_1, Node_4);

        return rootNode;
    }

    public static TreeNode TestCase3()
    {
        TreeNode Node_2 = new TreeNode(2);

        TreeNode rootNode = new TreeNode(1, null, Node_2);

        return rootNode;
    }

    public static int KthSmallest(TreeNode root, int k)
    {
        if (root == null)
        {
            return -1;
        }

        KthSmallest(root.left, k);

        // visit
        traversalOrder++;
        if (traversalOrder == k)
        {
            result = root.val;
        }

        KthSmallest(root.right, k);

        return result;
    }

    public static int KthSmallestIteration(TreeNode root, int k)
    {
        TreeNode current = root;
        Stack<TreeNode> stack = new Stack<TreeNode>();

        while (current != null || stack.Count > 0)
        {
            // Focus on traverse to the left first
            while (current != null)
            {
                stack.Push(current);
                current = current.left;
            }

            // Visit the current sub node then check for the kth traversal
            var visitedSubNode = stack.Pop();
            traversalOrder++;

            if (traversalOrder == k)
                return visitedSubNode.val;

            if (visitedSubNode.right != null)
                current = visitedSubNode.right;
        }

        return -1;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(KthSmallest(TestCase1(), 3));
        Console.WriteLine(KthSmallest(TestCase2(), 1));
        Console.WriteLine(KthSmallest(TestCase3(), 2));

        Console.WriteLine(KthSmallestIteration(TestCase1(), 3));
        Console.WriteLine(KthSmallestIteration(TestCase2(), 1));
        Console.WriteLine(KthSmallestIteration(TestCase3(), 2));
    }
}
