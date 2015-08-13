namespace RotatingWalkInMatrix
{
    using System;

    public class RotatingWalkInMatrix
    {
        public static void Main()
        {
            //Console.WriteLine("Enter a positive number ");
            //string input = Console.ReadLine();
            //int n;
            //while (!int.TryParse(input, out n) || n < 0 || n > 100)
            //{
            //    Console.WriteLine("You haven't entered a correct positive number");
            //    input = Console.ReadLine();
            //}

            int n = 6;

            Matrix matrix = new Matrix(n);
            Console.WriteLine(matrix);
        }
    }
}
