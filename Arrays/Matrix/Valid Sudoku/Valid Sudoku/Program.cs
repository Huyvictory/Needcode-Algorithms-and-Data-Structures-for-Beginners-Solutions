namespace Valid_Sudoku;

class Program
{
    private static char[][] TestCase1() {
        return [
            ['5','3','.','.','7','.','.','.','.'],
            ['6','.','.','1','9','5','.','.','.'],
            ['.','9','8','.','.','.','.','6','.'],
            ['8','.','.','.','6','.','.','.','3'],
            ['4','.','.','8','.','3','.','.','1'],
            ['7','.','.','.','2','.','.','.','6'],
            ['.','6','.','.','.','.','2','8','.'],
            ['.','.','.','4','1','9','.','.','5'],
            ['.','.','.','.','8','.','.','7','9']];
    }

    private static char[][] TestCase2() {
        return [
            ['8','3','.','.','7','.','.','.','.'],
            ['6','.','.','1','9','5','.','.','.'],
            ['.','9','8','.','.','.','.','6','.'],
            ['8','.','.','.','6','.','.','.','3'],
            ['4','.','.','8','.','3','.','.','1'],
            ['7','.','.','.','2','.','.','.','6'],
            ['.','6','.','.','.','.','2','8','.'],
            ['.','.','.','4','1','9','.','.','5'],
            ['.','.','.','.','8','.','.','7','9']];
    }

    // TC: O(n^2), SC: O(n^2)
    public static bool IsValidSudoku(char[][] board)
    {
        var mapRows = new Dictionary<int, HashSet<char>>();
        var mapCols = new Dictionary<int, HashSet<char>>();
        var mapSubMatrix = new Dictionary<(int, int), HashSet<char>>();

        for (int row = 0; row < board.Length; row++)
        {
            for (int column = 0; column < board[0].Length; column++)
            {
                if (board[row][column] == '.')
                {
                    continue;
                }

                // Populate the map of row, column, sub matrix with each equivalent number based on the current coordinate
                if (!mapRows.ContainsKey(row))
                {
                    mapRows.Add(row, new HashSet<char>());
                }

                if (!mapCols.ContainsKey(column))
                {
                    mapCols.Add(column, new HashSet<char>());
                }

                if (!mapSubMatrix.ContainsKey((row / 3, column / 3)))
                {
                    mapSubMatrix.Add((row / 3, column / 3), new HashSet<char>());
                }

                // Check for duplicate in current row, col, sub matrix hash set
                if (
                    mapRows[row].Contains(board[row][column])
                    || mapCols[column].Contains(board[row][column])
                    || mapSubMatrix[(row / 3, column / 3)].Contains(board[row][column])
                )
                {
                    return false;
                }
                // If current row, column, sub matrix all don't contain the number of the current coordinate
                // Then add to the equivalent hash sets
                else
                {
                    mapRows[row].Add(board[row][column]);
                    mapCols[column].Add(board[row][column]);
                    mapSubMatrix[(row / 3, column / 3)].Add(board[row][column]);
                }
            }
        }

        return true;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(IsValidSudoku(TestCase1()));
    }
}
