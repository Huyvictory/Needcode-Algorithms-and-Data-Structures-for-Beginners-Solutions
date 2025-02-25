namespace Max_Area_of_Island;

class Program
{
    private int max = 0;
    private int totalRows = 0;
    private int totalColumns = 0;

    private int[][] TestCase1() {
        return [
        [0,0,1,0,0,0,0,1,0,0,0,0,0],
        [0,0,0,0,0,0,0,1,1,1,0,0,0],
        [0,1,1,0,1,0,0,0,0,0,0,0,0],
        [0,1,0,0,1,1,0,0,1,0,1,0,0],
        [0,1,0,0,1,1,0,0,1,1,1,0,0],
        [0,0,0,0,0,0,0,0,0,0,1,0,0],
        [0,0,0,0,0,0,0,1,1,1,0,0,0],
        [0,0,0,0,0,0,0,1,1,0,0,0,0]];
    }

    private int[][] TestCase2() {
        return [
        [0,0,0,0,0,0,0,0]
        ];
    }

    private int Dfs(int[][] grid, int row, int column)
    {
        if (
            Math.Min(row, column) < 0
            || row == totalRows
            || column == totalColumns
            || grid[row][column] == 0
        )
        {
            return 0;
        }

        int area = 0;

        if (grid[row][column] == 1)
        {
            area = 1;
            grid[row][column] = 0;
        }

        return area
            + Dfs(grid, row - 1, column)
            + Dfs(grid, row + 1, column)
            + Dfs(grid, row, column + 1)
            + Dfs(grid, row, column - 1);
    }

    public int MaxAreaOfIsland(int[][] grid)
    {
        totalRows = grid.Length;
        totalColumns = grid[0].Length;

        for (int row = 0; row < totalRows; row++)
        {
            for (int column = 0; column < totalColumns; column++)
            {
                if (grid[row][column] == 1)
                {
                    var areaOfIsland = Dfs(grid, row, column);

                    if (areaOfIsland > max)
                    {
                        max = areaOfIsland;
                    }
                }
            }
        }

        return max;
    }

    static void Main(string[] args)
    {
        Program programTest = new Program();

        Console.WriteLine(programTest.MaxAreaOfIsland(programTest.TestCase1()));
        Console.WriteLine(programTest.MaxAreaOfIsland(programTest.TestCase2()));
    }
}
