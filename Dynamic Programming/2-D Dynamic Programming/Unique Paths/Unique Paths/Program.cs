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

    private int UniquePathsBottomUp(int m, int n, int[,] grid)
    {
        grid[m - 1, n - 1] = 1;

        // This is for resolving every single sub problem coordinate of the current row
        int[] recentRowSubProblem = new int[n];

        for (int i = grid.GetUpperBound(0); i >= 0; i--)
        {
            grid[i, n - 1] = 1;

            for (int j = n - 2; j >= 0; j--)
            {
                // Each sub coordinate will have the result of the same column (go down) + next column (go right)
                // in the recent row sub problem and current row respectively
                grid[i, j] = recentRowSubProblem[j] + grid[i, j + 1];

                // Update the recent row sub problem coordinate data to compute for other bigger sub problems
                recentRowSubProblem[j] = grid[i, j];
            }
        }

        return grid[0, 0];
    }

    public int UniquePaths(int m, int n)
    {
        totalRows = m;
        totalCols = n;

        int[,] grid = new int[m, n];

        return UniquePathsBottomUp(totalRows, totalCols, grid);
    }

    static void Main(string[] args)
    {
        Program testProgram = new Program();

        Console.WriteLine(testProgram.UniquePaths(3, 2));
    }
}
