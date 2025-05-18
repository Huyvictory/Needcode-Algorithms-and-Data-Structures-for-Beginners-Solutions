namespace Copy_List_with_Random_Pointer;

class Program
{
    private static Node TestCase1()
    {
        Node head = new Node(7);
        Node node13 = new Node(13);
        Node node11 = new Node(11);
        Node node10 = new Node(10);
        Node node1 = new Node(1);

        head.next = node13;
        node13.next = node11;
        node13.random = head;
        node11.next = node10;
        node11.random = node1;
        node10.next = node1;
        node10.random = node11;
        node1.random = head;

        return head;
    }

    private static Node TestCase2()
    {
        Node head = new Node(1);
        Node node2 = new Node(2);

        head.next = node2;
        head.random = node2;
        node2.random = node2;

        return head;
    }

    private static Node TestCase3()
    {
        Node head = new Node(3);
        Node node3_2 = new Node(3);
        Node node3_3 = new Node(3);

        head.next = node3_2;
        node3_2.next = node3_3;
        node3_2.random = head;

        return head;
    }

    private static Node TestCase4()
    {
        Node head = new Node(-1);

        head.random = head;

        return head;
    }

    // TC: O(n), SC: O(n)
    private static Node CopyRandomListHashMapTwoPass(Node head)
    {
        if (head == null)
            return null;

        // Map to store references object of old node and new node
        Dictionary<Node, Node> map = new Dictionary<Node, Node>();

        var cur = head;

        // Populate map with references of old and new nodes
        while (cur != null)
        {
            Node newNode = new Node(cur.val);

            map.Add(cur, newNode);

            cur = cur.next;
        }

        // Update the pointer references of the new linked list;
        cur = head;

        var newHead = map[head!];
        var newCur = newHead;

        while (cur != null)
        {
            if (cur.next != null)
            {
                newCur.next = map[cur.next];
            }

            if (cur.random != null)
            {
                newCur.random = map[cur.random];
            }

            cur = cur.next;
            newCur = newCur.next;
        }

        return newHead;
    }

    // TC: O(n), SC: O(n)
    private static Node CopyRandomListHashMapOnePass(Node head)
    {
        // Map to store references object of old node and new node
        Dictionary<Node, Node> map = new Dictionary<Node, Node>();

        var cur = head;

        while (cur != null)
        {
            if (!map.ContainsKey(cur))
            {
                map.Add(cur, new Node(cur.val));
            }
            // Override the exiting pair node value in both old new linked list
            else
            {
                map[cur].val = cur.val;
            }

            // If current node has next pointer reference
            if (cur.next != null)
            {
                if (!map.ContainsKey(cur.next))
                {
                    map.Add(cur.next, new Node(0));
                }

                map[cur].next = map[cur.next];
            }

            // If current node has random pointer reference
            if (cur.random != null)
            {
                if (!map.ContainsKey(cur.random))
                {
                    map.Add(cur.random, new Node(0));
                }

                map[cur].random = map[cur.random];
            }

            cur = cur.next;
        }

        return head != null ? map[head] : null;
    }

    public static Node CopyRandomList(Node head)
    {
        // return CopyRandomListHashMapTwoPass(head);
        return CopyRandomListHashMapOnePass(head);
    }

    static void Main(string[] args)
    {
        var result = CopyRandomList(TestCase1());

        return;
    }
}
