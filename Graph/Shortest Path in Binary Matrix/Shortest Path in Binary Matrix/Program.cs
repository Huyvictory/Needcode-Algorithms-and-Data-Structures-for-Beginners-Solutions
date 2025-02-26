namespace Shortest_Path_in_Binary_Matrix;

class Program
{
    private static int[][] TestCase1() {
        return [
            [0,1],
            [1,0]
            ];
    }

    private static int[][] TestCase2() {
        return [
            [0,0,0],
            [1,1,0],
            [1,1,0]
        ];
    }

    private static int[][] TestCase3() {
        return [
            [1,0,0],
            [1,1,0],
            [1,1,0]
        ];
    }

    private static int[][] TestCase4() {
        return [
            [0],
        ];
    }

    private static int[][] TestCase5() {
        return [
            [0,0,0,0,1],
            [1,0,0,0,0],
            [0,1,0,1,0],
            [0,0,0,1,1],
            [0,0,0,1,0]
        ];
    }

    private int ShortestPathBinaryMatrixImplementation(int[][] grid)
    {
        int pathLength = 1;
        int totalRows = grid.Length;
        int totalColumns = grid[0].Length;

        if (grid.Length == 1 && grid[0][0] == 0) return 1;

        if (grid[0][0] == 1 || grid[totalRows -1][totalColumns - 1] == 1) return -1;

        Queue<(int rowLevel, int columnLevel)> queue = new Queue<(int rowLevel, int columnLevel)>();
        HashSet<(int traversedRow, int traversedColumn)> traversed =
            new HashSet<(int rowLevel, int columnLevel)>();

        
        List<List<int>> directions = [[0, 1], [1, 1], [-1, -1], [-1, 0], [-1, 1], [0, -1], [1, -1], [1, 0]];

        queue.Enqueue((0, 0));
        traversed.Add((0, 0));

        while (queue.Any())
        {
            int NumberOfCoordinatesLevel = queue.Count;

            for (int coordinate = 0; coordinate < NumberOfCoordinatesLevel; coordinate++)
            {
                var currentCoordinate = queue.Dequeue();

                // Check for other possible traversable neighbor coordinates from the current one
                // If the traversable coordinate found then visit and add to queue for next level traversing
                foreach (var direction in directions)
                {
                    var neighborRow = currentCoordinate.rowLevel + direction[0];
                    var neighborColumn = currentCoordinate.columnLevel + direction[1];

                    if (Math.Min(neighborRow, neighborColumn) < 0 
                    || neighborRow == totalRows
                    || neighborColumn == totalColumns 
                    || grid[neighborRow][neighborColumn] == 1 
                    || traversed.Contains((neighborRow, neighborColumn))) {
                        continue;
                    }

                    if (neighborRow == totalRows - 1 && neighborColumn == totalColumns - 1) {
                        return pathLength + 1;
                    }

                    queue.Enqueue((neighborRow, neighborColumn));
                    traversed.Add((neighborRow, neighborColumn));
                }
            }
            pathLength++;
        }

        return -1;
    }

    private int ShortestPathBinaryMatrixImplementation2(int[][] grid)
    {
        int totalRows = grid.Length;
        int totalColumns = grid[0].Length;

        if (grid.Length == 1 && grid[0][0] == 0) return 1;

        if (grid[0][0] == 1 || grid[totalRows -1][totalColumns - 1] == 1) return -1;

        Queue<(int rowLevel, int columnLevel, int level)> queue = new Queue<(int rowLevel, int columnLevel, int level)>();
        
        List<List<int>> directions = [[0, 1], [1, 1], [-1, -1], [-1, 0], [-1, 1], [0, -1], [1, -1], [1, 0]];

        queue.Enqueue((0, 0, 1));

        while (queue.Any())
        {
            int NumberOfCoordinatesLevel = queue.Count;

            for (int coordinate = 0; coordinate < NumberOfCoordinatesLevel; coordinate++)
            {
                var currentCoordinate = queue.Dequeue();

                // If the coordinate of the current traversing level is the target destination then return its level
                if (currentCoordinate.rowLevel == totalRows - 1 && currentCoordinate.columnLevel == totalColumns - 1) {
                    return currentCoordinate.level;
                }

                // Check for other possible traversable neighbor coordinates from the current one
                // If the traversable coordinate found then visit and add to queue for next level traversing
                foreach (var direction in directions)
                {
                    var neighborRow = currentCoordinate.rowLevel + direction[0];
                    var neighborColumn = currentCoordinate.columnLevel + direction[1];

                    if (Math.Min(neighborRow, neighborColumn) < 0 
                    || neighborRow == totalRows
                    || neighborColumn == totalColumns 
                    || grid[neighborRow][neighborColumn] == 1) {
                        continue;
                    }
                    
                    queue.Enqueue((neighborRow, neighborColumn, currentCoordinate.level + 1));
                    grid[neighborRow][neighborColumn] = 1;
                }
            }
        }

        return -1;
    }

    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        return ShortestPathBinaryMatrixImplementation2(grid);
    }

    static void Main(string[] args)
    {
        Program testProgram = new Program();

        Console.WriteLine(testProgram.ShortestPathBinaryMatrix(TestCase1()));
    }
}
