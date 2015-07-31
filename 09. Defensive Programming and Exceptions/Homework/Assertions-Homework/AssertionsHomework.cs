using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class AssertionsHomework
{
    /// <exception cref="OverflowException">The array is multidimensional and contains more than <see cref="F:System.Int32.MaxValue" /> elements.</exception>
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(IsArrayValid(arr, 2), "Array cannot be null and should contain at least 2 elements to be sorted");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }
    }

    /// <exception cref="OverflowException">The array is multidimensional and contains more than <see cref="F:System.Int32.MaxValue" /> elements.</exception>
    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(IsArrayValid(arr, 1), "Array cannot be null or empty");
        Debug.Assert(IsSorted(arr), "Binary search works correctly with sorted arrays only");
        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        Debug.Assert(
            IsArrayValid(arr, 1) && startIndex <= endIndex,
            "Array cannot be null or empty, and startIndex cannot be bigger than endIndex");
        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }
        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        Debug.Assert(
            IsArrayValid(arr, 1) && startIndex <= endIndex,
            "Array cannot be null or empty, and startIndex cannot be bigger than endIndex");
        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }
            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else 
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    private static bool IsArrayValid<T>(T[] arr, int numberOfElements)
    {
        if (arr == null || arr.Length < numberOfElements)
        {
            return false;
        }
        return true;
    }

    private static bool IsSorted<T>(IEnumerable<T> list) where T : IComparable<T>
    {
        var y = list.First();
        return list.Skip(1).All(x =>
        {
            bool b = y.CompareTo(x) < 0;
            y = x;
            return b;
        });
    }

    private static void Main()
    {
        int[] arr = { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
}
