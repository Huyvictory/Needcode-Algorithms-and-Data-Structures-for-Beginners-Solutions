namespace Design_Binary_Search_Tree;

class TreeMap
{
    public TreeNode treeMap;

    public TreeMap()
    {
        treeMap = null;
    }

    public void Insert(int key, int val)
    {
        TreeNode cur = treeMap;
        TreeNode previousTraversedNode = cur;

        if (treeMap == null)
        {
            treeMap = new TreeNode(key, val);
            return;
        }

        while (cur != null)
        {
            previousTraversedNode = cur;

            if (cur.key < key)
            {
                cur = cur.right;
            }

            else if (cur.key > key)
            {
                cur = cur.left;
            }
            
            else {
                break;
            }
        }

        if (previousTraversedNode.key > key)
        {
            previousTraversedNode.left = new TreeNode(key, val);
        }
        else if (previousTraversedNode.key < key)
        {
            previousTraversedNode.right = new TreeNode(key, val);
        }

        // Same key insertion, override the last known data of the node with that key
        else {
            previousTraversedNode.val = val;
        }
    }

    public int Get(int key)
    {
        if (treeMap == null)
            return -1;

        TreeNode cur = treeMap;

        while (cur != null)
        {
            if (cur.key > key)
            {
                cur = cur.left;
            }
            else if (cur.key < key)
            {
                cur = cur.right;
            }
            else
            {
                return cur.val;
            }
        }

        return -1;
    }

    public int GetMin()
    {
        if (treeMap == null)
            return -1;

        TreeNode cur = treeMap;

        while (cur.left != null)
        {
            cur = cur.left;
        }

        return cur.val;
    }

    public int GetMax()
    {
        if (treeMap == null)
            return -1;

        TreeNode cur = treeMap;

        while (cur.right != null)
        {
            cur = cur.right;
        }

        return cur.val;
    }

    public static TreeNode FindMinimumRightSubTreeTarget(TreeNode target)
    {
        while (target != null && target.left != null)
        {
            target = target.left;
        }

        return target;
    }

    public void Remove(int key) { 

        if (treeMap == null)
            return;
        
        TreeNode cur = treeMap;
        TreeNode previousTraversedNode = cur;

        while (cur != null) {
            if (cur.key > key) {
                previousTraversedNode = cur;
                cur = cur.left;
            }
            else if (cur.key < key) {
                previousTraversedNode = cur;
                cur = cur.right;
            }
            else {

                // Handle for node key that has both subnodes on the left and right 
                // or the node that needs to be deleted is root node

                if (cur.left != null && cur.right != null || (cur.key == previousTraversedNode.key )) {
                    var subRightTree = cur.right;
                    var leftSubTree = cur.left;

                    if (subRightTree != null)
                    { 
                        var minimumNodeRightSubTree = FindMinimumRightSubTreeTarget(subRightTree);

                        cur.key = minimumNodeRightSubTree.key;
                        cur.val = minimumNodeRightSubTree.val;

                        if (subRightTree.left != null)
                        {
                            while (subRightTree.left != null) {
                                var nextNode = subRightTree.left;
                                if (nextNode.left == null && nextNode.right == null) {
                                    previousTraversedNode = subRightTree;
                                    break;
                                }
                                else {
                                subRightTree = subRightTree.left;
                                }
                            }
                                previousTraversedNode.left = null;
                        }
                        else {
                                previousTraversedNode.right = null;
                        }
                    }
                    else if (leftSubTree != null) {
                        cur.key = leftSubTree.key;
                        cur.val = leftSubTree.val;
                        cur.left = leftSubTree.left;

                        if (cur.right != null) {
                            Insert(cur.right.key, cur.right.val);
                        }
                    }

                    // root node that is also leaf node
                    else {
                        treeMap = null;
                    }
                }
                else {
                    if (cur.left == null && cur.right == null) {
                        previousTraversedNode.left = null;
                        previousTraversedNode.right = null;
                    }
                    else {
                        if (cur.left != null) {
                            previousTraversedNode.left = cur.left;
                        }
                        else {
                            previousTraversedNode.right = cur.right;
                        }
                    }
                }
                return;
            }
        }
    }

    public List<int> GetInorderKeys() {
        List<int> inorderTraversedKeys = [];

        Stack<TreeNode> stack = new Stack<TreeNode>();

        TreeNode cur = treeMap;

        while (cur != null || stack.Count > 0) {

            // Traverse to the left first
            while (cur != null) {
                stack.Push(cur);
                cur = cur.left;
            }

            TreeNode visitedSubNode = stack.Pop();
            inorderTraversedKeys.Add(visitedSubNode.key);

            cur = visitedSubNode.right;
        }

        return inorderTraversedKeys;
     }
}
