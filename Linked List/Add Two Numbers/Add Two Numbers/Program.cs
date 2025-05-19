namespace Add_Two_Numbers;

class Program
{
    private static (ListNode l1, ListNode l2) TestCase1()
    {
        ListNode head1 = new ListNode(2);
        ListNode head2 = new ListNode(5);

        ListNode Node4_1 = new ListNode(4);
        ListNode Node3_1 = new ListNode(3);

        ListNode Node6_2 = new ListNode(6);
        ListNode Node4_2 = new ListNode(4);

        head1.next = Node4_1;
        head2.next = Node6_2;

        Node4_1.next = Node3_1;
        Node6_2.next = Node4_2;

        return (head1, head2);
    }

    private static (ListNode l1, ListNode l2) TestCase2()
    {
        ListNode head1 = new ListNode(0);
        ListNode head2 = new ListNode(0);

        return (head1, head2);
    }

    private static (ListNode l1, ListNode l2) TestCase3()
    {
        ListNode head1 = new ListNode(9);
        ListNode head2 = new ListNode(9);

        ListNode Node9_1_1 = new ListNode(9);
        ListNode Node9_1_2 = new ListNode(9);
        ListNode Node9_1_3 = new ListNode(9);
        ListNode Node9_1_4 = new ListNode(9);
        ListNode Node9_1_5 = new ListNode(9);
        ListNode Node9_1_6 = new ListNode(9);

        ListNode Node9_2_1 = new ListNode(9);
        ListNode Node9_2_2 = new ListNode(9);
        ListNode Node9_2_3 = new ListNode(9);

        head1.next = Node9_1_1;
        Node9_1_1.next = Node9_1_2;
        Node9_1_2.next = Node9_1_3;
        Node9_1_3.next = Node9_1_4;
        Node9_1_4.next = Node9_1_5;
        Node9_1_5.next = Node9_1_6;

        head2.next = Node9_2_1;
        Node9_2_1.next = Node9_2_2;
        Node9_2_2.next = Node9_2_3;

        return (head2, head1);
    }

    private static string CheckRemainders(string totalToCheck)
    {
        return totalToCheck.Length == 2 ? totalToCheck.First().ToString() : "0";
    }

    // TC: O(m + n), SC: O(1)
    private static ListNode AddTwoNumbersThreePointers(ListNode l1, ListNode l2)
    {
        String resultTotal = (l1.val + l2.val).ToString();

        ListNode result = new ListNode(int.Parse(resultTotal.Last().ToString()));

        var pointerL1 = l1.next;
        var pointerL2 = l2.next;
        var pointerResult = result;

        var remainder = CheckRemainders(resultTotal);

        while (pointerL1 != null)
        {
            ListNode newNode = new ListNode(0);

            resultTotal =
                pointerL2 != null
                    ? (int.Parse(remainder) + pointerL1.val + pointerL2.val).ToString()
                    : (int.Parse(remainder) + pointerL1.val).ToString();

            newNode.val = int.Parse(resultTotal.Last().ToString());

            remainder = CheckRemainders(resultTotal);

            pointerResult.next = newNode;
            pointerResult = newNode;

            pointerL1 = pointerL1.next;

            if (pointerL2 != null)
            {
                pointerL2 = pointerL2.next;
            }
        }

        while (pointerL2 != null)
        {
            ListNode newNode = new ListNode(0);

            resultTotal =
                pointerL1 != null
                    ? (int.Parse(remainder) + pointerL1.val + pointerL2.val).ToString()
                    : (int.Parse(remainder) + pointerL2.val).ToString();

            newNode.val = int.Parse(resultTotal.Last().ToString());

            remainder = CheckRemainders(resultTotal);

            pointerResult.next = newNode;
            pointerResult = newNode;

            pointerL2 = pointerL2.next;

            if (pointerL1 != null)
            {
                pointerL1 = pointerL1.next;
            }
        }

        if (!remainder.Equals("0"))
        {
            if (remainder.Length == 2)
            {
                pointerResult.next = new ListNode(int.Parse(remainder.Last().ToString()));
                pointerResult.next.next = new ListNode(int.Parse(remainder.First().ToString()));
            }
            else
            {
                pointerResult.next = new ListNode(int.Parse(remainder));
            }
        }

        return result;
    }

    // TC: O(m + n), SC: O(1)
    private static ListNode AddTwoNumbersThreePointersShortened(ListNode l1, ListNode l2)
    {
        var pointerL1 = l1;
        var pointerL2 = l2;

        ListNode dummyNode = new ListNode(0);
        var pointerResult = dummyNode;
        var carry = 0;

        while (pointerL1 != null || pointerL2 != null || carry != 0)
        {
            ListNode newNode = new ListNode(0);

            var l1Value = pointerL1 != null ? pointerL1.val : 0;
            var l2Value = pointerL2 != null ? pointerL2.val : 0;

            var valueToUpdate = (l1Value + l2Value + carry) % 10;
            carry = (l1Value + l2Value + carry) / 10;

            newNode.val = valueToUpdate;

            pointerResult.next = newNode;

            pointerResult = newNode;

            pointerL1 = pointerL1 != null && pointerL1.next != null ? pointerL1.next : null;
            pointerL2 = pointerL2 != null && pointerL2.next != null ? pointerL2.next : null;
        }

        return dummyNode.next;
    }

    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        // return AddTwoNumbersThreePointers(l1, l2);
        return AddTwoNumbersThreePointersShortened(l1, l2);
    }

    static void Main(string[] args)
    {
        var result = AddTwoNumbers(TestCase1().l1, TestCase1().l2);

        return;
    }
}
