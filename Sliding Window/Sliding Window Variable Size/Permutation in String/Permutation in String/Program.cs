namespace Permutation_in_String;

class Program
{
    private static (string s1, string s2) TestCase1()
    {
        return ("ab", "eidbabaooo");
    }

    private static (string s1, string s2) TestCase2()
    {
        return ("ab", "eidboaoo");
    }

    private static (string s1, string s2) TestCase3()
    {
        return ("abcd", "eidbaooobdcae");
    }

    private static (string s1, string s2) TestCase4()
    {
        return ("adc", "dcda");
    }

    private static (string s1, string s2) TestCase5()
    {
        return ("hello", "ooolleoooleh");
    }

    private static bool CheckInclusionSlidingWindow(string s1, string s2)
    {
        // a string is a permutation of another string
        // is the same exact string but different characters arrangement

        // We need a map to store occurrence of every single character in the s1 string
        var map = new Dictionary<char, int>();

        foreach (var c in s1)
        {
            if (!map.ContainsKey(c))
            {
                map.Add(c, 1);
            }
            else
            {
                map[c] += 1;
            }
        }

        // We apply sliding window technique for string s2 and only expand window if we meet any character in string s1
        int left = 0;

        // Move left pointer of window until we reach any character in string s1
        while (!map.ContainsKey(s2[left]))
        {
            left++;
        }

        var mapCompare = new Dictionary<char, int>();

        // Check the permutation substring s1 in s2 string from window left to right
        for (int right = left; right <= s2.Length; right++)
        {
            if (right >= s2.Length || !map.ContainsKey(s2[right]))
            {
                // check for number of occurrences in window string s2 is it the same with string s1
                if (map.Values.Sum() <= mapCompare.Values.Sum())
                {
                    return true;
                }

                mapCompare.Clear();
                left = right + 1;
                continue;
            }

            if (!mapCompare.ContainsKey(s2[right]) && map.ContainsKey(s2[right]))
            {
                mapCompare.Add(s2[right], 1);
            }
            else if (mapCompare.ContainsKey(s2[right]) && map.ContainsKey(s2[right]))
            {
                mapCompare[s2[right]]++;
            }
        }

        return false;
    }

    // TC: O(n * m), SC: O(1)
    private static bool CheckInclusionSlidingWindowFixedSize(string s1, string s2)
    {
        if (s1.Length > s2.Length)
            return false;

        // We need a map to store occurrence of every single character in the s1 string
        var map = new Dictionary<char, int>();

        foreach (var c in s1)
        {
            if (!map.ContainsKey(c))
            {
                map.Add(c, 1);
            }
            else
            {
                map[c] += 1;
            }
        }

        int left = 0;

        while (left < s2.Length)
        {
            var alphabetMap = new Dictionary<char, int>();
            int right = left + s1.Length - 1;

            // If the sliding window is valid and has fixed size equals to the length of string s1
            if (right - left + 1 == s1.Length && right < s2.Length)
            {
                // Check on the current sliding window
                for (int i = left; i <= right; i++)
                {
                    // If we encounter a character that only exists in string s2
                    if (!map.ContainsKey(s2[i]))
                    {
                        break;
                    }

                    if (!alphabetMap.ContainsKey(s2[i]))
                    {
                        alphabetMap.Add(s2[i], 1);
                    }
                    else
                    {
                        alphabetMap[s2[i]]++;
                    }
                }

                bool isValidWindowSubstring = true;

                foreach (var c in s1)
                {
                    if (!alphabetMap.ContainsKey(c) || map[c] > alphabetMap[c])
                    {
                        isValidWindowSubstring = false;
                        break;
                    }
                }

                if (isValidWindowSubstring)
                {
                    return true;
                }
            }

            left++;
        }

        return false;
    }

    public static bool CheckInclusion(string s1, string s2)
    {
        // return CheckInclusionSlidingWindow(s1, s2);
        return CheckInclusionSlidingWindowFixedSize(s1, s2);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(CheckInclusion(TestCase4().s1, TestCase4().s2));
    }
}
