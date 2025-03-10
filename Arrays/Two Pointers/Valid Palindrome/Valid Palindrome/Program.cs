namespace Valid_Palindrome;

class Program
{
    private static string TestCase1()
    {
        return "A man, a plan, a canal: Panama";
    }

    private static string TestCase2()
    {
        return "race a car";
    }

    private static string TestCase3()
    {
        return " ";
    }

    public static bool IsPalindromeTwoPointers(string s)
    {
        s = new string(s.ToLower().Where(c => char.IsLetterOrDigit(c)).ToArray());

        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            if (s[left] != s[right])
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

    public static bool IsPalindrome(string s)
    {
        return IsPalindromeTwoPointers(s);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(IsPalindromeTwoPointers(TestCase1()));
    }
}
