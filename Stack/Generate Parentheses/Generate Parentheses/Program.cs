namespace Generate_Parentheses;

class Program
{
    private static int TestCase1()
    {
        return 3;
    }

    private static int TestCase2()
    {
        return 1;
    }

    private static IList<string> parenthesesCombinations = new List<string>();

    private static bool IsValidParenthesesCombination(string combination)
    {
        int checkSum = 0;
        foreach (var c in combination)
        {
            // If we face an open parentheses then we add one to check sum
            if (c.Equals('('))
            {
                checkSum++;
            }
            // If we face a close parentheses then we minus one to check sum
            else
            {
                checkSum--;
            }

            // If there is no open parentheses that could support current close one then this combination is not valid
            if (checkSum < 0)
            {
                return false;
            }
        }

        // If there is no redundant open parentheses then it is a valid combination
        return checkSum == 0;
    }

    // TC: O((2^2*n) * n), SC: O((2^2*n) * n)
    private static void GenerateParenthesesBruteForce(int n, string builtString)
    {
        // Base case to check if combination is valid
        if (builtString.Length == (2 * n))
        {
            if (IsValidParenthesesCombination(builtString))
                parenthesesCombinations.Add(builtString);

            return;
        }

        GenerateParenthesesBruteForce(n, builtString + "(");
        GenerateParenthesesBruteForce(n, builtString + ")");
    }

    // TC: O(4^n / sqrt(n)), SC: O(n)
    private static void GenerateParenthesesBacktrack(
        int n,
        string builtString,
        int numOpen,
        int numClose
    )
    {
        // If the number of open parentheses is larger than n pairs
        // which means the open parentheses number is redundant and it is not a valid combination
        if (numOpen > n)
        {
            return;
        }

        // If the number of close parentheses is greater than open parentheses then it is not valid combination
        // as there isn't enough open parentheses to close
        if (numClose > numOpen)
        {
            return;
        }

        // Base case built string has valid number of open and close parentheses
        if (builtString.Length == (2 * n))
        {
            parenthesesCombinations.Add(builtString);
            return;
        }

        numOpen++;
        GenerateParenthesesBacktrack(n, builtString + "(", numOpen, numClose);

        // Back track the number of open parentheses to go back to each previous state in the decision tree
        numOpen--;

        numClose++;
        GenerateParenthesesBacktrack(n, builtString + ")", numOpen, numClose);
    }

    public static IList<string> GenerateParenthesis(int n)
    {
        // GenerateParenthesesBruteForce(n, "");
        GenerateParenthesesBacktrack(n, "", 0, 0);

        return parenthesesCombinations;
    }

    static void Main(string[] args)
    {
        var result = GenerateParenthesis(TestCase1());

        return;
    }
}
