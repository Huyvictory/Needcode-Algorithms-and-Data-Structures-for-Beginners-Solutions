namespace Validate_Binary_Search_Tree;

class Program
{
    private static List<TreeNode> traversedNodes = new List<TreeNode>() { };

    private static TreeNode TestCase1()
    {
        TreeNode root = new TreeNode(2);
        TreeNode node1 = new TreeNode(1);
        TreeNode node3 = new TreeNode(3);

        root.left = node1;
        root.right = node3;

        return root;
    }

    private static TreeNode TestCase2()
    {
        TreeNode root = new TreeNode(5);
        TreeNode node1 = new TreeNode(1);
        TreeNode node4 = new TreeNode(4);
        TreeNode node3 = new TreeNode(3);
        TreeNode node6 = new TreeNode(6);

        root.left = node1;
        root.right = node4;
        node4.left = node3;
        node4.right = node6;

        return root;
    }

    private static TreeNode TestCase3()
    {
        TreeNode root = new TreeNode(8);
        TreeNode node3 = new TreeNode(3);
        TreeNode node1 = new TreeNode(1);
        TreeNode node6 = new TreeNode(6);
        TreeNode node4 = new TreeNode(4);
        TreeNode node7 = new TreeNode(7);
        // TreeNode node15 = new TreeNode(15);

        TreeNode node10 = new TreeNode(10);
        TreeNode node14 = new TreeNode(14);
        TreeNode node13 = new TreeNode(13);

        root.left = node3;
        root.right = node10;
        node3.left = node1;
        node3.right = node6;
        node6.left = node4;
        node6.right = node7;
        // node7.right = node15;
        node10.right = node14;
        node14.left = node13;

        return root;
    }

    private static TreeNode TestCase4()
    {
        TreeNode root = new TreeNode(int.MinValue);

        return root;
    }

    // TC: O(n), SC: O(n)
    private static bool IsValidBST_DFS(TreeNode root)
    {
        // Reached to the end of the tree and it is still valid then return true
        if (root == null)
        {
            return true;
        }

        if (root.left != null && root.left.val >= root.val)
        {
            return false;
        }

        if (root.right != null && root.right.val <= root.val)
        {
            return false;
        }

        bool isLeftSubTreeValid = IsValidBST_DFS(root.left);

        // If current visiting node has value that is smaller or equal to the last visited node
        // Then the current traversing list is not in ascending order so it is not a valid binary search tree
        if (traversedNodes.Count > 0 && root.val <= traversedNodes.Last().val)
        {
            return false;
        }

        traversedNodes.Add(root);

        bool isRightSubTreeValid = IsValidBST_DFS(root.right);
        return isLeftSubTreeValid && isRightSubTreeValid;
    }

    public static bool IsValidBST(TreeNode root)
    {
        return IsValidBST_DFS(root);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(IsValidBST(TestCase4()));
    }
}
