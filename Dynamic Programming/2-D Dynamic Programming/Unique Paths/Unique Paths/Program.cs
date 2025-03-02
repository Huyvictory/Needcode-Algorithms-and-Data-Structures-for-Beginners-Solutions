namespace Unique_Paths;

class Program
{
    private int totalRows = 0;
    private int totalCols = 0;

    private int UniquePathsTopDown(int m, int n, int[,] grid)
    {
        if (m == totalRows || n == totalCols)
        {
            return 0;
        }

        if (m == totalRows - 1 && n == totalCols - 1)
        {
            return 1;
        }

        if (grid[m, n] != 0)
        {
            return grid[m, n];
        }

        int GoDownDecisionUniqueSteps = UniquePathsTopDown(m + 1, n, grid);
        int GoRightDecisionUniqueSteps = UniquePathsTopDown(m, n + 1, grid);

        grid[m, n] = GoDownDecisionUniqueSteps + GoRightDecisionUniqueSteps;

        return grid[m, n];
    }

    public int UniquePaths(int m, int n)
    {
        totalRows = m;
        totalCols = n;

        int[,] grid = new int[m, n];

        return UniquePathsTopDown(0, 0, grid);
    }

    static void Main(string[] args)
    {
        Program testProgram = new Program();

        Console.WriteLine(testProgram.UniquePaths(3, 2));
    }
}
