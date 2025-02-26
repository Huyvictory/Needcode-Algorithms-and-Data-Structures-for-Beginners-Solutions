namespace Design_Graph;

class Program
{
    private static void TestCase1()
    {
        Graph graph = new Graph();
        graph.AddEdge(1, 2);
        graph.AddEdge(2, 3);
        Console.WriteLine(graph.HasPath(1, 3));
        Console.WriteLine(graph.HasPath(3, 1));
        Console.WriteLine(graph.RemoveEdge(1, 2));
        Console.WriteLine(graph.HasPath(1, 3));
    }

    private static void TestCase2()
    {
        Graph graph = new Graph();
        graph.AddEdge(1, 2);
        graph.AddEdge(2, 3);
        graph.AddEdge(3, 1);
        Console.WriteLine(graph.HasPath(1, 3));
        Console.WriteLine(graph.HasPath(3, 1));
    }

    private static void TestCase3()
    {
        Graph graph = new Graph();
        graph.AddEdge(42, 43);
        graph.AddEdge(43, 44);
        graph.AddEdge(43, 45);
        graph.AddEdge(44, 46);
        graph.AddEdge(45, 46);
        graph.AddEdge(44, 47);
        Console.WriteLine(graph.HasPath(42, 47));
    }

    static void Main(string[] args)
    {
        TestCase1();
    }
}
