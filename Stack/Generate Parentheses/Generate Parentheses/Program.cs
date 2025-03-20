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

    public static IList<string> GenerateParenthesis(int n)
    {
        GenerateParenthesesBruteForce(n, "");

        return parenthesesCombinations;
    }

    static void Main(string[] args)
    {
        var result = GenerateParenthesis(TestCase1());

        return;
    }
}
