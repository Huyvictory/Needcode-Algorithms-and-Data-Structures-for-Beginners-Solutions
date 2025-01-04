namespace Design_Browser_History;

public class BrowserHistory
{
    public BrowserHistoryNode HomePageNode;

    public BrowserHistoryNode currentBrowsingNode;

    public BrowserHistory(string homepage)
    {
        HomePageNode = new BrowserHistoryNode(homepage, null, null);
        currentBrowsingNode = HomePageNode;
    }

    public void Visit(string url)
    {
        BrowserHistoryNode newBrowsingNode = new BrowserHistoryNode(url, null, null);

        newBrowsingNode.prev = currentBrowsingNode;

        currentBrowsingNode.next = newBrowsingNode;

        currentBrowsingNode = newBrowsingNode;
    }

    public string Back(int steps)
    {
        while (currentBrowsingNode.prev != null && steps > 0)
        {
            currentBrowsingNode = currentBrowsingNode.prev;
            steps--;
        }

        return currentBrowsingNode.val;
    }

    public string Forward(int steps)
    {
        while (currentBrowsingNode.next != null && steps > 0)
        {
            currentBrowsingNode = currentBrowsingNode.next;
            steps--;
        }

        return currentBrowsingNode.val;
    }
}
