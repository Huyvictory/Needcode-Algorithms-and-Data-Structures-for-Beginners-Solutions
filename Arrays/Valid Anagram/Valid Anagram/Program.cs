namespace Valid_Anagram;

class Program
{
    private static (string string1, string string2) TestCase1()
    {
        return ("anagram", "nagaram");
    }

    private static (string string1, string string2) TestCase2()
    {
        return ("rat", "car");
    }

    private static string sortString(string input)
    {
        return string.Concat(input.OrderBy(c => c));
    }

    // Time complexity: O(nlogn), Space complexity: O(1)
    private static bool IsAnagramSort(string s, string t)
    {
        return sortString(s) == sortString(t);
    }

    // Time complexity: O(n), Space complexity: O(n)
    private static bool IsAnagramHashMap(string s, string t)
    {
        var map = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (!map.ContainsKey(s[i]))
            {
                map.Add(s[i], 1);
            }
            else
            {
                map[s[i]] += 1;
            }
        }

        for (int j = 0; j < t.Length; j++)
        {
            if (!map.ContainsKey(t[j]))
            {
                return false;
            }
            else if (map.ContainsKey(t[j]))
            {
                map[t[j]] -= 1;

                if (map[t[j]] == 0)
                {
                    map.Remove(t[j]);
                }
            }
        }

        return map.Count == 0;
    }

    // Time complexity: O(n), Space complexity: O(n)
    private static bool IsAnagramTwoHashMaps(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        var mapStringS = new Dictionary<char, int>();
        var mapStringT = new Dictionary<char, int>();

        foreach (char c in s)
        {
            if (!mapStringS.ContainsKey(c))
            {
                mapStringS.Add(c, 1);
            }
            else
            {
                mapStringS[c] += 1;
            }
        }

        foreach (char c in t)
        {
            if (!mapStringT.ContainsKey(c))
            {
                mapStringT.Add(c, 1);
            }
            else
            {
                mapStringT[c] += 1;
            }
        }

        foreach (var pair in mapStringS)
        {
            if (!mapStringT.ContainsKey(pair.Key))
            {
                return false;
            }
            else if (
                mapStringT.ContainsKey(pair.Key) && mapStringT[pair.Key] != mapStringS[pair.Key]
            )
            {
                return false;
            }
        }

        return true;
    }

    public static bool IsAnagram(string s, string t)
    {
        return IsAnagramTwoHashMaps(s, t);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(IsAnagram(TestCase2().string1, TestCase2().string2));
    }
}
