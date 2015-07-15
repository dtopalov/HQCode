namespace SearchInBitsProblem
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Threading;

    public class SearchInBits
    {
        /// <exception cref="OverflowException"><paramref /> represents a number less than <see cref="F:System.Int32.MinValue" /> or greater than <see cref="F:System.Int32.MaxValue" />. </exception>
        /// <exception cref="IOException">An I/O error occurred. </exception>
        /// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string. </exception>
        /// <exception cref="ArgumentNullException"><paramref /> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">Invalid input, should be an integer in the range [1, 100]</exception>
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string numberToLookFor = Console.ReadLine();
            if (numberToLookFor == null)
            {
                throw new ArgumentNullException("Invalid input, should be" + " an integer in the range [0, 15]");
            }

            string bitsOfTheNumberToLookFor = Convert.ToString(int.Parse(numberToLookFor), 2).PadLeft(4, '0');

            int numberOfNumbersToLookIn;
            bool isValidNumberToLookIn = int.TryParse(Console.ReadLine(), out numberOfNumbersToLookIn);
            if (!isValidNumberToLookIn)
            {
                throw new ArgumentException("Invalid input, should be an integer in the range [1, 100]");
            }

            int[] numbers = new int[numberOfNumbersToLookIn];
            int countOfOccurencesOfNumberToLookForInNumberToLookIn = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                bool isValidNumber = int.TryParse(Console.ReadLine(), out numbers[i]);
                if (!isValidNumber)
                {
                    throw new ArgumentException("Invalid input");
                }

                string bitsOfNumberToLookIn = Convert.ToString(numbers[i], 2).PadLeft(32, '0');
                string currentCheck = string.Empty;

                for (int j = 1; j <= 27; j++)
                {
                    for (int k = 3; k >= 0; k--)
                    {
                        currentCheck += bitsOfNumberToLookIn[bitsOfNumberToLookIn.Length - j - k].ToString();
                    }

                    if (currentCheck == bitsOfTheNumberToLookFor)
                    {
                        countOfOccurencesOfNumberToLookForInNumberToLookIn++;
                    }

                    currentCheck = string.Empty;
                }
            }

            Console.WriteLine(countOfOccurencesOfNumberToLookForInNumberToLookIn);
        }
    }
}
