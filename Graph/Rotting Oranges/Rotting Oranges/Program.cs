namespace Rotting_Oranges;

class Program
{
    private static int[][] TestCase1() {
        return [
            [2,1,1],
            [1,1,0],
            [0,1,1]
        ];
    }

    private static int[][] TestCase2() {
        return [
            [2,1,1],
            [0,1,1],
            [1,0,1]
        ];
    }

    private static int[][] TestCase3() {
        return [
            [0,2]
        ];
    }

    private static int[][] TestCase4() {
        return [
            [0,1]
        ];
    }

    private static int[][] TestCase5() {
        return [
            [1, 2]
        ];
    }

    private static int[][] TestCase6() {
        return [
            [2,1,1],
            [1,1,1],
            [0,1,2]
        ];
    }

    private int OrangesRottingImplementation(int[][] grid)
    {
        int totalRows = grid.Length;
        int totalColumns = grid[0].Length;

        int numberOfFreshOranges = 0;
        int minMinutes = 0;

        List<List<int>> directions = [[-1, 0], [1, 0], [0, 1], [0, -1]];

        Queue<(int rowLevel, int columnLevel)> queue = new Queue<(int rowLevel, int columnLevel)>();

        // Count number of fresh oranges
        for (int row = 0; row < totalRows; row++)
        {
            for (int column = 0; column < totalColumns; column++)
            {
                if (grid[row][column] == 1)
                {
                    numberOfFreshOranges++;
                }

                else if (grid[row][column] == 2) {
                    queue.Enqueue((row, column));
                }
            }
        }

        while (numberOfFreshOranges > 0 && queue.Any())
        {
            int NumberRottenOranges = queue.Count;

            for (int i = 0; i < NumberRottenOranges; i++)
            {
                var rottenOrange = queue.Dequeue();

                foreach (var direction in directions)
                {
                    var neighBorRow = rottenOrange.rowLevel + direction[0];
                    var neighBorColumn = rottenOrange.columnLevel + direction[1];

                    if (neighBorRow >= 0  && neighBorRow < totalRows 
                    && neighBorColumn >= 0 && neighBorColumn < totalColumns 
                    && grid[neighBorRow][neighBorColumn] == 1)  {

                        // rotten neighbor orange in next level bfs
                        numberOfFreshOranges--;
                        grid[neighBorRow][neighBorColumn] = 2;
                        queue.Enqueue((neighBorRow, neighBorColumn));
                    }
                }
            }

            // After rotting oranges of next level then increase the minimum minutes by 1
            minMinutes++;
        }

        return numberOfFreshOranges == 0 ? minMinutes : -1;
    }

    public int OrangesRotting(int[][] grid)
    {
        return OrangesRottingImplementation(grid);
    }

    static void Main(string[] args)
    {
        Program testProgram = new Program();

        Console.WriteLine(testProgram.OrangesRotting(TestCase1()));
    }
}
