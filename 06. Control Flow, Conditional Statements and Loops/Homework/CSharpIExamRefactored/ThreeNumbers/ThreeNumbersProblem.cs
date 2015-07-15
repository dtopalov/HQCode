namespace ThreeNumbers
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading;

    public class ThreeNumbersProblem
    {
        /// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string. </exception>
        /// <exception cref="IOException">An I/O error occurred. </exception>
        /// <exception cref="ArgumentException">Invalid number(s)</exception>
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            int firstNumber;
            bool isFirstNumberValid = int.TryParse(Console.ReadLine(), out firstNumber);
            int secondNumber;
            bool isSecondNumberValid = int.TryParse(Console.ReadLine(), out secondNumber);
            int thirdNumber;
            bool isThirdNumberValid = int.TryParse(Console.ReadLine(), out thirdNumber);
            if (!(isFirstNumberValid && isSecondNumberValid && isThirdNumberValid))
            {
                throw new ArgumentException("Invalid number(s)");
            }

            int largestNumber = GetLargestOfThreeNumbers(firstNumber, secondNumber, thirdNumber);
            int smallestNumber = GetSmallestOfThreeNumbers(firstNumber, secondNumber, thirdNumber);
            double average = GetAverageOfThreeNumbers(firstNumber, secondNumber, thirdNumber);

            Console.WriteLine(largestNumber);
            Console.WriteLine(smallestNumber);
            Console.WriteLine("{0:F2}", average);
        }

        public static int GetLargestOfThreeNumbers(int firstNumber, int secondNumber, int thirdNumber)
        {
            int[] numbers = { firstNumber, secondNumber, thirdNumber };
            return numbers.Max();
        }

        public static int GetSmallestOfThreeNumbers(int firstNumber, int secondNumber, int thirdNumber)
        {
            int[] numbers = { firstNumber, secondNumber, thirdNumber };
            return numbers.Min();
        }

        public static double GetAverageOfThreeNumbers(int firstNumber, int secondNumber, int thirdNumber)
        {
            int[] numbers = { firstNumber, secondNumber, thirdNumber };
            return numbers.Average();
        }
    }
}
