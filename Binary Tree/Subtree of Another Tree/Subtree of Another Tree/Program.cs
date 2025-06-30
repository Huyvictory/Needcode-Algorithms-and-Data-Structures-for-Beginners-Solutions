namespace Subtree_of_Another_Tree;

class Program
{
    private static (TreeNode root, TreeNode subRoot) TestCase1()
    {
        TreeNode root = new TreeNode(3);
        TreeNode node4 = new TreeNode(4);
        TreeNode node5 = new TreeNode(5);
        TreeNode node1 = new TreeNode(1);
        TreeNode node2 = new TreeNode(2);

        root.left = node4;
        root.right = node5;

        node4.left = node1;
        node4.right = node2;

        TreeNode subRoot = new TreeNode(4);
        subRoot.left = new TreeNode(1);
        subRoot.right = new TreeNode(2);

        return (root, subRoot);
    }

    private static (TreeNode root, TreeNode subRoot) TestCase2()
    {
        TreeNode root = new TreeNode(3);
        TreeNode node4 = new TreeNode(4);
        TreeNode node5 = new TreeNode(5);
        TreeNode node1 = new TreeNode(1);
        TreeNode node2 = new TreeNode(2);
        TreeNode node0 = new TreeNode(0);

        root.left = node4;
        root.right = node5;

        node4.left = node1;
        node4.right = node2;
        node2.left = node0;

        TreeNode subRoot = new TreeNode(4);
        subRoot.left = new TreeNode(1);
        subRoot.right = new TreeNode(2);

        return (root, subRoot);
    }

    private static (TreeNode root, TreeNode subRoot) TestCase3()
    {
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(1);

        TreeNode subRoot = new TreeNode(1);

        return (root, subRoot);
    }

    // TC: O(n), SC: O(n)
    // n is the number of nodes in the root tree
    // We traverse the root tree to find all nodes that have the same value as the root of the subRoot tree
    private static List<TreeNode> FindListSuitableSubRootNodes(TreeNode root, TreeNode subRoot)
    {
        if (root == null)
        {
            return new List<TreeNode>();
        }

        List<TreeNode> suitableSubRootNodes = new List<TreeNode>();

        List<TreeNode> listAvailableSubRootLeft = FindListSuitableSubRootNodes(root.left, subRoot);
        List<TreeNode> listAvailableSubRootRight = FindListSuitableSubRootNodes(
            root.right,
            subRoot
        );

        if (root.val == subRoot.val)
        {
            suitableSubRootNodes.Add(root);
        }

        return suitableSubRootNodes
            .Concat(listAvailableSubRootLeft)
            .Concat(listAvailableSubRootRight)
            .ToList();
    }

    // TC: O(n * m), SC: O(n + m)
    // n is the number of nodes in the root tree
    // m is the number of nodes in the subRoot tree
    // Function to check if the two trees are structurally and equally value the same
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

    // TC: O(k + n * m), SC: O(n + m)
    // k is the number of suitable sub root nodes found in the root tree
    // n is the number of nodes in the root tree
    // m is the number of nodes in the subRoot tree
    // We traverse every the suitable sub root nodes to check if any of them is structurally and equally value
    // the same as the subRoot tree
    private static bool IsSubtreeIterativeDFS(List<TreeNode> suitableSubRootNodes, TreeNode subRoot)
    {
        while (suitableSubRootNodes.Count > 0)
        {
            TreeNode currentSubRootNode = suitableSubRootNodes[0];
            suitableSubRootNodes.RemoveAt(0);

            if (IsSameTreeDFS(currentSubRootNode, subRoot))
            {
                return true;
            }
        }

        return false;
    }

    // TC: O(n * m), SC: O(n + m)
    // n is the number of nodes in the root tree
    // m is the number of nodes in the subRoot tree
    private static bool IsSubtreeRecursiveDFS(TreeNode root, TreeNode subRoot)
    {
        if (root == null)
        {
            return false;
        }

        if (IsSameTreeDFS(root, subRoot))
        {
            return true;
        }

        return IsSubtreeRecursiveDFS(root.left, subRoot)
            || IsSubtreeRecursiveDFS(root.right, subRoot);
    }

    public static bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        return IsSubtreeRecursiveDFS(root, subRoot);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(IsSubtree(TestCase1().root, TestCase1().subRoot));
    }
}
