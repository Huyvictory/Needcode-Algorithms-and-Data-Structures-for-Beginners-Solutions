namespace Clone_Graph;

class Program
{
    public Node CloneGraphBFS(Node node)
    {
        if (node == null)
        {
            return null;
        }

        if (node.neighbors.Count == 0)
        {
            return new Node(node.val, node.neighbors.ToList());
        }

        Queue<Node> queue = new Queue<Node>();
        Dictionary<Node, Node> clonedNodes = new Dictionary<Node, Node>()
        {
            { node, new Node(node.val) }
        };

        queue.Enqueue(node);

        while (queue.Any())
        {
            var NumNodesLevel = queue.Count;

            for (int i = 0; i < NumNodesLevel; i++)
            {
                var NodeLevel = queue.Dequeue();

                foreach (var neighbor in NodeLevel.neighbors)
                {
                    if (!clonedNodes.ContainsKey(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        clonedNodes[neighbor] = new Node(neighbor.val);
                    }

                    clonedNodes[NodeLevel].neighbors.Add(new Node(neighbor.val));
                }
            }
        }

        return clonedNodes[node];
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
