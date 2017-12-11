using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class Sorts
    {
        //the complexity of bubble sort is O(n^2)
        public static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                    }
                }
            }
        }

        //complexity of selection sort is O(n^2)
        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int index = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[index] > array[j])
                        index = j;
                }

                if (index != i)
                {
                    int tmp = array[index];
                    array[index] = array[i];
                    array[i] = tmp;
                }
            }
        }

        //complexity of quick sort is O(n^2)
        public static void QuickSort(int[] array)
        {
            DoQuickSort(array, 0, array.Length - 1);
        }

        private static void DoQuickSort(int[] array, int low, int high)
        {
            if (low > high)
                return;

            int mid = low + ((high - low) / 2);
            int i = low;
            int j = high;

            while (i <= j)
            {
                while (array[i] < array[mid])
                {
                    i++;
                }

                while (array[j] > array[mid])
                {
                    j--;
                }

                if (i <= j)
                {
                    int tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;
                    i++;
                    j--;
                }
            }

            if (low < j)
            {
                DoQuickSort( array, low, j);
            }
            if (high > i)
            {
                DoQuickSort(array, i, high);
            }

        }

        private static int Total;

        //the complexity is O(nlogn)
        public static void HeapSort(IComparable[] array)
        {
            Total = array.Length - 1;

            for (int i = Total / 2; i >= 0; i--)
            {
                Heapify(array, i);
            }

            for (int i = Total; i > 0; i--)
            {
                Swap(array, 0, i);
                Total--;
                Heapify(array, 0);
            }
        }

        //finding the biggest value in the tree
        private static void Heapify(IComparable[] array, int index)
        {
            int left = index * 2;
            int right = index * 2 + 1;
            int node = index;

            if ((left <= Total) && (array[left].CompareTo(array[node]) >= 0))
            {
                node = left;
            }

            if ((right <= Total) && (array[right].CompareTo(array[node]) >= 0))
            {
                node = right;
            }

            if (node != index)
            {
                Swap(array, index, node);
                Heapify(array, node);
            }
        }

        private static void Swap(IComparable[] array, int a, int b)
        {
            IComparable tmp = array[a];
            array[a] = array[b];
            array[b] = tmp;
        }
    }

    //the complexity of merge sort is O(nLogn)
    public class MergeSort
    {
        int[] array;
        int[] TempArray;

        public void PrepareForSort(int[] arr)
        {
            // prepare for sort
            this.array = arr;
            this.TempArray = new int[arr.Length];
            doMergeSort(0, arr.Length - 1);
        }

        private void doMergeSort(int LowerIndex, int HigherIndex)
        {

            if (LowerIndex < HigherIndex)
            {
                int middle = LowerIndex + (HigherIndex - LowerIndex) / 2;
                doMergeSort(LowerIndex, middle); //ex.(1-5)
                doMergeSort(middle + 1, HigherIndex);//ex.(6,10)
                MergePart(LowerIndex, middle, HigherIndex);
            }


        }

        // merge small problems and sort
        private void MergePart(int LowerIndex, int middle, int HigherIndex)
        {
            for (int a = LowerIndex; a <= HigherIndex; a++)
            {
                TempArray[a] = array[a];
            }
            int i = LowerIndex;
            int j = middle + 1;
            int k = LowerIndex;
            while (i <= middle && j <= HigherIndex)
            {
                if (TempArray[i] <= TempArray[j])
                {
                    array[k] = TempArray[i];
                    i++;
                }
                else
                {
                    array[k] = TempArray[j];
                    j++;
                }
                k++;
            }
            while (i <= middle)
            {
                array[k] = TempArray[i];
                k++;
                i++;
            }
        }
    }
}
