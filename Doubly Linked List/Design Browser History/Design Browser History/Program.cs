namespace Design_Browser_History;

class Program
{
    public static void TestCase1()
    {
        BrowserHistory browserHistory = new BrowserHistory("leetcode.com");
        browserHistory.Visit("google.com"); // You are in "leetcode.com". Visit "google.com"
        browserHistory.Visit("facebook.com"); // You are in "google.com". Visit "facebook.com"
        browserHistory.Visit("youtube.com"); // You are in "facebook.com". Visit "youtube.com"
        Console.WriteLine(browserHistory.Back(1)); // You are in "youtube.com", move back to "facebook.com" return "facebook.com"
        Console.WriteLine(browserHistory.Back(1)); // You are in "facebook.com", move back to "google.com" return "google.com"
        Console.WriteLine(browserHistory.Forward(1)); // You are in "google.com", move forward to "facebook.com" return "facebook.com"
        browserHistory.Visit("linkedin.com"); // You are in "facebook.com". Visit "linkedin.com"
        Console.WriteLine(browserHistory.Forward(2)); // You are in "linkedin.com", you cannot move forward any steps.
        Console.WriteLine(browserHistory.Back(2)); // You are in "linkedin.com", move back two steps to "facebook.com" then to "google.com". return "google.com"
        Console.WriteLine(browserHistory.Back(7)); // You are in "google.com", you can move back only one step to "leetcode.com". return "leetcode.com"
    }

    public static void TestCase2()
    {
        BrowserHistory2 browserHistory = new BrowserHistory2("leetcode.com");
        browserHistory.Visit("google.com"); // You are in "leetcode.com". Visit "google.com"
        browserHistory.Visit("facebook.com"); // You are in "google.com". Visit "facebook.com"
        browserHistory.Visit("youtube.com"); // You are in "facebook.com". Visit "youtube.com"
        Console.WriteLine(browserHistory.Back(1)); // You are in "youtube.com", move back to "facebook.com" return "facebook.com"
        Console.WriteLine(browserHistory.Back(1)); // You are in "facebook.com", move back to "google.com" return "google.com"
        Console.WriteLine(browserHistory.Forward(1)); // You are in "google.com", move forward to "facebook.com" return "facebook.com"
        browserHistory.Visit("linkedin.com"); // You are in "facebook.com". Visit "linkedin.com"
        Console.WriteLine(browserHistory.Forward(2)); // You are in "linkedin.com", you cannot move forward any steps.
        Console.WriteLine(browserHistory.Back(2)); // You are in "linkedin.com", move back two steps to "facebook.com" then to "google.com". return "google.com"
        Console.WriteLine(browserHistory.Back(7)); // You are in "google.com", you can move back only one step to "leetcode.com". return "leetcode.com"
    }

    static void Main(string[] args)
    {
        TestCase1();
        Console.WriteLine("-------------------");
        TestCase2();
    }
}
