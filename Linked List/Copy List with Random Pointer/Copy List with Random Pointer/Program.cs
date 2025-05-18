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
    private static Node CopyRandomListHashMap(Node head)
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

    public static Node CopyRandomList(Node head)
    {
        return CopyRandomListHashMap(head);
    }

    static void Main(string[] args)
    {
        var result = CopyRandomList(TestCase4());

        return;
    }
}
