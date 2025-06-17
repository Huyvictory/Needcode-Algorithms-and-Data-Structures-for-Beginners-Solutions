namespace Same_Tree;

class Program
{
    private static (TreeNode p, TreeNode q) TestCase1()
    {
        var root1 = new TreeNode(1);
        root1.left = new TreeNode(2);
        root1.right = new TreeNode(3);

        var root2 = new TreeNode(1);
        root2.left = new TreeNode(2);
        root2.right = new TreeNode(3);

        return (root1, root2);
    }

    private static (TreeNode p, TreeNode q) TestCase2()
    {
        var root1 = new TreeNode(1);

        root1.left = new TreeNode(2);

        var root2 = new TreeNode(1);
        root2.right = new TreeNode(2);

        return (root1, root2);
    }

    private static (TreeNode p, TreeNode q) TestCase3()
    {
        var root1 = new TreeNode(1);
        root1.left = new TreeNode(2);
        root1.right = new TreeNode(1);

        var root2 = new TreeNode(1);
        root2.left = new TreeNode(1);
        root2.right = new TreeNode(2);

        return (root1, root2);
    }

    // TC: O(n), SC: O(n)
    private static bool IsSameTreeDFS(TreeNode p, TreeNode q)
    {
        // Both two current sub root nodes are null
        // means we have reached the end of both trees
        // and they are structurally the same
        if (p == null && q == null)
            return true;

        // Not the same structure if one of them is null
        if (p == null || q == null)
        {
            return false;
        }

        bool hasSameLeftSubTree = false;
        bool hasSameRightSubTree = false;

        // Both two current sub root nodes have the same value now
        // move on checking the value and the structure of left and right subtrees
        if (p != null && q != null && p.val == q.val)
        {
            hasSameLeftSubTree = IsSameTreeDFS(p.left, q.left);

            hasSameRightSubTree = IsSameTreeDFS(p.right, q.right);
        }
        // Same structure but different value
        else if (p != null && q != null && p.val != q.val)
        {
            return false;
        }

        return hasSameLeftSubTree && hasSameRightSubTree;
    }

    public static bool IsSameTree(TreeNode p, TreeNode q)
    {
        return IsSameTreeDFS(p, q);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(IsSameTree(TestCase1().p, TestCase1().q));
    }
}
