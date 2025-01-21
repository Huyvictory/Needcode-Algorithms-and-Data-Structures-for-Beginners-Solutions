namespace First_Bad_Version;

class Program
{
    public static int firstBadVersion = 1;

    public static bool IsBadVersion(int version)
    {
        if (version > firstBadVersion)
        {
            return false;
        }

        if (version < firstBadVersion)
        {
            return false;
        }

        return true;
    }

    public static int FirstBadVersion(int n)
    {
        int left = 1;

        while (left < n)
        {
            int guessVersion = left + ((n - left) / 2);

            if (IsBadVersion(guessVersion))
            {
                n = guessVersion;
            }
            else
            {
                left = guessVersion + 1;
            }
        }

        return left;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(FirstBadVersion(3));
    }
}
