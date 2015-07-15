namespace Decoding
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Threading;

    public class DecodingProblem
    {
        /// <exception cref="IOException">An I/O error occurred. </exception>
        /// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string. </exception>
        /// <exception cref="ArgumentException">Invalid number</exception>
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            int salt;
            bool validNumberInput = int.TryParse(Console.ReadLine(), out salt);
            if (!validNumberInput)
            {
                throw new ArgumentException("Invalid number");
            }

            string input = Console.ReadLine();
            if (input == null)
            {
                throw new ArgumentException("Invalid input");
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '@')
                {
                    break;
                }

                double number;
                if (char.IsLetter(input[i]))
                {
                    number = (Convert.ToInt32(input[i]) * salt) + 1000;
                }
                else if (char.IsDigit(input[i]))
                {
                    number = Convert.ToInt32(input[i]) + salt + 500;
                }
                else
                {
                    number = Convert.ToInt32(input[i]) - salt;
                }

                PrintDecodedNumber(i, number);
            }
        }

        private static void PrintDecodedNumber(int charIndex, double number)
        {
            if (charIndex % 2 == 0)
            {
                double decodedNumber = number / 100;
                Console.WriteLine("{0:F2}", decodedNumber);
            }
            else
            {
                double decodedNumber = number * 100;
                Console.WriteLine("{0}", decodedNumber);
            }
        }
    }
}
