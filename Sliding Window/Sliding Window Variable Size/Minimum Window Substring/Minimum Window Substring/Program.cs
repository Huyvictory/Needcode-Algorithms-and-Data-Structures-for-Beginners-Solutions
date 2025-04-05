namespace Minimum_Window_Substring;

class Program
{
    private static (string s, string t) TestCase1()
    {
        return ("ADOBECODEBANC", "ABC");
    }

    private static (string s, string t) TestCase2()
    {
        return ("a", "a");
    }

    private static (string s, string t) TestCase3()
    {
        return ("a", "aa");
    }

    private static (string s, string t) TestCase4()
    {
        return ("ADOBEBANCCODBACE", "ABC");
    }

    private static (string s, string t) TestCase5()
    {
        return ("aa", "aa");
    }

    private static (string s, string t) TestCase6()
    {
        return ("cabwefgewcwaefgcf", "cae");
    }

    // TC: O(n), SC: O(m + n)
    private static string MinWindowSlidingVariable(string s, string t)
    {
        if (s.Length < t.Length)
            return "";

        var mapFrequencyCharactersT = new Dictionary<char, int>();
        var mapFrequencyCharactersSlidingWindowS = new Dictionary<char, int>();

        string result = "";
        int minLength = int.MaxValue;

        int have = 0;
        int need = 0;

        foreach (var c in t)
        {
            if (!mapFrequencyCharactersT.ContainsKey(c))
            {
                mapFrequencyCharactersT.Add(c, 0);
                need++;
            }

            mapFrequencyCharactersT[c]++;
        }

        int left = 0;

        for (int right = 0; right < s.Length; right++)
        {
            if (mapFrequencyCharactersT.ContainsKey(s[right]))
            {
                if (!mapFrequencyCharactersSlidingWindowS.ContainsKey(s[right]))
                {
                    mapFrequencyCharactersSlidingWindowS.Add(s[right], 0);
                }

                mapFrequencyCharactersSlidingWindowS[s[right]]++;

                if (
                    mapFrequencyCharactersSlidingWindowS[s[right]]
                    == mapFrequencyCharactersT[s[right]]
                )
                {
                    have++;
                }
            }

            // Check if the current sliding window has at least all of characters in string t with valid frequency characters
            if (have < need)
            {
                continue;
            }

            // If current sliding window substring is valid and it might contains some duplicate characters
            // Then we shrink to find smaller sliding window substring inside until the window is invalid
            // It's invalid when the next position window doesn't contain all characters in string t or some character has
            // smaller number when compared with the same exact character in string t
            while (have >= need)
            {
                // if new sliding window position has length smaller than previous computed length the override it
                if (right - left + 1 < minLength)
                {
                    result = s.Substring(left, right - left + 1);
                    minLength = right - left + 1;
                }

                if (mapFrequencyCharactersT.ContainsKey(s[left]))
                {
                    mapFrequencyCharactersSlidingWindowS[s[left]]--;
                }

                // If the new sliding window has number of characters less than the one of the exact charter with string t
                if (
                    mapFrequencyCharactersT.ContainsKey(s[left])
                    && mapFrequencyCharactersSlidingWindowS[s[left]]
                        < mapFrequencyCharactersT[s[left]]
                )
                {
                    have--;
                }

                left++;
            }
        }

        return result;
    }

    public static string MinWindow(string s, string t)
    {
        return MinWindowSlidingVariable(s, t);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(MinWindow(TestCase1().s, TestCase1().t));
    }
}
