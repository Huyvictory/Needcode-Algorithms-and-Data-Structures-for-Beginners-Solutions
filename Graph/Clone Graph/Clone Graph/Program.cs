namespace Clone_Graph;

class Program
{
    public Node CloneGraphBFS(Node node)
    {
        if (node == null)
        {
            return null;
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

    private Node Dfs(Node node, Dictionary<Node, Node> clonedNodes)
    {
        // the node has already been visited, cloned
        if (clonedNodes.ContainsKey(node))
        {
            return clonedNodes[node];
        }

        // Clone itself
        var newNodeInstance = new Node(node.val);

        // Add to map marked as visited
        clonedNodes.Add(node, newNodeInstance);

        // Clone its neighbor nodes and add to list
        foreach (var neighbor in node.neighbors)
        {
            newNodeInstance.neighbors.Add(Dfs(neighbor, clonedNodes));
        }

        // return cloned instance of a node
        return newNodeInstance;
    }

    public Node CloneGraphDFS(Node node)
    {
        Dictionary<Node, Node> clonedNodes = new Dictionary<Node, Node>();

        Dfs(node, clonedNodes);

        return clonedNodes[node];
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
