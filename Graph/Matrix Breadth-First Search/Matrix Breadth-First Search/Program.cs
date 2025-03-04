namespace Matrix_Breadth_First_Search;

class Program
{
    private HashSet<(int visitedRow, int visitedColumn)> visited =
        new HashSet<(int visitedRow, int visitedColumn)>();

    private int[][] TestCase1() {
        return [
            [0, 0, 0, 0],
            [1, 1, 0, 0],
            [0, 0, 0, 1],
            [0, 1, 0, 0]
        ];
    }

    private int[][] TestCase2() {
        return [
            [0, 0, 0],
        ];
    }

    private int[][] TestCase3() {
        return [
            [0],
        ];
    }

    private int Bfs(int[][] grid)
    {
        int totalRows = grid.Length;
        int totalColumns = grid[0].Length;
        
        Queue<(int levelRow, int levelColumn)> queue = new Queue<(int levelRow, int levelColumn)>();

        List<List<int>> directions = new List<List<int>>() {
            new List<int>() {-1, 0},
            new List<int>() {1, 0},
            new List<int>() {0, 1},
            new List<int>() {0, -1}
        };

        queue.Enqueue((0, 0));
        visited.Add((0, 0));

        int minimumLength = 1;

        while (queue.Count > 0)
        {
            int CoordinatesPerLevel = queue.Count();

            for (int i = 0; i < CoordinatesPerLevel; i++)
            {
                var currentCoordinate = queue.Dequeue();

                foreach (var direction in directions)
                {
                    var neighborRow = currentCoordinate.levelRow + direction[0];
                    var neighborColumn = currentCoordinate.levelColumn + direction[1];

                    if (
                    Math.Min(neighborRow, neighborColumn) < 0
                    || neighborRow == totalRows
                    || neighborColumn == totalColumns
                    || grid[neighborRow][neighborColumn] == 1
                    || visited.Contains((neighborRow, neighborColumn))
                    )
                    {
                        continue;
                    }

                    if (
                        neighborRow == totalRows - 1
                        && neighborColumn == totalColumns - 1
                    )
                    {
                        if (grid[neighborRow][neighborColumn] == 1)
                        {
                            return 0;
                        }
                        else
                        {
                            return minimumLength;
                        }
                    }

                    visited.Add((neighborRow, neighborColumn));
                    queue.Enqueue((neighborRow, neighborColumn));
                }
            }

            // Traverse a whole level means we have move another step closed to finish point
            // Increase the length of the traversed level
            minimumLength++;
        }

        return -1;
    }

    public int ShortestPath(int[][] grid)
    {
        if (grid.Length == 1 && grid[0].Length == 1) return 0;

        return Bfs(grid);
    }

    static void Main(string[] args)
    {
        Program testProgram = new Program();

        Console.WriteLine(testProgram.ShortestPath(testProgram.TestCase1()));
    }
}
