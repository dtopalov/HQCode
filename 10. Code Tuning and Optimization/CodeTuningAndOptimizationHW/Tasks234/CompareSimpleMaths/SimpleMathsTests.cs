namespace CompareSimpleMaths
{
    using System;
    using System.Diagnostics;

    public class SimpleMathsTests
    {
        private static void Main()
        {
            int numberOfOperations = 5000000;

            Console.WriteLine("5 million operations complete for:");
            Console.WriteLine(new string('-', 50));
            Console.Write("Int add: ");
            DisplayExecutionTime(() =>
            {
                int result = 0;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result += 1;
                } 
            });

            Console.Write("Int subtract: ");
            DisplayExecutionTime(() =>
            {
                int result = 5000000;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result -= 1;
                }
            });

            Console.Write("Int increment: ");
            DisplayExecutionTime(() =>
            {
                int result = 5000000;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result++;
                }
            });

            Console.Write("Int multiply: ");
            DisplayExecutionTime(() =>
            {
                int result = 1;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result *= 1;
                }
            });

            Console.Write("Int divide: ");
            DisplayExecutionTime(() =>
            {
                int result = 1;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result /= 1;
                }
            });
            Console.WriteLine(new string('-', 50));
            Console.Write("Long add: ");
            DisplayExecutionTime(() =>
            {
                long result = 0L;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result += 1L;
                }
            });

            Console.Write("Long subtract: ");
            DisplayExecutionTime(() =>
            {
                long result = 5000000L;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result -= 1L;
                }
            });

            Console.Write("Long increment: ");
            DisplayExecutionTime(() =>
            {
                long result = 5000000L;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result++;
                }
            });

            Console.Write("Long multiply: ");
            DisplayExecutionTime(() =>
            {
                long result = 1L;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result *= 1L;
                }
            });

            Console.Write("Long divide: ");
            DisplayExecutionTime(() =>
            {
                long result = 1L;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result /= 1;
                }
            });
            Console.WriteLine(new string('-', 50));
            Console.Write("Float add: ");
            DisplayExecutionTime(() =>
            {
                float result = 0.0f;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result += 1.0f;
                }
            });

            Console.Write("Float subtract: ");
            DisplayExecutionTime(() =>
            {
                float result = 5000000.0f;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result -= 1.0f;
                }
            });

            Console.Write("Float increment: ");
            DisplayExecutionTime(() =>
            {
                float result = 5000000.0f;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result++;
                }
            });

            Console.Write("Float multiply: ");
            DisplayExecutionTime(() =>
            {
                float result = 1.0f;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result *= 1.0f;
                }
            });

            Console.Write("Float divide: ");
            DisplayExecutionTime(() =>
            {
                float result = 1.0f;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result /= 1.0f;
                }
            });
            Console.WriteLine(new string('-', 50));

            Console.Write("Double add: ");
            DisplayExecutionTime(() =>
            {
                double result = 0.0;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result += 1.0;
                }
            });

            Console.Write("Double subtract: ");
            DisplayExecutionTime(() =>
            {
                double result = 5000000.0;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result -= 1.0;
                }
            });

            Console.Write("Double increment: ");
            DisplayExecutionTime(() =>
            {
                double result = 5000000.0;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result++;
                }
            });

            Console.Write("Double multiply: ");
            DisplayExecutionTime(() =>
            {
                double result = 1.0;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result *= 1.0;
                }
            });

            Console.Write("Double divide: ");
            DisplayExecutionTime(() =>
            {
                double result = 1.0;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result /= 1.0;
                }
            });
            Console.WriteLine(new string('-', 50));

            Console.Write("Decimal add: ");
            DisplayExecutionTime(() =>
            {
                decimal result = 0.0M;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result += 1.0M;
                }
            });

            Console.Write("Decimal subtract: ");
            DisplayExecutionTime(() =>
            {
                decimal result = 5000000.0M;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result -= 1.0M;
                }
            });

            Console.Write("Decimal increment: ");
            DisplayExecutionTime(() =>
            {
                decimal result = 5000000.0M;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result++;
                }
            });

            Console.Write("Decimal multiply: ");
            DisplayExecutionTime(() =>
            {
                decimal result = 1.0M;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result *= 1.0M;
                }
            });

            Console.Write("Decimal divide: ");
            DisplayExecutionTime(() =>
            {
                decimal result = 1.0M;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    result /= 1.0M;
                }
            });
        }

        private static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}
