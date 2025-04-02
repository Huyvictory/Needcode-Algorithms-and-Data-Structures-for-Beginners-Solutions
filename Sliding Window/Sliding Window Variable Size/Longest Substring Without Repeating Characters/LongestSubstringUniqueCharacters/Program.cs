namespace LongestSubstringUniqueCharacters;

class Program
{
    private static string TestCase1()
    {
        return "abcabcbb";
    }

    private static string TestCase2()
    {
        return "bbbbb";
    }

    private static string TestCase3()
    {
        return "pwwkew";
    }

    private static string TestCase4()
    {
        return " ";
    }

    private static string TestCase5()
    {
        return "dvdf";
    }

    private static string TestCase6()
    {
        return "qrsvbspk";
    }

    // TC: O(n), SC: O(k)
    private static int LengthOfLongestSubstringSlidingWindow(string s)
    {
        if (s.Length == 0)
            return 0;

        // Init a hash set window that contains unique characters of a substring
        var setWindow = new HashSet<char>();

        int left = 0;
        int right = 0;

        int maxLength = 0;

        while (right < s.Length)
        {
            // If substring already have the current character
            if (setWindow.Contains(s[right]))
            {
                // Check the length of the substring in the old sliding window before moving to new window
                maxLength = Math.Max(maxLength, setWindow.Count);

                // Move left pointer into next sliding window position and remove any possible characters in the old window
                while (left != right)
                {
                    setWindow.Remove(s[left]);

                    left++;

                    // if characters between left and right can form a new substring in a new window position
                    // And the new substring doesn't contain duplicate character at right pointer
                    if (s[left] != s[right] && !setWindow.Contains(s[right]))
                    {
                        break;
                    }
                }
            }

            setWindow.Add(s[right]);

            maxLength = Math.Max(maxLength, setWindow.Count);

            right++;
        }

        return maxLength;
    }

    public static int LengthOfLongestSubstring(string s)
    {
        return LengthOfLongestSubstringSlidingWindow(s);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(LengthOfLongestSubstring(TestCase1()));
    }
}
