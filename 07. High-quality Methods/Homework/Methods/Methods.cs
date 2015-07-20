namespace Methods
{
    using System;

    public class Methods
    {
        /// <exception cref="ArgumentOutOfRangeException">All sides of the triangle must be >= 0</exception>
        internal static double CalculateTriangleArea(double a, double b, double c)
        {
            bool positiveSides = a > 0 || b > 0 || c > 0;
            bool sumOfTwoSidesIsLargerThanThirdSide = a + b > c && a + c > b && b + c > a; 

            if (!positiveSides)
            {
                throw new ArgumentOutOfRangeException("All sides of the" + " triangle must be >= 0");
            }

            if (!sumOfTwoSidesIsLargerThanThirdSide)
            {
                throw new ArgumentOutOfRangeException("No side can be longer " + "than the sum of the other two sides");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        internal static string NumberToDigitName(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default:
                    return number + " is not a digit";
            }
        }

        /// <exception cref="ArgumentException">Input array cannot be null or empty</exception>
        internal static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Input array cannot be null or empty");
            }

            int max = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        internal static void PrintNumberWithPrecision(double number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        internal static void PrintNumberAsPercentage(double number)
        {
            {
                Console.WriteLine("{0:p0}", number);
            }
        }

        internal static void PrintNumberAlignedRight(double number)
        {
            Console.WriteLine("{0,8}", number);
        }

        internal static double CalculateDistance(
            double firstPointX,
            double firstPointY,
            double secondPointX,
            double secondPointY)
        {
            double distance = Math.Sqrt(((secondPointX - firstPointX) * (secondPointX - firstPointX))
                        + ((secondPointY - firstPointY) * (secondPointY - firstPointY)));
            return distance;
        }

        internal static bool IsLineHorizontal(double firstPointY, double secondPointY)
        {
            const double AcceptableDifference = 0.000001;
            return Math.Abs(firstPointY - secondPointY) < AcceptableDifference;
        }

        internal static bool IsLineVertical(double firstPointX, double secondPointX)
        {
            const double AcceptableDifference = 0.000001;
            return Math.Abs(firstPointX - secondPointX) < AcceptableDifference;
        }
    }
}
