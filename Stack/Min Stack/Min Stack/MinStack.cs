
namespace Min_Stack;

public class MinStack
{
    List<int> stackList = [];
    List<int> minStackList = [];

    public MinStack() { }

    public void Push(int val) {
        stackList.Add(val);

        if (minStackList.Count == 0) {
            minStackList.Add(val);
            return;
        }

        minStackList.Add(Math.Min(GetMin(), val));
    }

    public void Pop() {
        stackList.RemoveAt(stackList.Count - 1);
        minStackList.RemoveAt(minStackList.Count - 1);
    }

    public int Top() {

        if (stackList.Count == 0) return 0;

        return stackList[stackList.Count - 1];
    }

    public int GetMin() {

        if (stackList.Count == 1) return stackList[0];

        return minStackList[minStackList.Count - 1];
    }
}