namespace Merge_k_Sorted_Lists;

class Program
{
    public static List<ListNode> TestCase1()
    {
        // Linked List 1
        ListNode Node5_1 = new ListNode(5);
        ListNode Node4_1 = new ListNode(4, Node5_1);
        ListNode Node1_1 = new ListNode(1, Node4_1);

        // Linked List 2
        ListNode Node4_2 = new ListNode(4);
        ListNode Node3_2 = new ListNode(3, Node4_2);
        ListNode Node1_2 = new ListNode(1, Node3_2);

        // Linked List 3
        ListNode Node6_3 = new ListNode(6);
        ListNode Node2_3 = new ListNode(2, Node6_3);

        return new List<ListNode>() { Node1_1, Node1_2, Node2_3 };
    }

    public static List<ListNode> TestCase2()
    {
        return new List<ListNode>() { null };
    }

    public static List<ListNode> TestCase3()
    {
        return new List<ListNode>() { new ListNode(1) };
    }

    public static List<ListNode> TestCase4()
    {
        return new List<ListNode>() { null, null };
    }

    public static List<ListNode> TestCase5()
    {
        return new List<ListNode>() { };
    }

    public static List<ListNode> TestCase6()
    {
        // Linked List 1
        ListNode Node2_2 = new ListNode(2);
        ListNode Node2_1 = new ListNode(2, Node2_2);
        ListNode Node1_1 = new ListNode(1, Node2_1);

        // Linked List 2
        ListNode Node2_2_2 = new ListNode(2);
        ListNode Node1_2_2 = new ListNode(1, Node2_2_2);
        ListNode Node1_2_1 = new ListNode(1, Node1_2_2);

        return new List<ListNode>() { Node1_1, Node1_2_1 };
    }

    public static List<ListNode> TestCase7()
    {
        // Linked List 1
        ListNode Node3_1 = new ListNode(3);
        ListNode Node2_1 = new ListNode(2, Node3_1);
        ListNode Node1_1 = new ListNode(1, Node2_1);

        // Linked List 2
        ListNode Node7_2 = new ListNode(7);
        ListNode Node6_2 = new ListNode(6, Node7_2);
        ListNode Node5_2 = new ListNode(5, Node6_2);
        ListNode Node4_2 = new ListNode(4, Node5_2);

        return new List<ListNode>() { Node1_1, Node4_2 };
    }

    public static (
        ListNode HeadNodeMergedLinkedList,
        Dictionary<int, ListNode> MergedListMap,
        int TotalCountListNodesMergedLinkedList
    ) MergeWithoutSort(List<ListNode> listLinkedLists)
    {
        ListNode headMergedLinkedList = null;

        ListNode mergedLinkedList = headMergedLinkedList;
        Dictionary<int, ListNode> MergedListMap = new Dictionary<int, ListNode>();

        int CountMergedLinkedList = 0;

        for (int i = 0; i < listLinkedLists.Count; i++)
        {
            ListNode headNode = listLinkedLists[i];

            while (headNode != null)
            {
                if (mergedLinkedList == null)
                {
                    mergedLinkedList = headNode;
                    headMergedLinkedList = headNode;
                }
                else
                {
                    mergedLinkedList.next = headNode;
                    mergedLinkedList = headNode;
                }

                MergedListMap.Add(CountMergedLinkedList, new ListNode(mergedLinkedList.val));

                headNode = headNode.next;
                CountMergedLinkedList++;
            }

            mergedLinkedList.next = null;
        }

        return (
            HeadNodeMergedLinkedList: headMergedLinkedList,
            MergedListMap,
            TotalCountListNodesMergedLinkedList: CountMergedLinkedList
        );
    }

    public static ListNode MergeSubLinkedListsLeftRight(
        ListNode HeadNodeLeft,
        ListNode HeadNodeRight
    )
    {
        var tempHeadNodeLeft = HeadNodeLeft;
        var temHeadNodeRight = HeadNodeRight;

        ListNode mergedSortedSubLinkedList = null;

        ListNode tempMergedSubLinkedList = mergedSortedSubLinkedList;

        while (tempHeadNodeLeft != null & temHeadNodeRight != null)
        {
            if (tempHeadNodeLeft.val <= temHeadNodeRight.val)
            {
                if (tempMergedSubLinkedList == null)
                {
                    mergedSortedSubLinkedList = tempHeadNodeLeft;
                    tempMergedSubLinkedList = tempHeadNodeLeft;
                }
                else
                {
                    tempMergedSubLinkedList.next = tempHeadNodeLeft;
                    tempMergedSubLinkedList = tempHeadNodeLeft;
                }
                tempHeadNodeLeft = tempHeadNodeLeft.next;
            }
            else
            {
                if (tempMergedSubLinkedList == null)
                {
                    mergedSortedSubLinkedList = temHeadNodeRight;
                    tempMergedSubLinkedList = temHeadNodeRight;
                }
                else
                {
                    tempMergedSubLinkedList.next = temHeadNodeRight;
                    tempMergedSubLinkedList = temHeadNodeRight;
                }
                temHeadNodeRight = temHeadNodeRight.next;
            }

            tempMergedSubLinkedList.next = null;
        }

        while (tempHeadNodeLeft != null)
        {
            tempMergedSubLinkedList.next = tempHeadNodeLeft;
            break;
        }

        while (temHeadNodeRight != null)
        {
            tempMergedSubLinkedList.next = temHeadNodeRight;
            break;
        }

        return mergedSortedSubLinkedList;
    }

    public static ListNode MergeSortImplementation(
        ListNode HeadNode,
        Dictionary<int, ListNode> mergedListMap,
        int start,
        int end
    )
    {
        int mediumPoint = (start + end) / 2;

        // Base case when splitted sub array only have one element and we don't have to sort or continue the split
        if (start == end)
            return mergedListMap[start];

        // Half Left Sub Linked List
        var sortedSubLinkedListLeft = MergeSortImplementation(
            HeadNode,
            mergedListMap,
            start,
            mediumPoint
        );

        // Half Right Sub Linked List
        var sortedSubLinkedListRight = MergeSortImplementation(
            HeadNode,
            mergedListMap,
            mediumPoint + 1,
            end
        );

        ListNode sortedSubLinkedList = MergeSubLinkedListsLeftRight(
            sortedSubLinkedListLeft,
            sortedSubLinkedListRight
        );

        return sortedSubLinkedList;
    }

    public static ListNode MergeKLists(ListNode[] lists)
    {
        if (lists.Length <= 1)
        {
            if (lists[0] != null && lists[0].val != null)
            {
                return lists[0];
            }
            return null;
        }

        (
            ListNode HeadNodeMergedLinkedList,
            Dictionary<int, ListNode> MergedListMap,
            int TotalCountListNodesMergedLinkedList
        ) = MergeWithoutSort(lists.ToList());

        return MergeSortImplementation(
            HeadNodeMergedLinkedList,
            MergedListMap,
            0,
            TotalCountListNodesMergedLinkedList - 1
        );
    }

    public static (List<ListNode>, bool) EdgeCaseCheck(ListNode[] lists)
    {
        var nullFilteredList = lists.Where(l => l != null).ToArray();

        return nullFilteredList.Length == 0 ? (null, true) : (nullFilteredList.ToList(), false);
    }

    static void Main(string[] args)
    {
        ListNode mergedKList = null;
        (List<ListNode> filterReturn, bool hasEdgeCaseHappened) = EdgeCaseCheck(
            TestCase6().ToArray()
        );

        if (hasEdgeCaseHappened)
        {
            return;
        }

        mergedKList = MergeKLists(filterReturn.ToArray());

        return;
    }
}
