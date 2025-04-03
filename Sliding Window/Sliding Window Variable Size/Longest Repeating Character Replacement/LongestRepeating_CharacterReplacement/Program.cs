namespace LongestRepeating_CharacterReplacement;

class Program
{
    private static (string s, int k) TestCase1()
    {
        return ("ABAB", 2);
    }

    private static (string s, int k) TestCase2()
    {
        return ("AABABBA", 1);
    }

    private static (string s, int k) TestCase3()
    {
        return ("AAAAAAA", 1);
    }

    private static (string s, int k) TestCase4()
    {
        return ("AAAAAAB", 1);
    }

    private static (string s, int k) TestCase5()
    {
        return ("BAAAAAA", 1);
    }

    private static (string s, int k) TestCase6()
    {
        return ("AABBBB", 2);
    }

    private static (string s, int k) TestCase7()
    {
        return ("ABCD", 2);
    }

    private static (string s, int k) TestCase8()
    {
        return (
            "EOEMQLLQTRQDDCOERARHGAAARRBKCCMFTDAQOLOKARBIJBISTGNKBQGKKTALSQNFSABASNOPBMMGDIOETPTDICRBOMBAAHINTFLH",
            7
        );
    }

    private static (string s, int k) TestCase9()
    {
        return ("ABCDDD", 3);
    }

    // TC: O(n^2), SC: O(1)
    private static int CharacterReplacementSlidingWindowBruteForce(string s, int k)
    {
        int left = 0;
        int right = left + 1;
        int maxLength = 0;

        int countSwap = 0;

        while (right < s.Length)
        {
            // If current character at pointer right is different with character at pointer left
            // and countSwap is not greater than k then perform swapping and continue expanding window
            if (s[left] != s[right] && countSwap < k)
            {
                countSwap++;
            }
            // If character at these two pointers are different but the number of countSwap has reached k
            // meaning we can't perform any swap and have to shift left and right pointers to next sliding window position
            else if (s[left] != s[right] && countSwap == k)
            {
                maxLength = Math.Max(maxLength, right - left);

                left++;

                right = left + 1;
                countSwap = 0;
                continue;
            }

            maxLength = Math.Max(maxLength, right - left + 1);

            // For case of the substring that is in the last part of the input string and the window is still expanding
            if (right == s.Length - 1)
            {
                int currentSubStringLength = right - left + 1;
                int swappableCharacters = s.Length - currentSubStringLength;
                int remainingSwap = k - countSwap;

                if (countSwap < k && swappableCharacters > 0)
                {
                    maxLength = Math.Max(
                        maxLength,
                        currentSubStringLength
                            + (
                                swappableCharacters <= remainingSwap
                                    ? swappableCharacters
                                    : remainingSwap
                            )
                    );
                }
            }

            right++;
        }

        return maxLength;
    }

    // TC: O(n), SC: O(m)
    private static int CharacterReplacementSlidingWindowMap(string s, int k)
    {
        int left = 0;
        int maxLength = 0;

        var mapCharacters = new Dictionary<char, int>() { };

        for (int right = 0; right < s.Length; right++)
        {
            if (mapCharacters.ContainsKey(s[right]))
            {
                mapCharacters[s[right]]++;
            }
            else
            {
                mapCharacters.Add(s[right], 1);
            }

            // Look up for the maximum frequency character in the current sliding window
            // Shrink the current window and move to next position
            // when the differences between current sliding window length and character with most frequency in current window
            // exceeds k
            while (right - left + 1 - mapCharacters.Values.Max() > k)
            {
                mapCharacters[s[left]]--;
                left++;
            }

            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }

    // TC: O(n), SC: O(m)
    private static int CharacterReplacementSlidingWindowMapOptimized(string s, int k)
    {
        int left = 0;
        int maxLength = 0;
        int maxFCharacter = 0;

        var mapCharacters = new Dictionary<char, int>() { };

        for (int right = 0; right < s.Length; right++)
        {
            if (mapCharacters.ContainsKey(s[right]))
            {
                mapCharacters[s[right]]++;
            }
            else
            {
                mapCharacters.Add(s[right], 1);
            }

            // This variable store the character with most frequency for every sliding window traversed
            // if we encounter multiples invalid sliding window substring, this variable doesn't need to change
            // as if we meet different sliding window substring
            // attached to that most frequency character then we would get larger output
            maxFCharacter = Math.Max(maxFCharacter, mapCharacters[s[right]]);

            // Shrink the current window and move to next position
            // when the differences between current sliding window length and character with most frequency in current window
            // exceeds k
            while ((right - left + 1) - maxFCharacter > k)
            {
                mapCharacters[s[left]]--;
                left++;
            }

            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }

    public static int CharacterReplacement(string s, int k)
    {
        // return CharacterReplacementSlidingWindowBruteForce(s, k);
        // return CharacterReplacementSlidingWindowMap(s, k);
        return CharacterReplacementSlidingWindowMapOptimized(s, k);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(CharacterReplacement(TestCase1().s, TestCase1().k));
    }
}
