namespace Unique_Paths_II;

class Program
{
    private static int[][] TestCase1() {
        return [
            [0,0,0],
            [0,1,0],
            [0,0,0]
        ];
    }

    private static int[][] TestCase2() {
        return [
            [0,1],
            [0,0]
        ];
    }

    private static int[][] TestCase3() {
        return [
            [0,0],
            [0,1]
        ];
    }

    private static int[][] TestCase4() {
        return [
            [0,1,0,0]
        ];
    }

    private static int[][] TestCase5() {
        return [
            [0,0,0,0],
            [0,1,0,0],
            [0,0,0,0],
            [0,0,1,0],
            [0,0,0,0]
        ];
    }

    private int UniquePathsWithObstaclesTopDown(int[][] obstacleGrid, int row, int col, Dictionary<(int row, int column), int> cache)
    {
        if (row == obstacleGrid.Length - 1 && col == obstacleGrid[0].Length - 1)
        {
            return 1;
        }

        if (cache.ContainsKey((row, col))) {
            return cache[(row, col)];
        }

        int numberOfUniquePaths = 0;

        if (row + 1 < obstacleGrid.Length && obstacleGrid[row + 1][col] != 1)
        {
            numberOfUniquePaths += UniquePathsWithObstaclesTopDown(obstacleGrid, row + 1, col, cache);
        }

        if (col + 1 < obstacleGrid[0].Length && obstacleGrid[row][col + 1] != 1)
        {
            numberOfUniquePaths += UniquePathsWithObstaclesTopDown(obstacleGrid, row, col + 1, cache);
        }

        cache.Add((row, col), numberOfUniquePaths);

        return numberOfUniquePaths;
    }

    private int UniquePathsWithObstaclesTopDown2(int[][] obstacleGrid, int row, int col, Dictionary<(int row, int column), int> cache)
    {
        // If the coordinate has calculated the number of unique paths then get from it.
        if (cache.ContainsKey((row, col))) {
            return cache[(row, col)];
        }

        // Reached to destination from the coordination return 1
        if (row == obstacleGrid.Length - 1 && col == obstacleGrid[0].Length - 1)
        {
            return 1;
        }

        // If coordinate row or column is outbound then return 0
        if (row == obstacleGrid.Length || col == obstacleGrid[0].Length) {
            return 0;
        }

        // If the decision taken reached obstacle, then you can not go further return 0
        if (obstacleGrid[row][col] == 1) {
            return 0;
        }

        int numberOfUniquePaths = UniquePathsWithObstaclesTopDown2(obstacleGrid, row + 1, col, cache) + 
                                    UniquePathsWithObstaclesTopDown2(obstacleGrid, row, col + 1, cache);

        cache.Add((row, col), numberOfUniquePaths);

        return numberOfUniquePaths;
    }

    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        if (obstacleGrid[0][0] == 1 || obstacleGrid[obstacleGrid.Length - 1][obstacleGrid[0].Length - 1] == 1) {
            return 0;
        }

        var cache = new Dictionary<(int row, int column), int>();

        return UniquePathsWithObstaclesTopDown2(obstacleGrid, 0, 0, cache);
    }

    static void Main(string[] args)
    {
        Program testProgram = new Program();
        Console.WriteLine(testProgram.UniquePathsWithObstacles(TestCase5()));
    }
}
