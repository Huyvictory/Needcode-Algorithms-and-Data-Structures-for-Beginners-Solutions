using System.Text;

namespace Encode_and_Decode_Strings;

class Program
{
    private static IList<string> TestCase1() {
        return ["neet","code","love","you"];
    }

    private static IList<string> TestCase2() {
        return ["we","say",":","yes"];
    }

    private static IList<string> TestCase3() {
        return [];
    }

    private static IList<string> TestCase4() {
        return [""];
    }

    private static IList<string> TestCase5() {
        return ["we","say",":","yes","!@#$%^&*()"];
    }

    private static IList<string> TestCase6() {
        return ["1,23","45,6","7,8,9"];
    }

    private static IList<string> TestCase7() {
        return ["#","##"];
    }

    // Using Separator approach 
    // TC: O(N), SC: O(1)
    public string Encode(IList<string> strs)
    {
        if (strs.Count == 0) return null;

        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < strs.Count; i++)
        {
            stringBuilder.Append(i < strs.Count - 1 ? $"{strs[i]}@@" : strs[i]);
        }

        return stringBuilder.ToString();
    }

    public List<string> Decode(string s)
    {
        if (s == null) return [];

        return s.Split("@@").ToList();
    }

    // Using Length of each sub string approach with spaces
    // TC: O(n), SC: O(1)
    public string Encode2(IList<string> strs)
    {
        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < strs.Count; i++)
        {
            stringBuilder.Append($"{strs[i].Length} {strs[i]} ");
        }

        return stringBuilder.ToString();
    }

    public List<string> Decode2(string s) {

        var result = new List<string>();
        string currentLengthSubString = string.Empty;

        for (int i = 0; i < s.Length; i++) {
            if (s[i] >= '0' && s[i] <= '9' && (s[i + 1] == ' ' || (s[i + 1] >= '0' && s[i + 1] <= '9'))) {
                currentLengthSubString += s[i];
                continue;
            }
            
            else if (!string.IsNullOrEmpty(currentLengthSubString) && s[i] == ' ') {
                result.Add(s.Substring(i + 1, int.Parse(currentLengthSubString)));
                i += int.Parse(currentLengthSubString) + 1;

                currentLengthSubString = "";
            }
        }

        if (!string.IsNullOrEmpty(currentLengthSubString)) {
            foreach (var c in currentLengthSubString)
            {
                result.Add("");
            }
        }

        return result;
    }

    static void Main(string[] args)
    {
        Program testProgram = new Program();

        var decodedString = testProgram.Decode2(testProgram.Encode2(TestCase1()));
        
        return;
    }
}
