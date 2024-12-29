namespace Merge_Two_Sorted_Lists;

class Program
{
    public static ListNode ListNode4_1 = new ListNode(4);
    public static ListNode ListNode2_1 = new ListNode(2, ListNode4_1);
    public static ListNode ListNode1_1 = new ListNode(1, ListNode2_1);
    public static ListNode ListNode4_2 = new ListNode(4);
    public static ListNode ListNode3_2 = new ListNode(3, ListNode4_2);
    public static ListNode ListNode1_2 = new ListNode(1, ListNode3_2);

    public static List<ListNode> LinkList_1 = new List<ListNode>
    {
        ListNode1_1,
        ListNode2_1,
        ListNode4_1,
    };

    public static List<ListNode> LinkList_2 = new List<ListNode>
    {
        ListNode1_2,
        ListNode3_2,
        ListNode4_2,
    };

    static void Main(string[] args)
    {
        Console.WriteLine(MergeTwoLists(LinkList_1.First(), LinkList_2.First()).val);
    }

    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null)
            return list2;
        if (list2 == null)
            return list1;

        if (list1 == null && list2 == null)
            return null;

        ListNode resultList = new ListNode(0);

        ListNode tailNode = resultList;
        tailNode.next = null;

        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                tailNode.next = list1;
                list1 = list1.next;
            }
            else
            {
                tailNode.next = list2;
                list2 = list2.next;
            }

            tailNode = tailNode.next;
            tailNode.next = null;
        }

        if (list1 != null)
        {
            tailNode.next = list1;
        }
        else
        {
            tailNode.next = list2;
        }

        return resultList.next;
    }

    public static ListNode MergeTwoLists2(ListNode list1, ListNode list2)
    {
        if (list1 == null)
            return list2;
        if (list2 == null)
            return list1;

        if (list1 == null && list2 == null)
            return null;

        ListNode resultLinkList = new ListNode(0);
        ListNode nextPointer1 = list1;
        ListNode nextPointer2 = list2;
        ListNode newTail = resultLinkList;

        while (nextPointer1 != null && nextPointer2 != null)
        {
            var savedNextPointer1 = nextPointer1.next;
            var savedNextPointer2 = nextPointer2.next;

            if (nextPointer1.val < nextPointer2.val)
            {
                newTail.next = nextPointer1;
                newTail.next.next = nextPointer2;
            }
            else
            {
                newTail.next = nextPointer2;
                newTail.next.next = nextPointer1;
            }

            newTail = newTail.next.next;
            newTail.next = null;

            nextPointer1 = savedNextPointer1;
            nextPointer2 = savedNextPointer2;
        }

        return resultLinkList.next;
    }
}
