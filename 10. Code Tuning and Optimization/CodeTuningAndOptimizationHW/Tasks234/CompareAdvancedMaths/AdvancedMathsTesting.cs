namespace CompareAdvancedMaths
{
    using System;
    using System.Diagnostics;

    public class AdvancedMathsTesting
    {
        private static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            int numberOfRepetitions = 5000000;

            Console.WriteLine("Square root:");
            Console.WriteLine(new string('-', 50));
            stopwatch.Start();
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                float number = 5.0f;
                Math.Sqrt(number);
            }

            stopwatch.Stop();
            Console.WriteLine("Float: {0}", stopwatch.Elapsed);
            stopwatch.Restart();
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                double number = 5.0;
                Math.Sqrt(number);
            }

            stopwatch.Stop();
            Console.WriteLine("Double: {0}", stopwatch.Elapsed);
            stopwatch.Restart();
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                decimal number = 5.0M;
                Math.Sqrt((double)number);
            }

            stopwatch.Stop();
            Console.WriteLine("Decimal: {0}", stopwatch.Elapsed);
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Natural logarithm:");
            Console.WriteLine(new string('-', 50));

            stopwatch.Start();
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                float number = 5.0f;
                Math.Log(number);
            }

            stopwatch.Stop();
            Console.WriteLine("Float: {0}", stopwatch.Elapsed);
            stopwatch.Restart();
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                double number = 5.0;
                Math.Log(number);
            }

            stopwatch.Stop();
            Console.WriteLine("Double: {0}", stopwatch.Elapsed);
            stopwatch.Restart();
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                decimal number = 5.0M;
                Math.Log((double)number);
            }

            stopwatch.Stop();
            Console.WriteLine("Decimal: {0}", stopwatch.Elapsed);
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Sine:");
            Console.WriteLine(new string('-', 50));

            stopwatch.Start();
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                float number = 5.0f;
                Math.Sin(number);
            }

            stopwatch.Stop();
            Console.WriteLine("Float: {0}", stopwatch.Elapsed);
            stopwatch.Restart();
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                double number = 5.0;
                Math.Sin(number);
            }

            stopwatch.Stop();
            Console.WriteLine("Double: {0}", stopwatch.Elapsed);
            stopwatch.Restart();
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                decimal number = 5.0M;
                Math.Sin((double)number);
            }

            stopwatch.Stop();
            Console.WriteLine("Decimal: {0}", stopwatch.Elapsed);
            Console.WriteLine(new string('-', 50));
        }
    }
}
