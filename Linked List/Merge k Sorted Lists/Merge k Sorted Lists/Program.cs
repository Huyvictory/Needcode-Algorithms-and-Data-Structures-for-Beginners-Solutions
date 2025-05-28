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

    // TC: O(nlogn), SC: O(n)
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

    public static ListNode MergeKLists(ListNode[] lists)
    {
        return MergeKListsMergeSort(lists, 0, lists.Length - 1);
    }

    static void Main(string[] args)
    {
        var res = MergeKLists(TestCase1());

        return;
    }
}
