namespace CompareSortingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class SortingAlgorithmsTests
    {
        // selection sort
        public static void SelectionSort(int[] array)
        {
            int minValue;

            for (int i = 0; i < array.Length - 1; i++)
            {
                minValue = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minValue])
                    {
                        minValue = j;
                    }
                }

                if (minValue != i)
                {
                    int valueToSwap = array[minValue];
                    array[minValue] = array[i];
                    array[i] = valueToSwap;
                }
            }
        }

        // merge sort
        public static int[] Merge(int[] leftPart, int[] rightPart)
        {
            int[] result = new int[leftPart.Length + rightPart.Length];

            int leftIncrease = 0;
            int rightIncrease = 0;

            for (int i = 0; i < result.Length; i++)
            {
                if (rightIncrease == rightPart.Length || ((leftIncrease < leftPart.Length) && (leftPart[leftIncrease] <= rightPart[rightIncrease])))
                {
                    result[i] = leftPart[leftIncrease];
                    leftIncrease++;
                }
                else if (leftIncrease == leftPart.Length || ((rightIncrease < rightPart.Length) && (rightPart[rightIncrease] <= leftPart[leftIncrease])))
                {
                    result[i] = rightPart[rightIncrease];
                    rightIncrease++;
                }
            }

            return result;
        }

        // recursively merges two arrays
        public static int[] MergeSort(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            int middle = array.Length / 2;
            int[] leftArray = new int[middle];
            int[] rightArray = new int[array.Length - middle];

            for (int i = 0; i < middle; i++)
            {
                leftArray[i] = array[i];
            }

            for (int i = middle, j = 0; i < array.Length; i++, j++)
            {
                rightArray[j] = array[i];
            }

            leftArray = MergeSort(leftArray);
            rightArray = MergeSort(rightArray);

            return Merge(leftArray, rightArray);
        }

        // quick sort
        public static List<int> QuickSort(List<int> array)
        {
            if (array.Count <= 1)
            {
                return array;
            }

            int pivot = array[array.Count / 2];
            List<int> less = new List<int>();
            List<int> greater = new List<int>();

            for (int i = 0; i < array.Count; i++)
            {
                if (i != (array.Count / 2))
                {
                    if (array[i] <= pivot)
                    {
                        less.Add(array[i]);
                    }
                    else
                    {
                        greater.Add(array[i]);
                    }
                }
            }

            return ConcatenateArrays(QuickSort(less), pivot, QuickSort(greater));
        }

        public static List<int> ConcatenateArrays(List<int> less, int pivot, List<int> greater)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < less.Count; i++)
            {
                result.Add(less[i]);
            }

            result.Add(pivot);

            for (int i = 0; i < greater.Count; i++)
            {
                result.Add(greater[i]);
            }

            return result;
        }

        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();

            // random numbers
            Console.WriteLine("Testing with random numbers:");
            Console.WriteLine(new string('-', 50));
            int[] array = { 1, 1583, 15, 16, -1349, 22, 33, 44, -55, 55, -66, 0, -19, -10, 11, 2214, -1, 14, -5465 };
            stopwatch.Start();
            SelectionSort(array);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Selection sort");

            array = new[] { 1, 1583, 15, 16, -1349, 22, 33, 44, -55, 55, -66, 0, -19, -10, 11, 2214, -1, 14, -5465 };
            stopwatch.Restart();
            MergeSort(array);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Merge sort");

            List<int> list = new List<int> { 1, 1583, 15, 16, -1349, 22, 33, 44, -55, 55, -66, 0, -19, -10, 11, 2214, -1, 14, -5465 };
            stopwatch.Restart();
            QuickSort(list);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Quick sort");
            Console.WriteLine(new string('-', 50));

            // sorted numbers
            Console.WriteLine("Testing with sorted numbers");
            Console.WriteLine(new string('-', 50));
            array = MergeSort(array);
            list = QuickSort(list);

            stopwatch.Restart();
            SelectionSort(array);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Selection sort");

            stopwatch.Restart();
            MergeSort(array);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Merge sort");

            stopwatch.Restart();
            QuickSort(list);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Quick sort");
            Console.WriteLine(new string('-', 50));

            // values sorted in reverse
            Console.WriteLine("Testing with numbers sorted in reversed order:");
            Console.WriteLine(new string('-', 50));

            Array.Reverse(array);
            stopwatch.Restart();
            SelectionSort(array);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Selection sort");

            Array.Reverse(array);
            stopwatch.Restart();
            MergeSort(array);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Merge sort");

            list = QuickSort(list);
            list.Reverse();
            stopwatch.Restart();
            QuickSort(list);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Quick sort");
        }
    }
}
