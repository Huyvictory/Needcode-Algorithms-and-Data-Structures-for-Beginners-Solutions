namespace Longest_Common_Subsequence;

class Program
{
    private static (string string1, string string2) TestCase1()
    {
        return ("abcde", "ace");
    }

    private void UpdateCache(string builtString, Dictionary<char, List<string>> cache)
    {
        if (!cache.ContainsKey(builtString[0]))
        {
            cache.Add(builtString[0], []);
        }
    }

    private int LongestCommonSubsequenceTopDown(
        string text1,
        string text2,
        int row,
        int col,
        int[,] dp
    )
    {
        // If coordinate of row or column is out of bound return 0
        if (row == text1.Length || col == text2.Length) {
            return 0;
        }

        // Return LCS computed from other sub problems's LCSs
        if (dp[row, col] != 0) {
            return dp[row, col];
        }

        // If the coordinate row, column gives the same subsequence character from both string text1, text2
        // We move diagonally to move on to the next sub problem and find next total largest common subsequence between 
        // reduced substrings
        // Add 1 for the subsequence character that we just found
        if (text1[row] == text2[col]) {
            dp[row, col] = 1 + LongestCommonSubsequenceTopDown(text1, text2, row + 1, col + 1, dp);
        }

        // If the current coordinate isn't a valid subsequence character
        // Then we move on two other sub problem by going down one row and going right one column
        // And find the total of largest common subsequence of the reduced substring for each sub problem
        else if (text1[row] != text2[col]) {
            dp[row, col] = Math.Max(
                LongestCommonSubsequenceTopDown(text1, text2, row +1, col, dp), 
                LongestCommonSubsequenceTopDown(text1, text2, row, col + 1, dp));
        }

        return dp[row, col];
    }

    private int LongestCommonSubsequenceBottomUp(string text1, string text2) {

        int[,] dp = new int[text1.Length + 1, text2.Length + 1];

        for (int row = dp.GetUpperBound(0) - 1; row >= 0; row--)
        {
            for (int col = dp.GetUpperBound(1) - 1; col >= 0; col--)
            {
                // If the current coordinate is a valid subsequence get the lcs from the diagonal coordinate
                // plus 1 of the recent found subsequence character of the current sub problem
                if (text1[row] == text2[col]) {
                    dp[row, col] = 1 + dp[row + 1, col + 1];
                }

                // If the current coordinate isn't a valid subsequence character
                // Then we move on find the LCSs of adjacent sub problems by going down one row or going right one column
                // And find the total of largest common subsequence of the reduced substring for each sub problem
                // The max of two LCSs will be the result of the current sub problem
                else if (text1[row] != text2[col]) {
                    dp[row, col] = Math.Max(dp[row + 1, col], dp[row, col + 1]);
                }
            }   
        }

        return dp[0,0];
    }

    public int LongestCommonSubsequence(string text1, string text2)
    {
        return LongestCommonSubsequenceBottomUp(text1, text2);
    }

    static void Main(string[] args)
    {
        var testProgram = new Program();
        Console.WriteLine(testProgram.LongestCommonSubsequence(TestCase1().string1, TestCase1().string2));
    }
}
