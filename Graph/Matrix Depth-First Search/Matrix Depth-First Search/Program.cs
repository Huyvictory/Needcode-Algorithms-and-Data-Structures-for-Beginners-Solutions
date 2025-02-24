namespace Matrix_Depth_First_Search;

class Program
{

    private HashSet<(int visitedRow, int visitedColumn)> visited = new HashSet<(int visitedRow, int visitedColumn)>(); 

    private int[][] TestCase1() {
        return new int[][] {
            [0, 0, 0, 0],
            [1, 1, 0, 0],
            [0, 0, 0, 1],
            [0, 1, 0, 0]
        };
    }

    private int[][] TestCase2() {
        return new int[][] {
            [0, 0, 0],
            [0, 1, 0],
            [0, 0, 0] 
        };
    }

    private int[][] TestCase3() {
        return new int[][] {
            [0, 0, 0],
            [0, 0, 0],
            [0, 0, 1] 
        };
    }

    private int CountPathsImplementation(
        int[][] grid, 
        int row, 
        int column,
        HashSet<(int visitedRow, int visitedColumn)> visited) {

        // Calculate total number of rows and columns of input matrix
        int rows = grid.Length;
        int columns = grid[0].Length;

        if (grid[rows - 1][columns - 1] == 1) return 0;

        // Base happy case when reach to the target coordinate
        if (row == rows - 1 && column == columns - 1) {
            return 1;
        }

        // Base exception case
        if (Math.Min(row, column) < 0 // Out of lower bound 
        || row >= rows // Out of higher bound for row
        || column >= columns // Out of higher bound for column  
        || visited.Contains((row, column)) // The coordinate has already been visited
        || grid[row][column] == 1) // Go to unauthorized coordinate
        {
            return 0;
        }

        visited.Add((row, column));

        // Count for any valid path that could reach to the target node.
        // It applies to other sub problems
        int CountUniquePaths = 0;

        // Go down one row
        CountUniquePaths += CountPathsImplementation(grid, row + 1, column, visited);
        // Go up one row
        CountUniquePaths += CountPathsImplementation(grid, row - 1, column, visited);
        // Go right one column
        CountUniquePaths += CountPathsImplementation(grid, row, column + 1, visited);
        // Go left one column
        CountUniquePaths += CountPathsImplementation(grid, row, column - 1, visited);

        // Backtrack clear the traversed coordinate of a unique path to find others
        visited.Remove((row, column));

        return CountUniquePaths;
    }

    public int CountPaths(int[][] grid)
    {
        return CountPathsImplementation(grid, 0, 0, visited);
    }

    static void Main(string[] args)
    {
        Program programTest = new Program();

        Console.WriteLine(programTest.CountPaths(programTest.TestCase1()));
    }
}
