using System.Collections.Generic;
using System;

// 小根堆
public class BinaryHeap
{
    private List<NavigationNode> heap;

    public int Count => heap.Count;

    public bool Contains(NavigationNode node)
    {
        return heap.Contains(node);
    }

    public BinaryHeap()
    {
        heap = new List<NavigationNode>();
    }

    private void Swim(int index)
    {
        while (index > 0)
        {
            int parentIndex = GetParentIndex(index);

            if (heap[parentIndex].f <= heap[index].f)
                break;

            (heap[parentIndex], heap[index]) = (heap[index], heap[parentIndex]);
            index = parentIndex;
        }
    }

    private void Sink(int index)
    {
        while (index < Size())
        {
            int leftChildIndex = GetLeftChildIndex(index);
            int rightChildIndex = GetRightChildIndex(index);

            int nextIndex = index;

            if (leftChildIndex < Size() && heap[leftChildIndex].f < heap[nextIndex].f)
                nextIndex = leftChildIndex;

            if (rightChildIndex < Size() && heap[rightChildIndex].f < heap[nextIndex].f)
                nextIndex = rightChildIndex;

            if (nextIndex == index) break;

            (heap[index], heap[nextIndex]) = (heap[nextIndex], heap[index]);
            index = nextIndex;
        }
    }

    private int GetParentIndex(int index)
    {
        return (index - 1) / 2;
    }

    private int GetLeftChildIndex(int index)
    {
        return index * 2 + 1;
    }

    private int GetRightChildIndex(int index)
    {
        return index * 2 + 2;
    }

    public void Pop()
    {
        if (Empty()) throw new Exception("堆已空");

        (heap[0], heap[Size() - 1]) = (heap[Size() - 1], heap[0]);
        heap.RemoveAt(Size() - 1);

        if (!Empty())
        {
            Sink(0);
        }
    }

    public void Push(NavigationNode item)
    {
        heap.Add(item);
        Swim(Size() - 1);
    }

    public NavigationNode GetTop()
    {
        if (Empty()) throw new Exception("堆已空");

        return heap[0];
    }

    public bool Empty()
    {
        return heap.Count <= 0;
    }

    public int Size()
    {
        return heap.Count;
    }
}