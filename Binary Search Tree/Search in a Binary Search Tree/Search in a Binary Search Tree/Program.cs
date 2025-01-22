namespace Search_in_a_Binary_Search_Tree;

class Program
{
    public static (TreeNode rootNode1, int searchVal) TestCase1()
    {
        TreeNode node1 = new TreeNode(1);
        TreeNode node3 = new TreeNode(3);

        TreeNode node2 = new TreeNode(2, node1, node3);
        TreeNode node7 = new TreeNode(7);

        TreeNode rootNode = new TreeNode(4, node2, node7);

        return (rootNode, 2);
    }

    public static (TreeNode rootNode1, int searchVal) TestCase2()
    {
        TreeNode node1 = new TreeNode(1);
        TreeNode node3 = new TreeNode(3);

        TreeNode node2 = new TreeNode(2, node1, node3);
        TreeNode node7 = new TreeNode(7);

        TreeNode rootNode = new TreeNode(4, node2, node7);

        return (rootNode, 5);
    }

    public static TreeNode SearchBST(TreeNode root, int val)
    {
        if (root == null)
            return null;

        if (val > root.val)
        {
            return SearchBST(root.right, val);
        }
        else if (val < root.val)
        {
            return SearchBST(root.left, val);
        }
        else
        {
            return root;
        }
    }

    static void Main(string[] args)
    {
        (TreeNode rootNode, int searchVal) test_case_1 = TestCase1();
        (TreeNode rootNode, int searchVal) test_case_2 = TestCase2();

        var result_1 = SearchBST(test_case_1.rootNode, test_case_1.searchVal);

        var result_2 = SearchBST(test_case_2.rootNode, test_case_2.searchVal);

        return;
    }
}
