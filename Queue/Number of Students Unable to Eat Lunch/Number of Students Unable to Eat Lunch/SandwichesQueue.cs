namespace Number_of_Students_Unable_to_Eat_Lunch;

public class SandwichesQueue
{
    public SandwichNode FirstSandwich = null;

    public SandwichNode LastSandwich = null;

    public SandwichesQueue(int[] ListSandwiches)
    {
        FirstSandwich = new SandwichNode(ListSandwiches[0]);
        LastSandwich = FirstSandwich;

        SandwichNode currentSandwich = FirstSandwich;

        // Enqueue sandwiches into queue of a linked list
        for (int i = 1; i < ListSandwiches.Length; i++)
        {
            currentSandwich.next = new SandwichNode(ListSandwiches[i]);
            currentSandwich = currentSandwich.next;
        }
        LastSandwich = currentSandwich;
    }

    public SandwichNode Dequeue(SandwichNode dequeuedSandwich)
    {
        FirstSandwich = dequeuedSandwich.next;

        dequeuedSandwich.next = null;

        return dequeuedSandwich;
    }
}
