namespace Construct_Binary_Tree_Tree_Traversal;

class Program
{
    public static Dictionary<int, int> addedNode = new Dictionary<int, int>();

    public static int pointerPre = 0;

    public static (int[] preOrderArray, int[] inOrderArray) TestCase1()
    {
        return (
            new int[] { 3, 9, 26, 10, 8, 28, 20, 15, 7 },
            new int[] { 10, 26, 8, 9, 28, 3, 15, 20, 7 }
        );
    }

    public static (int[] preOrderArray, int[] inOrderArray) TestCase2()
    {
        return (new int[] { 3, 9, 20, 15, 7 }, new int[] { 9, 3, 15, 20, 7 });
    }

    public static (int[] preOrderArray, int[] inOrderArray) TestCase3()
    {
        return (new int[] { -1 }, new int[] { -1 });
    }

    public static (int[] preOrderArray, int[] inOrderArray) TestCase4()
    {
        return (new int[] { 1, 2 }, new int[] { 2, 1 });
    }

    public static TreeNode BuildTreImplementation(int[] preorder, int[] inorder, int pointerIn)
    {
        if (pointerIn < 0 || pointerIn == inorder.Length || pointerPre == preorder.Length)
        {
            return null;
        }

        // Add new node to the binary tree
        TreeNode newNode = new TreeNode(preorder[pointerPre]);
        addedNode.Add(newNode.val, newNode.val);

        // Increase preOrder pointer just to move on the next node that needs to be inserted
        pointerPre++;

        // Get the pointer of the new node that has just been inserted to the tree and check which sub tree it should go to
        pointerIn = Array.IndexOf(inorder, newNode.val);

        // Focus insert on the left subtree branch first
        if (pointerIn - 1 >= 0 && !addedNode.ContainsKey(inorder[pointerIn - 1]))
        {
            newNode.left = BuildTreImplementation(preorder, inorder, pointerIn - 1);
        }

        // Focus insert on the right subtree branch later
        if (pointerIn + 1 < inorder.Length && !addedNode.ContainsKey(inorder[pointerIn + 1]))
        {
            newNode.right = BuildTreImplementation(preorder, inorder, pointerIn + 1);
        }

        return newNode;
    }

    public static TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        if (preorder.Length == 1)
            return new TreeNode(preorder[0]);

        TreeNode dummyNode = new TreeNode(0);

        dummyNode.left = BuildTreImplementation(preorder, inorder, 0);

        return dummyNode.left;
    }

    static void Main(string[] args)
    {
        var builtTree1 = BuildTree(TestCase4().preOrderArray, TestCase4().inOrderArray);

        return;
    }
}
