namespace ConsoleApplication1Problem
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Numerics;
    using System.Threading;

    public class Program
    {
        /// <exception cref="IOException">An I/O error occurred. </exception>
        /// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string. </exception>
        /// <exception cref="ArgumentNullException"><paramref /> is null. </exception>
        /// <exception><paramref /> represents a number less than <see cref="F:System.Int32.MinValue" /> or greater than <see cref="F:System.Int32.MaxValue" />. </exception>
        /// <exception cref="ArgumentException">Input is not a valid number!</exception>
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            List<decimal> numbers = new List<decimal>();
            int numbersCount = 0;
            bool isNumber;

            do
            {
                decimal inputNumber;
                isNumber = decimal.TryParse(Console.ReadLine(), out inputNumber);
                numbers.Add(inputNumber);
                numbersCount++;
            }
            while (isNumber);

            BigInteger digitsProductForFirstUpToTenNumbers = 1;
            BigInteger totalProductForFirstUpToTenNumbers = 1;
            BigInteger digitsProductForTheNumbersAfterTheTenth = 1;
            BigInteger totalProductForTheNumbersAfterTheTenth = 1;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i < 10)
                {
                    DigitsProduct(i, numbers, ref digitsProductForFirstUpToTenNumbers, ref totalProductForFirstUpToTenNumbers);
                }
                else
                {
                    DigitsProduct(i, numbers, ref digitsProductForTheNumbersAfterTheTenth, ref totalProductForTheNumbersAfterTheTenth);
                }
            }

            Console.WriteLine(totalProductForFirstUpToTenNumbers);
            if (numbersCount > 10)
            {
                Console.WriteLine(totalProductForTheNumbersAfterTheTenth);
            }
        }

        private static void DigitsProduct(int index, List<decimal> numbers, ref BigInteger digitsProduct, ref BigInteger totalProduct)
        {
            if (index % 2 == 1)
            {
                if (numbers[index] == 0)
                {
                    return;
                }

                string number = numbers[index].ToString(CultureInfo.InvariantCulture);

                for (int j = 0; j < number.Length; j++)
                {
                    if (char.IsDigit(number[j]))
                    {
                        if (int.Parse(number[j].ToString()) == 0)
                        {
                            continue;
                        }

                        digitsProduct *= int.Parse(number[j].ToString());
                    }
                }

                totalProduct *= digitsProduct;
                digitsProduct = 1;
            }
        }
    }
}
