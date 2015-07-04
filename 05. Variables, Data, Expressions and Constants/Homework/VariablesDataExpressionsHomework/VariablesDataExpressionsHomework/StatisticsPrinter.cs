namespace VariablesDataExpressionsHomework
{
    using System;
    using System.Linq;

    public class StatisticsPrinter
    {
        public void PrintStatistics(double[] numbers)
        {
            Console.WriteLine("Statistics for {0}:", numbers);
            double smallestNumber = numbers.Min();
            this.PrintMin(smallestNumber);
            double largestNumber = numbers.Max();
            this.PrintMax(largestNumber);
            double average = numbers.Average();
            this.PrintAverage(average);
        }

        private void PrintMin(double smallestNumber)
        {
            Console.WriteLine("The smallest number is {0}.", smallestNumber);
        }

        private void PrintMax(double largestNumber)
        {
            Console.WriteLine("The largest number is {0}.", largestNumber);
        }

        private void PrintAverage(double average)
        {
            Console.WriteLine("The average of the numbers is {0}.", average);
        }
    }
}
