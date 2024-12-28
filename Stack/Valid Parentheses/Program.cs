namespace Valid_Parentheses;

class Program
{
    public static string testCase1 = "()";
    public static string testCase2 = "()[]{}";
    public static string testCase3 = "(]";
    public static string testCase4 = "([])";
    public static string testCase5 = "[";
    public static string testCase6 = "]";
    public static string testCase7 = "[[[";
    public static string testCase8 = "]]]";
    public static string testCase9 = "[([]])";

    static void Main(string[] args)
    {
        Console.WriteLine(IsValid2(testCase2));
    }

    public static bool IsValid(string s)
    {
        if (s.Length == 1) return false;

        List<string> validParentheses = [ "()", "[]", "{}" ];

        List<char> openParenthesesArray = [];
    
        foreach ( char c in s) {
            if (c.Equals('(') || c.Equals('[') || c.Equals('{')) {
                openParenthesesArray.Add(c);
            }

            else if (openParenthesesArray.Count == 0 || !validParentheses.Contains($"{openParenthesesArray.Last()}{c}")) {
                return false;
            }

            else {
                openParenthesesArray.RemoveAt(openParenthesesArray.Count - 1);
            }
        }

        if (openParenthesesArray.Count > 0) return false;

        return true;
    }

    public static bool IsValid2(string s) {
        List<char> openParenthesesStack = [];

        Dictionary<char, char> validParentheses = new Dictionary<char, char>()
            {
                {')', '('},
                {']', '['},
                {'}', '{'}
            };

        char openParentheses;

        foreach (char c in s)
        {
            if (validParentheses.TryGetValue(c, out openParentheses)) {

                if (openParenthesesStack.Count == 0 ||  !openParentheses.Equals(openParenthesesStack.Last())) {
                    return false;
                }

                else {
                    openParenthesesStack.RemoveAt(openParenthesesStack.Count() - 1);
                }
            }

            else {
                openParenthesesStack.Add(c);
            }
        }

        return openParenthesesStack.Count == 0;
    }    
}
