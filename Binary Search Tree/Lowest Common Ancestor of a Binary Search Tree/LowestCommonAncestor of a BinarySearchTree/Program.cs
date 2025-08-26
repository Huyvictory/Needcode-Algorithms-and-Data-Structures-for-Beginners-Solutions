namespace LowestCommonAncestor_of_a_BinarySearchTree;

class Program
{
    private static (TreeNode root, TreeNode p, TreeNode q) TestCase1()
    {
        TreeNode root = new TreeNode(6);
        TreeNode node2 = new TreeNode(2);
        TreeNode node8 = new TreeNode(8);
        TreeNode node0 = new TreeNode(0);
        TreeNode node4 = new TreeNode(4);
        TreeNode node7 = new TreeNode(7);
        TreeNode node9 = new TreeNode(9);
        TreeNode node3 = new TreeNode(3);
        TreeNode node5 = new TreeNode(5);

        root.left = node2;
        root.right = node8;
        node2.left = node0;
        node2.right = node4;
        node4.left = node3;
        node4.right = node5;
        node8.left = node7;
        node8.right = node9;

        return (root, node2, node8);
    }

    private static (TreeNode root, TreeNode p, TreeNode q) TestCase2()
    {
        TreeNode root = new TreeNode(6);
        TreeNode node2 = new TreeNode(2);
        TreeNode node8 = new TreeNode(8);
        TreeNode node0 = new TreeNode(0);
        TreeNode node4 = new TreeNode(4);
        TreeNode node7 = new TreeNode(7);
        TreeNode node9 = new TreeNode(9);
        TreeNode node3 = new TreeNode(3);
        TreeNode node5 = new TreeNode(5);

        root.left = node2;
        root.right = node8;
        node2.left = node0;
        node2.right = node4;
        node4.left = node3;
        node4.right = node5;
        node8.left = node7;
        node8.right = node9;

        return (root, node2, node4);
    }

    private static (TreeNode root, TreeNode p, TreeNode q) TestCase3()
    {
        TreeNode root = new TreeNode(2);
        TreeNode node1 = new TreeNode(1);

        root.left = node1;

        return (root, root, node1);
    }

    private static (TreeNode root, TreeNode p, TreeNode q) TestCase4()
    {
        TreeNode root = new TreeNode(3);
        TreeNode node1 = new TreeNode(1);
        TreeNode node4 = new TreeNode(4);
        TreeNode node2 = new TreeNode(2);

        root.left = node1;
        root.right = node4;
        node1.right = node2;

        return (root, node2, node4);
    }

    private static (TreeNode root, TreeNode p, TreeNode q) TestCase5()
    {
        TreeNode root = new TreeNode(6);
        TreeNode node2 = new TreeNode(2);
        TreeNode node8 = new TreeNode(8);
        TreeNode node0 = new TreeNode(0);
        TreeNode node4 = new TreeNode(4);
        TreeNode node7 = new TreeNode(7);
        TreeNode node9 = new TreeNode(9);
        TreeNode node3 = new TreeNode(3);
        TreeNode node5 = new TreeNode(5);

        root.left = node2;
        root.right = node8;
        node2.left = node0;
        node2.right = node4;
        node4.left = node3;
        node4.right = node5;
        node8.left = node7;
        node8.right = node9;

        return (root, node0, node8);
    }

    // TC: O(h), SC: O(h)
    // Where h is the height of the binary tree
    private static TreeNode LowestCommonAncestorDFS(TreeNode root, TreeNode p, TreeNode q)
    {
        // If current sub root node has value that is larger than both values of p and q then traverse to the left
        if (root.val > p.val && root.val > q.val)
        {
            return LowestCommonAncestorDFS(root.left, p, q);
        }

        // If current sub root node has value that is smaller than both values of p and q then traverse to the right
        if (root.val < p.val && root.val < q.val)
        {
            return LowestCommonAncestorDFS(root.right, p, q);
        }

        // For case that is the root node has direct access to sub root node p and q at both left and right subtree
        // Or the root node is one of the sub root node p or q then just return it
        // Or sub root node p or q is in different branch and current sub root node is in the range of p and q
        if (
            (root.left == p && root.right == q)
            || (root.left == q && root.right == p)
            || (root.val > p.val && root.val < q.val)
            || (root.val > q.val && root.val < p.val)
            || root == p
            || root == q
        )
        {
            return root;
        }

        // Abitrary return to avoid compile code error
        return null;
    }

    public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        return LowestCommonAncestorDFS(root, p, q);
    }

    static void Main(string[] args)
    {
        var (root, p, q) = TestCase5();

        var res = LowestCommonAncestor(root, p, q);

        return;
    }
}
