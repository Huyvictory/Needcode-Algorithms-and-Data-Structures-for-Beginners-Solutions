namespace Design_Browser_History;

public class BrowserHistory2
{
    public List<string> BrowsingHistory = [];
    public int currentBrowsingPage = 0;
    public int actualLengthAfterVisit = 1;

    public BrowserHistory2(string homepage) { 
        BrowsingHistory.Add(homepage);
    }

    public void Visit(string url) { 
        if (BrowsingHistory.Count < (currentBrowsingPage + 2)) {
            BrowsingHistory.Add(url);
        }
        else {
            BrowsingHistory[currentBrowsingPage + 1]  = url;
        }

        currentBrowsingPage += 1;
        actualLengthAfterVisit = currentBrowsingPage + 1;
    }

    public string Back(int steps) {
        currentBrowsingPage = Math.Max(currentBrowsingPage - steps, 0);

        return BrowsingHistory[currentBrowsingPage];
     }

    public string Forward(int steps) { 
        currentBrowsingPage = Math.Min(currentBrowsingPage  +  steps, actualLengthAfterVisit - 1);

        return BrowsingHistory[currentBrowsingPage];
    }
}
