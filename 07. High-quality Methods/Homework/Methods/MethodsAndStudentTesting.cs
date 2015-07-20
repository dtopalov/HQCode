namespace Methods
{
    using System;

    internal class MethodsAndStudentTesting
    {
        private static void Main()
        {
            Console.WriteLine(Methods.CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(Methods.NumberToDigitName(5));

            Console.WriteLine(Methods.FindMax(5, -1, 3, 2, 14, 2, 3));

            Methods.PrintNumberWithPrecision(1.3);
            Methods.PrintNumberAsPercentage(0.75);
            Methods.PrintNumberAlignedRight(2.30);

            bool horizontal = Methods.IsLineHorizontal(-1, 2.5);
            bool vertical = Methods.IsLineVertical(3, 3);

            Console.WriteLine(Methods.CalculateDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student("Peter", "Ivanov", new DateTime(1992, 3, 17), "From Sofia");
            Student stella = new Student("Stella", "Markova", new DateTime(1993, 11, 3), "From Vidin, gamer, high results");

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
