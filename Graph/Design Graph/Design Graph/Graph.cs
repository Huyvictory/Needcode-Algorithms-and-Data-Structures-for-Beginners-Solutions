namespace Design_Graph;

public class Graph
{
    private Dictionary<int, HashSet<int>> graph;

    public Graph()
    {
        graph = new Dictionary<int, HashSet<int>>();
    }

    public void AddEdge(int src, int dst)
    {
        if (!graph.ContainsKey(src))
        {
            graph.Add(src, new HashSet<int>());
        }

        if (!graph.ContainsKey(dst))
        {
            graph.Add(dst, new HashSet<int>());
        }

        graph[src].Add(dst);
    }

    public bool RemoveEdge(int src, int dst)
    {
        if (graph.ContainsKey(src) && graph.ContainsKey(dst))
        {
            graph[src].Remove(dst);
            return true;
        }

        return false;
    }

    public bool HasPath(int src, int dst)
    {
        Queue<int> queue = new Queue<int>();
        HashSet<int> visit = new HashSet<int>();

        queue.Enqueue(src);
        visit.Add(src);

        while (queue.Any())
        {
            int vertexLevel = queue.Count;

            for (int i = 0; i < vertexLevel; i++)
            {
                var traversedVertex = queue.Dequeue();
                var neighbors = graph[traversedVertex];

                if (traversedVertex == dst)
                {
                    return true;
                }

                foreach (var neighbor in neighbors)
                {
                    if (!visit.Contains(neighbor) && graph[traversedVertex].Contains(neighbor))
                    {
                        visit.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        return false;
    }
}
