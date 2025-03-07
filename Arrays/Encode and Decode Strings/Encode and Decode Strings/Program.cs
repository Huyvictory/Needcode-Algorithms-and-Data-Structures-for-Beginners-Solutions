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


    static void Main(string[] args)
    {
        Program testProgram = new Program();

        var decodedString = testProgram.Decode(testProgram.Encode(TestCase1()));
        
        return;
    }
}
