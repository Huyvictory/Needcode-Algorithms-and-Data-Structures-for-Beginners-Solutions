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

    private static (TreeNode p, TreeNode q) TestCase4()
    {
        var root1 = new TreeNode(1);

        root1.right = new TreeNode(1);

        var root2 = new TreeNode(1);
        root2.right = new TreeNode(1);

        return (root1, root2);
    }

    // TC: O(n), SC: O(n)
    private static bool IsSameTreeDFS(TreeNode p, TreeNode q)
    {
        // Both two current sub root nodes are null
        // means we have reached the end of both trees
        // and they are structurally the samee
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

    // TC: O(n), SC: O(n)
    private static bool IsSameTreeBFS(TreeNode p, TreeNode q)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        Queue<TreeNode> queue2 = new Queue<TreeNode>();

        queue.Enqueue(p);
        queue2.Enqueue(q);

        while (queue.Count > 0 && queue2.Count > 0)
        {
            var currentQueue1CountSnapShot = queue.Count;
            var currentQueue2CountSnapShot = queue2.Count;

            while (currentQueue1CountSnapShot > 0 && currentQueue2CountSnapShot > 0)
            {
                currentQueue1CountSnapShot--;
                currentQueue2CountSnapShot--;

                var currentNode1 = queue.Dequeue();
                var currentNode2 = queue2.Dequeue();

                // Both two current sub root nodes are null from parent leaf nodes
                // means we have reached the end of both trees
                // and they are structurally the same
                if (currentNode1 == null && currentNode2 == null)
                {
                    continue;
                }

                // If one of the nodes is null, but the other is not (different structure)
                // or if both nodes are not null but have different values
                // then the trees are not structurally the same
                if (
                    currentNode1 == null
                    || currentNode2 == null
                    || currentNode1.val != currentNode2.val
                )
                {
                    return false;
                }

                // Enqueue the left and right children of both binary trees including null value
                queue.Enqueue(currentNode1.left);
                queue.Enqueue(currentNode1.right);

                queue2.Enqueue(currentNode2.left);
                queue2.Enqueue(currentNode2.right);
            }
        }

        return true;
    }

    public static bool IsSameTree(TreeNode p, TreeNode q)
    {
        // return IsSameTreeDFS(p, q);
        return IsSameTreeBFS(p, q);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(IsSameTree(TestCase1().p, TestCase1().q));
    }
}
