namespace Number_of_Islands;

class Program
{
    private int[][] traverseDirection = [[1, 0], [-1, 0], [0, 1], [0, -1]];

    private int rows = 0;
    private int columns = 0;

    private char[][] TestCase1() {
        return [
            ['1','1','1','1','0'],
            ['1','1','0','1','0'],
            ['1','1','0','0','0'],
            ['0','0','0','0','0']
        ];
    }

    private char[][] TestCase2() {
        return [
            ['1','1','0','0','0'],
            ['1','1','0','0','0'],
            ['0','0','1','0','0'],
            ['0','0','0','1','1']
        ];
    }

    private void Dfs(char[][] grid, int row, int column) {
        if (Math.Min(row, column) < 0 || 
        row == rows || 
        column == columns || 
        grid[row][column] == '0') {
            return;
        }

        else if (grid[row][column] == '1') {
            grid[row][column] = '0';

            foreach (var direction in traverseDirection)
            {
                Dfs(grid, row + direction[0], column + direction[1]);
            }
        }
    }

    private int NumsIslandsImplementation(char[][] grid) {
        

        int numberOfIslands = 0;

        // Traverse for every row of the matrix to find any land of any island
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                // If land found, proceed to destroy its neighbor lands
                if (grid[row][column] == '1') {
                    numberOfIslands++;
                    Dfs(grid, row, column);
                }
            }
        }

        return numberOfIslands;
    }

    public int NumIslands(char[][] grid)
    {
        rows = grid.Length;
        columns = grid[0].Length;

        return NumsIslandsImplementation(grid);
    }

    static void Main(string[] args)
    {
        Program testProgram = new Program();

        Console.WriteLine(testProgram.NumIslands(testProgram.TestCase1()));
        Console.WriteLine(testProgram.NumIslands(testProgram.TestCase2()));
    }
}
