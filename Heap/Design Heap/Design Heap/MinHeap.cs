namespace Design_Heap;

public class MinHeap
{
    private List<int> heap;

    public MinHeap()
    {
        heap = new List<int>() { 0 };
    }

    public void Push(int val)
    {
        heap.Add(val);
        PercolateUpElementsHeap(heap, heap.Count - 1);
    }

    private void Swap(List<int> heap, int indexFirst, int indexSecond)
    {
        int temp = heap[indexFirst];
        heap[indexFirst] = heap[indexSecond];
        heap[indexSecond] = temp;
    }

    private void PercolateUpElementsHeap(List<int> heap, int index)
    {
        while ((index / 2) > 0 && heap[index] < heap[index / 2])
        {
            Swap(heap, index, index / 2);
            index = index / 2;
        }
    }

    private void PercolateDownElementsHeap(List<int> heap, int index)
    {
        // the index is still inbound and there is still left subtree to percolate down
        while (2 * index < heap.Count)
        {
            var leftSubtree = 2 * index;
            var rightSubtree = 2 * index + 1;

            // Swap right sub tree
            if (
                rightSubtree < heap.Count
                && heap[rightSubtree] < heap[leftSubtree]
                && heap[rightSubtree] < heap[index]
            )
            {
                Swap(heap, index, rightSubtree);
                index = rightSubtree;
            }
            // Swap left sub tree
            else if (heap[leftSubtree] < heap[index])
            {
                Swap(heap, index, leftSubtree);
                index = leftSubtree;
            }
            else
            {
                break;
            }
        }
    }

    public int? Pop()
    {
        if (heap.Count - 1 == 0)
            return -1;

        if (heap.Count - 1 == 1)
        {
            var poppedElement = heap[heap.Count - 1];

            heap.RemoveAt(heap.Count - 1);
            return poppedElement;
        }

        var result = heap[1];
        var lastElement = heap[heap.Count - 1];
        heap[1] = lastElement;
        heap.RemoveAt(heap.Count - 1);
        var index = 1;

        PercolateDownElementsHeap(heap, index);

        return result;
    }

    public int? Top()
    {
        if (heap.Count - 1 == 0)
            return -1;

        return heap[1];
    }

    public void Heapify(List<int> nums)
    {
        var heapArray = heap.Concat(nums).ToList();
        var firstNonLeafNode = (heapArray.Count - 1) / 2;

        var cur = firstNonLeafNode;

        while (cur >= 1)
        {
            PercolateDownElementsHeap(heapArray, cur);
            cur--;
        }

        heap = heapArray;
    }
}
