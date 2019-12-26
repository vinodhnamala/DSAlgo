using System;

namespace DSAlgo
{

    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[] { 5, 4, 3, 2, 8, 9, 32, 23, 1, 3, 2, 44, 67, 59 };

            Print(A);

            SortingAlgorithms.QuickSort(A, 0, A.Length - 1);
            SortingAlgorithms.MergeSort(A);
            SortingAlgorithms.InsertionSort(A);
            SortingAlgorithms.BubbleSort(A);
            SortingAlgorithms.SelectionSort(A);

            Print(A);
        }

        static void Print(int[] A)
        {
            Console.WriteLine();
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + " ");
            }
            Console.WriteLine();
        }
    }
    class SortingAlgorithms
    {
        public static void SelectionSort(int[] A)
        {
            int n = A.Length;

            for (int i = 0; i <= n - 2; i++)
            {
                int iMin = i;
                for (int j = i + 1; j <= n - 1; j++)
                {
                    if (A[j] < A[iMin])
                    {
                        iMin = j;
                    }
                }
                int temp = A[iMin];
                A[iMin] = A[i];
                A[i] = temp;
            }
        }

        public static void BubbleSort(int[] A)
        {
            int n = A.Length;
            for (int k = 0; k <= n - 2; k++)
            {
                bool isAlreadySorted = true;
                for (int i = 0; i <= n - 2 - k; i++)
                {
                    if (A[i] > A[i + 1])
                    {
                        int temp = A[i + 1];
                        A[i + 1] = A[i];
                        A[i] = temp;
                        isAlreadySorted = false;
                    }
                }
                if (isAlreadySorted)
                    break;
            }
        }

        public static void InsertionSort(int[] A)
        {
            int n = A.Length;

            for (int i = 1; i <= n - 1; i++)
            {
                int hole = i;
                int value = A[hole];

                while (hole > 0 && value < A[hole - 1])
                {
                    A[hole] = A[hole - 1];
                    hole = hole - 1;
                }
                A[hole] = value;
            }
        }

        public static void MergeSort(int[] A)
        {
            int n = A.Length;
            if (n <= 1)
                return;

            int mid = (n + 1) / 2;

            int[] left = new int[mid];
            int[] right = new int[n - mid];

            for (int i = 0; i < mid; i++)
            {
                left[i] = A[i];
            }
            for (int j = mid; j < n; j++)
            {
                right[j - mid] = A[j];
            }
            MergeSort(left);
            MergeSort(right);
            Merge(left, right, A);

        }

        private static void Merge(int[] left, int[] right, int[] A)
        {
            int nL = left.Length;
            int nR = right.Length;
            int i = 0, j = 0, k = 0;

            while (i < nL && j < nR)
            {
                if (left[i] < right[j])
                {
                    A[k] = left[i];
                    i = i + 1;
                }
                else
                {
                    A[k] = right[j];
                    j = j + 1;
                }
                k = k + 1;
            }
            while (i < nL)
            {
                A[k] = left[i];
                i = i + 1;
                k = k + 1;
            }
            while (j < nR)
            {
                A[k] = right[j];
                j = j + 1;
                k = k + 1;
            }
        }

        /// <summary>
        /// Pass Array , Array start index and Array End Index
        /// </summary>
        /// <param name="A">Array</param>
        /// <param name="start">start index</param>
        /// <param name="end">End Index</param>
        public static void QuickSort(int[] A, int start, int end)
        {
            if (start < end)
            {
                int partitionIndex = RandomizedPartitionIndex(A, start, end);
                QuickSort(A, start, partitionIndex - 1);
                QuickSort(A, partitionIndex + 1, end);
            }
        }

        private static int RandomizedPartitionIndex(int[] A, int start, int end)
        {
            int randomPivot = new Random().Next(start, end + 1);
            int temp = A[randomPivot];
            A[randomPivot] = A[end];
            A[end] = temp;
            return PartitionIndex(A, start, end);
        }

        private static int PartitionIndex(int[] A, int start, int end)
        {
            int partitionIndex = start;
            int pivot = A[end];

            for (int i = start; i < end; i++)
            {
                if (A[i] <= pivot)
                {
                    int temp = A[i];
                    A[i] = A[partitionIndex];
                    A[partitionIndex] = temp;
                    partitionIndex++;
                }
            }
            A[end] = A[partitionIndex];
            A[partitionIndex] = pivot;

            return partitionIndex;
        }
    }

}
