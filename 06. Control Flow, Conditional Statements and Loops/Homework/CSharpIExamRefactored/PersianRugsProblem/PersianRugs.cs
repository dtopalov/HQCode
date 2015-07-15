namespace PersianRugsProblem
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Threading;

    public class PersianRugs
    {
        /// <exception cref="ArgumentException">Invalid size - must be an integer in the range [2, 100]</exception>
        /// <exception cref="IOException">An I/O error occurred. </exception>
        /// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string. </exception>
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            int size;
            bool isSizeValid = int.TryParse(Console.ReadLine(), out size);
            if (!isSizeValid)
            {
                throw new ArgumentException("Invalid size - must be an integer in the range [2, 100]");
            }

            int distance;
            bool isDistanceValid = int.TryParse(Console.ReadLine(), out distance);
            if (!isDistanceValid)
            {
              throw new ArgumentException("Invalid distance - must be an integer in the range [0, 100]");  
            }

            DrawTop(size, distance);
            DrawMiddle(size);
            DrawBottom(size, distance);
        }

        private static void DrawTop(int size, int distance)
        {
            int rugWidthAndHeight = (2 * size) + 1;
            for (int i = 0; i < size; i++)
            {
                DrawMainPart(distance, i, rugWidthAndHeight, '\\', '/');
            }
        }

        private static void DrawMiddle(int size)
        {
            Console.Write(new string('#', size));
            Console.Write("X");
            Console.WriteLine(new string('#', size));
        }

        private static void DrawBottom(int size, int distance)
        {
            int rugWidthAndHeight = (2 * size) + 1;
            for (int i = size - 1; i >= 0; i--)
            {
                DrawMainPart(distance, i, rugWidthAndHeight, '/', '\\');
            }
        }

        private static void DrawMainPart(int distance, int i, int rugWidthAndHeight, char firstSlash, char secondSlash)
        {
            Console.Write(new string('#', i));
            Console.Write(firstSlash);
            if (rugWidthAndHeight > (2 * i) + (2 * distance) + 4)
            {
                Console.Write(new string(' ', distance));
                Console.Write(firstSlash);
                Console.Write(new string('.', rugWidthAndHeight - (2 * distance) - 4 - (2 * i)));
                Console.Write(secondSlash);
                Console.Write(new string(' ', distance));
            }
            else
            {
                Console.Write(new string(' ', rugWidthAndHeight - 2 - (2 * i)));
            }

            Console.Write(secondSlash);
            Console.WriteLine(new string('#', i));
        }
    }
}
