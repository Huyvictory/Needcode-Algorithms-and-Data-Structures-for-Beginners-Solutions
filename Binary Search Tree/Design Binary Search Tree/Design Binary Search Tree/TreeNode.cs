namespace Design_Binary_Search_Tree;

public class TreeNode
{
    public int val;
    public int key;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int key, int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.key = key;
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
