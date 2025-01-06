namespace Implement_Stack_using_Queues;

public class MyStack2
{
    public Queue<int> Queue1;

    public MyStack2()
    {
        Queue1 = new Queue<int>();
    }

    public void Push(int x)
    {
        Queue1.Enqueue(x);

        GetElementTopStack();
    }

    public int GetElementTopStack()
    {
        int currentElementsQueue = Queue1.Count - 1;

        while (currentElementsQueue > 0)
        {
            int peekQueue1 = Queue1.Peek();

            Queue1.Enqueue(peekQueue1);

            Queue1.Dequeue();
            currentElementsQueue--;
        }

        return Queue1.Peek();
    }

    public int Pop()
    {
        int previousTopStackElement = Queue1.Peek();

        Queue1.Dequeue();

        return previousTopStackElement;
    }

    public int Top()
    {
        return Queue1.Peek();
    }

    public bool Empty()
    {
        return Queue1.Count == 0;
    }
}
