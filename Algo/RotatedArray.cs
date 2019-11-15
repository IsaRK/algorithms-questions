using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class RotatedArray
    {
        //https://www.geeksforgeeks.org/search-an-element-in-a-sorted-and-pivoted-array/
        public static int FindPivotInRotatedArray(int[] arr)
        {
            return BinarySearch(arr, 0, arr.Length -1);
        }

        public static int BinarySearch(int[] arr, int indexMin, int indexMax)
        {
            if (indexMax - indexMin == 1)
            {
                return arr[indexMax] < arr[indexMin] ? indexMax : indexMin;
            }
                
            int mid = (indexMax + indexMin ) / 2;
            if (arr[indexMax - 1] > arr[mid])
            {
                //tout est normal, le pivot est à gauche du mid
                return BinarySearch(arr, indexMin, mid);
            }
            else if (arr[indexMax - 1] < arr[mid])
            {
                //le pivot est à droite du mid
                return BinarySearch(arr, mid, indexMax);
            }
            else
            {
                if (arr[mid] > arr[indexMin])
                {
                    return BinarySearch(arr, mid, indexMax);
                }
                return BinarySearch(arr, indexMin, mid);
            }
        }
    }
}
