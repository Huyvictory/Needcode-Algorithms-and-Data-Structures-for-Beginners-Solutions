namespace Merge_k_Sorted_Lists;

class Program
{
    private static ListNode[] TestCase1()
    {
        var head1 = new ListNode(1);
        var head1_4 = new ListNode(4);
        var head1_5 = new ListNode(5);

        head1.next = head1_4;
        head1_4.next = head1_5;

        var head1_2 = new ListNode(1);
        var head1_2_3 = new ListNode(3);
        var head1_2_4 = new ListNode(4);

        head1_2.next = head1_2_3;
        head1_2_3.next = head1_2_4;

        var head2 = new ListNode(2);
        var head2_6 = new ListNode(6);

        head2.next = head2_6;

        return new ListNode[] { head1, head1_2, head2, };
    }

    private static ListNode[] TestCase2()
    {
        var head1_1 = new ListNode(1);
        var head1_2 = new ListNode(2);
        var head1_2_1 = new ListNode(2);

        head1_1.next = head1_2;
        head1_2.next = head1_2_1;

        var head2_1 = new ListNode(1);
        var head2_1_2 = new ListNode(1);
        var head2_2 = new ListNode(2);

        head2_1.next = head2_1_2;
        head2_1_2.next = head2_2;

        return new ListNode[] { head1_1, head2_1 };
    }

    private static ListNode MergeTwoLinkedLists(ListNode linkedListLeft, ListNode linkedListRight)
    {
        // Head of the merged sorted linked list
        ListNode headMergedSortedLinkedList = new ListNode(0);
        ListNode mergedLinkedListCur = headMergedSortedLinkedList;

        while (linkedListLeft != null && linkedListRight != null)
        {
            if (linkedListLeft.val <= linkedListRight.val)
            {
                mergedLinkedListCur.next = linkedListLeft;
                linkedListLeft = linkedListLeft.next;
            }
            else
            {
                mergedLinkedListCur.next = linkedListRight;
                linkedListRight = linkedListRight.next;
            }

            mergedLinkedListCur = mergedLinkedListCur.next;
        }

        while (linkedListLeft != null)
        {
            mergedLinkedListCur.next = linkedListLeft;
            linkedListLeft = linkedListLeft.next;
            mergedLinkedListCur = mergedLinkedListCur.next;
        }

        while (linkedListRight != null)
        {
            mergedLinkedListCur.next = linkedListRight;
            linkedListRight = linkedListRight.next;
            mergedLinkedListCur = mergedLinkedListCur.next;
        }

        return headMergedSortedLinkedList.next;
    }

    // TC: O(nlogk), SC: O(logk)
    private static ListNode MergeKListsMergeSort(ListNode[] lists, int start, int end)
    {
        if (lists.Length == 0)
            return null;

        // If we reach to sub problem that has the linked list already sorted
        if (start == end)
            return lists[start];

        // Calculate medium value with this formula to void integer overflow
        int medium = start + (end - start) / 2;

        // half left linked lists
        var mergedSortedLinkedListLeft = MergeKListsMergeSort(lists, start, medium);

        // half right linked lists
        var mergedSortedLinkedListRight = MergeKListsMergeSort(lists, medium + 1, end);

        var res = MergeTwoLinkedLists(mergedSortedLinkedListLeft, mergedSortedLinkedListRight);

        return res;
    }

    // TC: O(k), SC: O(1)
    private static ListNode MergeKListsIteration(ListNode[] lists)
    {
        if (lists.Length == 0)
            return null;

        for (int i = 1; i < lists.Length; i++)
        {
            lists[i] = MergeTwoLinkedLists(lists[i], lists[i - 1]);
        }

        return lists[lists.Length - 1];
    }

    // TC: O(klogn + n), SC: O(n)
    private static ListNode MergeKListsHeap(ListNode[] lists)
    {
        if (lists.Length == 0)
            return null;

        var queue = new PriorityQueue<ListNode, int>();

        // Enqueue every single node of every linked list into priority queue
        foreach (var linkedList in lists)
        {
            if (linkedList != null)
                queue.Enqueue(linkedList, linkedList.val);
        }

        ListNode res = new ListNode(0);
        var resCur = res;

        while (queue.Count > 0)
        {
            var dequeuedNode = queue.Dequeue();

            resCur.next = dequeuedNode;
            resCur = resCur.next;

            if (dequeuedNode.next != null)
                queue.Enqueue(dequeuedNode.next, dequeuedNode.next.val);
        }

        return res.next;
    }

    // TC: O(klogn + n), SC: O(n)
    private static ListNode MergeKListsHeap2(ListNode[] lists)
    {
        var queue = new PriorityQueue<ListNode, int>();

        // Enqueue every single node of every linked list into priority queue
        foreach (var linkedList in lists)
        {
            var curLinkedList = linkedList;

            while (curLinkedList != null)
            {
                queue.Enqueue(new ListNode(curLinkedList.val), curLinkedList.val);
                curLinkedList = curLinkedList.next;
            }
        }

        ListNode res = new ListNode(0);
        var resCur = res;

        while (queue.Count > 0)
        {
            resCur.next = queue.Dequeue();
            resCur = resCur.next;
        }

        return res.next;
    }

    public static ListNode MergeKLists(ListNode[] lists)
    {
        // return MergeKListsMergeSort(lists, 0, lists.Length - 1);
        // return MergeKListsIteration(lists);
        // return MergeKListsHeap(lists);
        return MergeKListsHeap2(lists);
    }

    static void Main(string[] args)
    {
        var res = MergeKLists(TestCase2());

        return;
    }
}
