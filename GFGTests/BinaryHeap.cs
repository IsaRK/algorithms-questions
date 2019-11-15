using System;
using System.Collections.Generic;
using System.Text;

namespace GFGTests
{
    //Min Heap : https://egorikas.com/max-and-min-heap-implementation-with-csharp/
    public class BinaryHeap
    {
        public int[] arr;
        public int size;

        public int? GetParentValue(int index)
        {
            if (GetParentIndex(index) < 0) return null;
            return arr[GetParentIndex(index)];
        }

        public int GetParentIndex(int index) => (index - 1) / 2;

        private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
        private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;

        private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < size;
        private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < size;
        private bool IsRoot(int elementIndex) => elementIndex == 0;

        private int GetLeftChild(int elementIndex) => arr[GetLeftChildIndex(elementIndex)];
        private int GetRightChild(int elementIndex) => arr[GetRightChildIndex(elementIndex)];

        public BinaryHeap(int size)
        {
            arr = new int[size];
        }

        public void Insert(int val)
        {
            if (size == 0)
            {
                arr[0] = val;
                size++;
            }
            else
            {
                //Insert at the end
                arr[size] = val;
                size++;

                //heapifyUp
                HeapifyUp();
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = temp;
        }

        public void HeapifyUp()
        {
            var index = size -1;
            while (index != 0 && arr[index] < arr[GetParentIndex(index)])
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }

        public void HeapifyDown()
        {
            var index = 0;
            while (HasLeftChild(index))
            {
                var smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
                {
                    smallerIndex = GetRightChildIndex(index);
                }

                if (arr[smallerIndex] >= arr[index])
                {
                    break;
                }

                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }

        public int Pop()
        {
            var result = arr[0];

            arr[0] = arr[size - 1];
            size--;

            HeapifyDown();

            return result;
        }

    }

    public class GfGTests
    {
        //https://www.geeksforgeeks.org/merge-k-sorted-arrays/
        //https://www.geeksforgeeks.org/k-largestor-smallest-elements-in-an-array/
        public static int[] getKthMinElementInArray(int[] input, int nbOfLargestElt)
        {
            var size = input.Length;
            var minHeap = new BinaryHeap(size);
            foreach (var n in input)
            {
                minHeap.Insert(n);
            }

            var result = new int[nbOfLargestElt];

            for (var i = 0; i < nbOfLargestElt; i++)
            {
                result[i] = minHeap.Pop();
            }
            return result;
        }
    }
}
