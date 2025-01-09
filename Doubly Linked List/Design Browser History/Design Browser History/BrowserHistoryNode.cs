namespace Design_Browser_History;

public class BrowserHistoryNode
{
    public BrowserHistoryNode prev;
    public string val;
    public BrowserHistoryNode next;

    public BrowserHistoryNode(
        string val,
        BrowserHistoryNode prev = null,
        BrowserHistoryNode next = null
    )
    {
        this.prev = prev;
        this.val = val;
        this.next = next;
    }
}
